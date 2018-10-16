using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Dashboard.Models.Widgets
{

    public enum EWidgetType
    {
        Error,
        WeatherConditon,
    }

    public interface IWidgetResult
    {
        string WidgetName();
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
    }

    public interface IWidget
    {
        string Name();
        EWidgetType WidgetType();
        string ServiceName();
        IWidgetResult Request(User user);
    }
}
