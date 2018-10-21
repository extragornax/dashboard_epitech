/*
** EPITECH PROJECT, 2018
** dashboard
** File description:
** IWidget
*/

using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Dashboard.Models.Widgets
{

    public enum EWidgetType
    {
        Error,
        WeatherConditon,
        RssFeed,
        TempUnitConversion,
        Twitter,
    }

    public interface IWidgetResult
    {
        string WidgetName();
        string DataPackage();
        EWidgetType WidgetType();
    }

    public class WidgetError : IWidgetResult
    {
        public string WidgetName()
        {
            return "Error";
        }
        public EWidgetType WidgetType()
        {
            return EWidgetType.Error;
        }
        public string DataPackage()
        {
            return "";
        }
    }

    public class Params
    {
        public string data;
        public string type;
    }

    [BsonKnownTypes(typeof(RssFeed), typeof(WeatherConditions), typeof(TempUnitConversion))]
    public abstract class IWidget
    {
        public ObjectId Id { get; set; }
        public readonly string Name;
        public readonly EWidgetType Type;
        public readonly string ServiceName;
        [JsonProperty(PropertyName = "params")]
        public List<Params> Parameters;

        public IWidget(string name, EWidgetType type, string serviceName)
        {
            Name = name;
            Type = type;
            ServiceName = serviceName;
        }

        abstract public void Intake(string val);
        abstract public void Intake(int val);
        abstract public IWidgetResult Invoke(User user);
    }
}
