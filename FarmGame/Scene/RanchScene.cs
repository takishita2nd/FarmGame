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
        PowerPanel _powerPanel;

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

            float scale = (Common.Parameter.WindowWidth / 6.0f) / Texture.FarmButton.Size.X;

            SpriteNode node1 = new SpriteNode();
            node1.Texture = Texture2D.Load("chip23a_forest_fall.png");
            int xsize = (int)(node1.ContentSize.X / 29);
            int ysize = (int)(node1.ContentSize.Y / 16);
            node1.Src = new RectF(25 * xsize, 7 * ysize, xsize, ysize);
            node1.Scale = new Vector2F(3.8f, 3.8f);
            node1.Position = new Vector2F(60, 190);
            node1.ZOrder = Common.Parameter.ZOrder.Ranch;
            AddChildNode(node1);

            SpriteNode node2 = new SpriteNode();
            node2.Texture = Texture2D.Load("300x35_bl.png");
            node2.Position = new Vector2F(5 + 60 + xsize * 3.8f, 5 + 190);
            node2.Scale = new Vector2F(1.5f, 1.5f);
            node2.ZOrder = Common.Parameter.ZOrder.Ranch;
            AddChildNode(node2);

            SpriteNode node3 = new SpriteNode();
            node3.Texture = Texture.CareButton;
            node3.Position = new Vector2F(5 + 60 + xsize * 3.8f + node2.ContentSize.X * 1.5f, 190);
            node3.Scale = new Vector2F(scale, scale);
            node3.ZOrder = Common.Parameter.ZOrder.Ranch;
            AddChildNode(node3);
        }

        protected override void OnUpdate()
        {
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
