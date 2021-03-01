using System;
using System.Collections.Generic;
using System.Text;
using Altseed2;

namespace FarmGame.UI.Parts
{
    class MoneyPanel : Parameter
    {
        public MoneyPanel()
        {
            
        }

        public void SetValue(int money)
        {
            _text.Text = money + "G";
            _text.Position = new Vector2F(_node.Position.X + _node.ContentSize.X - _text.ContentSize.X - 20, _node.Position.Y);
        }
    }
}
