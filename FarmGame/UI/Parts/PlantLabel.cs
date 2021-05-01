using System;
using System.Collections.Generic;
using System.Text;
using Altseed2;

namespace FarmGame.UI.Parts
{
    class PlantLabel : LabelBase
    {
        public PlantLabel() : base()
        {
            var scale = Texture.FarmWindow.Size.Y * 1.5f / (Texture.FarmTexture1.Size.Y / 8.0f);
            _node.Scale = new Vector2F(scale, scale);
            _node.ZOrder = Common.Parameter.ZOrder.Farm;

            _text.Color = new Color(0, 0, 0);
            _text.ZOrder = Common.Parameter.ZOrder.Farm;
        }
    }
}
