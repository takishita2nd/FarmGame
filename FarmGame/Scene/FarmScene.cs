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

        protected override void OnAdded()
        {
            //背景
            var background = new SpriteNode();
            background.Texture = Texture2D.Load("bg_farm.jpg");
            background.Position = new Vector2F(0, 0);
            background.ZOrder = CommonParameter.ZOrder.BackGround;
            AddChildNode(background);

            var sign = new SpriteNode();
            sign.Texture = Texture2D.Load("farmsign.png");
            sign.Position = new Vector2F(0, 0);
            sign.ZOrder = CommonParameter.ZOrder.Sign;
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

            farm = new Farm();
            farm.SetNode(this);

            var window = new SpriteNode();
            window.Texture = Texture2D.Load("284244.png");
            window.Src = new RectF(0, 680, 900, 220);
            window.Scale = new Vector2F(1.0f, 1.5f);
            window.Position = new Vector2F(0, 170);
            window.ZOrder = CommonParameter.ZOrder.Dialog;
            AddChildNode(window);

            var seed = new SpriteNode();
            seed.Texture = Texture2D.Load("100x25_bl.png");
            seed.Scale = new Vector2F(2.0f, 2.0f);
            seed.Position = new Vector2F(30, 190);
            seed.ZOrder = CommonParameter.ZOrder.Seed;
            AddChildNode(seed);

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
            }
        }
    }
}
