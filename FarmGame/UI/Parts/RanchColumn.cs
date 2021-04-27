using FarmGame.Common;
using FarmGame.Model;
using System;
using System.Collections.Generic;
using System.Text;
using static FarmGame.Common.Parameter;

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
            CareButton.SetZOrder(ZOrder.Ranch);
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
        public int Id
        {
            get
            {
                if (_ranch == null)
                {
                    return -1;
                }
                else
                {
                    return _ranch.id;
                }
            }
        }
        public int Exp
        {
            get
            {
                return Function.SearchAnimalById(_ranch.id).cost;
            }
        }

        public bool IsHarvest
        {
            get
            {
                if (_ranch != null && _ranch.growth >= 100)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public string HarvestItemName
        {
            get
            {
                return Function.SearchItemById(Function.SearchAnimalById(_ranch.id).product).name;
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
                if(_ranch.growth < 100)
                {
                    Window.SetText(Function.SearchItemById(_ranch.id).name);
                }
                else
                {
                    Window.SetText(Function.SearchItemById(_ranch.id).name + 
                        "(" + HarvestItemName + ")");
                }
                if (_ranch.care)
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
        public Quality GetQuolity()
        {
            int maxQuolity = Function.SearchAnimalById(_ranch.id).cost * 150;
            int quolity = _ranch.quality * 100 / maxQuolity;
            return Function.QualityByValue(quolity);
        }
        public void Harvest()
        {
            _ranch.growth = 0;
            _ranch.care = false;
            _ranch.quality = 0;
            CareButton.Lock();
        }

    }
}
