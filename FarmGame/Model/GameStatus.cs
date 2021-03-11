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
        public List<Recipe> Recipes { get; set; }
        public GameStatus()
        {
            Turn = 1;
            Weather = WeatherParameter.Sunny;
            Items = FileAccess.ItemLoad();
            Plants = FileAccess.PlantLoad();
            Recipes = new List<Recipe>();
            Recipes.Add(new Recipe() { id = 0, itemid = 100, material = new Material[] { new Material() { id = 100, num = 1 } } });
            Recipes.Add(new Recipe() { id = 1, itemid = 101, material = new Material[] { new Material() { id = 101, num = 1 } } });
        }
    }
}
