using Altseed2;
using FarmGame.UI.Parts;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmGame.UI
{
    class SeedWindow
    {

        private bool _valid = false;
        private List<SeedButton> seedButtons = new List<SeedButton>();
        private SpriteNode _node;
        private Node _parentNode;
        private Button _okButton;
        private Button _cancelButton;
        private FarmColunm _farmColunm;

        private const float buttonScale = 0.6f;
        private const int seedYInterval = 40;
        public SeedWindow(Node parentNode, FarmColunm farmColunm)
        {
            _node = new SpriteNode();
            _node.Texture = Texture.SeedWindow;
            _node.Src = new RectF(0, 680, 900, 220);
            _node.Position = new Vector2F(0, 170);
            _node.Scale = new Vector2F(1.0f, 1.5f);
            _node.ZOrder = Parameter.ZOrder.Dialog;

            _okButton = new Button(Texture.OKButton, Texture.OKButtonHover, Texture.OKButtonClick);
            _okButton.SetPosition(new Vector2F(230, 410));
            _okButton.SetScale(buttonScale);
            _okButton.SetZOrder(Parameter.ZOrder.Seed);
            _cancelButton = new Button(Texture.CancelButton, Texture.CancelButtonHover, Texture.CancelButtonClick);
            _cancelButton.SetPosition(new Vector2F(430, 410));
            _cancelButton.SetScale(buttonScale);
            _cancelButton.SetZOrder(Parameter.ZOrder.Seed);

            foreach(var seed in GameData.GameStatus.Plants)
            {
                if(GameData.PlayerData.Seed.Length > seed.id)
                {
                    SeedButton seedButton = new SeedButton(Texture.SeedButton, Texture.SeedButtonPush, seed.name, GameData.PlayerData.Seed[seed.id], seed.id);
                    seedButtons.Add(seedButton);
                }
            }

            _parentNode = parentNode;
            _farmColunm = farmColunm;
        }

        public void Show()
        {
            _valid = true;
            _parentNode.AddChildNode(_node);
            int index = 0;
            foreach(var seedButton in seedButtons)
            {
                seedButton.SetPosition(new Vector2F(30, 190 + seedYInterval * index));
                seedButton.SetNode(_parentNode);
                index++;
            }
            _cancelButton.SetNode(_parentNode);
        }

        public void Hide()
        {
            _valid = false;
            _parentNode.RemoveChildNode(_node);
            foreach (var seedButton in seedButtons)
            {
                seedButton.RemoveNode(_parentNode);
            }
            _okButton.RemoveNode(_parentNode);
            _cancelButton.RemoveNode(_parentNode);
        }

        public bool IsShow()
        {
            return _valid;
        }

        public void OnMouse(Vector2F position)
        {
            _okButton.Hover(position);
            _cancelButton.Hover(position);
        }

        public void OnClick(Vector2F position)
        {
            if (_okButton.Click(position))
            {
                foreach(var seedButton in seedButtons)
                {
                    if (seedButton.GetButtonStatus())
                    {
                        _farmColunm.SetSeed(seedButton.GetSeedId());
                    }
                }
                Hide();
            }
            if(_cancelButton.Click(position))
            {
                Hide();
            }
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
                    if(seedButton.Equals(pushedSeedButton))
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
