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
        private string key = "4a535c75fe9b1848c8e3075c0d41c30d";

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
                Console.WriteLine(String.Format(url, key, city));
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Format(url, key,
                    city));
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream resStream = response.GetResponseStream();
                var json = new string(new StreamReader(response.GetResponseStream()).ReadToEnd());
                System.Console.WriteLine(response);
                System.Console.WriteLine(json);
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
