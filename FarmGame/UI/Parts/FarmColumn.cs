using System;
using System.Collections.Generic;
using System.Text;
using FarmGame.Common;

namespace FarmGame.UI.Parts
{
    class FarmColunm
    {
        public FarmIcon Icon;
        public PlantWindow Window;
        public Button CareButton;
        public Button WaterButton;

        public FarmColunm()
        {
            Icon = new FarmIcon();
            Window = new PlantWindow();
            CareButton = new Button(Texture.CareButton, Texture.CareButtonHover, Texture.CareButtonClick);
            WaterButton = new Button(Texture.WaterButton, Texture.WaterButtonHover, Texture.WaterButtonClick);
        }

        public void SetSeed(int seedId)
        {
            Icon.Plant(Function.SeedId2Type(seedId));
        }

    }
}
