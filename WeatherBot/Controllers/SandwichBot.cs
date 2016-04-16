using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Bot.Builder.Dialogs;
using System.Threading.Tasks;

namespace WeatherBot.Controllers
{
    public enum SandwichOptions
    {
        BLT, BlackForestHam, BuffaloChicken, ChickenAndBaconRanchMelt, ColdCutCombo, MeatballMarinara,
        OverRoastedChicken, RoastBeef, RotisserieStyleChicken, SpicyItalian, SteakAndCheese, SweetOnionTeriyaki, Tuna,
        TurkeyBreast, Veggie
    };
    public enum LengthOptions { SixInch, FootLong };
    public enum BreadOptions { NineGrainWheat, NineGrainHoneyOat, Italian, ItalianHerbsAndCheese, Flatbread };
    public enum CheeseOptions { American, MontereyCheddar, Pepperjack };
    public enum ToppingOptions
    {
        Avocado, BananaPeppers, Cucumbers, GreenBellPeppers, Jalapenos,
        Lettuce, Olives, Pickles, RedOnion, Spinach, Tomatoes
    };
    public enum SauceOptions
    {
        ChipotleSouthwest, HoneyMustard, LightMayonnaise, RegularMayonnaise,
        Mustard, Oil, Pepper, Ranch, SweetOnion, Vinegar
    };

    [Serializable]
    class SandwichBot
    {
        public SandwichOptions? Sandwich;
        public LengthOptions? Length;
        public BreadOptions? Bread;
        public CheeseOptions? Cheese;
        public List<ToppingOptions> Toppings;
        public List<SauceOptions> Sauces;

        public static IForm<SandwichBot> BuildForm()
        {
            return new FormBuilder<SandwichBot>()
                    .Message("Welcome to the simple sandwich order bot!")
                    //.Field(nameof(SandwichBot.Sandwich))
                    //.Field(nameof(SandwichBot.Length))
                    //.Field(nameof(SandwichBot.Bread))
                    //.Field(nameof(SandwichBot.Cheese))
                    //.Field(nameof(SandwichBot.Toppings))
                    //.AddRemainingFields()
                    //.Confirm("Do you want to order your {Length} {Sandwich} on {Bread} {&Bread} with {[{Cheese} {Toppings} {Sauces}]} ?")
                    //.Message("Thanks for ordering a sandwich!")
                    //.OnCompletionAsync(processOrder)
                    .Build();
        }

        private static Task processOrder(IDialogContext context, SandwichBot state)
        {
            throw new NotImplementedException();
        }
    };
}