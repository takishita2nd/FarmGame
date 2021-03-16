using Altseed2;
using FarmGame.Model;
using FarmGame.UI.Parts;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmGame.UI
{
    class StudioPanel
    {
        private const int xpos = 50;
        private const int ypos = 170;
        private const int xinterval = 320;
        private const int yinterval = 50;
        private const int Row = 2;
        private const int Col = 7;
        private ItemButton[,] button = new ItemButton[Row, Col];
        private int page;
        private Button _prevPageButton;
        private Button _nextPageButton;
        private CraftWindow _craftWindow;
        private Node _parentNode = null;

        public StudioPanel()
        {
            page = 0;
            int row = 0;
            int col = 0;
            int skip = 0;
            foreach(var item in GameData.GameStatus.Items)
            {
                if(skip < page * row * Col)
                {
                    skip++;
                    continue;
                }
                Recipe keeprecipe = null;
                foreach(var recipe in GameData.GameStatus.Recipes)
                {
                    if(item.id == recipe.id)
                    {
                        keeprecipe = recipe;
                    }
                }
                button[row, col] = new ItemButton(Texture.ItemButton, Texture.ItemButtonValid, item.id, keeprecipe);
                button[row, col].SetPosition(new Vector2F(xpos + xinterval * row, ypos + yinterval * col));
                button[row, col].SetZOrder(Common.Parameter.ZOrder.Item);
                col++;
                if(col >= Col)
                {
                    col = 0;
                    row++;
                    if(row >= Row)
                    {
                        break;
                    }
                }
            }

            for (row = 0; row < Row; row++)
            {
                for (col = 0; col < Col; col++)
                {
                    if(button[row, col] == null)
                    {
                        button[row, col] = new ItemButton(Texture.ItemButton, Texture.ItemButtonValid, -1, null);
                        button[row, col].SetPosition(new Vector2F(xpos + xinterval * row, ypos + yinterval * col));
                        button[row, col].SetZOrder(Common.Parameter.ZOrder.Item);
                    }
                }
            }

            float careButtonScale = 0.6f;
            _prevPageButton = new Button(Texture.PrevPageButton, Texture.PrevPageButtonHover, Texture.PrevPageButtonClick);
            _prevPageButton.SetPosition(new Vector2F(374, 520));
            _prevPageButton.SetScale(careButtonScale);
            _prevPageButton.SetZOrder(Common.Parameter.ZOrder.Item);

            _nextPageButton = new Button(Texture.NextPageButton, Texture.NextPageButtonHover, Texture.NextPageButtonClick);
            _nextPageButton.SetPosition(new Vector2F(534, 520));
            _nextPageButton.SetScale(careButtonScale);
            _nextPageButton.SetZOrder(Common.Parameter.ZOrder.Item);
        }

        public void SetNode(Node parentNode)
        {
            _parentNode = parentNode;
            for (int row = 0; row < Row; row++)
            {
                for(int col = 0; col < Col; col++)
                {
                    button[row, col].SetNode(parentNode);
                }
            }
            if(GameData.GameStatus.Items.Count > Row * Col)
            {
                _nextPageButton.SetNode(parentNode);
            }
        }

        public void DisplayUpdate()
        {
            for (int row = 0; row < Row; row++)
            {
                for (int col = 0; col < Col; col++)
                {
                    var recipe = button[row, col].GetRecipe();
                    if(recipe == null)
                    {
                        button[row, col].SetValid(false);
                    }
                    else
                    {
                        foreach (var m in recipe)
                        {
                            int num = 0;
                            for (int q = 0; q < Common.Parameter.QuolityMaxNum; q++)
                            {
                                num += GameData.PlayerData.Item[m.id, q];
                            }
                            if (num >= m.num)
                            {
                                button[row, col].SetValid(true);
                            }
                            else
                            {
                                button[row, col].SetValid(false);
                            }
                        }
                    }
                    button[row, col].TextUpdate();
                }
            }
        }

        public void OnMouse(Vector2F position)
        {
            if (_craftWindow != null && _craftWindow.IsShow())
            {
                _craftWindow.OnMouse(position);
            }
        }

        public void OnClick(Vector2F position)
        {
            if(_craftWindow != null && _craftWindow.IsShow())
            {
                _craftWindow.OnClick(position);
                if(_craftWindow.IsCreated)
                {
                    DisplayUpdate();
                }
            }
            else
            {
                for (int r = 0; r < Row; r++)
                {
                    for (int c = 0; c < Col; c++)
                    {
                        if (button[r,c].IsValid && button[r, c].IsClick(position))
                        {
                            _craftWindow = new CraftWindow(button[r, c].ItemId, button[r, c].GetRecipe(), _parentNode);
                            _craftWindow.Show();
                        }
                    }
                }
            }
        }
    }
}
