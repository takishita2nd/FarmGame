using Altseed2;
using FarmGame.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmGame.UI.Parts
{
    class ItemButton : ButtonBase
    {
        private Recipe _recipe;
        public bool IsValid
        {
            get
            {
                return _valid;
            }
        }

        private Texture2D _texture = null;
        private Texture2D _textureValid = null;
        private TextNode _text = null;

        public ItemButton(Texture2D texture, Texture2D textureValid, string name, int num, Recipe recipe) : base()
        {
            _texture = texture;
            _textureValid = textureValid;
            if (recipe == null)
            {
                SetValid(false);
                _recipe = null;
            }
            else
            {
                SetValid(true);
                _recipe = recipe;
            }

            _text = new TextNode();
            _text.Font = Font.LoadDynamicFontStrict("HachiMaruPop-Regular.ttf", 40);
            _text.Color = new Color(0, 0, 0);
            _text.ZOrder = Common.Parameter.ZOrder.Seed;
            if(name != string.Empty)
            {
                _text.Text = name + "×" + num.ToString();
            }

            _width = _texture.Size.X;
            _height = _texture.Size.Y;
        }

        override public void SetPosition(Vector2F position)
        {
            _position = position;
            _node.Position = position;
            _text.Position = position;
        }

        override public void SetNode(Node parent)
        {
            parent.AddChildNode(_node);
            parent.AddChildNode(_text);
        }

        override public void SetZOrder(int zOrder)
        {
            _node.ZOrder = zOrder;
            _text.ZOrder = zOrder;
        }

        override public void RemoveNode(Node parent)
        {
            parent.RemoveChildNode(_node);
            parent.RemoveChildNode(_text);
        }

        public void SetValid(bool valid)
        {
            if(valid)
            {
                _valid = true;
                _node.Texture = _textureValid;
            }
            else
            {
                _valid = false;
                _node.Texture = _texture;
            }
        }

        public Model.Material[] GetRecipe()
        {
            if(_recipe != null)
            {
                return _recipe.material;
            }
            else
            {
                return null;
            }
        }
    }
}
