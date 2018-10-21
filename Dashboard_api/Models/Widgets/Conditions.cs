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
        private string _dataPackage;

        public WeatherConditionsResult(string DataPackage) { _dataPackage = DataPackage; }

        public string WidgetName() { return "WeatherConditions"; }

        public EWidgetType WidgetType() { return EWidgetType.WeatherConditon; }

        public string DataPackage() { return _dataPackage; }

        public void DataPackage(string data) { _dataPackage = data; }
    }

    [MongoDB.Bson.Serialization.Attributes.BsonDiscriminator("WidgetWeatherConditions")]
    public class WeatherConditions : IWidget
    {
        private string url = "https://api.openweathermap.org/data/2.5/weather?q={0}&appid=2254cd740b40a4553ade575f6a057c98";

        private string town = "Paris,fr";

        public WeatherConditions() : base("WeatherConditions", EWidgetType.WeatherConditon, "Weather")
        {
            Parameters = new List<Params>();
            Parameters.Add(new Params { data = "town", type = "string" });
        }

        public override void Intake(string value) { town = value; }

        public override void Intake(int val) { }

        public override IWidgetResult Invoke(User user)
        {
            try
            {
                string final_url = String.Format(url, town);
                System.Net.WebClient cli = new WebClient();
                string data = cli.DownloadString(final_url);
                Console.WriteLine("RETURNING -> " + data);
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
