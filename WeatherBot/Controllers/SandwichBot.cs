using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
        public List<SauceOptions> Sauce;

        public static IForm<SandwichBot> BuildForm()
        {
            return new FormBuilder<SandwichBot>()
                    .Message("Welcome to the simple sandwich order bot!")
                    .Build();
        }
    };
}