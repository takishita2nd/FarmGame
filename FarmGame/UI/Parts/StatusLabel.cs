﻿using Altseed2;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmGame.UI.Parts
{
    class StatusLabel : LabelBase
    {
        private const float Scale = 1.5f;
        public StatusLabel()
        {
            _node.Texture = Texture.SeedButton;
            _node.ZOrder = Common.Parameter.ZOrder.Request;
            _node.Scale = new Vector2F(Scale, Scale);

            _text.Color = new Color(0, 0, 0);
            _text.ZOrder = Common.Parameter.ZOrder.Farm;
        }
    }
}
