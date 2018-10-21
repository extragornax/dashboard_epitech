/*
** EPITECH PROJECT, 2018
** dashboard
** File description:
** Conditions
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Specialized;
using LinqToTwitter;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Linq;

namespace Dashboard.Models.Widgets
{

    public class TwitterResult : IWidgetResult
    {
        private string _dataPackage;

        public TwitterResult(string DataPackage)
        {
            _dataPackage = DataPackage;
        }

        public string WidgetName()
        {
            return "TwitterUserTweets";
        }
        public EWidgetType WidgetType()
        {
            return EWidgetType.WeatherConditon;
        }
        public string DataPackage()
        {
            return _dataPackage;
        }
        public void DataPackage(string data)
        {
            _dataPackage = data;
        }
    }

    [MongoDB.Bson.Serialization.Attributes.BsonDiscriminator("Twitter")]
    public class Twitter : IWidget
    {
        private string _user = "epitech";

        private string oauth_consumer_key = "yTPUBIODuVigVfju6jwTAjF3e";
        private string oauth_consumer_secret = "wiLdIEB8Y9YVfgKVpPWmhQsgMGm4aepbVQ0ZHyAdPmEVTBdiBQ";
        private string oauth_access_token = "272385254-CSy35Xdhvd8uw3AHJ6UzlLSiGEjzF4AfmQpvkZcR";
        private string oauth_access_token_secret = "LOy2CGei2rZlIsvmErsCqOhmdeu1iQK9detJyg52D5G6x";

        public Twitter() : base("TwitterTweets", EWidgetType.Twitter, "Twitter")
        {
            Parameters = new List<Params>();
            Parameters.Add(new Params { data = "user", type = "string" });
        }

        public override void Intake(string value)
        {
            _user = value;
        }
        public override void Intake(int val) { }

        public override IWidgetResult Invoke(User user)
        {

            string screenname = "epitech";


            try
            {
                var auth = new SingleUserAuthorizer
                {
                    CredentialStore = new InMemoryCredentialStore()
                    {
                        ConsumerKey = oauth_consumer_key,
                        ConsumerSecret = oauth_consumer_secret,
                        OAuthToken = oauth_access_token,
                        OAuthTokenSecret = oauth_access_token_secret

                    }

                };
                var twitterCtx = new TwitterContext(auth);
                var ownTweets = new List<Status>();

                ulong maxId = 0;
                bool flag = true;
                var statusResponse = new List<Status>();
                statusResponse = (from tweet in twitterCtx.Status
                                  where tweet.Type == StatusType.User
                                  && tweet.ScreenName == screenname
                                  && tweet.Count == 200
                                  select tweet).ToList();

                if (statusResponse.Count > 0)
                {
                    maxId = ulong.Parse(statusResponse.Last().StatusID.ToString()) - 1;
                    ownTweets.AddRange(statusResponse);

                }
                do
                {
                    int rateLimitStatus = twitterCtx.RateLimitRemaining;
                    if (rateLimitStatus != 0)
                    {

                        statusResponse = (from tweet in twitterCtx.Status
                                          where tweet.Type == StatusType.User
                                          && tweet.ScreenName == screenname
                                          && tweet.MaxID == maxId
                                          && tweet.Count == 200
                                          select tweet).ToList();

                        if (statusResponse.Count != 0)
                        {
                            maxId = ulong.Parse(statusResponse.Last().StatusID.ToString()) - 1;
                            ownTweets.AddRange(statusResponse);
                        }
                        else
                        {
                            flag = false;
                        }
                    }
                    else
                    {
                        flag = false;
                    }
                } while (flag);

                ownTweets.ForEach(Console.WriteLine);
                return new TwitterResult("HELLO");
            }
            catch (SystemException e)
            {
                Console.WriteLine(e);
                return new WidgetError();
            }
        }
    }
}
