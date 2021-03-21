﻿using Altseed2;
using FarmGame.UI.Parts;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmGame.UI
{
    class MarketPanel
    {
        private Button _seedButton;
        private Button _foodButton;
        private Button _animalButton;
        private Button _farmButton;

        public MarketPanel()
        {
            _seedButton = new Button(Texture.MarketSeedButton, Texture.MarketSeedButtonHover, Texture.MarketSeedButtonClick);
            _seedButton.SetPosition(new Vector2F(200, 200));
            _seedButton.SetZOrder(Common.Parameter.ZOrder.Panel);

            _foodButton = new Button(Texture.MarketFoodButton, Texture.MarketFoodButtonHover, Texture.MarketFoodButtonClick);
            _foodButton.SetPosition(new Vector2F(200, 400));
            _foodButton.SetZOrder(Common.Parameter.ZOrder.Panel);

            _animalButton = new Button(Texture.MarketAnimalButton, Texture.MarketAnimalButtonHover, Texture.MarketAnimalButtonClick);
            _animalButton.SetPosition(new Vector2F(500, 200));
            _animalButton.SetZOrder(Common.Parameter.ZOrder.Panel);

            _farmButton = new Button(Texture.MarketFarmButton, Texture.MarketFarmButtonHover, Texture.MarketFarmButtonClick);
            _farmButton.SetPosition(new Vector2F(500, 400));
            _farmButton.SetZOrder(Common.Parameter.ZOrder.Panel);
        }

        public void SetNode(Node parentNode)
        {
            _seedButton.SetNode(parentNode);
            _foodButton.SetNode(parentNode);
            _animalButton.SetNode(parentNode);
            _farmButton.SetNode(parentNode);
        }

        public void OnMouse(Vector2F position)
        {
            _seedButton.Hover(position);
            _foodButton.Hover(position);
            _animalButton.Hover(position);
            _farmButton.Hover(position);
        }

        public void OnClick(Vector2F position)
        {
            _seedButton.Click(position);
            _foodButton.Click(position);
            _animalButton.Click(position);
            _farmButton.Click(position);
        }
    }
}
