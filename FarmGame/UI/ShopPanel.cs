using Altseed2;
using FarmGame.Common;
using FarmGame.UI.Parts;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmGame.UI
{
    class ShopPanel
    {
        private const int LabelXIndex = 30;
        private const int LabelYIndex = 190;
        private const int columnInterval = 60;

        private bool _isLevelup = false;
        private List<RequestColumn> requestColumns = new List<RequestColumn>();
        private Node _parentNode;
        private ConfirmWindow _confirmWindow;
        private Dialog _dialog;

        public ShopPanel()
        {
            _isLevelup = false;
            for (int index = 0; index < Common.Parameter.RequestPageMaxColumn; index++)
            {
                RequestColumn requestColumn = new RequestColumn();
                requestColumn.Label.SetPosition(new Vector2F(LabelXIndex, LabelYIndex + columnInterval * index));
                requestColumn.DeliveryButton.SetZOrder(Common.Parameter.ZOrder.Request);
                requestColumn.DestructionButton.SetZOrder(Common.Parameter.ZOrder.Farm);

                if(index < GameData.PlayerData.Requests.Count)
                {
                    requestColumn.SetRequestData(GameData.PlayerData.Requests[index]);
                }

                requestColumns.Add(requestColumn);
            }
        }

        public void SetNode(Node parentNode)
        {
            _parentNode = parentNode;
            int index = 0;
            foreach(var column in requestColumns)
            {
                column.Label.SetNode(parentNode);
                column.DeliveryButton.SetPosition(new Vector2F(LabelXIndex + column.Label.GetContentWidth(), LabelYIndex + columnInterval * index));
                column.DeliveryButton.SetNode(parentNode);
                column.DestructionButton.SetPosition(new Vector2F(LabelXIndex + column.Label.GetContentWidth() + column.DeliveryButton.Width, LabelYIndex + columnInterval * index));
                column.DestructionButton.SetNode(parentNode);
                index++;
            }
        }

        public void OnMouse(Vector2F position)
        {
            if(_confirmWindow != null && _confirmWindow.IsShow())
            {
                _confirmWindow.OnMouse(position);
                return;
            }
            foreach (var column in requestColumns)
            {
                column.DeliveryButton.Hover(position);
                column.DestructionButton.Hover(position);
            }
        }

        public void OnClick(Vector2F position)
        {
            if( _dialog != null && _dialog.IsShow)
            {
                if (_isLevelup)
                {
                    _dialog.UpdateText(
                        "経営レベルが上がりました\n(" + GameData.PlayerData.ManagementLevel.ToString() + ")"
                        );
                    _isLevelup = false;
                    return;
                }
                _dialog.RemoveNode(_parentNode);
                _confirmWindow.Hide();
                return;
            }

            if (_confirmWindow != null && _confirmWindow.IsShow())
            {
                _confirmWindow.OnClick(position);
                return;
            }

            foreach (var column in requestColumns)
            {
                if(column.DeliveryButton.Click(position))
                {
                    _confirmWindow = new ConfirmWindow(_parentNode,
                        column.Label.GetText() + "\n" +
                        "納品しますか？\n" +
                        "(品質の高いものから使用されます)",
                        () => 
                        {
                            var request = column.GetRequest();
                            int num = request.Num;
                            int quolity = 0;
                            for (int q = 0; q < Common.Parameter.QuolityMaxNum; q++)
                            {
                                if(GameData.PlayerData.Item[request.ItemId, q] < num)
                                {
                                    quolity += Function.Quolity2Value(q) * GameData.PlayerData.Item[request.ItemId, q];
                                    num -= GameData.PlayerData.Item[request.ItemId, q];
                                    GameData.PlayerData.Item[request.ItemId, q] = 0;
                                }
                                else
                                {
                                    quolity += Function.Quolity2Value(q) * num;
                                    GameData.PlayerData.Item[request.ItemId, q] -= num;
                                    break;
                                }
                            }
                            Common.Parameter.Quality averageQuolity = Function.QualityByValue(quolity / request.Num);
                            float bonus = Function.Quolity2Bonus(averageQuolity);
                            GameData.PlayerData.Money += (int)(request.Money * bonus);
                            _dialog = new Dialog();
                            _dialog.SetNode("納品しました\n" +
                                "(品質" + Function.Quolity2String(averageQuolity) + ")\n" +
                                "(＋" + (request.Money * bonus).ToString() + "Ｇ)", _parentNode);
                            column.DeleteRequest();
                            //納品出来なくなったリクエストはロックする
                            foreach (var column2 in requestColumns)
                            {
                                column2.ButtonUpdate();
                            }
                            GameData.PlayerData.ManagementExperience += column.Exp;
                            if (GameData.PlayerData.ManagementExperience >= GameData.PlayerData.ManagementLevel * 25)
                            {
                                GameData.PlayerData.ManagementExperience -= GameData.PlayerData.ManagementLevel * 25;
                                GameData.PlayerData.ManagementLevel++;
                                GameData.PlayerData.MaxPower++;
                                _isLevelup = true;
                            }

                        });
                    _confirmWindow.Show();
                    return;
                }
                if(column.DestructionButton.Click(position))
                {
                    _confirmWindow = new ConfirmWindow(_parentNode,
                        column.Label.GetText() +
                        "\n破棄しますか？",
                        () =>
                        {
                            _dialog = new Dialog();
                            _dialog.SetNode("破棄しました", _parentNode);
                            column.DeleteRequest();
                        });
                    _confirmWindow.Show();
                    return;
                }
            }
        }

        public void RequestUpdate()
        {
            for (int index = 0; index < Common.Parameter.RequestPageMaxColumn; index++)
            {
                if (!requestColumns[index].Valid)
                {
                    requestColumns[index].SetRequestData(GameData.PlayerData.Requests[index]);
                }
            }
        }
    }
}

