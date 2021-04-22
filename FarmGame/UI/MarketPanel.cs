using Altseed2;
using FarmGame.Model;
using FarmGame.UI.Parts;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmGame.UI
{
    class MarketPanel
    {
        private Node _parentNode;
        private Button _seedButton;
        private Button _foodButton;
        private Button _animalButton;
        private Button _farmButton;
        private WindowBase _shopWindow = null;
        private Dialog _dialogWindow = null;
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
            _parentNode = parentNode;
            _seedButton.SetNode(parentNode);
            _foodButton.SetNode(parentNode);
            _animalButton.SetNode(parentNode);
            _farmButton.SetNode(parentNode);
        }

        public void OnMouse(Vector2F position)
        {
            if(_shopWindow != null &&_shopWindow.IsShow())
            {
                _shopWindow.OnMouse(position);
            }
            else
            {
                _seedButton.Hover(position);
                _foodButton.Hover(position);
                _animalButton.Hover(position);
                _farmButton.Hover(position);
            }
        }

        public void OnClick(Vector2F position)
        {
            if(_dialogWindow != null && _dialogWindow.IsShow)
            {
                _dialogWindow.RemoveNode(_parentNode);
                return;
            }
            if (_shopWindow != null && _shopWindow.IsShow())
            {
                _shopWindow.OnClick(position);
                return;
            }
            if (_seedButton.Click(position))
            {
                _shopWindow = new ShopWindow(GameData.GameStatus.Shoplist.shopList.seed, _parentNode);
                _shopWindow.Show();
                return;
            }
            if(_foodButton.Click(position))
            {
                _shopWindow = new ShopWindow(GameData.GameStatus.Shoplist.shopList.food, _parentNode);
                _shopWindow.Show();
                return;
            }
            if (_animalButton.Click(position))
            {
                _shopWindow = new ShopWindow(GameData.GameStatus.Shoplist.shopList.animal, _parentNode);
                _shopWindow.Show();
                return;
            }
            if( _farmButton.Click(position))
            {
                _shopWindow = new ConfirmWindow(_parentNode,
                    "畑を5つ購入します。\n" +
                    "(10000Ｇ)\n" +
                    "よろしいですか？",
                    () =>
                    {
                        GameData.PlayerData.farms.Add(new Farm());
                        GameData.PlayerData.farms.Add(new Farm());
                        GameData.PlayerData.farms.Add(new Farm());
                        GameData.PlayerData.farms.Add(new Farm());
                        GameData.PlayerData.farms.Add(new Farm());
                        _shopWindow.Hide();
                        _dialogWindow = new Dialog();
                        _dialogWindow.SetNode("畑を購入しました", _parentNode);
                    });
                _shopWindow.Show();
                return;
            }
        }
    }
}
