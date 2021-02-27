using System;
using System.Collections.Generic;
using System.Text;
using Altseed2;

namespace FarmGame.UI.Parts
{
    class PlantWindow
    {
        private SpriteNode _node;

        public PlantWindow()
        {
            _node = new SpriteNode();
            _node.Texture = Texture.FarmWindow;
            var scale = Texture.FarmWindow.Size.Y * 1.5f / (Texture.FarmTexture1.Size.Y / 8.0f);
            _node.Scale = new Vector2F(scale, scale);
            _node.ZOrder = FarmGame.Parameter.ZOrder.Farm;
        }

        public void SetPosition(Vector2F pos)
        {
            _node.Position = pos;
        }

        public void SetNode(Node parentNode)
        {
            parentNode.AddChildNode(_node);
        }

        public void RemoveNode(Node parentNode)
        {
            parentNode.RemoveChildNode(_node);
        }

    }
}
