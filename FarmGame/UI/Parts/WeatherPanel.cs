using System;
using System.Collections.Generic;
using System.Text;
using Altseed2;

namespace FarmGame.UI.Parts
{
    class WeatherPanel : Parameter
    {
        public WeatherPanel()
        {
            
        }

        public void UpdateValue()
        {
            string weather = string.Empty;
            switch(GameData.PlayerData.Weather)
            {
                case Model.GameStatus.WeatherParameter.Sunny:
                    weather = "晴れ";
                    break;
                case Model.GameStatus.WeatherParameter.Cloudy:
                    weather = "曇り";
                    break;
                case Model.GameStatus.WeatherParameter.Rain:
                    weather = "雨";
                    break;
            }
            _text.Text = weather;
            _text.Position = new Vector2F(_node.Position.X + _node.ContentSize.X - _text.ContentSize.X - 20, _node.Position.Y);
        }

    }
}
