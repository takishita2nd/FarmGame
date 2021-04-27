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
        private const string _plantfilename = "plant.dat";
        public static List<Plant> PlantLoad()
        {
            List<Plant> plants = new List<Plant>();
            string csv = Encrypt.Decode(_plantfilename);
            var lines = csv.Split("\n");
            bool flg = false;
            foreach(var line in lines)
            {
                //1行目はカラム名なので捨てる
                if(!flg)
                {
                    flg = true;
                }
                else
                {
                    var str = line.Split(",");
                    if (str.Length == 3)
                    {
                        Plant plant = new Plant() { id = int.Parse(str[0]), name = str[1], cost = int.Parse(str[2]) };
                        plants.Add(plant);
                    }
                }
            }
            return plants;
        }
        private const string _animalfilename = "animal.dat";
        public static List<Livestock> AnimalLoad()
        {
            List<Livestock> animals = new List<Livestock>();
            string csv = Encrypt.Decode(_animalfilename);
            var lines = csv.Split("\n");
            bool flg = false;
            foreach (var line in lines)
            {
                //1行目はカラム名なので捨てる
                if (!flg)
                {
                    flg = true;
                }
                else
                {
                    var str = line.Split(",");
                    if(str.Length == 4)
                    {
                        Livestock animal = new Livestock() { id = int.Parse(str[0]), name = str[1], cost = int.Parse(str[2]), product = int.Parse(str[3]) };
                        animals.Add(animal);
                    }
                }
            }
            return animals;
        }

        private const string _itemfilename = "item.dat";
        public static List<Item> ItemLoad()
        {
            List<Item> items = new List<Item>();
            string csv = Encrypt.Decode(_itemfilename);
            var lines = csv.Split("\n");
            bool flg = false;
            foreach (var line in lines)
            {
                //1行目はカラム名なので捨てる
                if (!flg)
                {
                    flg = true;
                }
                else
                {
                    var str = line.Split(",");
                    if (str.Length == 3)
                    {
                        Item item = new Item() { id = int.Parse(str[0]), name = str[1], level = int.Parse(str[2]) };
                        items.Add(item);
                    }
                }
            }
            return items;
        }
        private const string _recipefilename = "recipe.dat";
        public static Recipes RecipeLoad()
        {
            string json = Encrypt.Decode(_recipefilename);
            return JsonConvert.DeserializeObject<Recipes>(json);
        }

        private const string _shopfilename = "shoplist.dat";
        public static ShopListRoot ShopListLoad()
        {
            string json = Encrypt.Decode(_shopfilename);
            return JsonConvert.DeserializeObject<ShopListRoot>(json);
        }

        private const string _savefilename = "save.dat";
        public static void GameDataSave(PlayerData data)
        {
            if (File.Exists(_savefilename))
            {
                File.Delete(_savefilename);
            }

            string json = JsonConvert.SerializeObject(data);
            Encrypt.Save(json, _savefilename);
        }

        public static PlayerData GameDataLoad()
        {
            PlayerData gameData = null;
            if(File.Exists(_savefilename))
            {
                string json = Encrypt.Decode(_savefilename);
                gameData = JsonConvert.DeserializeObject<PlayerData>(json);
            }
            return gameData;
        }
    }
}
