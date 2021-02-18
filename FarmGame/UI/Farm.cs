using Altseed2;
using FarmGame.UI.Parts;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmGame.UI
{
    class FarmColunm
    {
        public FarmIcon Icom;
        public PlantWindow Window;
        public Button CareButton;
        public Button WaterButton;

        public FarmColunm()
        {
            Icom = new FarmIcon();
            Window = new PlantWindow();
            CareButton = new Button(Texture.CareButton, Texture.CareButtonHover, Texture.CareButtonClick);
            WaterButton = new Button(Texture.WaterButton, Texture.WaterButtonHover, Texture.WaterButtonClick);
        }
    }


    class Farm
    {
        private List<FarmColunm> farmColunms = new List<FarmColunm>();

        private const int iconXIndex = 50;
        private const int windowXIndex = iconXIndex + 64 + 10;
        private const int careButtonXIndex = windowXIndex + 250;
        private const int waterButtonXIndex = careButtonXIndex + 160;
        private const int iconYIndex = 160;
        private const int windowYIndex = 160 + 16;
        private const int careButtonYIndex = windowYIndex;
        private const int waterButtonYIndex = windowYIndex;
        private const float careButtonScale = 0.6f;

        private const int columnInterval = 60;

        public Farm(int column)
        {
            for(int index = 0; index < column; index++)
            {
                FarmColunm farmColunm = new FarmColunm();
                farmColunm.Icom.SetPosition(new Vector2F(iconXIndex, iconYIndex + columnInterval * index));
                farmColunm.Window.SetPosition(new Vector2F(windowXIndex, windowYIndex + columnInterval * index));
                farmColunm.CareButton.SetPosition(new Vector2F(careButtonXIndex, careButtonYIndex + columnInterval * index));
                farmColunm.CareButton.SetScale(careButtonScale);
                farmColunm.CareButton.SetZOrder(CommonParameter.ZOrder.Farm);
                farmColunm.WaterButton.SetPosition(new Vector2F(waterButtonXIndex, waterButtonYIndex + columnInterval * index));
                farmColunm.WaterButton.SetScale(careButtonScale);
                farmColunm.WaterButton.SetZOrder(CommonParameter.ZOrder.Farm);

                farmColunms.Add(farmColunm);
            }
        }

        public void SetNode(Node parentNode)
        {
            foreach(var column in farmColunms)
            {
                column.Icom.SetNode(parentNode);
                column.Window.SetNode(parentNode);
                column.CareButton.SetNode(parentNode);
                column.WaterButton.SetNode(parentNode);
            }
        }
    }
}
