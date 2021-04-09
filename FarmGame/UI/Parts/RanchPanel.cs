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
        RanchColumn ranchColumn;

        public RanchPanel()
        {
            ranchColumn = new RanchColumn();
            ranchColumn.Icon.SetPosition(new Vector2F(iconXIndex, iconYIndex));
            ranchColumn.Window.SetPosition(new Vector2F(windowXIndex + ranchColumn.Icon.Width, windowYIndex));
            ranchColumn.CareButton.SetPosition(new Vector2F(iconXIndex + ranchColumn.Icon.Width + ranchColumn.Window.GetContentWidth() + 10, windowYIndex));
        }

        public void SetNode(Node parentNode)
        {
            ranchColumn.Icon.SetNode(parentNode);
            ranchColumn.Window.SetNode(parentNode);
            ranchColumn.CareButton.SetNode(parentNode);
        }
    }

}
