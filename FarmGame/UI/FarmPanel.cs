using Altseed2;
using FarmGame.Common;
using FarmGame.UI.Parts;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmGame.UI
{
    class FarmPanel
    {
        private bool _isLevelup = false;
        private int page;
        private Node _parentNode = null;
        private Button _allCareButton;
        private Button _allWaterButton;
        private Button _nextPageButton;
        private Button _prevPageButton;
        private List<FarmColunm> farmColunms = new List<FarmColunm>();
        private Dialog dialog = new Dialog();

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
            _isLevelup = false;
            page = 0;
            int showColumn = GameData.PlayerData.farms.Count;
            if (showColumn > Common.Parameter.FarmPageMaxColumn)
            {
                showColumn = Common.Parameter.FarmPageMaxColumn;
            }
            for(int index = 0; index < showColumn; index++)
            {
                FarmColunm farmColunm = new FarmColunm();
                farmColunm.Icon.SetPosition(new Vector2F(iconXIndex, iconYIndex + columnInterval * index));
                farmColunm.Window.SetPosition(new Vector2F(windowXIndex, windowYIndex + columnInterval * index));
                farmColunm.CareButton.SetPosition(new Vector2F(careButtonXIndex, careButtonYIndex + columnInterval * index));
                farmColunm.CareButton.SetScale(careButtonScale);
                farmColunm.CareButton.SetZOrder(Common.Parameter.ZOrder.Farm);
                farmColunm.WaterButton.SetPosition(new Vector2F(waterButtonXIndex, waterButtonYIndex + columnInterval * index));
                farmColunm.WaterButton.SetScale(careButtonScale);
                farmColunm.WaterButton.SetZOrder(Common.Parameter.ZOrder.Farm);

                farmColunm.SetFarmData(GameData.PlayerData.farms[index]);

                farmColunms.Add(farmColunm);
            }

            _allCareButton = new Button(Texture.AllCareButton, Texture.AllCareButtonHover, Texture.AllCareButtonClick);
            _allCareButton.SetPosition(new Vector2F(careButtonXIndex, careButtonYIndex + columnInterval * -1));
            _allCareButton.SetScale(careButtonScale);
            _allCareButton.SetZOrder(Common.Parameter.ZOrder.Farm);

            _allWaterButton = new Button(Texture.AllWaterButton, Texture.AllWaterButtonHover, Texture.AllWaterButtonClick);
            _allWaterButton.SetPosition(new Vector2F(waterButtonXIndex, waterButtonYIndex + columnInterval * -1));
            _allWaterButton.SetScale(careButtonScale);
            _allWaterButton.SetZOrder(Common.Parameter.ZOrder.Farm);

            _prevPageButton = new Button(Texture.PrevPageButton, Texture.PrevPageButtonHover, Texture.PrevPageButtonClick);
            _prevPageButton.SetPosition(new Vector2F(careButtonXIndex, waterButtonYIndex + columnInterval * Common.Parameter.FarmPageMaxColumn + 1));
            _prevPageButton.SetScale(careButtonScale);
            _prevPageButton.SetZOrder(Common.Parameter.ZOrder.Farm);

            _nextPageButton = new Button(Texture.NextPageButton, Texture.NextPageButtonHover, Texture.NextPageButtonClick);
            _nextPageButton.SetPosition(new Vector2F(waterButtonXIndex, careButtonYIndex + columnInterval * Common.Parameter.FarmPageMaxColumn + 1));
            _nextPageButton.SetScale(careButtonScale);
            _nextPageButton.SetZOrder(Common.Parameter.ZOrder.Farm);

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
            if(GameData.PlayerData.farms.Count > Common.Parameter.FarmPageMaxColumn)
            {
                _nextPageButton.SetNode(parentNode);
            }
        }

        public void OnMouse(Vector2F position)
        {
            if (dialog.IsShow)
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

        /**
         * <summary>クリック処理</summary>
         * */
        public void OnClick(Vector2F position)
        {
            //ダイアログ表示中
            if(dialog.IsShow)
            {
                if(_isLevelup)
                {
                    dialog.UpdateText(
                        "農業レベルが上がりました\n(" + GameData.PlayerData.AgricultureLevel.ToString() + ")"
                        );
                    _isLevelup = false;
                    return;
                }
                dialog.RemoveNode(_parentNode);
                return;
            }
            //種ウィンドウ表示中
            if (seedWindow != null && seedWindow.IsShow())
            {
                seedWindow.OnClick(position);
                return;
            }

            //お手入れ/水やりボタン押下
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
            //全お手入れボタン押下
            if (_allCareButton.Click(position))
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
                    dialog.SetNode("パワーが足りません", _parentNode);
                    return;
                }

                foreach (var column in farmColunms)
                {
                    column.Care();
                }
                return;
            }
            //全水やりボタン押下
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
                    dialog.SetNode("パワーが足りません", _parentNode);
                    return;
                }
                foreach (var column in farmColunms)
                {
                    column.Water();
                }
                return;
            }

            //畑アイコンクリック時
            int maxPage = GameData.PlayerData.farms.Count / Common.Parameter.FarmPageMaxColumn;
            foreach(var farmColumn in farmColunms)
            {
                if(farmColumn.Icon.IsClick(position))
                {
                    if(!farmColumn.IsValid)
                    {
                        //畑が空
                        seedWindow = new SeedWindow(_parentNode, farmColumn);
                        seedWindow.Show();
                        return;
                    }
                    else if(farmColumn.IsHarvest)
                    {
                        //収穫可能
                        int num = 2 + Function.GetRandomValue(0, 3);
                        dialog.SetNode(
                            farmColumn.Name + "を" + num.ToString() + "つ収穫しました\n" + 
                            "(品質" + Function.Quolity2String(farmColumn.GetQuolity()) + ")",
                            _parentNode);
                        GameData.PlayerData.Item[farmColumn.Id + Common.Parameter.SeedIdOffset, Function.Quolity2Index(farmColumn.GetQuolity())] += num;
                        GameData.PlayerData.AgricultureExperience += farmColumn.Exp;
                        if(GameData.PlayerData.AgricultureExperience >= GameData.PlayerData.AgricultureLevel * 25)
                        {
                            GameData.PlayerData.AgricultureLevel++;
                            _isLevelup = true;
                        }
                        farmColumn.Harvest();
                        UpdateDisplay();
                        return;
                    }
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
                UpdateDisplay();
            }
            if (_prevPageButton.Click(position))
            {
                page--;
                if(page == 0)
                {
                    _prevPageButton.RemoveNode(_parentNode);
                }
                _nextPageButton.SetNode(_parentNode);
                UpdateDisplay();
            }

        }

        public void UpdateDisplay()
        {
            int index = page * Common.Parameter.FarmPageMaxColumn;
            foreach (var farmColunm in farmColunms)
            {
                farmColunm.SetFarmData(GameData.PlayerData.farms[index]);
                index++;
            }
        }
    }
}
