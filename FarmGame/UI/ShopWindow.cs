using Altseed2;
using FarmGame.UI.Parts;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmGame.UI
{
    class ShopWindow : WindowBase
    {
        public ShopWindow(Node parentNode) : base(parentNode)
        {

        }

        /**
         * <summary>ウィンドウ表示</summary>
         * */
        new public void Show()
        {
            base.Show();
        }

        /**
         * <summary>ウィンドウを閉じる</summary>
         * */
        new public void Hide()
        {
            base.Hide();

        }

        public override void OnClick(Vector2F position)
        {
            if(_cancelButton.IsClick(position))
            {
                Hide();
            }
        }
    }
}

