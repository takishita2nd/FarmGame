using Altseed2;
using FarmGame.Common;
using FarmGame.Model;
using FarmGame.UI.Parts;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmGame.UI
{
    class CraftWindow : WindowBase
    {
        public bool IsCreated
        {
            get
            {
                return _isCreated;
            }
        }
        private const int textLine = 5;
        private const int xPosition = 30;
        private const int yPosition = 190;
        private const int yInterval = 40;

        private bool _isLevelup = false;
        private bool _isCreated;
        private int _itemId;
        private Recipe _recipe = null;
        private TextNode[] _text = new TextNode[textLine];
        private Dialog _dialog = null;
        private bool _vaild;

        public CraftWindow(Recipe recipe, Node parentNode, bool valid): base(parentNode)
        {
            _vaild = valid;
            _isCreated = false;
            _itemId = recipe.id;
            _recipe = recipe;
            for(int line = 0; line < textLine; line++)
            {
                _text[line] = new TextNode();
                _text[line].Font = Font.LoadDynamicFontStrict("HachiMaruPop-Regular.ttf", 40);
                _text[line].Color = new Color(0, 0, 0);
                _text[line].ZOrder = Common.Parameter.ZOrder.Seed;
                _text[line].Position = new Vector2F(xPosition, yPosition + yInterval * line);
            }
        }

        /**
         * <summary>クラフトウィンドウ表示</summary>
         * */
        new public void Show()
        {
            base.Show();
            for (int line = 0; line < textLine - 1; line++)
            {
                if(line >= _recipe.material.Length)
                {
                    break;
                }
                int itemNum = 0;
                for(int q = 0; q < Common.Parameter.QuolityMaxNum; q++)
                {
                    itemNum += GameData.PlayerData.Item[_recipe.material[line].id, q];
                }
                var item = Function.SearchItemById(_recipe.material[line].id);
                _text[line].Text = item.name + ":"
                    + _recipe.material[line].num.ToString()
                    + "(" + itemNum.ToString() + ")";
                _parentNode.AddChildNode(_text[line]);
            }
            if(_vaild)
            {
                _text[4].Text = "アイテムは品質の高い物から使用されます。";
                _parentNode.AddChildNode(_text[4]);
                _okButton.SetNode(_parentNode);
            }
            else
            {
                _text[4].Text = "アイテムが足りません。";
                _parentNode.AddChildNode(_text[4]);
            }
        }

        /**
         * <summary>クラフトウィンドウ非表示</summary>
         * */
        new public void Hide()
        {
            base.Hide();
            for (int line = 0; line < textLine; line++)
            {
                _parentNode.RemoveChildNode(_text[line]);
            }
        }

        /**
         * <summary>クリック処理</summary>
         * */
        override public void OnClick(Vector2F position)
        {
            //ダイアログ表示中
            if(_dialog != null && _dialog.IsShow)
            {
                Function.PlaySoundOK();
                if (_isLevelup)
                {
                    _dialog.UpdateText(
                        "工房レベルが上がりました\n(" + GameData.PlayerData.ProcessingLevel.ToString() + ")"
                        );
                    _isLevelup = false;
                    return;
                }
                _isCreated = true;
                _dialog.RemoveNode(_parentNode);
                Hide();
                return;
            }
            //決定ボタン押下
            if (_okButton.Click(position))
            {
                Function.PlaySoundOK();
                if (GameData.PlayerData.Power < _recipe.cost)
                {
                    _dialog = new Dialog();
                    _dialog.SetNode("パワーが足りません", _parentNode);
                    return;
                }
                int quorityValue = 0;
                //アイテムを消費
                foreach(var r in _recipe.material)
                {
                    int num = r.num;
                    for(int q = 0; q < Common.Parameter.QuolityMaxNum; q++)
                    {
                        if(GameData.PlayerData.Item[r.id, q] >= num)
                        {
                            GameData.PlayerData.Item[r.id, q] -= num;
                            quorityValue += Function.Quolity2Value(q) * num;
                        }
                        else
                        {
                            num -= GameData.PlayerData.Item[r.id, q];
                            quorityValue += Function.Quolity2Value(q) * GameData.PlayerData.Item[r.id, q];
                            GameData.PlayerData.Item[r.id, q] = 0;
                        }
                    }
                }
                //品質を算出
                int itemNum = 0;
                foreach (var r in _recipe.material)
                {
                    itemNum += r.num;
                }
                var quolity = Function.QualityByValue(quorityValue / itemNum);
                //アイテムを追加
                if (_itemId > Common.Parameter.SeedIdOffset)
                {
                    GameData.PlayerData.Item[_itemId, Function.Quolity2Index(quolity)]++;
                }
                else
                {
                    GameData.PlayerData.Seed[_itemId]++;
                }
                GameData.PlayerData.Power -= _recipe.cost;
                //ダイアログ表示
                _dialog = new Dialog();
                if (_itemId > Common.Parameter.SeedIdOffset)
                {
                    _dialog.SetNode(
                    Function.SearchItemById(_itemId).name + "を作成しました\n" +
                            "(品質" + Function.Quolity2String(quolity) + ")",
                    _parentNode);
                    GameData.PlayerData.ProcessingExperience += _recipe.cost;
                    if (GameData.PlayerData.ProcessingExperience >= GameData.PlayerData.ProcessingLevel * 25)
                    {
                        GameData.PlayerData.ProcessingExperience -= GameData.PlayerData.ProcessingLevel * 25;
                        GameData.PlayerData.ProcessingLevel++;
                        _isLevelup = true;
                    }
                }
                else
                {
                    _dialog.SetNode(
                    Function.SearchItemById(_itemId).name + "を作成しました\n",
                    _parentNode);
                }
                return;
            }
            //キャンセルボタン押下
            if (_cancelButton.Click(position))
            {
                Function.PlaySoundCancel();
                Hide();
                return;
            }
        }
    }
}
