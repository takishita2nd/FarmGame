﻿using Altseed2;
using FarmGame.Common;
using FarmGame.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmGame.UI.Parts
{
    class ShopListButton : ButtonBase
    {
        public enum Type
        {
            Seed,
            Food,
            Animal
        }

        private int _id;
        public int Id 
        {
            get
            {
                return _id;
            }
        }
        private int _money;
        public int Money
        {
            get
            {
                return _money;
            }
        }
        private Common.Parameter.Quality _quolity;
        public Common.Parameter.Quality Quality
        {
            get
            {
                return _quolity;
            }
        }

        private Type _type;
        public Type type
        {
            get
            {
                return _type;
            }
        }

        private Texture2D _texture = null;
        private TextNode _text = null;

        public ShopListButton(Texture2D texture, int id, int money, Type type) : base()
        {
            _id = id;
            _money = money;
            _type = type;
            
            createButton(texture);

            switch (type)
            {
                case Type.Seed:
                    _text.Text = GameData.GameStatus.Items[id].name + "：" + money.ToString() + "Ｇ";
                    break;
                case Type.Animal:
                    _text.Text = Function.SearchItemById(id).name + "：" + money.ToString() + "Ｇ";
                    break;
                default:
                    break;
            }
        }

        public ShopListButton(Texture2D texture, int id, int money, Common.Parameter.Quality quality) : base()
        {
            _id = id;
            _money = money;
            _type = Type.Food;
            _quolity = quality;

            createButton(texture);

            _text.Text = Function.SearchItemById(id).name + "(品質:" + Function.Quolity2String(quality) + ")：" + money.ToString() + "Ｇ";
        }

        private void createButton(Texture2D texture)
        {
            _texture = texture;
            _node.Texture = texture;
            _node.ZOrder = Common.Parameter.ZOrder.ShopList;

            _text = new TextNode();
            _text.Font = Font.LoadDynamicFontStrict("HachiMaruPop-Regular.ttf", 40);
            _text.Color = new Color(0, 0, 0);
            _text.ZOrder = Common.Parameter.ZOrder.ShopList;

            _width = 300;
            _height = 35;
        }

        override public void SetPosition(Vector2F position)
        {
            _position = position;
            _node.Position = position;
            _text.Position = position;
        }

        override public void SetNode(Node parent)
        {
            parent.AddChildNode(_node);
            parent.AddChildNode(_text);
        }

        override public void SetZOrder(int zOrder)
        {
            _node.ZOrder = zOrder;
            _text.ZOrder = zOrder;
        }

        override public void RemoveNode(Node parent)
        {
            parent.RemoveChildNode(_node);
            parent.RemoveChildNode(_text);
        }

    }
}
