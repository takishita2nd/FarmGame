using System;
using System.Collections.Generic;
using System.Text;
using Altseed2;

namespace FarmGame
{
    public static class Texture
    {
        private static Texture2D _window = null;

        private static Texture2D _okButton = null;
        private static Texture2D _okButtonHover = null;
        private static Texture2D _okButtonClick = null;
        private static Texture2D _cancelButton = null;
        private static Texture2D _cancelButtonHover = null;
        private static Texture2D _cancelButtonClick = null;
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
        private static Texture2D _careButton = null;
        private static Texture2D _careButtonHover = null;
        private static Texture2D _careButtonClick = null;
        private static Texture2D _allcareButton = null;
        private static Texture2D _allcareButtonHover = null;
        private static Texture2D _allcareButtonClick = null;
        private static Texture2D _waterButton = null;
        private static Texture2D _waterButtonHover = null;
        private static Texture2D _waterButtonClick = null;
        private static Texture2D _allwaterButton = null;
        private static Texture2D _allwaterButtonHover = null;
        private static Texture2D _allwaterButtonClick = null;
        private static Texture2D _prevPageButton = null;
        private static Texture2D _prevPageButtonHover = null;
        private static Texture2D _prevPageButtonClick = null;
        private static Texture2D _nextPageButton = null;
        private static Texture2D _nextPageButtonHover = null;
        private static Texture2D _nextPageButtonClick = null;
        private static Texture2D _marketSeedButton = null;
        private static Texture2D _marketSeedButtonHover = null;
        private static Texture2D _marketSeedButtonClick = null;
        private static Texture2D _marketFoodButton = null;
        private static Texture2D _marketFoodButtonHover = null;
        private static Texture2D _marketFoodButtonClick = null;
        private static Texture2D _marketAnimalButton = null;
        private static Texture2D _marketAnimalButtonHover = null;
        private static Texture2D _marketAnimalButtonClick = null;
        private static Texture2D _marketFarmButton = null;
        private static Texture2D _marketFarmButtonHover = null;
        private static Texture2D _marketFarmButtonClick = null;
        private static Texture2D _deliveryButton = null;
        private static Texture2D _deliveryButtonHover = null;
        private static Texture2D _deliveryButtonClick = null;
        private static Texture2D _destructionButton = null;
        private static Texture2D _destructionButtonHover = null;
        private static Texture2D _destructionButtonClick = null;

        private static Texture2D _seedButton = null;
        private static Texture2D _seedButtonPush = null;

        private static Texture2D _homebutton = null;
        private static Texture2D _nextbutton = null;
        private static Texture2D _farmTexture1 = null;
        private static Texture2D _farmTexture2 = null;
        private static Texture2D _farmTexture3 = null;

        private static Texture2D _farmWindow = null;
        private static Texture2D _seedWindow = null;

        private static Texture2D _mapChip = null;

        public static Texture2D Window
        {
            get
            {
                if (_window == null)
                {
                    _window = Texture2D.Load("284244.png");
                }
                return _window;
            }
        }
        public static Texture2D OKButton
        {
            get
            {
                if (_okButton == null)
                {
                    _okButton = Texture2D.Load("ok.png");
                }
                return _okButton;
            }
        }

        public static Texture2D OKButtonHover
        {
            get
            {
                if (_okButtonHover == null)
                {
                    _okButtonHover = Texture2D.Load("ok_hover.png");
                }
                return _okButtonHover;
            }
        }

        public static Texture2D OKButtonClick
        {
            get
            {
                if (_okButtonClick == null)
                {
                    _okButtonClick = Texture2D.Load("ok_click.png");
                }
                return _okButtonClick;
            }
        }
        public static Texture2D CancelButton
        {
            get
            {
                if (_cancelButton == null)
                {
                    _cancelButton = Texture2D.Load("cancel.png");
                }
                return _cancelButton;
            }
        }

        public static Texture2D CancelButtonHover
        {
            get
            {
                if (_cancelButtonHover == null)
                {
                    _cancelButtonHover = Texture2D.Load("cancel_hover.png");
                }
                return _cancelButtonHover;
            }
        }

        public static Texture2D CancelButtonClick
        {
            get
            {
                if (_cancelButtonClick == null)
                {
                    _cancelButtonClick = Texture2D.Load("cancel_click.png");
                }
                return _cancelButtonClick;
            }
        }

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
        public static Texture2D CareButton
        {
            get
            {
                if (_careButton == null)
                {
                    _careButton = Texture2D.Load("care_button.png");
                }
                return _careButton;
            }
        }
        public static Texture2D CareButtonHover
        {
            get
            {
                if (_careButtonHover == null)
                {
                    _careButtonHover = Texture2D.Load("care_button_hover.png");
                }
                return _careButtonHover;
            }
        }
        public static Texture2D CareButtonClick
        {
            get
            {
                if (_careButtonClick == null)
                {
                    _careButtonClick = Texture2D.Load("care_button_click.png");
                }
                return _careButtonClick;
            }
        }

        public static Texture2D WaterButton
        {
            get
            {
                if (_waterButton == null)
                {
                    _waterButton = Texture2D.Load("water_button.png");
                }
                return _waterButton;
            }
        }
        public static Texture2D WaterButtonHover
        {
            get
            {
                if (_waterButtonHover == null)
                {
                    _waterButtonHover = Texture2D.Load("water_button_hover.png");
                }
                return _waterButtonHover;
            }
        }
        public static Texture2D WaterButtonClick
        {
            get
            {
                if (_waterButtonClick == null)
                {
                    _waterButtonClick = Texture2D.Load("water_button_click.png");
                }
                return _waterButtonClick;
            }
        }
        public static Texture2D AllCareButton
        {
            get
            {
                if (_allcareButton == null)
                {
                    _allcareButton = Texture2D.Load("allcare_button.png");
                }
                return _allcareButton;
            }
        }
        public static Texture2D AllCareButtonHover
        {
            get
            {
                if (_allcareButtonHover == null)
                {
                    _allcareButtonHover = Texture2D.Load("allcare_button_hover.png");
                }
                return _allcareButtonHover;
            }
        }
        public static Texture2D AllCareButtonClick
        {
            get
            {
                if (_allcareButtonClick == null)
                {
                    _allcareButtonClick = Texture2D.Load("allcare_button_click.png");
                }
                return _allcareButtonClick;
            }
        }

        public static Texture2D AllWaterButton
        {
            get
            {
                if (_allwaterButton == null)
                {
                    _allwaterButton = Texture2D.Load("allwater_button.png");
                }
                return _allwaterButton;
            }
        }
        public static Texture2D AllWaterButtonHover
        {
            get
            {
                if (_allwaterButtonHover == null)
                {
                    _allwaterButtonHover = Texture2D.Load("allwater_button_hover.png");
                }
                return _allwaterButtonHover;
            }
        }
        public static Texture2D AllWaterButtonClick
        {
            get
            {
                if (_allwaterButtonClick == null)
                {
                    _allwaterButtonClick = Texture2D.Load("allwater_button_click.png");
                }
                return _allwaterButtonClick;
            }
        }
        public static Texture2D PrevPageButton
        {
            get
            {
                if (_prevPageButton == null)
                {
                    _prevPageButton = Texture2D.Load("prev_page.png");
                }
                return _prevPageButton;
            }
        }
        public static Texture2D PrevPageButtonHover
        {
            get
            {
                if (_prevPageButtonHover == null)
                {
                    _prevPageButtonHover = Texture2D.Load("prev_page_hover.png");
                }
                return _prevPageButtonHover;
            }
        }
        public static Texture2D PrevPageButtonClick
        {
            get
            {
                if (_prevPageButtonClick == null)
                {
                    _prevPageButtonClick = Texture2D.Load("prev_page_click.png");
                }
                return _prevPageButtonClick;
            }
        }
        public static Texture2D NextPageButton
        {
            get
            {
                if (_nextPageButton == null)
                {
                    _nextPageButton = Texture2D.Load("next_page.png");
                }
                return _nextPageButton;
            }
        }
        public static Texture2D NextPageButtonHover
        {
            get
            {
                if (_nextPageButtonHover == null)
                {
                    _nextPageButtonHover = Texture2D.Load("next_page_hover.png");
                }
                return _nextPageButtonHover;
            }
        }
        public static Texture2D NextPageButtonClick
        {
            get
            {
                if (_nextPageButtonClick == null)
                {
                    _nextPageButtonClick = Texture2D.Load("wnext_page_click.png");
                }
                return _nextPageButtonClick;
            }
        }
        public static Texture2D MarketSeedButton
        {
            get
            {
                if (_marketSeedButton == null)
                {
                    _marketSeedButton = Texture2D.Load("market_seed_button.png");
                }
                return _marketSeedButton;
            }
        }
        public static Texture2D MarketSeedButtonHover
        {
            get
            {
                if (_marketSeedButtonHover == null)
                {
                    _marketSeedButtonHover = Texture2D.Load("market_seed_button_hover.png");
                }
                return _marketSeedButtonHover;
            }
        }
        public static Texture2D MarketSeedButtonClick
        {
            get
            {
                if (_marketSeedButtonClick == null)
                {
                    _marketSeedButtonClick = Texture2D.Load("market_seed_button_click.png");
                }
                return _marketSeedButtonClick;
            }
        }
        public static Texture2D MarketFoodButton
        {
            get
            {
                if (_marketFoodButton == null)
                {
                    _marketFoodButton = Texture2D.Load("market_food_button.png");
                }
                return _marketFoodButton;
            }
        }
        public static Texture2D MarketFoodButtonHover
        {
            get
            {
                if (_marketFoodButtonHover == null)
                {
                    _marketFoodButtonHover = Texture2D.Load("market_food_button_hover.png");
                }
                return _marketFoodButtonHover;
            }
        }
        public static Texture2D MarketFoodButtonClick
        {
            get
            {
                if (_marketFoodButtonClick == null)
                {
                    _marketFoodButtonClick = Texture2D.Load("market_food_button_click.png");
                }
                return _marketFoodButtonClick;
            }
        }
        public static Texture2D MarketAnimalButton
        {
            get
            {
                if (_marketAnimalButton == null)
                {
                    _marketAnimalButton = Texture2D.Load("market_animal_button.png");
                }
                return _marketAnimalButton;
            }
        }
        public static Texture2D MarketAnimalButtonHover
        {
            get
            {
                if (_marketAnimalButtonHover == null)
                {
                    _marketAnimalButtonHover = Texture2D.Load("market_animal_button_hover.png");
                }
                return _marketAnimalButtonHover;
            }
        }
        public static Texture2D MarketAnimalButtonClick
        {
            get
            {
                if (_marketAnimalButtonClick == null)
                {
                    _marketAnimalButtonClick = Texture2D.Load("market_animal_button_click.png");
                }
                return _marketAnimalButtonClick;
            }
        }
        public static Texture2D MarketFarmButton
        {
            get
            {
                if (_marketFarmButton == null)
                {
                    _marketFarmButton = Texture2D.Load("market_farm_button.png");
                }
                return _marketFarmButton;
            }
        }
        public static Texture2D MarketFarmButtonHover
        {
            get
            {
                if (_marketFarmButtonHover == null)
                {
                    _marketFarmButtonHover = Texture2D.Load("market_farm_button_hover.png");
                }
                return _marketFarmButtonHover;
            }
        }
        public static Texture2D MarketFarmButtonClick
        {
            get
            {
                if (_marketFarmButtonClick == null)
                {
                    _marketFarmButtonClick = Texture2D.Load("market_food_button_click.png");
                }
                return _marketFarmButtonClick;
            }
        }

        public static Texture2D DeliveryButton
        {
            get
            {
                if (_deliveryButton == null)
                {
                    _deliveryButton = Texture2D.Load("delivery_button.png");
                }
                return _deliveryButton;
            }
        }
        public static Texture2D DeliveryButtonHover
        {
            get
            {
                if (_deliveryButtonHover == null)
                {
                    _deliveryButtonHover = Texture2D.Load("delivery_button_hover.png");
                }
                return _deliveryButtonHover;
            }
        }
        public static Texture2D DeliveryButtonClick
        {
            get
            {
                if (_deliveryButtonClick == null)
                {
                    _deliveryButtonClick = Texture2D.Load("delivery_button_click.png");
                }
                return _deliveryButtonClick;
            }
        }
        public static Texture2D DestructionButton
        {
            get
            {
                if (_destructionButton == null)
                {
                    _destructionButton = Texture2D.Load("destruction_button.png");
                }
                return _destructionButton;
            }
        }
        public static Texture2D DestructionButtonHover
        {
            get
            {
                if (_destructionButtonHover == null)
                {
                    _destructionButtonHover = Texture2D.Load("destruction_button_hover.png");
                }
                return _destructionButtonHover;
            }
        }
        public static Texture2D DestructionButtonClick
        {
            get
            {
                if (_destructionButtonClick == null)
                {
                    _destructionButtonClick = Texture2D.Load("destruction_button_click.png");
                }
                return _destructionButtonClick;
            }
        }


        public static Texture2D SeedButton
        {
            get
            {
                if (_seedButton == null)
                {
                    _seedButton = Texture2D.Load("300x35_bl.png");
                }
                return _seedButton;
            }
        }
        public static Texture2D SeedButtonPush
        {
            get
            {
                if (_seedButtonPush == null)
                {
                    _seedButtonPush = Texture2D.Load("300x35_gr.png");
                }
                return _seedButtonPush;
            }
        }

        public static Texture2D ItemButton
        {
            get
            {
                if (_seedButton == null)
                {
                    _seedButton = Texture2D.Load("300x35_bl.png");
                }
                return _seedButton;
            }
        }
        public static Texture2D ItemButtonValid
        {
            get
            {
                if (_seedButtonPush == null)
                {
                    _seedButtonPush = Texture2D.Load("300x35_gr.png");
                }
                return _seedButtonPush;
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
        public static Texture2D FarmTexture1
        {
            get
            {
                if (_farmTexture1 == null)
                {
                    _farmTexture1 = Texture2D.Load("farm01.png");
                }
                return _farmTexture1;
            }
        }
        public static Texture2D FarmTexture2
        {
            get
            {
                if (_farmTexture2 == null)
                {
                    _farmTexture2 = Texture2D.Load("farm02.png");
                }
                return _farmTexture2;
            }
        }
        public static Texture2D FarmTexture3
        {
            get
            {
                if (_farmTexture3 == null)
                {
                    _farmTexture3 = Texture2D.Load("farm03.png");
                }
                return _farmTexture3;
            }
        }
        public static Texture2D FarmWindow
        {
            get
            {
                if (_farmWindow == null)
                {
                    _farmWindow = Texture2D.Load("150x35_or.png");
                }
                return _farmWindow;
            }
        }
        public static Texture2D SeedWindow
        {
            get
            {
                if (_seedWindow == null)
                {
                    _seedWindow = Texture2D.Load("284244.png");
                }
                return _seedWindow;
            }
        }

        public static Texture2D MapChip
        {
            get
            {
                if (_mapChip == null)
                {
                    _mapChip = Texture2D.Load("chip23a_forest_fall.png");
                }
                return _mapChip;
            }
        }

    }
}
