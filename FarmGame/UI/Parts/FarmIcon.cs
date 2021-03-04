﻿using Altseed2;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmGame.UI.Parts
{
    class FarmIcon: ButtonBase
    {
        public enum Type
        {
            None,
            Empty,  //空
            Wheat,  //小麦
            Cone    //とうもろこし
        }

        private Type _type = Type.None;
        private float width = 32.0f;
        private float height = 32.0f;

        public FarmIcon() : base()
        {
            _node.Scale = new Vector2F(2.5f, 2.5f);
            _node.ZOrder = FarmGame.Parameter.ZOrder.Farm;
        }

        public void SetClip(Type type, int growth)
        {
            switch (type)
            {
                case Type.Empty:
                    if(_node.Texture == null)
                    {
                        _node.Texture = Texture.FarmTexture1;
                        _node.Src = new RectF(0, 0, _node.ContentSize.X / 12.0f, _node.ContentSize.Y / 8.0f);
                    }
                    else if (!_node.Texture.Equals(Texture.FarmTexture1))
                    {
                        _node.Texture = Texture.FarmTexture1;
                        _node.Src = new RectF(0, 0, _node.ContentSize.X / 12.0f, _node.ContentSize.Y / 8.0f);
                    }
                    break;
                case Type.Wheat:
                    if (_node.Texture == null)
                    {
                        _node.Texture = Texture.FarmTexture3;
                    }
                    else if (!_node.Texture.Equals(Texture.FarmTexture3))
                    {
                        _node.Texture = Texture.FarmTexture3;
                    }
                    if (growth < 30)
                    {
                        _node.Src = new RectF(width * 9, height * 3, width, height);
                    }
                    if (growth >= 30 && growth < 100)
                    {
                        _node.Src = new RectF(width * 10, height * 3, width, height);
                    }
                    if (growth >= 100 && growth < 130)
                    {
                        _node.Src = new RectF(width * 11, height * 3, width, height);
                    }
                    if (growth >= 130)
                    {
                        _node.Src = new RectF(width * 11, height * 4, width, height);
                    }
                    break;
                case Type.Cone:
                    if (_node.Texture == null)
                    {
                        _node.Texture = Texture.FarmTexture2;
                    }
                    else if (!_node.Texture.Equals(Texture.FarmTexture2))
                    {
                        _node.Texture = Texture.FarmTexture2;
                    }
                    if (growth < 30)
                    {
                        _node.Src = new RectF(width * 0, height * 4, width, height);
                    }
                    if (growth >= 30 && growth < 100)
                    {
                        _node.Src = new RectF(width * 1, height * 4, width, height);
                    }
                    if (growth >= 100 && growth < 130)
                    {
                        _node.Src = new RectF(width * 2, height * 4, width, height);
                    }
                    if (growth >= 130)
                    {
                        _node.Src = new RectF(width * 5, height * 4, width, height);
                    }
                    break;
                default:
                    break;
            }
            _width = (int)(_node.ContentSize.X * 2.5f);
            _height = (int)(_node.ContentSize.Y * 2.5f);
        }
    }
}
