using Altseed2;
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
            Wheat   //小麦
        }

        private Type _type = Type.None;

        public FarmIcon() : base()
        {
            _node.Scale = new Vector2F(2.5f, 2.5f);
            _node.ZOrder = FarmGame.Parameter.ZOrder.Farm;
        }

        public void Plant(Type type)
        {
            if(_type != type)
            {
                _type = type;
                setClip(_type, 0);
            }
        }

        private void setClip(Type type, int growth)
        {
            switch(type)
            {
                case Type.Empty:
                    _node.Texture = Texture.FarmTexture1;
                    _node.Src = new RectF(0, 0, _node.ContentSize.X / 12.0f, _node.ContentSize.Y / 8.0f);
                    break;
                case Type.Wheat:
                    _node.Texture = Texture.FarmTexture3;
                    float width = _node.ContentSize.X / 12.0f;
                    float height = _node.ContentSize.Y / 8.0f;
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
                default:
                    break;
            }
            _width = (int)(_node.ContentSize.X * 2.5f);
            _height = (int)(_node.ContentSize.Y * 2.5f);
        }
    }
}
