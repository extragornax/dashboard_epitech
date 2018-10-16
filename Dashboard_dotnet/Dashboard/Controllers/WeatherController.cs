/*
** EPITECH PROJECT, 2018
** Dashboard
** File description:
** WeatherController
*/

using System;
using System.IO;
using System.Net;
using System.Xml;
// using System.Web.Script.Serialization;

namespace Dashboard.Controllers
{

    enum degreeValList { Kel = 1, Cel = 2, Far = 3 };
    public class WeatherModule
    {
        private string _apiKey = "appid=2254cd740b40a4553ade575f6a057c98";
        private int _degreeVal = (int)degreeValList.Cel;
        private string _town = "q=Parieees,fr";
        private int _timeLog = -1;
        private int _degree = 0;

        public void printLineToConsole(string line)
        {
            Console.WriteLine("=============================================================================================");
            Console.WriteLine("=============================================================================================");
            Console.WriteLine("============== " + DateTime.Now.TimeOfDay + " ==============");
            Console.WriteLine("========== ->" + line + "<- ==================");
            Console.WriteLine("=============================================================================================");
            Console.WriteLine("=============================================================================================");
        }

        private string resolveEnumValue(int val)
        {
            if (val == (int)degreeValList.Kel)
                return "Kel";
            else if (val == (int)degreeValList.Cel)
                return "Cel";
            else if (val == (int)degreeValList.Far)
                return "Far";
            else
                return "ERROR";
        }
        /* 
        ** GETTERS
        ** 
        */
        private string getTemperature()
        {
            int tmpTime = DateTime.Now.Second / 10;
            if (tmpTime != _timeLog)
                _timeLog = tmpTime;
            else
                return _degree.ToString();

            string url = "https://api.openweathermap.org/data/2.5/weather?";

            url += _apiKey += "&mode=xml";

            if (_degreeVal == (int)degreeValList.Cel)
                url += "&units=metric";
            else if (_degreeVal == (int)degreeValList.Far)
                url += "&units=imperial";
            url += "&" + _town;
            printLineToConsole(url + " -> " + _degree + " in " + resolveEnumValue(_degreeVal));

            var cli = new WebClient();
            string data = cli.DownloadString(url);
            printLineToConsole("Got " + data);

            // var ser = new System.Web.Script.Serialization.JavaScriptSerializer();
            // ser.DeserializeObject(data);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(data);

            XmlNode node = doc.SelectSingleNode("//ClientError/cod");


            // printLineToConsole(node.Value);
            // int errCode = node.Value;
            if (node == null)
                return (data);
            else
                return ("XML = ERROR got error code -> ");// + node.InnerText);
        }

        /*
        ** POST / PUT
        **
        */
        public void setDegreeVal(int val)
        {
            _degreeVal = val;
        }

        public void setTown(string town)
        {
            _town = town;
        }

        public string runGetter()
        {
            printLineToConsole("In runGetter");
            return (getTemperature());

        }

    }
}