/*
** EPITECH PROJECT, 2018
** Dashboard
** File description:
** Conditions
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Newtonsoft.Json;

namespace Dashboard.Models.Widgets
{

    public class RssFeedResult : IWidgetResult
    {
        private string _dataPackage;

        public RssFeedResult(string DataPackage)
        {
            _dataPackage = DataPackage;
        }

        public string WidgetName()
        {
            return "RssFeed";
        }
        public EWidgetType WidgetType()
        {
            return EWidgetType.Error;
        }
        public string DataPackage()
        {
            return _dataPackage;
        }
        public void DataPackage(string DataPackage)
        {
            _dataPackage = DataPackage;
        }
    }

    [MongoDB.Bson.Serialization.Attributes.BsonDiscriminator("RssFeed")]
    public class RssFeed : IWidget
    {
        private string _url = "https://www.techrepublic.com/rssfeeds/articles/";

        public RssFeed() : base("RssFeed", EWidgetType.RssFeed, "Rss")
        {
            Parameters = new List<Params>();
            Parameters.Add(new Params { data = "url", type = "string" });
        }

        public override void Intake(string val)
        {
            Console.WriteLine("New URL " + val);
            val = HttpUtility.UrlDecode(val);
            Console.WriteLine("AFTER New URL " + val);
            _url = val;
        }

        public override void Intake(int val) { }

        public override IWidgetResult Invoke(User user)
        {
            try
            {
                var cli = new WebClient();
                string data = cli.DownloadString(_url);
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(data);
                string jsonText = JsonConvert.SerializeXmlNode(doc);
                return new WeatherConditionsResult(jsonText);
            }
            catch (SystemException e)
            {
                Console.WriteLine(e);
                return new WidgetError();
            }
        }
    }
}
