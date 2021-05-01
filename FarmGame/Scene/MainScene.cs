﻿using System;
using System.Collections.Generic;
using System.Text;
using Altseed2;
using FarmGame.UI;
using FarmGame.UI.Parts;

namespace FarmGame.Scene
{
    public class MainScene : Node, IScene
    {
        CommonMenu menu = null;
        PowerPanel _powerPanel;
        MoneyPanel _moneyPanel;
        WeatherPanel _weatherPanel;

        public void Update()
        {
            _powerPanel.UpdateValue();
            _weatherPanel.UpdateValue();
        }

        protected override void OnAdded()
        {
            //背景
            var background = new SpriteNode();
            background.Texture = Texture2D.Load("bg_main.jpg");
            background.Position = new Vector2F(0, 0);
            background.ZOrder = Common.Parameter.ZOrder.BackGround;
            AddChildNode(background);

            var sign = new SpriteNode();
            sign.Texture = Texture2D.Load("homesign.png");
            sign.Position = new Vector2F(0, 0);
            sign.ZOrder = Common.Parameter.ZOrder.Panel;
            AddChildNode(sign);

            _powerPanel = new PowerPanel();
            _powerPanel.SetPosition(new Vector2F(sign.Texture.Size.X, 0));
            _powerPanel.SetNode(this);
            _powerPanel.UpdateValue();

            _moneyPanel = new MoneyPanel();
            _moneyPanel.SetPosition(new Vector2F(sign.Texture.Size.X, _powerPanel.GetHeight()));
            _moneyPanel.SetNode(this);
            _moneyPanel.SetValue(GameData.PlayerData.Money);

            _weatherPanel = new WeatherPanel();
            _weatherPanel.SetPosition(new Vector2F(sign.Texture.Size.X, _powerPanel.GetHeight() + _moneyPanel.GetHeight()));
            _weatherPanel.SetNode(this);
            _weatherPanel.UpdateValue();

            menu = new CommonMenu(this);
        }

        protected override void OnUpdate()
        {
            var position = Engine.Mouse.Position;

            menu.OnMouse(position);

            var mouseStatus = Engine.Mouse.GetMouseButtonState(MouseButton.ButtonLeft);
            if (mouseStatus == ButtonState.Push)
            {
                menu.Click(position, this);
            }
        }
    }
}
