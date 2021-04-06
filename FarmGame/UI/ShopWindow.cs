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

        private const int seedYInterval = 40;

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
                ShopListButton shopListButton = new ShopListButton(Texture.SeedButton, animal.id, animal.money, ShopListButton.Type.Animal); ;
                shopListButtons.Add(shopListButton);
            }
        }

        /**
         * <summary>ウィンドウ表示</summary>
         * */
        new public void Show()
        {
            base.Show();
            int index = 0;
            foreach (var shopListButton in shopListButtons)
            {
                shopListButton.SetPosition(new Vector2F(30, 190 + seedYInterval * index));
                shopListButton.SetNode(_parentNode);
                index++;
            }
        }

        /**
         * <summary>ウィンドウを閉じる</summary>
         * */
        new public void Hide()
        {
            base.Hide();
            foreach (var shopListButton in shopListButtons)
            {
                shopListButton.RemoveNode(_parentNode);
            }

        }

        public override void OnMouse(Vector2F position)
        {
            if(_numberInputWindow != null && _numberInputWindow.IsShow())
            {
                _numberInputWindow.OnMouse(position);
                return;
            }
            base.OnMouse(position);
        }

        /**
         * <summary>クリック処理</summary>
         * */
        public override void OnClick(Vector2F position)
        {
            if (_numberInputWindow != null && _numberInputWindow.IsShow())
            {
                _numberInputWindow.OnClick(position);
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
                    else
                    {
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

