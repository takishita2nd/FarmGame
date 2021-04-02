﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FarmGame.Model
{
    class Request
    {
        /**
         * <summary>アイテムID</summary>
         * */
        public int ItemId { get; set; }
        /**
         * <summary>アイテム数</summary>
         * */
        public int Num { get; set; }
        /**
         * <summary>報酬</summary>
         * */
        public int Money { get; set; }
    }
}
