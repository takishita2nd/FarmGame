﻿using System;
using System.Collections.Generic;
using System.Text;
using FarmGame.Common;
using FarmGame.Model;
using static FarmGame.Common.Parameter;

namespace FarmGame.UI.Parts
{
    class FarmColunm
    {
        public FarmIcon Icon;
        public PlantLabel Window;
        public Button CareButton;
        public Button WaterButton;
        private Model.Farm _farm;

        public FarmColunm()
        {
            Icon = new FarmIcon();
            Window = new PlantLabel();
            CareButton = new Button(Texture.CareButton, Texture.CareButtonHover, Texture.CareButtonClick);
            WaterButton = new Button(Texture.WaterButton, Texture.WaterButtonHover, Texture.WaterButtonClick);
        }

        public bool IsValid
        {
            get
            {
                return _farm.valid;
            }
        }

        public bool IsHarvest
        {
            get
            {
                if(_farm.growth >= 100)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public string Name
        {
            get
            {
                return GameData.GameStatus.Plants[_farm.id].name;
            }
        }

        public int Id
        {
            get
            {
                return _farm.id;
            }
        }

        public int Exp
        {
            get
            {
                return GameData.GameStatus.Plants[_farm.id].cost;
            }
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
            if(GameData.PlayerData.Weather == GameStatus.WeatherParameter.Rain)
            {
                _farm.water = true;
                WaterButton.Lock();
            }
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

        public void Harvest()
        {
            _farm.valid = false;
            _farm.id = -1;
            _farm.growth = 0;
            _farm.water = false;
            _farm.care = false;
            _farm.quality = 0;
            CareButton.Lock();
            WaterButton.Lock();
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

        public Quality GetQuolity()
        {
            int maxQuolity = GameData.GameStatus.Plants[_farm.id].cost * 150;
            int quolity = _farm.quality * 100 / maxQuolity ;
            return Function.QualityByValue(quolity);
        }
    }
}
