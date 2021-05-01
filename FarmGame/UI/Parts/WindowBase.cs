using Altseed2;
using FarmGame.UI.Parts;
using FarmGame.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmGame.UI.Parts
{
    class WindowBase
    {
        private bool _valid = false;
        protected SpriteNode _node;
        protected Button _okButton;
        protected Button _cancelButton;
        protected Node _parentNode;

        private const float buttonScale = 0.6f;

        public WindowBase(Node parentNode)
        {
            _node = new SpriteNode();
            _node.Texture = Texture.SeedWindow;
            _node.Src = new RectF(0, 680, 900, 220);
            _node.Position = new Vector2F(0, 170);
            _node.Scale = new Vector2F(1.0f, 1.5f);
            _node.ZOrder = Common.Parameter.ZOrder.Dialog;

            _okButton = new Button(Texture.OKButton, Texture.OKButtonHover, Texture.OKButtonClick);
            _okButton.SetPosition(new Vector2F(230, 410));
            _okButton.SetScale(buttonScale);
            _okButton.SetZOrder(Common.Parameter.ZOrder.Seed);
            _cancelButton = new Button(Texture.CancelButton, Texture.CancelButtonHover, Texture.CancelButtonClick);
            _cancelButton.SetPosition(new Vector2F(430, 410));
            _cancelButton.SetScale(buttonScale);
            _cancelButton.SetZOrder(Common.Parameter.ZOrder.Seed);

            _parentNode = parentNode;
        }

        virtual public void Show()
        {
            _valid = true;
            _parentNode.AddChildNode(_node);
            _cancelButton.SetNode(_parentNode);
        }
        virtual public void Hide()
        {
            _valid = false;
            _parentNode.RemoveChildNode(_node);
            _okButton.RemoveNode(_parentNode);
            _cancelButton.RemoveNode(_parentNode);
        }
        public bool IsShow()
        {
            return _valid;
        }

        virtual public void OnMouse(Vector2F position)
        {
            _okButton.Hover(position);
            _cancelButton.Hover(position);
        }

        virtual public void OnClick(Vector2F position)
        {

        }
    }
}
