using Altseed2;
using FarmGame.UI;
using FarmGame.UI.Parts;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmGame.Scene
{
    class StudioScene : Node, IScene
    {
        CommonMenu menu = null;
        StudioPanel panel = null;
        PowerPanel _powerPanel;
        MoneyPanel _moneyPanel;

        public void Update()
        {
        }

        protected override void OnAdded()
        {
            //背景
            var background = new SpriteNode();
            background.Texture = Texture2D.Load("bg_studio.jpg");
            background.Position = new Vector2F(0, 0);
            background.ZOrder = Common.Parameter.ZOrder.BackGround;
            AddChildNode(background);

            var sign = new SpriteNode();
            sign.Texture = Texture2D.Load("studiosign.png");
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
            panel = new StudioPanel();
            panel.SetNode(this);
            panel.DisplayUpdate();
        }

        protected override void OnUpdate()
        {
            var position = Engine.Mouse.Position;

            panel.OnMouse(position);
            menu.OnMouse(position);

            var mouseStatus = Engine.Mouse.GetMouseButtonState(MouseButton.ButtonLeft);
            if (mouseStatus == ButtonState.Push)
            {
                panel.OnClick(position);
                menu.Click(position, this);
                _powerPanel.UpdateValue();
                _moneyPanel.SetValue(GameData.PlayerData.Money);
            }
        }
    }
}
