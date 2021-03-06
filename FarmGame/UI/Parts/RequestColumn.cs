﻿using Altseed2;
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

        public bool Valid
        {
            get
            {
                if(_request == null)
                {
                    return false;
                }
                else
                {
                    return _request.Valid;
                }
            }
        }

        public int Exp
        {
            get
            {
                return Function.SearchItemById(_request.ItemId).level * _request.Num;
            }
        }

        public RequestColumn()
        {
            Label = new RequestLabel();

            DeliveryButton = new Button(Texture.DeliveryButton, Texture.DeliveryButtonHover, Texture.DeliveryButtonClick);
            DeliveryButton.SetZOrder(Common.Parameter.ZOrder.Request);
            DeliveryButton.SetScale(0.6f);
            DeliveryButton.Lock();

            DestructionButton = new Button(Texture.DestructionButton, Texture.DestructionButtonHover, Texture.DestructionButtonClick);
            DestructionButton.SetZOrder(Common.Parameter.ZOrder.Request);
            DestructionButton.SetScale(0.6f);
            DestructionButton.Lock();
        }

        public void SetRequestData(Request request)
        {
            _request = request;
            Label.SetText(Function.SearchItemById(_request.ItemId).name + 
                "×" + _request.Num.ToString() + 
                "（" + _request.Money.ToString() + "Ｇ）");

            //アイテムを所有しているかを確認
            if (Function.GetItemNum(_request.ItemId) >= _request.Num)
            {
                DeliveryButton.Unlock();
            }
            DestructionButton.Unlock();
        }

        public void ButtonUpdate()
        {
            if (Function.GetItemNum(_request.ItemId) < _request.Num)
            {
                DeliveryButton.Lock();
            }
        }

        public void DeleteRequest()
        {
            Label.SetText(string.Empty);
            DeliveryButton.Lock();
            DestructionButton.Lock();
            _request.Valid = false;
        }

        public Request GetRequest()
        {
            return _request;
        }
    }
}
