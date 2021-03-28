using Altseed2;
using FarmGame.UI.Parts;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmGame.UI
{
    class ShopPanel
    {
        SpriteNode _node;
        Button _delivery;
        Button _destruction;

        public ShopPanel()
        {
            _node = new SpriteNode();
            _node.Texture = Texture.SeedButton;
            _node.ZOrder = Common.Parameter.ZOrder.Request;
            _node.Scale = new Vector2F(1.5f, 1.5f);

            _delivery = new Button(Texture.DeliveryButton, Texture.DeliveryButtonHover, Texture.DeliveryButtonClick);
            _delivery.SetZOrder(Common.Parameter.ZOrder.Request);
            _delivery.SetScale(0.6f);

            _destruction = new Button(Texture.DestructionButton, Texture.DestructionButtonHover, Texture.DestructionButtonClick);
            _destruction.SetZOrder(Common.Parameter.ZOrder.Request);
            _destruction.SetScale(0.6f);
        }

        public void SetNode(Node parentNode)
        {
            _node.Position = new Vector2F(30, 190);
            parentNode.AddChildNode(_node);
            _delivery.SetPosition(new Vector2F(30 + _node.ContentSize.X * 1.5f, 190));
            _delivery.SetNode(parentNode);
            _destruction.SetPosition(new Vector2F(30 + _node.ContentSize.X * 1.5f + _delivery.Width, 190));
            _destruction.SetNode(parentNode);
        }

        public void OnMouse(Vector2F position)
        {

        }
        public void OnClick(Vector2F position)
        {

        }
    }
}

