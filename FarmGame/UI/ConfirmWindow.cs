using Altseed2;
using FarmGame.Common;
using FarmGame.UI.Parts;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmGame.UI
{
    class ConfirmWindow : WindowBase
    {
        private const float buttonScale = 0.6f;
        protected SpriteNode _node2;
        new private Button _okButton;
        new private Button _cancelButton;
        private TextNode[] _message = new TextNode[5];
        private Action _callback;

        public ConfirmWindow(Node parent, string message, Action confirmCallback) : base(parent)
        {
            _callback = confirmCallback;

            _node.Src = new RectF(0, 680, 300, 220);
            _node.Position = new Vector2F(150, 170);
            _node.ZOrder = Common.Parameter.ZOrder.Confirm;

            _node2 = new SpriteNode();
            _node2.Texture = Texture.SeedWindow;
            _node2.Src = new RectF(600, 680, 300, 220);
            _node2.Position = new Vector2F(450, 170);
            _node2.Scale = new Vector2F(1.0f, 1.5f);
            _node2.ZOrder = Common.Parameter.ZOrder.Confirm;

            var messages = message.Split("\n");
            int i = 0;
            foreach (var m in messages)
            {
                _message[i] = new TextNode();
                _message[i].Font = Font.LoadDynamicFontStrict("HachiMaruPop-Regular.ttf", 40);
                _message[i].Color = new Color(0, 0, 0);
                _message[i].Text = m;
                _message[i].Position = new Vector2F(200, 200 + _message[i].ContentSize.Y * i);
                _message[i].ZOrder = Common.Parameter.ZOrder.Confirm;
                i++;
            }

            _okButton = new Button(Texture.OKButton, Texture.OKButtonHover, Texture.OKButtonClick);
            _okButton.SetPosition(new Vector2F(230, 410));
            _okButton.SetScale(buttonScale);
            _okButton.SetZOrder(Common.Parameter.ZOrder.Confirm);
            _cancelButton = new Button(Texture.CancelButton, Texture.CancelButtonHover, Texture.CancelButtonClick);
            _cancelButton.SetPosition(new Vector2F(430, 410));
            _cancelButton.SetScale(buttonScale);
            _cancelButton.SetZOrder(Common.Parameter.ZOrder.Confirm);

        }

        override public void Show()
        {
            base.Show();
            _parentNode.AddChildNode(_node2);
            foreach(var m in _message)
            {
                if(m == null)
                {
                    break;
                }
                _parentNode.AddChildNode(m);
            }
            _okButton.SetNode(_parentNode);
            _cancelButton.SetNode(_parentNode);
        }
        override public void Hide()
        {
            base.Hide();
            _parentNode.RemoveChildNode(_node2);
            foreach (var m in _message)
            {
                if (m == null)
                {
                    break;
                }
                _parentNode.RemoveChildNode(m);
            }
            _okButton.RemoveNode(_parentNode);
            _cancelButton.RemoveNode(_parentNode);
        }
        public override void OnMouse(Vector2F position)
        {
            _okButton.Hover(position);
            _cancelButton.Hover(position);
        }
        override public void OnClick(Vector2F position)
        {
            if(_okButton.IsClick(position))
            {
                Function.PlaySoundOK();
                _callback();
            }
            if(_cancelButton.IsClick(position))
            {
                Function.PlaySoundCancel();
                Hide();
            }
        }
    }
}
