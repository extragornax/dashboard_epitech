/*
** EPITECH PROJECT, 2018
** Dashboard
** File description:
** TempUnitConversion
*/

using System;
using System.Collections.Generic;
using System.Globalization;
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

    public class TempUnitConversionResult : IWidgetResult
    {
        private string _dataPackage;

        public TempUnitConversionResult(string DataPackage) { _dataPackage = DataPackage; }

        public string WidgetName() { return "TempUnitConversion"; }

        public EWidgetType WidgetType() { return EWidgetType.Error; }

        public string DataPackage() { return _dataPackage; }

        public void DataPackage(string DataPackage) { _dataPackage = DataPackage; }
    }

    [MongoDB.Bson.Serialization.Attributes.BsonDiscriminator("TempUnitConversion")]
    public class TempUnitConversion : IWidget
    {
        private string _temp = null;
        private string _toUnit = "C";

        public TempUnitConversion() : base("TempUnitConversion", EWidgetType.TempUnitConversion, "TempConversion")
        {
            Parameters = new List<Params>();
            Parameters.Add(new Params { data = "Ctemp", type = "string" });
            Parameters.Add(new Params { data = "toUnit", type = "string" });
        }

        public override void Intake(string val)
        {
            if (_temp == null) _temp = val;
            else _toUnit = val;
        }

        public override void Intake(int val) { }

        public override IWidgetResult Invoke(User user)
        {
            double value = float.Parse(_temp, CultureInfo.InvariantCulture.NumberFormat);

            try
            {
                if (_toUnit == "F") value = (value * 9) / 5 + 32;
                else if (_toUnit == "K") value = value + 273.15;
                return new TempUnitConversionResult(value.ToString());
            }
            catch (SystemException e)
            {
                Console.WriteLine(e);
                return new WidgetError();
            }
        }
    }
}
