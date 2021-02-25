using Altseed2;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmGame.UI.Parts
{
    class SeedButton
    {
        private bool _pushStatus = false;
        private SpriteNode _node = null;
        private Texture2D _texture = null;
        private Texture2D _texturePush = null;
        private Vector2F _position;
        private int _width;
        private int _height;

        public SeedButton(Texture2D texture, Texture2D texturePush)
        {
            _node = new SpriteNode();
            _texture = texture;
            _texturePush = texturePush;
            _node.Texture = texture;
            _node.ZOrder = CommonParameter.ZOrder.Seed;
            _width = 150;
            _height = 35;
        }

        public void SetPosition(Vector2F position)
        {
            _position = position;
            _node.Position = position;
        }

        public void SetNode(Node parent)
        {
            parent.AddChildNode(_node);
        }

        public void SetZOrder(int zOrder)
        {
            _node.ZOrder = zOrder;
        }

        public void RemoveNode(Node parent)
        {
            parent.RemoveChildNode(_node);
        }

        public bool Click(Vector2F pos)
        {
            if (isOnMouse(pos))
            {
                _pushStatus = !_pushStatus;
                if (_pushStatus)
                {
                    _node.Texture = _texturePush;
                }
                else
                {
                    _node.Texture = _texture;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool GetButtonStatus()
        {
            return _pushStatus;
        }

        private bool isOnMouse(Vector2F pos)
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
