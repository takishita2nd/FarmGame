using System;
using System.Collections.Generic;
using System.Text;
using Altseed2;
using FarmGame.UI.Parts;

namespace FarmGame.Scene
{
    public class Main : Node
    {
        private Button farmButton = null;

        protected override void OnAdded()
        {
            //背景
            var background = new RectangleNode();
            background.Color = new Color(255, 255, 255);
            background.Position = new Vector2F(0, 0);
            background.RectangleSize = new Vector2F(960, 720);
            background.ZOrder = 0;
            AddChildNode(background);

            float scale = (CommonParameter.WindowWidth / 6.0f) / Texture.FarmButton.Size.X;
            var buttonYPosition = CommonParameter.WindowHeight - Texture.FarmButton.Size.Y * scale;
            float buttonXPosition = 0.0f;
            var xInterval = Texture.FarmButton.Size.X * scale;

            // 農場ボタン
            farmButton = new Button(Texture.FarmButton, Texture.FarmButtonHover, Texture.FarmButtonClick);
            farmButton.SetZOrder(1);
            farmButton.SetPosition(new Vector2F(buttonXPosition, buttonYPosition));
            farmButton.SetScale(scale);
            farmButton.SetNode(this);

            // 牧場ボタン
            buttonXPosition += xInterval;
            var ranchButton = new SpriteNode();
            ranchButton.Texture = Texture.RanchButton;
            ranchButton.ZOrder = 1;
            ranchButton.Position = new Vector2F(buttonXPosition, buttonYPosition);
            ranchButton.Scale = new Vector2F(scale, scale);
            AddChildNode(ranchButton);

            // 市場ボタン
            buttonXPosition += xInterval;
            var marketButton = new SpriteNode();
            marketButton.Texture = Texture.MarketButton;
            marketButton.ZOrder = 1;
            marketButton.Position = new Vector2F(buttonXPosition, buttonYPosition);
            marketButton.Scale = new Vector2F(scale, scale);
            AddChildNode(marketButton);

            // 工房ボタン
            buttonXPosition += xInterval;
            var studioButton = new SpriteNode();
            studioButton.Texture = Texture.StudioButton;
            studioButton.ZOrder = 1;
            studioButton.Position = new Vector2F(buttonXPosition, buttonYPosition);
            studioButton.Scale = new Vector2F(scale, scale);
            AddChildNode(studioButton);

            // お店ボタン
            buttonXPosition += xInterval;
            var shopButton = new SpriteNode();
            shopButton.Texture = Texture.ShopButton;
            shopButton.ZOrder = 1;
            shopButton.Position = new Vector2F(buttonXPosition, buttonYPosition);
            shopButton.Scale = new Vector2F(scale, scale);
            AddChildNode(shopButton);

            // 能力ボタン
            buttonXPosition += xInterval;
            var statusButton = new SpriteNode();
            statusButton.Texture = Texture.StatusButton;
            statusButton.ZOrder = 1;
            statusButton.Position = new Vector2F(buttonXPosition, buttonYPosition);
            statusButton.Scale = new Vector2F(scale, scale);
            AddChildNode(statusButton);
        }

        protected override void OnUpdate()
        {
            var position = Engine.Mouse.Position;

            farmButton.Hover(position);

            var mouseStatus = Engine.Mouse.GetMouseButtonState(MouseButton.ButtonLeft);
            if (mouseStatus == ButtonState.Push || mouseStatus == ButtonState.Hold)
            {
                farmButton.Click(position);
            }
        }
    }
}
