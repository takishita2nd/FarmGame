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
        private const int textLine = 5;
        private const int xPosition = 30;
        private const int yPosition = 190;
        private const int yInterval = 40;

        private Model.Material[] _recipe = null;
        private TextNode[] _text = new TextNode[textLine];

        public CraftWindow(Model.Material[] recipe, Node parentNode): base(parentNode)
        {
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

        new public void Show()
        {
            base.Show();
            for (int line = 0; line < textLine - 1; line++)
            {
                if(line >= _recipe.Length)
                {
                    break;
                }
                int itemNum = 0;
                for(int q = 0; q < Common.Parameter.QuolityMaxNum; q++)
                {
                    itemNum += GameData.PlayerData.Item[_recipe[line].id, q];
                }
                var item = Function.SearchItemById(_recipe[line].id);
                _text[line].Text = item.name + ":"
                    + _recipe[line].num.ToString()
                    + "(" + itemNum.ToString() + ")";
                _parentNode.AddChildNode(_text[line]);
            }
            _text[4].Text = "アイテムは品質の高い物から使用されます。";
            _parentNode.AddChildNode(_text[4]);
            _okButton.SetNode(_parentNode);
        }

        new public void Hide()
        {
            base.Hide();
            for (int line = 0; line < textLine; line++)
            {
                _parentNode.RemoveChildNode(_text[line]);
            }
        }

        override public void OnClick(Vector2F position)
        {
            if (_okButton.Click(position))
            {
                Hide();
            }
            if (_cancelButton.Click(position))
            {
                Hide();
            }

        }
    }
}
