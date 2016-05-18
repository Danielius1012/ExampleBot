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
using WeatherBot.App_Start;

namespace WeatherBot.Controllers
{
    /// <summary>
    /// The LUIS dialog. Please use your own credentials file or just paste your LUIS credentials here.
    /// </summary>
    [LuisModel(Credentials.LUISModelId, Credentials.LUISSubscriptionKey)]
    [Serializable]
    public class CarDialog : LuisDialog<object>
    {
        public const string Entity_Company = "company";
        public const string Entity_Year = "year";

        // Ask questions like: get cars form <company> of <year>

        [LuisIntent("")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            string message = $"Sorry I did not understand that.)";
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("getModels")]
        public async Task GetModels(IDialogContext context, LuisResult result)
        {
            EntityRecommendation company;
            EntityRecommendation year;
            if (result.TryFindEntity(Entity_Company, out company))
            {
                if (result.TryFindEntity(Entity_Year, out year))
                {
                    await context.PostAsync(await CarAPICaller.GetModels(company.Entity, year.Entity));
                }
                else
                {
                    await context.PostAsync("Year is missing, please try again.");
                }
                    
            }
            else
            {
                await context.PostAsync("Unable to get cars.");
            }

            context.Wait(MessageReceived);
        }
    }
    


}

