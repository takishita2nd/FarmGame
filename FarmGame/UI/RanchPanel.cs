using Altseed2;
using FarmGame.Common;
using System;
using System.Collections.Generic;
using System.Text;
using static FarmGame.Common.Parameter;

namespace FarmGame.UI.Parts
{
    class RanchPanel
    {
        private const int iconXIndex = 60;
        private const int windowXIndex = iconXIndex + 5;
        private const int iconYIndex = 190;
        private const int windowYIndex = iconYIndex + 5;
        private const int columnInterval = 60;
        private const float careButtonScale = 0.6f;

        RanchColumn[] ranchColumns = new RanchColumn[Common.Parameter.RanchPageMaxColumn];
        private Button _allCareButton;
        private Button _nextPageButton;
        private Button _prevPageButton;
        private int page;
        private Node _parentNode = null;
        private Dialog dialog = new Dialog();
        private bool _isLevelup = false;

        public RanchPanel()
        {
            page = 0;
            for (int i = 0; i < Common.Parameter.RanchPageMaxColumn; i++)
            {
                ranchColumns[i] = new RanchColumn();
                ranchColumns[i].Icon.SetPosition(new Vector2F(iconXIndex, iconYIndex + columnInterval * i));
                int xPos = windowXIndex + ranchColumns[i].Icon.Width;
                ranchColumns[i].Window.SetPosition(new Vector2F(xPos, windowYIndex + columnInterval * i));
                xPos += ranchColumns[i].Window.GetContentWidth() + 10;
                ranchColumns[i].CareButton.SetPosition(new Vector2F(xPos, windowYIndex + columnInterval * i));
            }

            int j = 0;
            foreach(var r in GameData.PlayerData.ranches)
            {
                if(j >= Common.Parameter.RanchPageMaxColumn)
                {
                    break;
                }
                ranchColumns[j].SetRanchData(r);
                j++;
            }
            _allCareButton = new Button(Texture.AllCareButton, Texture.AllCareButtonHover, Texture.AllCareButtonClick);
            _allCareButton.SetPosition(new Vector2F(iconXIndex + ranchColumns[Common.Parameter.RanchPageMaxColumn - 1].Icon.Width + ranchColumns[Common.Parameter.RanchPageMaxColumn - 1].Window.GetContentWidth() + 10,
                windowYIndex + columnInterval * -1));
            _allCareButton.SetScale(careButtonScale);
            _allCareButton.SetZOrder(Common.Parameter.ZOrder.Farm);

            _nextPageButton = new Button(Texture.NextPageButton, Texture.NextPageButtonHover, Texture.NextPageButtonClick);
            _nextPageButton.SetPosition(new Vector2F(iconXIndex + ranchColumns[Common.Parameter.RanchPageMaxColumn - 1].Icon.Width + ranchColumns[Common.Parameter.RanchPageMaxColumn - 1].Window.GetContentWidth() + 10,
                windowYIndex + columnInterval * Common.Parameter.FarmPageMaxColumn + 1));
            _nextPageButton.SetScale(careButtonScale);
            _nextPageButton.SetZOrder(Common.Parameter.ZOrder.Farm);

            _prevPageButton = new Button(Texture.PrevPageButton, Texture.PrevPageButtonHover, Texture.PrevPageButtonClick);
            _prevPageButton.SetPosition(new Vector2F(iconXIndex + ranchColumns[Common.Parameter.RanchPageMaxColumn - 1].Icon.Width + ranchColumns[Common.Parameter.RanchPageMaxColumn - 1].Window.GetContentWidth() + 10 - ranchColumns[Common.Parameter.RanchPageMaxColumn - 1].CareButton.Width,
                windowYIndex + columnInterval * Common.Parameter.FarmPageMaxColumn + 1));
            _prevPageButton.SetScale(careButtonScale);
            _prevPageButton.SetZOrder(Common.Parameter.ZOrder.Farm);

        }

        public void SetNode(Node parentNode)
        {
            _parentNode = parentNode;
            foreach (var r in ranchColumns)
            {
                r.Icon.SetNode(parentNode);
                r.Window.SetNode(parentNode);
                r.CareButton.SetNode(parentNode);
            }
            _allCareButton.SetNode(parentNode);
            if (page != 0)
            {
                _prevPageButton.SetNode(parentNode);
            }
            if (GameData.PlayerData.ranches.Count > Common.Parameter.RanchPageMaxColumn)
            {
                _nextPageButton.SetNode(parentNode);
            }
        }

        public void Animetion()
        {
            foreach (var r in ranchColumns)
            {
                r.Icon.Animetion();
            }
        }

        public void OnMouse(Vector2F position)
        {
            if (dialog.IsShow)
            {
                return;
            }

            foreach (var column in ranchColumns)
            {
                column.CareButton.Hover(position);
            }
            _allCareButton.Hover(position);
            _nextPageButton.Hover(position);
            _prevPageButton.Hover(position);

        }

        public void OnClick(Vector2F position)
        {
            //ダイアログ表示中
            if (dialog.IsShow)
            {
                Function.PlaySoundOK();
                if (_isLevelup)
                {
                    dialog.UpdateText(
                        "酪農レベルが上がりました\n(" + GameData.PlayerData.DairyLevel.ToString() + ")"
                        );
                    _isLevelup = false;
                    return;
                }
                dialog.RemoveNode(_parentNode);
                return;
            }

            //お手入れボタン押下
            foreach (var column in ranchColumns)
            {
                if (column.CareButton.Click(position))
                {
                    Function.PlaySoundOK();
                    if (GameData.PlayerData.Power == 0)
                    {
                        dialog.SetNode("パワーが足りません", _parentNode);
                        return;
                    }
                    column.Care();
                    return;
                }
            }
            //全お手入れボタン押下
            if (_allCareButton.Click(position))
            {
                Function.PlaySoundOK();
                int count = 0;
                foreach (var column in ranchColumns)
                {
                    if (!column.CareButton.IsLocked)
                    {
                        count++;
                    }
                }
                if (count > GameData.PlayerData.Power)
                {
                    dialog.SetNode("パワーが足りません", _parentNode);
                    return;
                }

                foreach (var column in ranchColumns)
                {
                    column.Care();
                }
                return;
            }

            //収穫処理
            foreach(var column in ranchColumns)
            {
                if(column.Icon.IsClick(position))
                {
                    if(column.Valid && column.IsHarvest)
                    {
                        Function.PlaySoundOK();
                        //収穫可能
                        if (GameData.PlayerData.Power == 0)
                        {
                            dialog.SetNode("パワーが足りません", _parentNode);
                            return;
                        }
                        int num = 2 + Function.GetRandomValue(0, 3);
                        Quality q = column.GetQuolity();
                        dialog.SetNode(
                            column.HarvestItemName + "を" + num.ToString() + "つ収穫しました\n" +
                            "(品質" + Function.Quolity2String(q) + ")",
                            _parentNode);
                        GameData.PlayerData.Item[Function.SearchAnimalById(column.Id).product, Function.Quolity2Index(q)] += num;
                        GameData.PlayerData.DairyExperience += column.Exp;
                        if (GameData.PlayerData.DairyExperience >= GameData.PlayerData.DairyLevel * 25)
                        {
                            GameData.PlayerData.DairyExperience -= GameData.PlayerData.DairyLevel * 25;
                            GameData.PlayerData.DairyLevel++;
                            _isLevelup = true;
                        }
                        GameData.PlayerData.Power--;
                        column.Harvest();
                        UpdateDisplay();
                    }
                }
            }

            //ページング処理
            int maxPage = GameData.PlayerData.ranches.Count / Common.Parameter.RanchPageMaxColumn;

            if (_nextPageButton.Click(position))
            {
                Function.PlaySoundOK();
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
                Function.PlaySoundOK();
                page--;
                if (page == 0)
                {
                    _prevPageButton.RemoveNode(_parentNode);
                }
                _nextPageButton.SetNode(_parentNode);
                UpdateDisplay();
            }

        }
        public void UpdateDisplay()
        {
            int index = page * Common.Parameter.RanchPageMaxColumn;
            foreach (var ranchColumn in ranchColumns)
            {
                if(index < GameData.PlayerData.ranches.Count)
                {
                    ranchColumn.SetRanchData(GameData.PlayerData.ranches[index]);
                    index++;
                }
                else
                {
                    ranchColumn.SetRanchData(null);
                }
            }
        }

    }

}
