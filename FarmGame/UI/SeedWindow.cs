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
            _node.ZOrder = CommonParameter.ZOrder.Dialog;

            _okButton = new Button(Texture.OKButton, Texture.OKButtonHover, Texture.OKButtonClick);
            _okButton.SetPosition(new Vector2F(230, 410));
            _okButton.SetScale(buttonScale);
            _okButton.SetZOrder(CommonParameter.ZOrder.Seed);
            _cancelButton = new Button(Texture.CancelButton, Texture.CancelButtonHover, Texture.CancelButtonClick);
            _cancelButton.SetPosition(new Vector2F(430, 410));
            _cancelButton.SetScale(buttonScale);
            _cancelButton.SetZOrder(CommonParameter.ZOrder.Seed);

            foreach(var seed in GameData.GameStatus.Plants)
            {
                if(GameData.PlayerData.Seed.Length > seed.id)
                {
                    SeedButton seedButton = new SeedButton(Texture.SeedButton, Texture.SeedButtonPush);
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
                Hide();
            }
            if(_cancelButton.Click(position))
            {
                Hide();
            }
            foreach(var seedButton in seedButtons)
            {
                if (seedButton.Click(position))
                {
                    if(seedButton.GetButtonStatus())
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
    }
}
