using Altseed2;
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

        private List<RequestColumn> requestColumns = new List<RequestColumn>();
        private Node _parentNode;
        private ConfirmWindow _confirmWindow;

        public ShopPanel()
        {
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
                        column.Label.GetText() +
                        "\n納品しますか？");
                    _confirmWindow.Show();
                    return;
                }
                if(column.DestructionButton.Click(position))
                {
                    _confirmWindow = new ConfirmWindow(_parentNode,
                        column.Label.GetText() +
                        "\n破棄しますか？");
                    _confirmWindow.Show();
                    return;
                }
            }
        }
    }
}

