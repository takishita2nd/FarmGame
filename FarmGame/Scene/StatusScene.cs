﻿using System;
using System.Collections.Generic;
using System.Text;
using Altseed2;
using FarmGame.UI;
using FarmGame.UI.Parts;

namespace FarmGame.Scene
{
    public class StatusScene : Node
    {
        CommonMenu menu = null;

        protected override void OnAdded()
        {
            //背景
            var background = new SpriteNode();
            background.Texture = Texture2D.Load("bg_main.jpg");
            background.Position = new Vector2F(0, 0);
            background.ZOrder = CommonParameter.ZOrder.BackGround;
            AddChildNode(background);

            var sign = new SpriteNode();
            sign.Texture = Texture2D.Load("statussign.png");
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