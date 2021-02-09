using System;
using System.Collections.Generic;
using System.Text;
using Altseed2;
using FarmGame.UI;
using FarmGame.UI.Parts;

namespace FarmGame.Scene
{
    public class MainScene : Node
    {
        CommonMenu menu = null;

        protected override void OnAdded()
        {
            //背景
            var background = new SpriteNode();
            background.Texture = Texture2D.Load("bg_main.jpg");
            background.Position = new Vector2F(0, 0);
            background.ZOrder = 0;
            AddChildNode(background);

            var sign = new SpriteNode();
            sign.Texture = Texture2D.Load("homesign.png");
            sign.Position = new Vector2F(0, 0);
            sign.ZOrder = 1;
            AddChildNode(sign);

            var statusHp = new SpriteNode();
            statusHp.Texture = Texture2D.Load("parameter.png");
            statusHp.Position = new Vector2F(sign.Texture.Size.X, 0);
            statusHp.ZOrder = 1;
            AddChildNode(statusHp);

            var statusMoney = new SpriteNode();
            statusMoney.Texture = Texture2D.Load("parameter.png");
            statusMoney.Position = new Vector2F(sign.Texture.Size.X, statusHp.Texture.Size.Y);
            statusMoney.ZOrder = 1;
            AddChildNode(statusMoney);

            var weather = new SpriteNode();
            weather.Texture = Texture2D.Load("parameter.png");
            weather.Position = new Vector2F(sign.Texture.Size.X, statusHp.Texture.Size.Y + statusMoney.Texture.Size.Y);
            weather.ZOrder = 1;
            AddChildNode(weather);

            menu = new CommonMenu(this);

            var home = new SpriteNode();
            home.Texture = Texture2D.Load("homebutton.png");
            home.Position = new Vector2F(CommonParameter.WindowWidth - home.Texture.Size.X, menu.GetYPosition() - home.Texture.Size.Y);
            home.ZOrder = 1;
            AddChildNode(home);

            var next = new SpriteNode();
            next.Texture = Texture2D.Load("nextbutton.png");
            next.Position = new Vector2F(CommonParameter.WindowWidth - home.Texture.Size.X, menu.GetYPosition() - home.Texture.Size.Y - next.Texture.Size.Y);
            next.ZOrder = 1;
            AddChildNode(next);
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
