using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherBot.Converter
{
    public class TemperatureConverter
    {
        public static string KelvinToCelsius(string kelvinTemp)
        {
            int temp = (int)(double.Parse(kelvinTemp, System.Globalization.CultureInfo.InvariantCulture) - 273.15);
            return temp.ToString();
        }
    }
}