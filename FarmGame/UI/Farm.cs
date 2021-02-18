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
        private Button _allCareButton;
        private Button _allWaterButton;
        private Button _nextPageButton;
        private Button _prevPageButton;
        private List<FarmColunm> farmColunms = new List<FarmColunm>();

        private const int iconXIndex = 50;
        private const int windowXIndex = iconXIndex + 64 + 10;
        private const int careButtonXIndex = windowXIndex + 250;
        private const int waterButtonXIndex = careButtonXIndex + 160;
        private const int iconYIndex = 170;
        private const int windowYIndex = iconYIndex + 16;
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

            _allCareButton = new Button(Texture.AllCareButton, Texture.AllCareButtonHover, Texture.AllCareButtonClick);
            _allCareButton.SetPosition(new Vector2F(careButtonXIndex, careButtonYIndex + columnInterval * -1));
            _allCareButton.SetScale(careButtonScale);
            _allCareButton.SetZOrder(CommonParameter.ZOrder.Farm);

            _allWaterButton = new Button(Texture.AllWaterButton, Texture.AllWaterButtonHover, Texture.AllWaterButtonClick);
            _allWaterButton.SetPosition(new Vector2F(waterButtonXIndex, waterButtonYIndex + columnInterval * -1));
            _allWaterButton.SetScale(careButtonScale);
            _allWaterButton.SetZOrder(CommonParameter.ZOrder.Farm);

            _prevPageButton = new Button(Texture.PrevPageButton, Texture.PrevPageButtonHover, Texture.PrevPageButtonClick);
            _prevPageButton.SetPosition(new Vector2F(careButtonXIndex, waterButtonYIndex + columnInterval * CommonParameter.FarmPageMaxColumn + 1));
            _prevPageButton.SetScale(careButtonScale);
            _prevPageButton.SetZOrder(CommonParameter.ZOrder.Farm);

            _nextPageButton = new Button(Texture.NextPageButton, Texture.NextPageButtonHover, Texture.NextPageButtonClick);
            _nextPageButton.SetPosition(new Vector2F(waterButtonXIndex, careButtonYIndex + columnInterval * CommonParameter.FarmPageMaxColumn + 1));
            _nextPageButton.SetScale(careButtonScale);
            _nextPageButton.SetZOrder(CommonParameter.ZOrder.Farm);

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
            _allCareButton.SetNode(parentNode);
            _allWaterButton.SetNode(parentNode);
            _nextPageButton.SetNode(parentNode);
            _prevPageButton.SetNode(parentNode);
        }
    }
}
