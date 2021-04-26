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
            Empty,      //空
            Wheat,      //小麦
            Cone,       //とうもろこし
            Carrot,     //人参
            Pumpkin,    //かぼちゃ
            Tomato,     //トマト
            Strawberry, //いちご
            Potato,     //じゃがいも
            Pineapple,  //パイナップル
            Rice        //米
        }

        private Type _type = Type.None;
        private float width = 32.0f;
        private float height = 32.0f;

        public FarmIcon() : base()
        {
            _node.Scale = new Vector2F(2.5f, 2.5f);
            _node.ZOrder = Common.Parameter.ZOrder.Farm;
        }

        public void SetClip(Type type, int growth)
        {
            switch (type)
            {
                case Type.Empty:
                    _node.Texture = Texture.FarmTexture1;
                    _node.Src = new RectF(0, 0, width, height);
                    break;
                case Type.Wheat:
                    _node.Texture = Texture.FarmTexture3;
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
                    _node.Texture = Texture.FarmTexture2;
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
                case Type.Carrot:
                    _node.Texture = Texture.FarmTexture2;
                    if (growth < 30)
                    {
                        _node.Src = new RectF(width * 0, height * 5, width, height);
                    }
                    if (growth >= 30 && growth < 100)
                    {
                        _node.Src = new RectF(width * 1, height * 5, width, height);
                    }
                    if (growth >= 100 && growth < 130)
                    {
                        _node.Src = new RectF(width * 2, height * 5, width, height);
                    }
                    if (growth >= 130)
                    {
                        _node.Src = new RectF(width * 5, height * 5, width, height);
                    }
                    break;
                case Type.Pumpkin:
                    _node.Texture = Texture.FarmTexture1;
                    if (growth < 30)
                    {
                        _node.Src = new RectF(width * 0, height * 2, width, height);
                    }
                    if (growth >= 30 && growth < 100)
                    {
                        _node.Src = new RectF(width * 1, height * 2, width, height);
                    }
                    if (growth >= 100 && growth < 130)
                    {
                        _node.Src = new RectF(width * 0, height * 3, width, height);
                    }
                    if (growth >= 130)
                    {
                        _node.Src = new RectF(width * 3, height * 3, width, height);
                    }
                    break;
                case Type.Tomato:
                    _node.Texture = Texture.FarmTexture2;
                    if (growth < 30)
                    {
                        _node.Src = new RectF(width * 0, height * 0, width, height);
                    }
                    if (growth >= 30 && growth < 100)
                    {
                        _node.Src = new RectF(width * 1, height * 0, width, height);
                    }
                    if (growth >= 100 && growth < 130)
                    {
                        _node.Src = new RectF(width * 2, height * 0, width, height);
                    }
                    if (growth >= 130)
                    {
                        _node.Src = new RectF(width * 5, height * 0, width, height);
                    }
                    break;
                case Type.Strawberry:
                    _node.Texture = Texture.FarmTexture3;
                    if (growth < 30)
                    {
                        _node.Src = new RectF(width * 9, height * 0, width, height);
                    }
                    if (growth >= 30 && growth < 100)
                    {
                        _node.Src = new RectF(width * 10, height * 0, width, height);
                    }
                    if (growth >= 100 && growth < 130)
                    {
                        _node.Src = new RectF(width * 11, height * 0, width, height);
                    }
                    if (growth >= 130)
                    {
                        _node.Src = new RectF(width * 11, height * 1, width, height);
                    }
                    break;
                case Type.Potato:
                    _node.Texture = Texture.FarmTexture1;
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
                case Type.Pineapple:
                    _node.Texture = Texture.FarmTexture1;
                    if (growth < 30)
                    {
                        _node.Src = new RectF(width * 0, height * 1, width, height);
                    }
                    if (growth >= 30 && growth < 100)
                    {
                        _node.Src = new RectF(width * 1, height * 1, width, height);
                    }
                    if (growth >= 100 && growth < 130)
                    {
                        _node.Src = new RectF(width * 2, height * 1, width, height);
                    }
                    if (growth >= 130)
                    {
                        _node.Src = new RectF(width * 5, height * 1, width, height);
                    }
                    break;
                case Type.Rice:
                    _node.Texture = Texture.FarmTexture1;
                    if (growth < 30)
                    {
                        _node.Src = new RectF(width * 0, height * 7, width, height);
                    }
                    if (growth >= 30 && growth < 100)
                    {
                        _node.Src = new RectF(width * 1, height * 7, width, height);
                    }
                    if (growth >= 100 && growth < 130)
                    {
                        _node.Src = new RectF(width * 2, height * 7, width, height);
                    }
                    if (growth >= 130)
                    {
                        _node.Src = new RectF(width * 5, height * 7, width, height);
                    }
                    break;
                default:
                    break;
            }
            _type = type;
            _width = (int)(_node.ContentSize.X * 2.5f);
            _height = (int)(_node.ContentSize.Y * 2.5f);
        }
    }
}
