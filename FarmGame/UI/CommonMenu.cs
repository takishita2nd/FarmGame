using System;
using System.Collections.Generic;
using System.Text;
using Altseed2;
using FarmGame.Scene;
using FarmGame.UI.Parts;

namespace FarmGame.UI
{
    class CommonMenu
    {
        private Button farmButton = null;
        private Button ranchButton = null;
        private Button marketButton = null;
        private Button studioButton = null;
        private Button shopButton = null;
        private Button statusButton = null;
        private Button homeButton = null;
        private Button nextButton = null;
        private Node node = null;
        private float buttonYPosition;

        public CommonMenu(Node parentNode)
        {
            node = parentNode;

            float scale = (Parameter.WindowWidth / 6.0f) / Texture.FarmButton.Size.X;
            buttonYPosition = Parameter.WindowHeight - Texture.FarmButton.Size.Y * scale;
            float buttonXPosition = 0.0f;
            var xInterval = Texture.FarmButton.Size.X * scale;

            // 農場ボタン
            farmButton = new Button(Texture.FarmButton, Texture.FarmButtonHover, Texture.FarmButtonClick);
            farmButton.SetZOrder(1);
            farmButton.SetPosition(new Vector2F(buttonXPosition, buttonYPosition));
            farmButton.SetScale(scale);
            farmButton.SetNode(parentNode);

            // 牧場ボタン
            buttonXPosition += xInterval;
            ranchButton = new Button(Texture.RanchButton, Texture.RanchButtonHover, Texture.RanchButtonClick);
            ranchButton.SetZOrder(1);
            ranchButton.SetPosition(new Vector2F(buttonXPosition, buttonYPosition));
            ranchButton.SetScale(scale);
            ranchButton.SetNode(parentNode);

            // 市場ボタン
            buttonXPosition += xInterval;
            marketButton = new Button(Texture.MarketButton, Texture.MarketButtonHover, Texture.MarketButtonClick);
            marketButton.SetZOrder(1);
            marketButton.SetPosition(new Vector2F(buttonXPosition, buttonYPosition));
            marketButton.SetScale(scale);
            marketButton.SetNode(parentNode);

            // 工房ボタン
            buttonXPosition += xInterval;
            studioButton = new Button(Texture.StudioButton, Texture.StudioButtonHover, Texture.StudioButtonClick);
            studioButton.SetZOrder(1);
            studioButton.SetPosition(new Vector2F(buttonXPosition, buttonYPosition));
            studioButton.SetScale(scale);
            studioButton.SetNode(parentNode);

            // お店ボタン
            buttonXPosition += xInterval;
            shopButton = new Button(Texture.ShopButton, Texture.ShopButtonHover, Texture.ShopButtonClick);
            shopButton.SetZOrder(1);
            shopButton.SetPosition(new Vector2F(buttonXPosition, buttonYPosition));
            shopButton.SetScale(scale);
            shopButton.SetNode(parentNode);

            // 能力ボタン
            buttonXPosition += xInterval;
            statusButton = new Button(Texture.StatusButton, Texture.StatusButtonHover, Texture.StatusButtonClick);
            statusButton.SetZOrder(1);
            statusButton.SetPosition(new Vector2F(buttonXPosition, buttonYPosition));
            statusButton.SetScale(scale);
            statusButton.SetNode(parentNode);

            //ホームボタン
            homeButton = new Button(Texture.HomeButton, Texture.HomeButton, Texture.HomeButton);
            homeButton.SetZOrder(1);
            homeButton.SetPosition(new Vector2F(Parameter.WindowWidth - Texture.HomeButton.Size.X, buttonYPosition - Texture.HomeButton.Size.Y));
            homeButton.SetNode(parentNode);

            //次へボタン
            nextButton = new Button(Texture.NextButton, Texture.NextButton, Texture.NextButton);
            nextButton.SetZOrder(1);
            nextButton.SetPosition(new Vector2F(Parameter.WindowWidth - Texture.HomeButton.Size.X, buttonYPosition - Texture.HomeButton.Size.Y - Texture.NextButton.Size.Y));
            nextButton.SetNode(parentNode);

        }

        public float GetYPosition()
        {
            return buttonYPosition;
        }

        public void OnMouse(Vector2F position)
        {
            farmButton.Hover(position);
            ranchButton.Hover(position);
            marketButton.Hover(position);
            studioButton.Hover(position);
            shopButton.Hover(position);
            statusButton.Hover(position);
        }

        public void Click(Vector2F position, IScene scene)
        {
            if(farmButton.Click(position))
            {
                Engine.RemoveNode(node);
                node = new FarmScene();
                Engine.AddNode(node);
            }
            if (ranchButton.Click(position))
            {
                Engine.RemoveNode(node);
                node = new RanchScene();
                Engine.AddNode(node);
            }
            if (marketButton.Click(position))
            {
                Engine.RemoveNode(node);
                node = new MarketScene();
                Engine.AddNode(node);
            }
            if (studioButton.Click(position))
            {
                Engine.RemoveNode(node);
                node = new StudioScene();
                Engine.AddNode(node);
            }
            if (shopButton.Click(position))
            {
                Engine.RemoveNode(node);
                node = new ShopScene();
                Engine.AddNode(node);
            }
            if (statusButton.Click(position))
            {
                Engine.RemoveNode(node);
                node = new StatusScene();
                Engine.AddNode(node);
            }
            if (homeButton.Click(position))
            {
                Engine.RemoveNode(node);
                node = new MainScene();
                Engine.AddNode(node);
            }
            if (nextButton.Click(position))
            {
                Process.Process.Run(scene);
            }
        }
    }
}
