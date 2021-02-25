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
        private TextNode _text = null;
        private Texture2D _texture = null;
        private Texture2D _texturePush = null;
        private Vector2F _position;
        private int _width;
        private int _height;

        public SeedButton(Texture2D texture, Texture2D texturePush, string name, int num)
        {
            _node = new SpriteNode();
            _texture = texture;
            _texturePush = texturePush;
            _node.Texture = texture;
            _node.ZOrder = CommonParameter.ZOrder.Seed;

            _text = new TextNode();
            _text.Font = Font.LoadDynamicFontStrict("HachiMaruPop-Regular.ttf", 40);
            _text.Color = new Color(0, 0, 0);
            _text.ZOrder = CommonParameter.ZOrder.Seed;
            _text.Text = name + "の種×" + num.ToString();
            _width = 300;
            _height = 35;
        }

        public int GetWidth()
        {
            return _width;
        }

        public int GetHeight()
        {
            return _height;
        }

        public void SetPosition(Vector2F position)
        {
            _position = position;
            _node.Position = position;
            _text.Position = position;
        }

        public void SetNode(Node parent)
        {
            parent.AddChildNode(_node);
            parent.AddChildNode(_text);
        }

        public void SetZOrder(int zOrder)
        {
            _node.ZOrder = zOrder;
            _text.ZOrder = zOrder;
        }

        public void RemoveNode(Node parent)
        {
            parent.RemoveChildNode(_node);
            parent.RemoveChildNode(_text);
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

        public void SetClick(bool set)
        {
            _pushStatus = set;
            if (set)
            {
                _node.Texture = _texturePush;
            }
            else
            {
                _node.Texture = _texture;
            }
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

        public void SetUnpush()
        {
            _pushStatus = false;
            _node.Texture = _texture;
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
