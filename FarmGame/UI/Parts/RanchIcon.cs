using Altseed2;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmGame.UI.Parts
{
    class RanchIcon : ButtonBase
    {
        public enum Type
        {
            Empty,
            Chicken,    //ニワトリ
            Cow,        //ウシ
        }

        private const int xPosition = 25;
        private const int yPosition = 7;
        private const int xMaxsize = 29;
        private const int yMaxsize = 16;
        private const float scale = 3.8f;

        private SpriteNode _animal = null;
        private Type _type = Type.Empty;

        private float width;
        public int Width
        {
            get
            {
                return (int)width;
            }
        }
        private float height;
        public int Height
        {
            get
            {
                return (int)height;
            }
        }

        public RanchIcon() : base()
        {
            _node.Texture = Texture.MapChip;

            int xsize = (int)(_node.ContentSize.X / xMaxsize);
            int ysize = (int)(_node.ContentSize.Y / yMaxsize);

            _node.Src = new RectF(xPosition * xsize, yPosition * ysize, xsize, ysize);
            _node.Scale = new Vector2F(scale, scale);
            width = xsize * scale;
            height = ysize * scale;
            _node.ZOrder = Common.Parameter.ZOrder.Ranch;
        }

        public void SetClip(Type type, int growth)
        {
            switch (type)
            {
                case Type.Empty:
                    _animal.Texture = null;
                    break;

            }
        }
    }
}
