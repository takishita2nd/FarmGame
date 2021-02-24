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
        private int page;
        private Node _parentNode = null;
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

        SeedWindow seedWindow = null;

        public Farm()
        {
            page = 0;
            int showColumn = GameData.PlayerData.farms.Count;
            if (showColumn > CommonParameter.FarmPageMaxColumn)
            {
                showColumn = CommonParameter.FarmPageMaxColumn;
            }
            for(int index = 0; index < showColumn; index++)
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
            _parentNode = parentNode;
            foreach (var column in farmColunms)
            {
                column.Icom.SetNode(parentNode);
                column.Window.SetNode(parentNode);
                column.CareButton.SetNode(parentNode);
                column.WaterButton.SetNode(parentNode);
            }
            _allCareButton.SetNode(parentNode);
            _allWaterButton.SetNode(parentNode);
            if(page != 0)
            {
                _prevPageButton.SetNode(parentNode);
            }
            if(GameData.PlayerData.farms.Count > CommonParameter.FarmPageMaxColumn)
            {
                _nextPageButton.SetNode(parentNode);
            }
        }

        public void OnMouse(Vector2F position)
        {
            foreach(var column in farmColunms)
            {
                column.CareButton.Hover(position);
                column.WaterButton.Hover(position);
            }
            _allCareButton.Hover(position);
            _allWaterButton.Hover(position);
            _nextPageButton.Hover(position);
            _prevPageButton.Hover(position);
        }

        public void OnClick(Vector2F position)
        {
            int maxPage = GameData.PlayerData.farms.Count / CommonParameter.FarmPageMaxColumn;
            foreach(var farmColumn in farmColunms)
            {
                if(farmColumn.Icom.IsClick(position))
                {
                    seedWindow = new SeedWindow(_parentNode, farmColumn);
                    seedWindow.SetPosition(new Vector2F(0, 170));
                    seedWindow.SetScale(new Vector2F(1.0f, 1.5f));
                    seedWindow.Show();

                }
            }

            if (_nextPageButton.Click(position))
            {
                page++;
                if (page == maxPage)
                {
                    int showColumn = GameData.PlayerData.farms.Count - CommonParameter.FarmPageMaxColumn * page;
                    int skip = 0;
                    if (showColumn != CommonParameter.FarmPageMaxColumn)
                    {
                        foreach (var column in farmColunms)
                        {
                            if (showColumn > skip)
                            {
                                skip++;
                                continue;
                            }
                            column.Icom.RemoveNode(_parentNode);
                            column.Window.RemoveNode(_parentNode);
                            column.CareButton.RemoveNode(_parentNode);
                            column.WaterButton.RemoveNode(_parentNode);
                        }
                        farmColunms.RemoveRange(showColumn, farmColunms.Count - showColumn);
                        _nextPageButton.RemoveNode(_parentNode);
                    }
                }
                _prevPageButton.SetNode(_parentNode);
            }
            if (_prevPageButton.Click(position))
            {
                page--;
                int showColumn = farmColunms.Count;
                int skip = 0;
                for(var index = 0; index < CommonParameter.FarmPageMaxColumn; index++)
                {
                    if (showColumn > skip)
                    {
                        skip++;
                        continue;
                    }

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

                    farmColunm.Icom.SetNode(_parentNode);
                    farmColunm.Window.SetNode(_parentNode);
                    farmColunm.CareButton.SetNode(_parentNode);
                    farmColunm.WaterButton.SetNode(_parentNode);
                }
                if(page == 0)
                {
                    _prevPageButton.RemoveNode(_parentNode);
                }
                _nextPageButton.SetNode(_parentNode);
            }
        }
    }
}
