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
            return EWidgetType.WeatherConditon;
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

    [MongoDB.Bson.Serialization.Attributes.BsonDiscriminator("WidgetWeatherConditions")]
    public class WeatherConditions : IWidget
    {
        private string url = "https://api.openweathermap.org/data/2.5/weather?q={1}&appid={0}";
        private string key = "2254cd740b40a4553ade575f6a057c98";

        private string city = "Paris,fr";

        public WeatherConditions() : base("WeatherConditions", EWidgetType.WeatherConditon, "Weather")
        {
            Parameters = new List<Params>();
            Parameters.Add(new Params { data = "city", type = "string" });
        }

        public override void Intake(string val)
        {
            city = val;
        }
        public override void Intake(int val) { }

        public override IWidgetResult Invoke(User user)
        {
            try
            {
                string final_url = String.Format(url, key, city);
                var cli = new WebClient();
                string data = cli.DownloadString(final_url);
                return new WeatherConditionsResult(data);
            }
            catch (SystemException e)
            {
                Console.WriteLine(e);
                return new WidgetError();
            }
        }
    }
}
