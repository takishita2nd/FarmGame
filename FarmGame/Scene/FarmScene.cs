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

            menu = new CommonMenu(this);
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
