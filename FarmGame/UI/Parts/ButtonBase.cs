using Altseed2;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmGame.UI.Parts
{
    class ButtonBase
    {
        protected bool _valid = false;
        protected SpriteNode _node = null;
        protected Vector2F _position;
        protected int _width;
        protected int _height;

        public ButtonBase()
        {
            _node = new SpriteNode();
        }

        virtual public void SetScale(float scale)
        {
            _node.Scale = new Vector2F(scale, scale);
        }
        virtual public void SetPosition(Vector2F position)
        {
            _position = position;
            _node.Position = _position;
        }
        virtual public void SetZOrder(int zOrder)
        {
            _node.ZOrder = zOrder;
        }

        virtual public void SetNode(Node parentNode)
        {
            _valid = true;
            parentNode.AddChildNode(_node);
        }
        virtual public void RemoveNode(Node parentNode)
        {
            if (_valid)
            {
                _valid = false;
                parentNode.RemoveChildNode(_node);
            }
        }


        public bool IsClick(Vector2F pos)
        {
            if (isOnMouse(pos))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        protected bool isOnMouse(Vector2F pos)
        {
            if (pos.X >= _position.X && pos.X <= _position.X + _width
                && pos.Y >= _position.Y && pos.Y <= _position.Y + _height)
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
