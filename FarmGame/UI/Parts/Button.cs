using System;
using System.Collections.Generic;
using System.Text;
using Altseed2;

namespace FarmGame.UI.Parts
{
    class Button
    {
        private bool _valid = false;
        private SpriteNode _node = null;
        private Texture2D _texture = null;
        private Texture2D _textureHover = null;
        private Texture2D _textureClick = null;
        private Vector2F _position;
        private int _width;
        private int _height;

        public Button(Texture2D texture, Texture2D textureHover, Texture2D textureClick)
        {
            _node = new SpriteNode();
            _texture = texture;
            _textureHover = textureHover;
            _textureClick = textureClick;
            _node.Texture = _texture;
            _width = _texture.Size.X;
            _height = _texture.Size.Y;
        }

        public void SetPosition(Vector2F position)
        {
            _position = position;
            _node.Position = _position;
        }

        public void SetScale(float scale)
        {
            _width = (int)(_texture.Size.X * scale);
            _height = (int)(_texture.Size.Y * scale);
            _node.Scale = new Vector2F(scale, scale);
        }

        public void SetZOrder(int zOrder)
        {
            _node.ZOrder = zOrder;
        }

        public void SetNode(Node parentNode)
        {
            _valid = true;
            parentNode.AddChildNode(_node);
        }

        public void RemoveNode(Node parentNode)
        {
            if(_valid)
            {
                _valid = false;
                parentNode.RemoveChildNode(_node);
            }
        }

        public void Hover(Vector2F pos)
        {
            if (_valid == true)
            {
                if (isOnMouse(pos))
                {
                    _node.Texture = _textureHover;
                }
                else
                {
                    _node.Texture = _texture;
                }
            }
        }

        public bool Click(Vector2F pos)
        {
            if(_valid == true)
            {
                if (isOnMouse(pos))
                {
                    _node.Texture = _textureClick;
                    return true;
                }
                else
                {
                    _node.Texture = _texture;
                    return false;
                }
            }
            else
            {
                return false;
            }
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
