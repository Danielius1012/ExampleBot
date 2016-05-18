/*

Wetter Bot by Daniel Heinze (heinze.business@outlook.com)
with http://openweathermap.org/current

GOAL:

- Wetter für versch. Städte
- Entweder Stadt , Stadt+Land, Postleitzahl, Geo. Coord, CityID?
- Temperatur: Kelvin, Celsius, Fahrenheit?

*/

using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace WeatherBot.Controllers
{
    [LuisModel("", "")]
    [Serializable]
    public class WeatherDialog : LuisDialog<object>
    {
        public const string Entity_Location = "locationName";

        [LuisIntent("")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            string message = $"Sorry I did not understand: " + string.Join(", ", result.Intents.Select(i => i.Intent));
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("CREATED INTENT")]
        public async Task GetTemperature(IDialogContext context, LuisResult result)
        {
            EntityRecommendation location;
            if (result.TryFindEntity(Entity_Location, out location))
            {
                await context.PostAsync(await WeatherAPICaller.GetWeatherData(location.Entity));
            }
            else
            {
                await context.PostAsync("Unable to get temperature from location.");
            }

            context.Wait(MessageReceived);
        }
    }
    


}

