using Altseed2;
using FarmGame.Common;
using FarmGame.Model;
using FarmGame.UI.Parts;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmGame.UI
{
    class ShopWindow : WindowBase
    {
        private List<ShopListButton> shopListButtons = new List<ShopListButton>();
        NumberInputWindow _numberInputWindow = null;
        ConfirmWindow _confirmWindow = null;
        Dialog _dialog = null;

        private const int seedYInterval = 40;
        private const int seedXInterval = 320;
        private const int seedIndex = 5;

        public ShopWindow(Seed[] seeds, Node parentNode) : base(parentNode)
        {
            foreach (var seed in seeds)
            {
                if (GameData.PlayerData.Seed.Length > seed.id)
                {
                    ShopListButton shopListButton = new ShopListButton(Texture.SeedButton, seed.id, seed.money, ShopListButton.Type.Seed);
                    shopListButtons.Add(shopListButton);
                }
            }
        }

        public ShopWindow(Animal[] animals, Node parentNode) : base(parentNode)
        {
            foreach (var animal in animals)
            {
                ShopListButton shopListButton = new ShopListButton(Texture.SeedButton, animal.id, animal.money, ShopListButton.Type.Animal);
                shopListButtons.Add(shopListButton);
            }
        }

        public ShopWindow(Food[] foods, Node parentNode) : base(parentNode)
        {
            foreach (var food in foods)
            {
                ShopListButton shopListButton = new ShopListButton(Texture.SeedButton, food.id, food.money, Function.String2Quolity(food.quolity));
                shopListButtons.Add(shopListButton);
            }
        }

        /**
         * <summary>ウィンドウ表示</summary>
         * */
        override public void Show()
        {
            base.Show();
            int index = 0;
            foreach (var shopListButton in shopListButtons)
            {
                if(index < seedIndex)
                {
                    shopListButton.SetPosition(new Vector2F(30, 190 + seedYInterval * index));
                }
                else
                {
                    shopListButton.SetPosition(new Vector2F(30 + seedXInterval, 190 + seedYInterval * (index - seedIndex)));
                }
                shopListButton.SetNode(_parentNode);
                index++;
            }
        }

        /**
         * <summary>ウィンドウを閉じる</summary>
         * */
        override public void Hide()
        {
            base.Hide();
            foreach (var shopListButton in shopListButtons)
            {
                shopListButton.RemoveNode(_parentNode);
            }

        }

        public override void OnMouse(Vector2F position)
        {
            if(_dialog != null && _dialog.IsShow)
            {
                return;
            }
            if(_numberInputWindow != null && _numberInputWindow.IsShow())
            {
                _numberInputWindow.OnMouse(position);
                return;
            }
            if (_confirmWindow != null && _confirmWindow.IsShow())
            {
                _confirmWindow.OnMouse(position);
                return;
            }
            base.OnMouse(position);
        }

        /**
         * <summary>クリック処理</summary>
         * */
        public override void OnClick(Vector2F position)
        {
            if (_dialog != null && _dialog.IsShow)
            {
                _dialog.RemoveNode(_parentNode);
                return;
            }
            if (_numberInputWindow != null && _numberInputWindow.IsShow())
            {
                _numberInputWindow.OnClick(position);
                return;
            }
            if (_confirmWindow != null && _confirmWindow.IsShow())
            {
                _confirmWindow.OnClick(position);
                return;
            }

            foreach (var shopListButton in shopListButtons)
            {
                if(shopListButton.IsClick(position))
                {
                    if(shopListButton.type == ShopListButton.Type.Seed)
                    {
                        _numberInputWindow = new NumberInputWindow(_parentNode, shopListButton.Id, shopListButton.Money);
                        _numberInputWindow.Show();
                    }
                    else if(shopListButton.type == ShopListButton.Type.Food)
                    {
                        _numberInputWindow = new NumberInputWindow(_parentNode, shopListButton.Id, shopListButton.Money, shopListButton.Quality);
                        _numberInputWindow.Show();
                    }
                    else if(shopListButton.type == ShopListButton.Type.Animal)
                    {
                        if(GameData.PlayerData.Money >= shopListButton.Money)
                        {
                            _confirmWindow = new ConfirmWindow(_parentNode,
                                Function.SearchItemById(shopListButton.Id).name + "を購入しますか？\n" +
                                "(" + shopListButton.Money.ToString() + "Ｇ)",
                                () => {
                                    _dialog = new Dialog();
                                    _dialog.SetNode(
                                        Function.SearchItemById(shopListButton.Id).name + "を購入しました",
                                        _parentNode);
                                    //お金を払う
                                    GameData.PlayerData.Money -= shopListButton.Money;
                                    //動物の追加
                                    GameData.PlayerData.ranches.Add(new Ranch() { id = shopListButton.Id, growth = 0, quality = 0 });
                                    _confirmWindow.Hide();
                                });
                            _confirmWindow.Show();
                        }
                        else
                        {
                            _dialog = new Dialog();
                            _dialog.SetNode("お金が足りません。", _parentNode);
                        }
                    }
                    return;
                }
            }

            //キャンセルボタン押下
            if (_cancelButton.IsClick(position))
            {
                Hide();
            }
        }
    }
}

