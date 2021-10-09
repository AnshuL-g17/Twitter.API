using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToTwitter;
using LinqToTwitter.OAuth;

namespace Tweets
{
    public class TwitterService
    {
        public static TwitterContext GeTwitterContext()
        {
            var auth = new SingleUserAuthorizer
            {
                CredentialStore = new InMemoryCredentialStore
                {
                    ConsumerKey = APICredentials.ConsumerKey,
                    ConsumerSecret = APICredentials.ConsumerSecret,
                    OAuthToken = APICredentials.OAuthToken,
                    OAuthTokenSecret = APICredentials.OAuthTokenSecret
                }
            };

            return new TwitterContext(auth);
        }
    }
}
