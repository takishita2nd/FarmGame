using System;
using System.Collections.Generic;
using System.Text;
using Altseed2;

namespace FarmGame.UI.Parts
{
    class PowerPanel : Parameter
    {
        public PowerPanel() : base()
        {
        }

        public override void SetPosition(Vector2F pos)
        {
            base.SetPosition(pos);
        }

        public void UpdateValue()
        {
            _text.Text = GameData.PlayerData.Power + " / " + GameData.PlayerData.MaxPower;
            _text.Position = new Vector2F(_node.Position.X + _node.ContentSize.X - _text.ContentSize.X - 20, _node.Position.Y);
        }
    }
}
