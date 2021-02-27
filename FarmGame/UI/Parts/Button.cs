using System;
using System.Collections.Generic;
using System.Text;
using Altseed2;

namespace FarmGame.UI.Parts
{
    class Button : ButtonBase
    {
        private bool _valid = false;
        private Texture2D _texture = null;
        private Texture2D _textureHover = null;
        private Texture2D _textureClick = null;

        public Button(Texture2D texture, Texture2D textureHover, Texture2D textureClick) : base()
        {
            _texture = texture;
            _textureHover = textureHover;
            _textureClick = textureClick;
            _node.Texture = _texture;
            _width = _texture.Size.X;
            _height = _texture.Size.Y;
        }

        override public void SetScale(float scale)
        {
            _width = (int)(_texture.Size.X * scale);
            _height = (int)(_texture.Size.Y * scale);
            _node.Scale = new Vector2F(scale, scale);
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
    }
}
