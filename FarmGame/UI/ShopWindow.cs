using Altseed2;
using FarmGame.Model;
using FarmGame.UI.Parts;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmGame.UI
{
    class ShopWindow : WindowBase
    {
        Seed[] _seeds = null;
        private List<ShopListButton> shopListButtons = new List<ShopListButton>();
        NumberInputWindow _numberInputWindow = null;

        private const int seedYInterval = 40;

        public ShopWindow(Seed[] seeds, Node parentNode) : base(parentNode)
        {
            _seeds = seeds;
            foreach (var seed in seeds)
            {
                if (GameData.PlayerData.Seed.Length > seed.id)
                {
                    ShopListButton shopListButton = new ShopListButton(Texture.SeedButton, seed.id, seed.money);
                    shopListButtons.Add(shopListButton);
                }
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
                    _numberInputWindow = new NumberInputWindow(_parentNode, shopListButton.Id, shopListButton.Money);
                    _numberInputWindow.Show();
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

