using System;
using System.Collections.Generic;
using System.Text;
using Altseed2;

namespace FarmGame.Scene
{
    public class Main : Node
    {
        protected override void OnAdded()
        {
            //背景
            var background = new RectangleNode();
            background.Color = new Color(255, 255, 255);
            background.Position = new Vector2F(0, 0);
            background.RectangleSize = new Vector2F(960, 720);
            background.ZOrder = 0;
            AddChildNode(background);

            float scale = (CommonParameter.WindowWidth / 6.0f) / Texture.TextureButton.Size.X;
            var buttonYPosition = CommonParameter.WindowHeight - Texture.TextureButton.Size.Y * scale;
            float buttonXPosition = 0.0f;
            var xInterval = Texture.TextureButton.Size.X * scale;

            // 農場ボタン
            var farmButton = new SpriteNode();
            farmButton.Texture = Texture.TextureButton;
            farmButton.ZOrder = 1;
            farmButton.Position = new Vector2F(buttonXPosition, buttonYPosition);
            farmButton.Scale = new Vector2F(scale, scale);
            AddChildNode(farmButton);

            var announce = new TextNode();
            announce.Font = Font.LoadDynamicFontStrict("HachiMaruPop-Regular.ttf", 50);
            announce.Text = "農場";
            announce.Color = new Color(0, 0, 0);
            announce.CenterPosition = announce.ContentSize / 2;
            announce.Position = new Vector2F(farmButton.Position.X + announce.CenterPosition.X + 45, farmButton.Position.Y + announce.CenterPosition.Y - 5);
            announce.ZOrder = 2;
            AddChildNode(announce);

            // 牧場ボタン
            buttonXPosition += xInterval;
            var ranchButton = new SpriteNode();
            ranchButton.Texture = Texture.TextureButton;
            ranchButton.ZOrder = 1;
            ranchButton.Position = new Vector2F(buttonXPosition, buttonYPosition);
            ranchButton.Scale = new Vector2F(scale, scale);
            AddChildNode(ranchButton);

            // 市場ボタン
            buttonXPosition += xInterval;
            var marketButton = new SpriteNode();
            marketButton.Texture = Texture.TextureButton;
            marketButton.ZOrder = 1;
            marketButton.Position = new Vector2F(buttonXPosition, buttonYPosition);
            marketButton.Scale = new Vector2F(scale, scale);
            AddChildNode(marketButton);

            // 工房ボタン
            buttonXPosition += xInterval;
            var studioButton = new SpriteNode();
            studioButton.Texture = Texture.TextureButton;
            studioButton.ZOrder = 1;
            studioButton.Position = new Vector2F(buttonXPosition, buttonYPosition);
            studioButton.Scale = new Vector2F(scale, scale);
            AddChildNode(studioButton);

            // お店ボタン
            buttonXPosition += xInterval;
            var shopButton = new SpriteNode();
            shopButton.Texture = Texture.TextureButton;
            shopButton.ZOrder = 1;
            shopButton.Position = new Vector2F(buttonXPosition, buttonYPosition);
            shopButton.Scale = new Vector2F(scale, scale);
            AddChildNode(shopButton);

            // 能力ボタン
            buttonXPosition += xInterval;
            var statusButton = new SpriteNode();
            statusButton.Texture = Texture.TextureButton;
            statusButton.ZOrder = 1;
            statusButton.Position = new Vector2F(buttonXPosition, buttonYPosition);
            statusButton.Scale = new Vector2F(scale, scale);
            AddChildNode(statusButton);
        }

        protected override void OnUpdate()
        {

        }
    }
}
