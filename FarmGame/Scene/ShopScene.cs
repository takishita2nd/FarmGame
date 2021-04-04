using Altseed2;
using FarmGame.UI;
using FarmGame.UI.Parts;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmGame.Scene
{
    class ShopScene : Node, IScene
    {
        private CommonMenu menu = null;
        private ShopPanel shop = null;
        PowerPanel _powerPanel;
        MoneyPanel _moneyPanel;

        public void Update()
        {
            _moneyPanel.SetValue(GameData.PlayerData.Money);
            shop.RequestUpdate();
        }

        protected override void OnAdded()
        {
            //背景
            var background = new SpriteNode();
            background.Texture = Texture2D.Load("bg_shop.jpg");
            background.Position = new Vector2F(0, 0);
            background.ZOrder = Common.Parameter.ZOrder.BackGround;
            AddChildNode(background);

            var sign = new SpriteNode();
            sign.Texture = Texture2D.Load("shopsign.png");
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
            shop = new ShopPanel();
            shop.SetNode(this);
        }

        protected override void OnUpdate()
        {
            var position = Engine.Mouse.Position;

            menu.OnMouse(position);
            shop.OnMouse(position);

            var mouseStatus = Engine.Mouse.GetMouseButtonState(MouseButton.ButtonLeft);
            if (mouseStatus == ButtonState.Push)
            {
                menu.Click(position, this);
                shop.OnClick(position);
                _powerPanel.UpdateValue();
                _moneyPanel.SetValue(GameData.PlayerData.Money);
            }
        }
    }
}
