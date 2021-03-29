using Altseed2;
using FarmGame.Common;
using FarmGame.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmGame.UI.Parts
{
    class RequestColumn
    {
        public RequestLabel Label;
        public Button DeliveryButton;
        public Button DestructionButton;
        private Request _request;

        public RequestColumn()
        {
            Label = new RequestLabel();

            DeliveryButton = new Button(Texture.DeliveryButton, Texture.DeliveryButtonHover, Texture.DeliveryButtonClick);
            DeliveryButton.SetZOrder(Common.Parameter.ZOrder.Request);
            DeliveryButton.SetScale(0.6f);

            DestructionButton = new Button(Texture.DestructionButton, Texture.DestructionButtonHover, Texture.DestructionButtonClick);
            DestructionButton.SetZOrder(Common.Parameter.ZOrder.Request);
            DestructionButton.SetScale(0.6f);
        }

        public void SetRequestData(Request request)
        {
            _request = request;
            Label.SetText(Function.SearchItemById(_request.ItemId).name + "×" + _request.Num.ToString());
        }
    }
}
