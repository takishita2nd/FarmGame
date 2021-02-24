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
        private int _width;
        private int _height;

        public FarmIcon()
        {
            _node = new SpriteNode();
            setClip(Type.Empty, 0);
            _node.Scale = new Vector2F(2.5f, 2.5f);
            _width = (int)(_node.ContentSize.X * 2.5f);
            _height = (int)(_node.ContentSize.Y * 2.5f);
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

        public void RemoveNode(Node parentNode)
        {
            parentNode.RemoveChildNode(_node);
        }
        public bool IsClick(Vector2F pos)
        {
            if(isOnMouse(pos))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void setClip(Type type, int growth)
        {
            switch(type)
            {
                case Type.Empty:
                    _node.Texture = Texture.FarmTexture1;
                    _node.Src = new RectF(0, 0, _node.ContentSize.X / 12.0f, _node.ContentSize.Y / 8.0f);
                    break;
                default:
                    break;
            }
        }
        private bool isOnMouse(Vector2F pos)
        {
            if (pos.X >= _node.Position.X && pos.X <= _node.Position.X + _width
                && pos.Y >= _node.Position.Y && pos.Y <= _node.Position.Y + _height)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
