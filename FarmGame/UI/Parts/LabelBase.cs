using Altseed2;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmGame.UI.Parts
{
    class LabelBase
    {
        protected SpriteNode _node;
        protected TextNode _text;
        public LabelBase()
        {
            _node = new SpriteNode();
            _node.Texture = Texture.FarmWindow;

            _text = new TextNode();
            _text.Font = Font.LoadDynamicFontStrict("HachiMaruPop-Regular.ttf", 40);
            _text.Color = new Color(0, 0, 0);
        }

        public void SetPosition(Vector2F pos)
        {
            _node.Position = pos;
            _text.Position = pos;
        }

        public void SetNode(Node parentNode)
        {
            parentNode.AddChildNode(_node);
            parentNode.AddChildNode(_text);
        }

        public void RemoveNode(Node parentNode)
        {
            parentNode.RemoveChildNode(_node);
            parentNode.RemoveChildNode(_text);
        }

        public void SetText(string text)
        {
            _text.Text = text;
        }
    }
}
