using Altseed2;
using FarmGame.Common;
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
            int skip = 0;
            int row = 0;
            int col = 0;
            foreach (var recipe in GameData.GameStatus.Recipes.recipe)
            {
                int maxSkip = page * Row * Col;
                if (skip < maxSkip)
                {
                    skip++;
                    continue;
                }
                button[row, col] = new ItemButton(Texture.ItemButton, Texture.ItemButtonValid, recipe);
                button[row, col].SetPosition(new Vector2F(xpos + xinterval * row, ypos + yinterval * col));
                button[row, col].SetZOrder(Common.Parameter.ZOrder.Item);
                col++;
                if(col >= Col)
                {
                    row++;
                    col = 0;
                    if (row >= Row)
                    {
                        break;
                    }
                }
            }
            while (true)
            {
                if(row >= Row)
                {
                    break;
                }
                if (col >= Col)
                {
                    col = 0;
                    row++;
                    if (row >= Row)
                    {
                        break;
                    }
                }
                button[row, col] = new ItemButton(Texture.ItemButton, Texture.ItemButtonValid, null);
                button[row, col].SetPosition(new Vector2F(xpos + xinterval * row, ypos + yinterval * col));
                button[row, col].SetZOrder(Common.Parameter.ZOrder.Item);
                col++;
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
                        foreach (var m in recipe.material)
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

        /**
         * <summary>クリック処理</summary>
         * */
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
                if(_nextPageButton.IsClick(position))
                {
                    Function.PlaySoundOK();

                    page++;
                    updateRecipeList();
                    DisplayUpdate();
                    if (page >= 1)
                    {
                        _prevPageButton.SetNode(_parentNode);
                    }
                    int maxPage = GameData.GameStatus.Recipes.recipe.Length / (Row * Col);
                    if (page == maxPage)
                    {
                        _nextPageButton.RemoveNode(_parentNode);
                    }
                    return;
                }
                if (_prevPageButton.IsClick(position))
                {
                    Function.PlaySoundOK();

                    page--;
                    updateRecipeList();
                    DisplayUpdate();
                    if (page == 0)
                    {
                        _prevPageButton.RemoveNode(_parentNode);
                    }
                    _nextPageButton.SetNode(_parentNode);
                    return;
                }
                for (int r = 0; r < Row; r++)
                {
                    for (int c = 0; c < Col; c++)
                    {
                        if (button[r, c].IsClick(position))
                        {
                            Function.PlaySoundOK();
                            _craftWindow = new CraftWindow(button[r, c].GetRecipe(), _parentNode, button[r, c].IsValid);
                            _craftWindow.Show();
                        }
                    }
                }
            }
        }

        private void updateRecipeList()
        {
            int skip = 0;
            int row = 0;
            int col = 0;
            foreach (var recipe in GameData.GameStatus.Recipes.recipe)
            {
                if (skip < page * Row * Col)
                {
                    skip++;
                    continue;
                }
                button[row, col].SetRecipe(recipe);
                col++;
                if (col >= Col)
                {
                    col = 0;
                    row++;
                    if (row >= Row)
                    {
                        break;
                    }
                }

            }
            while (true)
            {
                if (row >= Row)
                {
                    break;
                }

                if (col >= Col)
                {
                    col = 0;
                    row++;
                    if (row >= Row)
                    {
                        break;
                    }
                }
                button[row, col].SetRecipe(null);
                col++;
            }
        }
    }
}
