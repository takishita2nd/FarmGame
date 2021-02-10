using System;
using System.Collections.Generic;
using System.Text;
using Altseed2;

namespace FarmGame.UI.Parts
{
    class PowerPanel : Parameter
    {
        public PowerPanel()
        {
            
        }

        public void UpdateValue()
        {
            _text.Text = GameData.PlayerData.Power + " / " + GameData.PlayerData.MaxPower;
            _text.Position = new Vector2F(_text.Position.X - _text.ContentSize.X - 20, _text.Position.Y);
        }

    }
}
