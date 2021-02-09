using Altseed2;
using FarmGame.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmGame.Scene
{
    class FarmScene : Node
    {
        CommonMenu menu = null;

        protected override void OnAdded()
        {
            //背景
            var background = new SpriteNode();
            background.Texture = Texture2D.Load("bg_farm.jpg");
            background.Position = new Vector2F(0, 0);
            background.ZOrder = 0;
            AddChildNode(background);

            var sign = new SpriteNode();
            sign.Texture = Texture2D.Load("farmsign.png");
            sign.Position = new Vector2F(0, 0);
            sign.ZOrder = 1;
            AddChildNode(sign);

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
