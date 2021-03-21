using Altseed2;
using FarmGame.UI;
using FarmGame.UI.Parts;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmGame.Scene
{
    class MarketScene : Node, IScene
    {
        CommonMenu menu = null;
        MarketPanel panel = null;

        public void Update()
        {
        }

        protected override void OnAdded()
        {
            //背景
            var background = new SpriteNode();
            background.Texture = Texture2D.Load("bg_market.jpg");
            background.Position = new Vector2F(0, 0);
            background.ZOrder = Common.Parameter.ZOrder.BackGround;
            AddChildNode(background);

            var sign = new SpriteNode();
            sign.Texture = Texture2D.Load("marketsign.png");
            sign.Position = new Vector2F(0, 0);
            sign.ZOrder = Common.Parameter.ZOrder.Sign;
            AddChildNode(sign);

            PowerPanel powerPanel = new PowerPanel();
            powerPanel.SetPosition(new Vector2F(sign.Texture.Size.X, 0));
            powerPanel.SetNode(this);
            powerPanel.UpdateValue();

            MoneyPanel moneyPanel = new MoneyPanel();
            moneyPanel.SetPosition(new Vector2F(sign.Texture.Size.X, powerPanel.GetHeight()));
            moneyPanel.SetNode(this);
            moneyPanel.SetValue(100);

            WeatherPanel weatherPanel = new WeatherPanel();
            weatherPanel.SetPosition(new Vector2F(sign.Texture.Size.X, powerPanel.GetHeight() + moneyPanel.GetHeight()));
            weatherPanel.SetNode(this);
            weatherPanel.UpdateValue();

            menu = new CommonMenu(this);
            panel = new MarketPanel();
            panel.SetNode(this);
        }

        protected override void OnUpdate()
        {
            var position = Engine.Mouse.Position;

            menu.OnMouse(position);
            panel.OnMouse(position);

            var mouseStatus = Engine.Mouse.GetMouseButtonState(MouseButton.ButtonLeft);
            if (mouseStatus == ButtonState.Push)
            {
                menu.Click(position, this);
                panel.OnClick(position);
            }
        }
    }
}
