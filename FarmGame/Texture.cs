using System;
using System.Collections.Generic;
using System.Text;
using Altseed2;

namespace FarmGame
{
    public static class Texture
    {
        private static Texture2D _farmButton = null;
        private static Texture2D _farmButtonHover = null;
        private static Texture2D _farmButtonClick = null;
        private static Texture2D _ranchButton = null;
        private static Texture2D _marketButton = null;
        private static Texture2D _shopButton = null;
        private static Texture2D _studioButton = null;
        private static Texture2D _statusButton = null;
        public static Texture2D FarmButton
        {
            get
            {
                if (_farmButton == null)
                {
                    _farmButton = Texture2D.Load("farm_button.png");
                }
                return _farmButton;
            }
        }

        public static Texture2D FarmButtonHover
        {
            get
            {
                if (_farmButtonHover == null)
                {
                    _farmButtonHover = Texture2D.Load("farm_button_hover.png");
                }
                return _farmButtonHover;
            }
        }

        public static Texture2D FarmButtonClick
        {
            get
            {
                if (_farmButtonClick == null)
                {
                    _farmButtonClick = Texture2D.Load("farm_button_click.png");
                }
                return _farmButtonClick;
            }
        }

        public static Texture2D RanchButton
        {
            get
            {
                if (_ranchButton == null)
                {
                    _ranchButton = Texture2D.Load("ranch_button.png");
                }
                return _ranchButton;
            }
        }
        public static Texture2D MarketButton
        {
            get
            {
                if (_marketButton == null)
                {
                    _marketButton = Texture2D.Load("market_button.png");
                }
                return _marketButton;
            }
        }
        public static Texture2D ShopButton
        {
            get
            {
                if (_shopButton == null)
                {
                    _shopButton = Texture2D.Load("shop_button.png");
                }
                return _shopButton;
            }
        }
        public static Texture2D StudioButton
        {
            get
            {
                if (_studioButton == null)
                {
                    _studioButton = Texture2D.Load("studio_button.png");
                }
                return _studioButton;
            }
        }
        public static Texture2D StatusButton
        {
            get
            {
                if (_statusButton == null)
                {
                    _statusButton = Texture2D.Load("status_button.png");
                }
                return _statusButton;
            }
        }
    }
}
