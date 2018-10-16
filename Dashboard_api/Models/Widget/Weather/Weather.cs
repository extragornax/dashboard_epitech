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

using Microsoft.AspNetCore.Mvc;

using MongoDB.Bson;

namespace Dashboard.Models.Widgets
{

    public class WeatherConditionsResult : IWidgetResult
    {
        private string _payload;

        public WeatherConditionsResult(string payload)
        {
            _payload = payload;
        }

        public string WidgetName()
        {
            return "WeatherConditions";
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

    class WeatherConditonsIntake
    {

    }

    public class WeatherConditions : IWidget
    {
        private string _url = "https://api.openweathermap.org/data/2.5/weather?appid={0}&q={1}";
        private string _passkey = "2254cd740b40a4553ade575f6a057c98";
        private string _town = "Paris,fr";

        public ObjectId Id { get; set; }

        public string name = "WeatherConditions";
        public string serviceName = "Weather";

        public WeatherConditions() { }

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
                string tmpURL = String.Format(_url, _passkey, _town);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(tmpURL);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream resStream = response.GetResponseStream();
                var json = new string(new StreamReader(response.GetResponseStream()).ReadToEnd());
                return new WeatherConditionsResult(json);
            }
            catch (SystemException e)
            {
                Console.WriteLine(e);
                return new WidgetError();
            }
        }
    }
}
