﻿using Altseed2;
using FarmGame.UI;
using FarmGame.UI.Parts;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmGame.Scene
{
    class RanchScene : Node, IScene
    {
        CommonMenu menu = null;
        MoneyPanel _moneyPanel;
        PowerPanel _powerPanel;
        RanchPanel _ranchPanel;
        public void Update()
        {
        }

        protected override void OnAdded()
        {
            //背景
            var background = new SpriteNode();
            background.Texture = Texture2D.Load("bg_ranch.jpg");
            background.Position = new Vector2F(0, 0);
            background.ZOrder = Common.Parameter.ZOrder.BackGround;
            AddChildNode(background);

            var sign = new SpriteNode();
            sign.Texture = Texture2D.Load("ranchsign.png");
            sign.Position = new Vector2F(0, 0);
            sign.ZOrder = Common.Parameter.ZOrder.Sign;
            AddChildNode(sign);

            _powerPanel = new PowerPanel();
            _powerPanel.SetPosition(new Vector2F(sign.Texture.Size.X, 0));
            _powerPanel.SetNode(this);
            _powerPanel.UpdateValue();

            _moneyPanel = new MoneyPanel();
            _moneyPanel.SetPosition(new Vector2F(sign.Texture.Size.X, _powerPanel.GetHeight()));
            _moneyPanel.SetNode(this);
            _moneyPanel.SetValue(GameData.PlayerData.Money);

            WeatherPanel weatherPanel = new WeatherPanel();
            weatherPanel.SetPosition(new Vector2F(sign.Texture.Size.X, _powerPanel.GetHeight() + _moneyPanel.GetHeight()));
            weatherPanel.SetNode(this);
            weatherPanel.UpdateValue();

            menu = new CommonMenu(this);
            _ranchPanel = new RanchPanel();
            _ranchPanel.SetNode(this);
        }

        int frameCount = 0;
        protected override void OnUpdate()
        {
            if(frameCount > Engine.TargetFPS / 4)
            {
                frameCount = 0;
                _ranchPanel.Animetion();
            }
            frameCount++;
            var position = Engine.Mouse.Position;

            menu.OnMouse(position);

            var mouseStatus = Engine.Mouse.GetMouseButtonState(MouseButton.ButtonLeft);
            if (mouseStatus == ButtonState.Push)
            {
                menu.Click(position, this);
                _powerPanel.UpdateValue();
                _moneyPanel.SetValue(GameData.PlayerData.Money);
            }
        }
    }
}
