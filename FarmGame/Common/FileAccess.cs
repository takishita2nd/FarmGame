﻿using FarmGame.Model;
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
                    Plant plant = new Plant() {id = int.Parse(str[0]), name = str[1], cost = int.Parse(str[2]), money = int.Parse(str[3])};
                    plants.Add(plant);
                    line = stream.ReadLine();
                }
            }
            return plants;
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
                    Item item = new Item() { id = int.Parse(str[0]), name = str[1] };
                    items.Add(item);
                    line = stream.ReadLine();
                }
            }
            return items;
        }
    }
}