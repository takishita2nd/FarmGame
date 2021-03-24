using FarmGame.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmGame.Model
{
    class GameStatus
    {
        public enum WeatherParameter
        {
            Sunny,
            Cloudy,
            Rain,
        }

        public WeatherParameter Weather { get; set; }
        public int Turn { get; set; }
        public List<Plant> Plants { get; set; }
        public List<Item> Items { get; set; }
        public Recipes Recipes { get; set; }
        public ShopList Shoplists { get; set; }
        public GameStatus()
        {
            Turn = 1;
            Weather = WeatherParameter.Sunny;
            Items = FileAccess.ItemLoad();
            Plants = FileAccess.PlantLoad();
            Recipes = FileAccess.RecipeLoad();
            Shoplists = new ShopList();
            Shoplists.seed = new Seed[2];
            Shoplists.seed[0] = new Seed { id = 0, money = 10 };
            Shoplists.seed[1] = new Seed { id = 1, money = 30 };
        }
    }
}
