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

            FarmIcon icon = new FarmIcon();
            icon.SetPosition(new Vector2F(50, 160));
            icon.SetNode(this);

            PlantWindow window = new PlantWindow();
            window.SetPosition(new Vector2F(50 + 64 + 10, 160 + 16));
            window.SetNode(this);

            Button careButton = new Button(Texture.CareButton, Texture.CareButtonHover, Texture.CareButtonClick);
            careButton.SetPosition(new Vector2F(50 + 64 + 10 + 250, 160 + 16));
            careButton.SetScale(0.6f);
            careButton.SetZOrder(CommonParameter.ZOrder.Farm);
            careButton.SetNode(this);

            Button waterButton = new Button(Texture.WaterButton, Texture.WaterButtonHover, Texture.WaterButtonClick);
            waterButton.SetPosition(new Vector2F(50 + 64 + 10 + 250 + 160, 160 + 16));
            waterButton.SetScale(0.6f);
            waterButton.SetZOrder(CommonParameter.ZOrder.Farm);
            waterButton.SetNode(this);

        }

        protected override void OnUpdate()
        {
            var position = Engine.Mouse.Position;

            menu.OnMouse(position);

            var mouseStatus = Engine.Mouse.GetMouseButtonState(MouseButton.ButtonLeft);
            if (mouseStatus == ButtonState.Push || mouseStatus == ButtonState.Hold)
            {
                menu.Click(position);
            }
        }
    }
}
