using System;
using System.Collections.Generic;
using System.Text;
using FarmGame.Common;

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
        private int _index;

        public FarmColunm()
        {
            Icon = new FarmIcon();
            Window = new PlantWindow();
            CareButton = new Button(Texture.CareButton, Texture.CareButtonHover, Texture.CareButtonClick);
            WaterButton = new Button(Texture.WaterButton, Texture.WaterButtonHover, Texture.WaterButtonClick);
        }

        public void SetFarmIndex(int index)
        {
            _index = index;
            if(!GameData.PlayerData.farms[index].valid)
            {
                Icon.Plant(FarmIcon.Type.Empty);
                Window.SetText(string.Empty);
            }
            else
            {
                Icon.Plant(Function.SeedId2Type(GameData.PlayerData.farms[index].id));
                Window.SetText(GameData.GameStatus.Plants[GameData.PlayerData.farms[index].id].name);
            }
        }

        public void SetSeed(int seedId)
        {
            setFarmData(seedId);
            Icon.Plant(Function.SeedId2Type(seedId));
            Window.SetText(GameData.GameStatus.Plants[seedId].name);
        }

        private void setFarmData(int seedId)
        {
            GameData.PlayerData.farms[_index].valid = true;
            GameData.PlayerData.farms[_index].id = seedId;
            GameData.PlayerData.farms[_index].growth = 0;
            GameData.PlayerData.farms[_index].water = false;
            GameData.PlayerData.farms[_index].quality = 0;
        }
    }
}
