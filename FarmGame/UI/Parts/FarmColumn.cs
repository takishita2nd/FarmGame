using System;
using System.Collections.Generic;
using System.Text;
using FarmGame.Common;
using FarmGame.Model;

namespace FarmGame.UI.Parts
{
    class FarmColunm
    {
        public enum Status
        {
            Empty,
            Growth,
            Harvest
        }

        public FarmIcon Icon;
        public PlantWindow Window;
        public Button CareButton;
        public Button WaterButton;
        private Model.Farm _farm;

        public FarmColunm()
        {
            Icon = new FarmIcon();
            Window = new PlantWindow();
            CareButton = new Button(Texture.CareButton, Texture.CareButtonHover, Texture.CareButtonClick);
            WaterButton = new Button(Texture.WaterButton, Texture.WaterButtonHover, Texture.WaterButtonClick);
        }

        public void SetFarmData(Farm farm)
        {
            _farm = farm;
            if(!_farm.valid)
            {
                Icon.SetClip(FarmIcon.Type.Empty, 0);
                Window.SetText(string.Empty);
                CareButton.Lock();
                WaterButton.Lock();
            }
            else
            {
                Icon.SetClip(Function.SeedId2Type(_farm.id), farm.growth);
                Window.SetText(GameData.GameStatus.Plants[_farm.id].name);
                if (farm.care)
                {
                    CareButton.Lock();
                }
                else
                {
                    CareButton.Unlock();
                }
                if (farm.water)
                {
                    WaterButton.Lock();
                }
                else
                {
                    WaterButton.Unlock();
                }
            }
        }

        public void SetSeed(int seedId)
        {
            GameData.PlayerData.Seed[seedId]--;
            setFarmData(seedId);
            Icon.SetClip(Function.SeedId2Type(seedId), 0);
            Window.SetText(GameData.GameStatus.Plants[seedId].name);
        }

        public void Care()
        {
            if(_farm.valid && !_farm.care)
            {
                _farm.care = true;
                _farm.quality += GameData.PlayerData.AgricultureLevel;
                GameData.PlayerData.Power--;
                CareButton.Lock();
            }
        }
        public void Water()
        {
            if(_farm.valid && !_farm.water)
            {
                _farm.water = true;
                GameData.PlayerData.Power--;
                WaterButton.Lock();
            }
        }

        private void setFarmData(int seedId)
        {
            _farm.valid = true;
            _farm.id = seedId;
            _farm.growth = 0;
            _farm.water = false;
            _farm.care = false;
            _farm.quality = 0;
            CareButton.Unlock();
            WaterButton.Unlock();
        }
    }
}
