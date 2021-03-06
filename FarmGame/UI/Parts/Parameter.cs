﻿using Altseed2;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmGame.UI.Parts
{
    class Parameter
    {
        protected SpriteNode _node = null;
        protected TextNode _text = null;

        public Parameter()
        {
            _node = new SpriteNode();
            _node.Texture = Texture2D.Load("parameter.png");
            _node.ZOrder = Common.Parameter.ZOrder.Panel;

            _text = new TextNode();
            _text.Font = Font.LoadDynamicFontStrict("HachiMaruPop-Regular.ttf", 40);
            _text.Color = new Color(0, 0, 0);
            _text.ZOrder = Common.Parameter.ZOrder.Text;
        }

        virtual public void SetPosition(Vector2F pos)
        {
            _node.Position = pos;
            _text.Position = new Vector2F(pos.X + _node.ContentSize.X, pos.Y);
        }

        public void SetNode(Node parentNode)
        {
            parentNode.AddChildNode(_node);
            parentNode.AddChildNode(_text);
        }

        public int GetHeight()
        {
            return _node.Texture.Size.Y;
        }
    }
}
