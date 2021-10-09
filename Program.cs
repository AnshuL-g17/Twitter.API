using System;
using LinqToTwitter;
using System.Linq;
using LinqToTwitter.OAuth;
using System.Threading.Tasks;

namespace Tweets
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Chose from the following: ");
            Console.WriteLine("To post a tweet: Enter 1");
            Console.WriteLine("To print all tweets: Enter 2");
            Console.WriteLine("To Post a tweet first and then print all tweets: Enter 3");
            var choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 1)
            {
                Console.WriteLine("Enter a tweet to post");
                String tweet = Console.ReadLine();
                try
                {
                    Task.Run(() => SendTweet(tweet));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else if (choice == 2)
            {
                var twitterCtx = TwitterService.GeTwitterContext();
                Console.WriteLine("Enter the username whose tweets you want to see");
                var userInput = Console.ReadLine();
                Console.WriteLine("Loading Top 10 Tweets\n");

                var tweets = (from tweet in twitterCtx.Status
                    where tweet.Type == StatusType.User
                          && tweet.ScreenName == userInput
                    select tweet).Take(10);

                foreach (var tweet in tweets)
                {
                    Console.WriteLine($"{tweet.User.Name} - {tweet.Text.Trim()}\n");
                }

                Console.ReadLine();
            }
            else if (choice == 3)
            {
                Console.WriteLine("Enter a tweet to post");
                String tweet1 = Console.ReadLine();
                try
                {
                    Task.Run(() => SendTweet(tweet1));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                var twitterCtx = TwitterService.GeTwitterContext();
                Console.WriteLine("Enter the username whose tweets you want to see");
                var userInput = Console.ReadLine();
                Console.WriteLine("Loading Top 10 Tweets\n");

                var tweets = (from tweet in twitterCtx.Status
                    where tweet.Type == StatusType.User
                          && tweet.ScreenName == userInput
                    select tweet).Take(10);

                foreach (var tweet in tweets)
                {
                    Console.WriteLine($"{tweet.User.Name} - {tweet.Text.Trim()}\n");
                }

                Console.ReadLine();
            }

        }

        static async void SendTweet(String tweet)
        {
            
            var context = TwitterService.GeTwitterContext();

            await context.TweetAsync(
                tweet
            );
        }
    }
            }
