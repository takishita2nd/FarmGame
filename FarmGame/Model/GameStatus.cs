﻿using System;
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
        public GameStatus()
        {
            Turn = 1;
            Weather = WeatherParameter.Sunny;
            Plants = new List<Plant>();
            Plants.Add(new Plant() { id = 0, name = "小麦", cost = 10, money = 10 });
            Plants.Add(new Plant() { id = 1, name = "トウモロコシ", cost = 12, money = 15 });
        }
    }
}
