using Altseed2;
using System;
using System.Collections.Generic;
using System.Text;

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
                if(j > Common.Parameter.RanchPageMaxColumn)
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
            foreach(var r in ranchColumns)
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
    }

}
