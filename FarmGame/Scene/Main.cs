using System;
using System.Collections.Generic;
using System.Text;
using Altseed2;
using FarmGame.UI;
using FarmGame.UI.Parts;

namespace FarmGame.Scene
{
    public class Main : Node
    {
        CommonMenu menu = null;

        protected override void OnAdded()
        {
            //背景
            var background = new RectangleNode();
            background.Color = new Color(255, 255, 255);
            background.Position = new Vector2F(0, 0);
            background.RectangleSize = new Vector2F(960, 720);
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
