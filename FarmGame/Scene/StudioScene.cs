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

        public void Update()
        {
            throw new NotImplementedException();
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
            panel = new StudioPanel();
            panel.SetNode(this);
            panel.DisplayUpdate();

            var _node = new SpriteNode();
            _node.Texture = Texture.SeedWindow;
            _node.Src = new RectF(0, 680, 900, 220);
            _node.Position = new Vector2F(0, 170);
            _node.Scale = new Vector2F(1.0f, 1.5f);
            _node.ZOrder = Common.Parameter.ZOrder.Dialog;
            AddChildNode(_node);

            float buttonScale = 0.6f;
            var _okButton = new Button(Texture.OKButton, Texture.OKButtonHover, Texture.OKButtonClick);
            _okButton.SetPosition(new Vector2F(230, 410));
            _okButton.SetScale(buttonScale);
            _okButton.SetZOrder(Common.Parameter.ZOrder.Seed);
            _okButton.SetNode(this);
            var _cancelButton = new Button(Texture.CancelButton, Texture.CancelButtonHover, Texture.CancelButtonClick);
            _cancelButton.SetPosition(new Vector2F(430, 410));
            _cancelButton.SetScale(buttonScale);
            _cancelButton.SetZOrder(Common.Parameter.ZOrder.Seed);
            _cancelButton.SetNode(this);
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
