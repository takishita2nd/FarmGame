﻿using Altseed2;
using FarmGame.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmGame.Scene
{
    class StudioScene : Node
    {
        CommonMenu menu = null;

        protected override void OnAdded()
        {
            //背景
            var background = new SpriteNode();
            background.Texture = Texture2D.Load("bg_studio.jpg");
            background.Position = new Vector2F(0, 0);
            background.ZOrder = 0;
            AddChildNode(background);

            var sign = new SpriteNode();
            sign.Texture = Texture2D.Load("studiosign.png");
            sign.Position = new Vector2F(0, 0);
            sign.ZOrder = 1;
            AddChildNode(sign);

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
