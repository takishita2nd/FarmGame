using Altseed2;
using FarmGame.Common;
using FarmGame.UI.Parts;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmGame.UI
{
    class NumberInputWindow : WindowBase
    {
        protected SpriteNode _node2;
        new private Button _okButton;
        new private Button _cancelButton;
        private TextNode _itemName;
        private TextNode[] _number = new TextNode[2];
        private TextNode[] _upButton = new TextNode[2];
        private TextNode[] _downButton = new TextNode[2];
        private TextNode _calcNumber;
        private int[] _inputValue = { 1, 0 };
        private int _money;
        private int _id;
        private const float buttonScale = 0.6f;
        private const int xPosition = 370;
        private const int yPosition = 260;
        private const int xInterval = 30;
        private const int yInterval = 40;
        private const string upString = "▲";
        private const string downString = "▼";
        private Dialog _dialog;
        private Common.Parameter.Quality _quority;

        public NumberInputWindow(Node parent, int id, int money) : base(parent)
        {
            _id = id;
            _money = money;
            _quority = Common.Parameter.Quality.Empty;

            createWindow(id, money);
        }
        public NumberInputWindow(Node parent, int id, int money, Common.Parameter.Quality quality) : base(parent)
        {
            _id = id;
            _money = money;
            _quority = quality;

            createWindow(id, money);
        }

        private void createWindow(int id, int money)
        {
            _node.Src = new RectF(0, 680, 300, 220);
            _node.Position = new Vector2F(150, 170);
            _node.ZOrder = Common.Parameter.ZOrder.NumberInput;

            _node2 = new SpriteNode();
            _node2.Texture = Texture.SeedWindow;
            _node2.Src = new RectF(600, 680, 300, 220);
            _node2.Position = new Vector2F(450, 170);
            _node2.Scale = new Vector2F(1.0f, 1.5f);
            _node2.ZOrder = Common.Parameter.ZOrder.NumberInput;

            _itemName = new TextNode();
            _itemName.Font = Font.LoadDynamicFontStrict("HachiMaruPop-Regular.ttf", 40);
            _itemName.Color = new Color(0, 0, 0);
            if(_quority == Common.Parameter.Quality.Empty)
            {
                _itemName.Text = Function.SearchItemById(id).name;
            }
            else
            {
                _itemName.Text = Function.SearchItemById(id).name + "(品質:" + Function.Quolity2String(_quority) + ")";
            }
            _itemName.Position = new Vector2F(200, 200);
            _itemName.ZOrder = Common.Parameter.ZOrder.NumberInput;

            _upButton[1] = new TextNode();
            _upButton[1].Font = Font.LoadDynamicFontStrict("HachiMaruPop-Regular.ttf", 40);
            _upButton[1].Color = new Color(0, 0, 0);
            _upButton[1].Text = upString;
            _upButton[1].Position = new Vector2F(xPosition, yPosition);
            _upButton[1].ZOrder = Common.Parameter.ZOrder.NumberInput;

            _upButton[0] = new TextNode();
            _upButton[0].Font = Font.LoadDynamicFontStrict("HachiMaruPop-Regular.ttf", 40);
            _upButton[0].Color = new Color(0, 0, 0);
            _upButton[0].Text = upString;
            _upButton[0].Position = new Vector2F(xPosition + xInterval, yPosition);
            _upButton[0].ZOrder = Common.Parameter.ZOrder.NumberInput;

            _number[1] = new TextNode();
            _number[1].Font = Font.LoadDynamicFontStrict("HachiMaruPop-Regular.ttf", 40);
            _number[1].Color = new Color(0, 0, 0);
            _number[1].Text = _inputValue[1].ToString();
            _number[1].Position = new Vector2F(xPosition, yPosition + yInterval);
            _number[1].ZOrder = Common.Parameter.ZOrder.NumberInput;

            _number[0] = new TextNode();
            _number[0].Font = Font.LoadDynamicFontStrict("HachiMaruPop-Regular.ttf", 40);
            _number[0].Color = new Color(0, 0, 0);
            _number[0].Text = _inputValue[0].ToString();
            _number[0].Position = new Vector2F(xPosition + xInterval, yPosition + yInterval);
            _number[0].ZOrder = Common.Parameter.ZOrder.NumberInput;

            _downButton[1] = new TextNode();
            _downButton[1].Font = Font.LoadDynamicFontStrict("HachiMaruPop-Regular.ttf", 40);
            _downButton[1].Color = new Color(0, 0, 0);
            _downButton[1].Text = downString;
            _downButton[1].Position = new Vector2F(xPosition, yPosition + yInterval * 2);
            _downButton[1].ZOrder = Common.Parameter.ZOrder.NumberInput;

            _downButton[0] = new TextNode();
            _downButton[0].Font = Font.LoadDynamicFontStrict("HachiMaruPop-Regular.ttf", 40);
            _downButton[0].Color = new Color(0, 0, 0);
            _downButton[0].Text = downString;
            _downButton[0].Position = new Vector2F(xPosition + xInterval, yPosition + yInterval * 2);
            _downButton[0].ZOrder = Common.Parameter.ZOrder.NumberInput;

            _calcNumber = new TextNode();
            _calcNumber.Font = Font.LoadDynamicFontStrict("HachiMaruPop-Regular.ttf", 40);
            _calcNumber.Color = new Color(0, 0, 0);
            _calcNumber.Text = "個(" + money.ToString() + "Ｇ)";
            _calcNumber.Position = new Vector2F(xPosition + xInterval * 2, yPosition + yInterval);
            _calcNumber.ZOrder = Common.Parameter.ZOrder.NumberInput;

            _okButton = new Button(Texture.OKButton, Texture.OKButtonHover, Texture.OKButtonClick);
            _okButton.SetPosition(new Vector2F(230, 410));
            _okButton.SetScale(buttonScale);
            _okButton.SetZOrder(Common.Parameter.ZOrder.NumberInput);
            _cancelButton = new Button(Texture.CancelButton, Texture.CancelButtonHover, Texture.CancelButtonClick);
            _cancelButton.SetPosition(new Vector2F(430, 410));
            _cancelButton.SetScale(buttonScale);
            _cancelButton.SetZOrder(Common.Parameter.ZOrder.NumberInput);
        }

        override public void Show()
        {
            base.Show();
            _parentNode.AddChildNode(_node2);
            _parentNode.AddChildNode(_itemName);
            for(int i = 0; i < 2; i++)
            {
                _parentNode.AddChildNode(_upButton[i]);
                _parentNode.AddChildNode(_number[i]);
                _parentNode.AddChildNode(_downButton[i]);
            }
            _parentNode.AddChildNode(_calcNumber);
            _okButton.SetNode(_parentNode);
            _cancelButton.SetNode(_parentNode);
        }

        override public void Hide()
        {
            base.Hide();
            _parentNode.RemoveChildNode(_node2);
            _parentNode.RemoveChildNode(_itemName);
            for (int i = 0; i < 2; i++)
            {
                _parentNode.RemoveChildNode(_upButton[i]);
                _parentNode.RemoveChildNode(_number[i]);
                _parentNode.RemoveChildNode(_downButton[i]);
            }
            _parentNode.RemoveChildNode(_calcNumber);
            _okButton.RemoveNode(_parentNode);
            _cancelButton.RemoveNode(_parentNode);
        }

        public override void OnMouse(Vector2F position)
        {
            _okButton.Hover(position);
            _cancelButton.Hover(position);
        }

        override public void OnClick(Vector2F position)
        {
            if(_dialog != null && _dialog.IsShow)
            {
                Function.PlaySoundOK();
                _dialog.RemoveNode(_parentNode);
                Hide();
                return;
            }
            for(int i = 0; i < 2; i++)
            {
                if(isClick(position, _upButton[i]))
                {
                    Function.PlaySoundOK();
                    _inputValue[i] = (_inputValue[i] + 1) % 10;
                    _number[i].Text = _inputValue[i].ToString();
                    _calcNumber.Text = "個(" + (calcNum() * _money).ToString() + "Ｇ)";
                    if(calcNum() * _money > GameData.PlayerData.Money)
                    {
                        _okButton.Lock();
                    }
                    else
                    {
                        _okButton.Unlock();
                    }
                    return;
                }
                if (isClick(position, _downButton[i]))
                {
                    Function.PlaySoundOK();
                    _inputValue[i] = _inputValue[i] - 1;
                    if(_inputValue[i] < 0)
                    {
                        _inputValue[i] = 9;
                    }
                    _number[i].Text = _inputValue[i].ToString();
                    _calcNumber.Text = "個(" + (calcNum() * _money).ToString() + "Ｇ)";
                    if (calcNum() * _money > GameData.PlayerData.Money)
                    {
                        _okButton.Lock();
                    }
                    else
                    {
                        _okButton.Unlock();
                    }
                    return;
                }
            }
            if (!_okButton.IsLocked && _okButton.IsClick(position))
            {
                Function.PlaySoundOK();
                _dialog = new Dialog();
                _dialog.SetNode(
                    Function.SearchItemById(_id).name + "を" + calcNum().ToString() + "個購入しました",
                    _parentNode);
                if(_id >= Common.Parameter.ItemIdOffset)
                {
                    GameData.PlayerData.Item[_id, Function.Quolity2Index(_quority)] += calcNum();
                    GameData.PlayerData.Money -= calcNum() * _money;
                }
                else
                {
                    GameData.PlayerData.Seed[_id] += calcNum();
                    GameData.PlayerData.Money -= calcNum() * _money;
                }
                return;
            }
            if(_cancelButton.IsClick(position))
            {
                Function.PlaySoundCancel();
                Hide();
            }
        }

        private bool isClick(Vector2F position, TextNode textNode)
        {
            if (position.X > textNode.Position.X && position.X < textNode.Position.X + textNode.ContentSize.X &&
                position.Y > textNode.Position.Y && position.Y < textNode.Position.Y + textNode.ContentSize.Y)
            {
                return true;
            }
            return false;
        }

        private int calcNum()
        {
            return _inputValue[1] * 10 + _inputValue[0];
        }
    }
}
