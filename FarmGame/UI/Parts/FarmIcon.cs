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
            Empty,
            Wheat
        }

        private Type _type;

        public FarmIcon() : base()
        {
            setClip(Type.Empty, 0);
            _node.Scale = new Vector2F(2.5f, 2.5f);
            _width = (int)(_node.ContentSize.X * 2.5f);
            _height = (int)(_node.ContentSize.Y * 2.5f);
            _node.ZOrder = CommonParameter.ZOrder.Farm;
        }

        private void setClip(Type type, int growth)
        {
            switch(type)
            {
                case Type.Empty:
                    _node.Texture = Texture.FarmTexture1;
                    _node.Src = new RectF(0, 0, _node.ContentSize.X / 12.0f, _node.ContentSize.Y / 8.0f);
                    break;
                default:
                    break;
            }
        }
    }
}
