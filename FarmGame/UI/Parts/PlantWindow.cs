using System;
using System.Collections.Generic;
using System.Text;
using Altseed2;

namespace FarmGame.UI.Parts
{
    class PlantWindow
    {
        private SpriteNode _node;
        private TextNode _text;

        public PlantWindow()
        {
            _node = new SpriteNode();
            _node.Texture = Texture.FarmWindow;
            var scale = Texture.FarmWindow.Size.Y * 1.5f / (Texture.FarmTexture1.Size.Y / 8.0f);
            _node.Scale = new Vector2F(scale, scale);
            _node.ZOrder = FarmGame.Parameter.ZOrder.Farm;

            _text = new TextNode();
            _text.Font = Font.LoadDynamicFontStrict("HachiMaruPop-Regular.ttf", 40);
            _text.Color = new Color(0, 0, 0);
            _text.ZOrder = FarmGame.Parameter.ZOrder.Farm;
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
