using FarmGame.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FarmGame.Common
{
    class FileAccess
    {
        private const string _plantfilename = "plant.csv";
        public static List<Plant> PlantLoad()
        {
            List<Plant> plants = new List<Plant>();
            using (var stream = new StreamReader(_plantfilename, true))
            {
                //1行目はカラム名なので捨てる
                string? line = stream.ReadLine();
                line = stream.ReadLine();
                while (line != null)
                {
                    var str = line.Split(",");
                    Plant plant = new Plant() {id = int.Parse(str[0]), name = str[1], cost = int.Parse(str[2])};
                    plants.Add(plant);
                    line = stream.ReadLine();
                }
            }
            return plants;
        }
        private const string _animalfilename = "animal.csv";
        public static List<Livestock> AnimalLoad()
        {
            List<Livestock> animals = new List<Livestock>();
            using (var stream = new StreamReader(_animalfilename, true))
            {
                //1行目はカラム名なので捨てる
                string? line = stream.ReadLine();
                line = stream.ReadLine();
                while (line != null)
                {
                    var str = line.Split(",");
                    Livestock animal = new Livestock() { id = int.Parse(str[0]), name = str[1], cost = int.Parse(str[2]), product = int.Parse(str[3]) };
                    animals.Add(animal);
                    line = stream.ReadLine();
                }
            }
            return animals;
        }

        private const string _itemfilename = "item.csv";
        public static List<Item> ItemLoad()
        {
            List<Item> items = new List<Item>();
            using (var stream = new StreamReader(_itemfilename, true))
            {
                //1行目はカラム名なので捨てる
                string? line = stream.ReadLine();
                line = stream.ReadLine();
                while (line != null)
                {
                    var str = line.Split(",");
                    Item item = new Item() { id = int.Parse(str[0]), name = str[1], level = int.Parse(str[2]) };
                    items.Add(item);
                    line = stream.ReadLine();
                }
            }
            return items;
        }
        private const string _recipefilename = "recipe.json";
        public static Recipes RecipeLoad()
        {
            Recipes recipes = null;
            using (var stream = new StreamReader(_recipefilename, true))
            {
                string json = stream.ReadToEnd();
                recipes = JsonConvert.DeserializeObject<Recipes>(json);
            }
            return recipes;
        }
        private const string _shopfilename = "shoplist.json";
        public static ShopListRoot ShopListLoad()
        {
            ShopListRoot shoplist = null;
            using (var stream = new StreamReader(_shopfilename, true))
            {
                string json = stream.ReadToEnd();
                shoplist = JsonConvert.DeserializeObject<ShopListRoot>(json);
            }
            return shoplist;
        }
        private const string _savefilename = "save.json";
        public static void GameDataSave(PlayerData data)
        {
            using (var stream = new StreamWriter(_savefilename, false))
            {
                string json = JsonConvert.SerializeObject(data);
                stream.Write(json);
            }
        }
        public static PlayerData GameDataLoad()
        {
            PlayerData gameData = null;
            if(File.Exists(_savefilename))
            {
                using (var stream = new StreamReader(_savefilename, true))
                {
                    string json = stream.ReadToEnd();
                    gameData = JsonConvert.DeserializeObject<PlayerData>(json);
                }
            }
            return gameData;
        }
    }
}
