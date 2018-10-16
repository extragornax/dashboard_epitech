/*
** EPITECH PROJECT, 2018
** Dashboard_api
** File description:
** Conditions
*/

using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNetCore.Mvc;

using MongoDB.Bson;
using Newtonsoft.Json;

namespace Dashboard.Models.Widgets
{

    public class RssFeedResult : IWidgetResult
    {
        private string _payload;

        public RssFeedResult(string payload)
        {
            _payload = payload;
        }

        public string WidgetName()
        {
            return "RssFeed";
        }
        public EWidgetType WidgetType()
        {
            return EWidgetType.Error;
        }
        public string Payload()
        {
            return _payload;
        }
        public void Payload(string payload)
        {
            _payload = payload;
        }
    }

    class RssFeedIntake
    {

    }

    public class RssFeed : IWidget
    {
        private string _url = "https://www.techrepublic.com/rssfeeds/articles/";
        public ObjectId Id { get; set; }

        public string name = "RssFeed";
        public string serviceName = "RSS";

        public RssFeed() { }

        public string Name()
        {
            return name;
        }

        public void Name(string value)
        {
            name = value;
        }

        public EWidgetType WidgetType()
        {
            return EWidgetType.WeatherConditon;
        }

        public string ServiceName()
        {
            return serviceName;
        }

        public void ServiceName(string value)
        {
            serviceName = value;
        }

        public IWidgetResult Request(User user)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream resStream = response.GetResponseStream();
                XmlDocument doc = new XmlDocument();
                var json = new string(new StreamReader(response.GetResponseStream()).ReadToEnd());
                doc.LoadXml(json);
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
