using Altseed2;
using FarmGame.UI;
using FarmGame.UI.Parts;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmGame.Scene
{
    class FarmScene : Node
    {
        CommonMenu menu = null;
        Farm farm = null;
        PowerPanel _powerPanel;

        protected override void OnAdded()
        {
            //背景
            var background = new SpriteNode();
            background.Texture = Texture2D.Load("bg_farm.jpg");
            background.Position = new Vector2F(0, 0);
            background.ZOrder = Parameter.ZOrder.BackGround;
            AddChildNode(background);

            var sign = new SpriteNode();
            sign.Texture = Texture2D.Load("farmsign.png");
            sign.Position = new Vector2F(0, 0);
            sign.ZOrder = Parameter.ZOrder.Sign;
            AddChildNode(sign);

            _powerPanel = new PowerPanel();
            _powerPanel.SetPosition(new Vector2F(sign.Texture.Size.X, 0));
            _powerPanel.SetNode(this);
            _powerPanel.UpdateValue();

            MoneyPanel moneyPanel = new MoneyPanel();
            moneyPanel.SetPosition(new Vector2F(sign.Texture.Size.X, _powerPanel.GetHeight()));
            moneyPanel.SetNode(this);
            moneyPanel.SetValue(100);

            WeatherPanel weatherPanel = new WeatherPanel();
            weatherPanel.SetPosition(new Vector2F(sign.Texture.Size.X, _powerPanel.GetHeight() + moneyPanel.GetHeight()));
            weatherPanel.SetNode(this);
            weatherPanel.UpdateValue();

            menu = new CommonMenu(this);

            farm = new Farm();
            farm.SetNode(this);

            var node1 = new SpriteNode();
            node1.Texture = Texture2D.Load("008_b.png");
            float partswidth = node1.ContentSize.X / 3.0f;
            float partsheight = node1.ContentSize.Y / 3.0f;
            node1.Src = new RectF(0, 0, partswidth, partsheight);
            node1.Position = new Vector2F(200, 200);
            node1.ZOrder = Parameter.ZOrder.Alarm;
            AddChildNode(node1);

            var node2 = new SpriteNode();
            node2.Texture = Texture2D.Load("008_b.png");
            node2.Src = new RectF(partswidth, 0, partswidth, partsheight);
            node2.Position = new Vector2F(200 + partswidth, 200);
            node2.ZOrder = Parameter.ZOrder.Alarm;
            AddChildNode(node2);

            var node3 = new SpriteNode();
            node3.Texture = Texture2D.Load("008_b.png");
            node3.Src = new RectF(partswidth * 1, 0, partswidth, partsheight);
            node3.Position = new Vector2F(200 + partswidth * 2, 200);
            node3.ZOrder = Parameter.ZOrder.Alarm;
            AddChildNode(node3);

            var node4 = new SpriteNode();
            node4.Texture = Texture2D.Load("008_b.png");
            node4.Src = new RectF(partswidth * 2, 0, partswidth, partsheight);
            node4.Position = new Vector2F(200 + partswidth * 3, 200);
            node4.ZOrder = Parameter.ZOrder.Alarm;
            AddChildNode(node4);

            var node5 = new SpriteNode();
            node5.Texture = Texture2D.Load("008_b.png");
            node5.Src = new RectF(0, partsheight * 2, partswidth, partsheight);
            node5.Position = new Vector2F(200, 200 + partsheight);
            node5.ZOrder = Parameter.ZOrder.Alarm;
            AddChildNode(node5);

            var node6 = new SpriteNode();
            node6.Texture = Texture2D.Load("008_b.png");
            node6.Src = new RectF(partswidth, partsheight * 2, partswidth, partsheight);
            node6.Position = new Vector2F(200 + partswidth, 200 + partsheight);
            node6.ZOrder = Parameter.ZOrder.Alarm;
            AddChildNode(node6);

            var node7 = new SpriteNode();
            node7.Texture = Texture2D.Load("008_b.png");
            node7.Src = new RectF(partswidth * 1, partsheight * 2, partswidth, partsheight);
            node7.Position = new Vector2F(200 + partswidth * 2, 200 + partsheight);
            node7.ZOrder = Parameter.ZOrder.Alarm;
            AddChildNode(node7);

            var node8 = new SpriteNode();
            node8.Texture = Texture2D.Load("008_b.png");
            node8.Src = new RectF(partswidth * 2, partsheight * 2, partswidth, partsheight);
            node8.Position = new Vector2F(200 + partswidth * 3, 200 + partsheight);
            node8.ZOrder = Parameter.ZOrder.Alarm;
            AddChildNode(node8);

        }

        protected override void OnUpdate()
        {
            var position = Engine.Mouse.Position;

            menu.OnMouse(position);
            farm.OnMouse(position);

            var mouseStatus = Engine.Mouse.GetMouseButtonState(MouseButton.ButtonLeft);
            if (mouseStatus == ButtonState.Push)
            {
                menu.Click(position);
                farm.OnClick(position);
                _powerPanel.UpdateValue();
            }
        }
    }
}
