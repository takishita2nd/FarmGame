using System;
using System.Collections.Generic;
using System.Text;

namespace FarmGame.UI.Parts
{
    class RanchColumn
    {
        public RanchIcon Icon;
        public RanchLabel Window;
        public Button CareButton;
        private Model.Ranch _ranch;

        public RanchColumn()
        {
            Icon = new RanchIcon();
            Window = new RanchLabel();
            CareButton = new Button(Texture.CareButton, Texture.CareButtonHover, Texture.CareButtonClick);
            CareButton.SetZOrder(Common.Parameter.ZOrder.Ranch);
            CareButton.SetScale(0.6f);
        }

        public bool Valid
        {
            get
            {
                if (_ranch == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

    }
}
