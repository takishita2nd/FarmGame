using Altseed2;
using FarmGame.Model;
using FarmGame.UI.Parts;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmGame.UI
{
    class CraftWindow : WindowBase
    {
        private Model.Material[] _recipe = null;
        public CraftWindow(Model.Material[] recipe, Node parentNode): base(parentNode)
        {
            _recipe = recipe;
        }

        new public void Show()
        {
            base.Show();
            _okButton.SetNode(_parentNode);
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
