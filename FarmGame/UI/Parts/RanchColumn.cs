using FarmGame.Common;
using FarmGame.Model;
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
            CareButton.Lock();
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

        public void SetRanchData(Ranch ranch)
        {
            _ranch = ranch;
            if(ranch == null)
            {
                Icon.SetClip(RanchIcon.Type.Empty, 0);
                Window.SetText(string.Empty);
                CareButton.Lock();
            }
            else
            {
                Icon.SetClip(Function.GetId2RanchType(_ranch.id), _ranch.growth);
                Window.SetText(Function.SearchItemById(_ranch.id).name);
                if(_ranch.care)
                {
                    CareButton.Lock();
                }
                else
                {
                    CareButton.Unlock();
                }
            }
        }
        /**
         * <summary>お手入れ処理</summary>
         * */
        public void Care()
        {
            if (_ranch != null && !_ranch.care)
            {
                _ranch.care = true;
                _ranch.quality += GameData.PlayerData.DairyLevel;
                GameData.PlayerData.Power--;
                CareButton.Lock();
            }
        }

    }
}
