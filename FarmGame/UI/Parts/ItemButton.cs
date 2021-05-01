using Altseed2;
using FarmGame.Common;
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

        public ItemButton(Texture2D texture, Texture2D textureValid, Recipe recipe) : base()
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
            TextUpdate();

            _width = _texture.Size.X;
            _height = _texture.Size.Y;
        }

        public void SetRecipe(Recipe recipe)
        {
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
            TextUpdate();
        }

        public void TextUpdate()
        {
            if(_recipe == null)
            {
                _text.Text = "";
                return;
            }
            var item = Function.SearchItemById(_recipe.id);
            int itemnum = 0;
            if (item != null)
            {
                if (item.id < Common.Parameter.SeedIdOffset)
                {
                    itemnum = GameData.PlayerData.Seed[item.id];
                }
                else
                {
                    for (int quolity = 0; quolity < Common.Parameter.QuolityMaxNum; quolity++)
                    {
                        itemnum += GameData.PlayerData.Item[item.id, quolity];
                    }
                }
                _text.Text = item.name + "×" + itemnum.ToString();
            }
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

        public Model.Recipe GetRecipe()
        {
            if(_recipe != null)
            {
                return _recipe;
            }
            else
            {
                return null;
            }
        }
    }
}
