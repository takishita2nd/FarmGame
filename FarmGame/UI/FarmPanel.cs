using Altseed2;
using FarmGame.UI.Parts;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmGame.UI
{
    class FarmPanel
    {
        private int page;
        private Node _parentNode = null;
        private Button _allCareButton;
        private Button _allWaterButton;
        private Button _nextPageButton;
        private Button _prevPageButton;
        private List<FarmColunm> farmColunms = new List<FarmColunm>();
        private AlartDialog alartDialog = new AlartDialog();

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

        public FarmPanel()
        {
            page = 0;
            int showColumn = GameData.PlayerData.farms.Count;
            if (showColumn > Parameter.FarmPageMaxColumn)
            {
                showColumn = Parameter.FarmPageMaxColumn;
            }
            for(int index = 0; index < showColumn; index++)
            {
                FarmColunm farmColunm = new FarmColunm();
                farmColunm.Icon.SetPosition(new Vector2F(iconXIndex, iconYIndex + columnInterval * index));
                farmColunm.Window.SetPosition(new Vector2F(windowXIndex, windowYIndex + columnInterval * index));
                farmColunm.CareButton.SetPosition(new Vector2F(careButtonXIndex, careButtonYIndex + columnInterval * index));
                farmColunm.CareButton.SetScale(careButtonScale);
                farmColunm.CareButton.SetZOrder(Parameter.ZOrder.Farm);
                farmColunm.WaterButton.SetPosition(new Vector2F(waterButtonXIndex, waterButtonYIndex + columnInterval * index));
                farmColunm.WaterButton.SetScale(careButtonScale);
                farmColunm.WaterButton.SetZOrder(Parameter.ZOrder.Farm);

                farmColunm.SetFarmData(GameData.PlayerData.farms[index]);

                farmColunms.Add(farmColunm);
            }

            _allCareButton = new Button(Texture.AllCareButton, Texture.AllCareButtonHover, Texture.AllCareButtonClick);
            _allCareButton.SetPosition(new Vector2F(careButtonXIndex, careButtonYIndex + columnInterval * -1));
            _allCareButton.SetScale(careButtonScale);
            _allCareButton.SetZOrder(Parameter.ZOrder.Farm);

            _allWaterButton = new Button(Texture.AllWaterButton, Texture.AllWaterButtonHover, Texture.AllWaterButtonClick);
            _allWaterButton.SetPosition(new Vector2F(waterButtonXIndex, waterButtonYIndex + columnInterval * -1));
            _allWaterButton.SetScale(careButtonScale);
            _allWaterButton.SetZOrder(Parameter.ZOrder.Farm);

            _prevPageButton = new Button(Texture.PrevPageButton, Texture.PrevPageButtonHover, Texture.PrevPageButtonClick);
            _prevPageButton.SetPosition(new Vector2F(careButtonXIndex, waterButtonYIndex + columnInterval * Parameter.FarmPageMaxColumn + 1));
            _prevPageButton.SetScale(careButtonScale);
            _prevPageButton.SetZOrder(Parameter.ZOrder.Farm);

            _nextPageButton = new Button(Texture.NextPageButton, Texture.NextPageButtonHover, Texture.NextPageButtonClick);
            _nextPageButton.SetPosition(new Vector2F(waterButtonXIndex, careButtonYIndex + columnInterval * Parameter.FarmPageMaxColumn + 1));
            _nextPageButton.SetScale(careButtonScale);
            _nextPageButton.SetZOrder(Parameter.ZOrder.Farm);

        }

        public void SetNode(Node parentNode)
        {
            _parentNode = parentNode;
            foreach (var column in farmColunms)
            {
                column.Icon.SetNode(parentNode);
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
            if(GameData.PlayerData.farms.Count > Parameter.FarmPageMaxColumn)
            {
                _nextPageButton.SetNode(parentNode);
            }
        }

        public void OnMouse(Vector2F position)
        {
            if (alartDialog.IsShow)
            {
                return;
            }
            if (seedWindow != null && seedWindow.IsShow())
            {
                seedWindow.OnMouse(position);
                return;
            }

            foreach (var column in farmColunms)
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
            if(alartDialog.IsShow)
            {
                alartDialog.RemoveNode(_parentNode);
                return;
            }
            if (seedWindow != null && seedWindow.IsShow())
            {
                seedWindow.OnClick(position);
                return;
            }

            foreach (var column in farmColunms)
            {
                if (column.CareButton.Click(position))
                {
                    column.Care();
                    return;
                }
                if (column.WaterButton.Click(position))
                {
                    column.Water();
                    return;
                }
            }

            if(_allCareButton.Click(position))
            {
                int count = 0;
                foreach (var column in farmColunms)
                {
                    if (!column.CareButton.IsPushed)
                    {
                        count++;
                    }
                }
                if(count > GameData.PlayerData.Power)
                {
                    alartDialog.SetNode("パワーが足りません", _parentNode);
                    return;
                }

                foreach (var column in farmColunms)
                {
                    column.Care();
                }
                return;
            }
            if (_allWaterButton.Click(position))
            {
                int count = 0;
                foreach (var column in farmColunms)
                {
                    if (!column.WaterButton.IsPushed)
                    {
                        count++;
                    }
                }
                if (count > GameData.PlayerData.Power)
                {
                    alartDialog.SetNode("パワーが足りません", _parentNode);
                    return;
                }
                foreach (var column in farmColunms)
                {
                    column.Water();
                }
                return;
            }

            int maxPage = GameData.PlayerData.farms.Count / Parameter.FarmPageMaxColumn;
            foreach(var farmColumn in farmColunms)
            {
                if(farmColumn.Icon.IsClick(position))
                {
                    seedWindow = new SeedWindow(_parentNode, farmColumn);
                    seedWindow.Show();
                    return;
                }
            }

            if (_nextPageButton.Click(position))
            {
                page++;
                if (page == maxPage - 1)
                {
                    _nextPageButton.RemoveNode(_parentNode);
                }
                _prevPageButton.SetNode(_parentNode);
                updateDisplay();
            }
            if (_prevPageButton.Click(position))
            {
                page--;
                if(page == 0)
                {
                    _prevPageButton.RemoveNode(_parentNode);
                }
                _nextPageButton.SetNode(_parentNode);
                updateDisplay();
            }

        }

        private void updateDisplay()
        {
            int index = page * Parameter.FarmPageMaxColumn;
            foreach (var farmColunm in farmColunms)
            {
                farmColunm.SetFarmData(GameData.PlayerData.farms[index]);
                index++;
            }
        }
    }
}
