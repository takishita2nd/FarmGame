using Altseed2;
using FarmGame.Common;
using FarmGame.UI.Parts;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmGame.UI
{
    class SeedWindow : WindowBase
    {

        private List<SeedButton> seedButtons = new List<SeedButton>();
        private FarmColunm _farmColunm = null;

        private const int seedYInterval = 40;
        private const int seedXInterval = 320;
        private const int seedIndex = 5;
        public SeedWindow(Node parentNode, FarmColunm farmColunm) : base(parentNode)
        {
            foreach(var seed in GameData.GameStatus.Plants)
            {
                if(GameData.PlayerData.Seed.Length > seed.id)
                {
                    SeedButton seedButton = new SeedButton(Texture.SeedButton, Texture.SeedButtonPush, seed.name, GameData.PlayerData.Seed[seed.id], seed.id);
                    seedButtons.Add(seedButton);
                }
            }

            _farmColunm = farmColunm;
        }

        override public void Show()
        {
            base.Show();
            int index = 0;
            foreach(var seedButton in seedButtons)
            {
                if (index < seedIndex)
                {
                    seedButton.SetPosition(new Vector2F(30, 190 + seedYInterval * index));
                }
                else
                {
                    seedButton.SetPosition(new Vector2F(30 + seedXInterval, 190 + seedYInterval * (index - seedIndex)));
                }
                seedButton.SetNode(_parentNode);
                index++;
            }
        }

        override public void Hide()
        {
            base.Hide();
            foreach (var seedButton in seedButtons)
            {
                seedButton.RemoveNode(_parentNode);
            }
        }


        /**
         * <summary>種ウィンドウのクリック処理</summary>
         * */
        override public void OnClick(Vector2F position)
        {
            //OKボタン押下
            if (_okButton.Click(position))
            {
                Function.PlaySoundOK();
                foreach (var seedButton in seedButtons)
                {
                    if (seedButton.GetButtonStatus())
                    {
                        _farmColunm.SetSeed(seedButton.GetSeedId());
                        GameData.PlayerData.Power--;
                    }
                }
                Hide();
            }
            //キャンセルボタン押下
            if (_cancelButton.Click(position))
            {
                Function.PlaySoundCancel();
                Hide();
            }
            //種ボタン押下
            SeedButton pushedSeedButton = null;
            foreach (var seedButton in seedButtons)
            {
                if(seedButton.IsClick(position) && GameData.PlayerData.Seed[seedButton.GetSeedId()] > 0)
                {
                    pushedSeedButton = seedButton;
                    break;
                }
            }
            foreach (var seedButton in seedButtons)
            {
                if(pushedSeedButton != null){
                    if (seedButton.Equals(pushedSeedButton))
                    {
                        pushedSeedButton.Click(position);
                    }
                    else
                    {
                        seedButton.SetUnpush();
                    }
                }
            }
            bool showOK = false;
            foreach (var seedButton in seedButtons)
            {
                showOK |= seedButton.GetButtonStatus();
            }
            if (showOK)
            {
                _okButton.SetNode(_parentNode);
            }
            else
            {
                _okButton.RemoveNode(_parentNode);
            }
        }
    }
}
