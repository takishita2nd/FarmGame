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
        private static Texture2D _ranchButtonHover = null;
        private static Texture2D _ranchButtonClick = null;
        private static Texture2D _marketButton = null;
        private static Texture2D _marketButtonHover = null;
        private static Texture2D _marketButtonClick = null;
        private static Texture2D _shopButton = null;
        private static Texture2D _shopButtonHover = null;
        private static Texture2D _shopButtonClick = null;
        private static Texture2D _studioButton = null;
        private static Texture2D _studioButtonHover = null;
        private static Texture2D _studioButtonClick = null;
        private static Texture2D _statusButton = null;
        private static Texture2D _statusButtonHover = null;
        private static Texture2D _statusButtonClick = null;
        private static Texture2D _homebutton = null;
        private static Texture2D _nextbutton = null;

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

        public static Texture2D RanchButtonHover
        {
            get
            {
                if (_ranchButtonHover == null)
                {
                    _ranchButtonHover = Texture2D.Load("ranch_button_hover.png");
                }
                return _ranchButtonHover;
            }
        }

        public static Texture2D RanchButtonClick
        {
            get
            {
                if (_ranchButtonClick == null)
                {
                    _ranchButtonClick = Texture2D.Load("ranch_button_click.png");
                }
                return _ranchButtonClick;
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

        public static Texture2D MarketButtonHover
        {
            get
            {
                if (_marketButtonHover == null)
                {
                    _marketButtonHover = Texture2D.Load("market_button_hover.png");
                }
                return _marketButtonHover;
            }
        }

        public static Texture2D MarketButtonClick
        {
            get
            {
                if (_marketButtonClick == null)
                {
                    _marketButtonClick = Texture2D.Load("market_button_click.png");
                }
                return _marketButtonClick;
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

        public static Texture2D ShopButtonHover
        {
            get
            {
                if (_shopButtonHover == null)
                {
                    _shopButtonHover = Texture2D.Load("shop_button_hover.png");
                }
                return _shopButtonHover;
            }
        }

        public static Texture2D ShopButtonClick
        {
            get
            {
                if (_shopButtonClick == null)
                {
                    _shopButtonClick = Texture2D.Load("shop_button_click.png");
                }
                return _shopButtonClick;
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

        public static Texture2D StudioButtonHover
        {
            get
            {
                if (_studioButtonHover == null)
                {
                    _studioButtonHover = Texture2D.Load("studio_button_hover.png");
                }
                return _studioButtonHover;
            }
        }

        public static Texture2D StudioButtonClick
        {
            get
            {
                if (_studioButtonClick == null)
                {
                    _studioButtonClick = Texture2D.Load("studio_button_click.png");
                }
                return _studioButtonClick;
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

        public static Texture2D StatusButtonHover
        {
            get
            {
                if (_statusButtonHover == null)
                {
                    _statusButtonHover = Texture2D.Load("status_button_hover.png");
                }
                return _statusButtonHover;
            }
        }

        public static Texture2D StatusButtonClick
        {
            get
            {
                if (_statusButtonClick == null)
                {
                    _statusButtonClick = Texture2D.Load("status_button_click.png");
                }
                return _statusButtonClick;
            }
        }
        public static Texture2D HomeButton
        {
            get
            {
                if (_homebutton == null)
                {
                    _homebutton = Texture2D.Load("homebutton.png");
                }
                return _homebutton;
            }
        }
        public static Texture2D NextButton
        {
            get
            {
                if (_nextbutton == null)
                {
                    _nextbutton = Texture2D.Load("nextbutton.png");
                }
                return _nextbutton;
            }
        }
    }
}
