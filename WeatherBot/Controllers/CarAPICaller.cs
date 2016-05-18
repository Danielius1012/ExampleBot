using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using WeatherBot.Converter;
using WeatherBot.Objects;

namespace WeatherBot.Controllers
{
    public class CarAPICaller
    {
        // Sample URL: http://www.carqueryapi.com/api/0.3/?callback=?&cmd=getMakes&year=2000&make=ford

        public static async Task<string> GetModels(string company, string year)
        {
            
            var urlBase = $"http://www.carqueryapi.com/api/0.3/?callback=?&cmd=getModels";

            var callURL = $"{urlBase}&make={company}&year={year}";

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
                string responseFromServer = reader.ReadToEnd().Substring(3);

                // Remove first 2 and last two elements from response
                responseFromServer = responseFromServer.Remove(responseFromServer.Length - 2);

                // Deserialize JSON
                var infos = JsonConvert.DeserializeObject<CarData>(responseFromServer);

                string output = ComposeAnswer(infos);

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

        private static string ComposeAnswer(CarData infos)
        {
            string cars = "The cars are: ";

            foreach (var car in infos.Models.ToList())
            {
                cars += $" **{car.model_make_id} {car.model_name}** , ";
            }

            return cars;
        }
    }
}