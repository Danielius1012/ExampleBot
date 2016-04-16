using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using WeatherBot.Converter;

namespace WeatherBot.Controllers
{
    public class WeatherAPICaller
    {
        private static string API_KEY = "043ef5b645f0dfe2144806aeb37266b6";

        public static async Task<string> GetWeatherData(string city)
        {
            
            var urlBase = $"http://api.openweathermap.org/data/2.5/weather?";

            var callURL = $"{urlBase}q={city}&appid={API_KEY}";

            // Call API
            return CallWeatherAPI(callURL);
        }

        private static string CallWeatherAPI(string url)
        {
            try
            {
                // Send JSON to endpoint
                WebRequest request = WebRequest.Create(url);
                request.Method = "GET";
                
                // Handle Response from endpoint
                WebResponse response = request.GetResponse();
                var dataStream = response.GetResponseStream();

                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();

                // Deserialize JSON
                var infos = ""; // JsonConvert.DeserializeObject<OWMCurrentWeather>(responseFromServer);

                string output = ""; // ComposeWeatherAnswer(infos);

                // Clean up the streams.
                reader.Close();
                dataStream.Close();
                response.Close();

                return output;
            }
            catch (Exception e)
            {
                var error = e;
                return "No weather data available.";
            }
            
        }

        private static string ComposeWeatherAnswer()
        {
            // string temperature = TemperatureConverter.KelvinToCelsius(infos.Main.Temperature);

            // Keep in mind: &#13;&#10; for new line
            // string weatherInfos = $"The temperature for {infos.Name} is {temperature}°C.";

            return "";
        }
    }
}