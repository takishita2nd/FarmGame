using System;
using System.Collections.Generic;
using System.Text;
using Altseed2;

namespace FarmGame
{
    public static class Texture
    {
        private static Texture2D _textureButton = null;
        public static Texture2D TextureButton
        {
            get
            {
                if (_textureButton == null)
                {
                    _textureButton = Texture2D.Load("002_03.png");
                }
                return _textureButton;
            }
        }
    }
}
