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

        private const int wchipnum = 12;
        private const int hchipnum = 8;

        private SpriteNode _animal = null;
        private Type _type = Type.Empty;
        private int _anime = 0;
        private Node _parentNode = null;

        private float width;
        public int Width
        {
            get
            {
                return (int)width;
            }
        }
        private float height;

        private float animeWidth = 48.0f;
        private float animeHeight = 48.0f;

        public int Height
        {
            get
            {
                return (int)height;
            }
        }

        public RanchIcon() : base()
        {
            _anime = 0;
            _node.Texture = Texture.MapChip;
            _animal = new SpriteNode();
            _animal.ZOrder = Common.Parameter.ZOrder.Animal;

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
            float x;
            float y;

            _type = type;
            switch (type)
            {
                case Type.Empty:
                    _animal.Texture = null;
                    _animal.Src = new RectF(0, 0, 0, 0);
                    break;
                case Type.Chicken:
                    _animal.Texture = Texture.Chikin;
                    x = 0;
                    y = animeHeight;
                    _animal.Src = new RectF(x, y, animeWidth, animeHeight);
                    break;
                case Type.Cow:
                    _animal.Texture = Texture.Cow;
                    x = 0;
                    y = animeHeight;
                    _animal.Src = new RectF(x, y, animeWidth, animeHeight);
                    break;
            }
        }

        public override void SetNode(Node parent)
        {
            _parentNode = parent;
            base.SetNode(parent);
            parent.AddChildNode(_animal);
        }

        private const int xMargin = 10;
        private const int yMargin = 15;
        public override void SetPosition(Vector2F position)
        {
            base.SetPosition(position);
            _animal.Position = new Vector2F(position.X + xMargin, position.Y + yMargin);
        }

        public void Animetion()
        {
            float x;
            float y;

            switch (_anime)
            {
                case 0:
                    _anime++;
                    switch (_type)
                    {
                        case Type.Chicken:
                            x = animeWidth;
                            y = animeHeight;
                            _animal.Src = new RectF(x, y, animeWidth, animeHeight);
                            break;
                        case Type.Cow:
                            x = animeWidth;
                            y = animeHeight;
                            _animal.Src = new RectF(x, y, animeWidth, animeHeight);
                            break;
                    }
                    break;
                case 1:
                default:
                    _anime = 0;
                    switch (_type)
                    {
                        case Type.Chicken:
                            x = 0;
                            y = animeHeight;
                            _animal.Src = new RectF(x, y, animeWidth, animeHeight);
                            break;
                        case Type.Cow:
                            x = 0;
                            y = animeHeight;
                            _animal.Src = new RectF(x, y, animeWidth, animeHeight);
                            break;
                    }
                    break;
            }
        }
    }
}
