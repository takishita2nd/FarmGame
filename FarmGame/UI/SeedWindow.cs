using Altseed2;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmGame.UI
{
    class SeedWindow
    {
        private SpriteNode _node;
        private Node _parentNode;
        private FarmColunm _farmColunm;
        public SeedWindow(Node parentNode, FarmColunm farmColunm)
        {
            _node = new SpriteNode();
            _node.Texture = Texture.SeedWindow;
            _node.Src = new RectF(0, 680, 900, 220);
            _node.ZOrder = CommonParameter.ZOrder.Dialog;
            _parentNode = parentNode;
            _farmColunm = farmColunm;
        }

        public void SetPosition(Vector2F pos)
        {
            _node.Position = pos;
        }

        public void SetScale(Vector2F scale)
        {
            _node.Scale = scale;
        }

        public void Show()
        {
            _parentNode.AddChildNode(_node);
        }

        public void Hide()
        {
            _parentNode.RemoveChildNode(_node);
        }
    }
}
