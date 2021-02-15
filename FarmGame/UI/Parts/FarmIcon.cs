using Altseed2;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmGame.UI.Parts
{
    class FarmIcon
    {
        public enum Type
        {
            Empty,
            Wheat
        }

        private SpriteNode _node;
        private Type _type;

        public FarmIcon()
        {
            _node = new SpriteNode();
            setClip(Type.Empty, 0);
            _node.Scale = new Vector2F(2, 2);
            _node.ZOrder = CommonParameter.ZOrder.Farm;
        }

        public void SetPosition(Vector2F pos)
        {
            _node.Position = pos;
        }

        public void SetNode(Node parentNode)
        {
            parentNode.AddChildNode(_node);
        }

        private void setClip(Type type, int growth)
        {
            switch(type)
            {
                case Type.Empty:
                    _node.Texture = Texture.FarmTexture1;
                    _node.Src = new RectF(0, 0, _node.ContentSize.X / 12, _node.ContentSize.Y / 8);
                    break;
                default:
                    break;
            }
        }
    }
}
