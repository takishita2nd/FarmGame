using Altseed2;
using FarmGame.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmGame.UI.Parts
{
    class ShopListButton : ButtonBase
    {
        private Texture2D _texture = null;
        private TextNode _text = null;

        public ShopListButton(Texture2D texture, int id, int money) : base()
        {
            _texture = texture;
            _node.Texture = texture;
            _node.ZOrder = Common.Parameter.ZOrder.ShopList;

            _text = new TextNode();
            _text.Font = Font.LoadDynamicFontStrict("HachiMaruPop-Regular.ttf", 40);
            _text.Color = new Color(0, 0, 0);
            _text.ZOrder = Common.Parameter.ZOrder.ShopList;
            _text.Text = GameData.GameStatus.Items[id].name + "：" + money.ToString() + "Ｇ";

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
