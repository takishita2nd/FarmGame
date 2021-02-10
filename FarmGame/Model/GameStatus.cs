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
            rain,
        }

        public WeatherParameter Weather { get; set; }
        public int Turn { get; set; }
    }
}
