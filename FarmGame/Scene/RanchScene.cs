using Altseed2;
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

        public void Update()
        {
            throw new NotImplementedException();
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

            PowerPanel powerPanel = new PowerPanel();
            powerPanel.SetPosition(new Vector2F(sign.Texture.Size.X, 0));
            powerPanel.SetNode(this);
            powerPanel.UpdateValue();

            _moneyPanel = new MoneyPanel();
            _moneyPanel.SetPosition(new Vector2F(sign.Texture.Size.X, powerPanel.GetHeight()));
            _moneyPanel.SetNode(this);
            _moneyPanel.SetValue(100);

            WeatherPanel weatherPanel = new WeatherPanel();
            weatherPanel.SetPosition(new Vector2F(sign.Texture.Size.X, powerPanel.GetHeight() + _moneyPanel.GetHeight()));
            weatherPanel.SetNode(this);
            weatherPanel.UpdateValue();

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
