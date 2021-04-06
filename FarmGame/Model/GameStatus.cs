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

        public List<Plant> Plants { get; set; }
        public List<Item> Items { get; set; }
        public List<Livestock> Animals { get; set; }
        public Recipes Recipes { get; set; }
        public ShopListRoot Shoplist { get; set; }
        public GameStatus()
        {
            Items = FileAccess.ItemLoad();
            Plants = FileAccess.PlantLoad();
            Animals = FileAccess.AnimalLoad();
            Recipes = FileAccess.RecipeLoad();
            Shoplist = FileAccess.ShopListLoad();
        }
    }
}
