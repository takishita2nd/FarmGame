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
            background.ZOrder = Parameter.ZOrder.BackGround;
            AddChildNode(background);

            var sign = new SpriteNode();
            sign.Texture = Texture2D.Load("studiosign.png");
            sign.Position = new Vector2F(0, 0);
            sign.ZOrder = Parameter.ZOrder.Sign;
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

            int xpos = 50;
            int ypos = 170;
            int xinterval = 320;
            int yinterval = 50;
            SpriteNode[,] bottun = new SpriteNode[2,7];
            for(int j = 0; j < 2; j++)
            {
                for (int i = 0; i < 7; i++)
                {
                    bottun[j,i] = new SpriteNode();
                    bottun[j,i].Texture = Texture.ItemButton;
                    bottun[j,i].Position = new Vector2F(xpos + xinterval * j, ypos + yinterval * i);
                    bottun[j,i].ZOrder = Parameter.ZOrder.Item;
                    AddChildNode(bottun[j,i]);
                }
            }
            float careButtonScale = 0.6f;
            var _prevPageButton = new Button(Texture.PrevPageButton, Texture.PrevPageButtonHover, Texture.PrevPageButtonClick);
            _prevPageButton.SetPosition(new Vector2F(374, 520));
            _prevPageButton.SetScale(careButtonScale);
            _prevPageButton.SetZOrder(Parameter.ZOrder.Item);
            _prevPageButton.SetNode(this);

            var _nextPageButton = new Button(Texture.NextPageButton, Texture.NextPageButtonHover, Texture.NextPageButtonClick);
            _nextPageButton.SetPosition(new Vector2F(534, 520));
            _nextPageButton.SetScale(careButtonScale);
            _nextPageButton.SetZOrder(Parameter.ZOrder.Item);
            _nextPageButton.SetNode(this);
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
