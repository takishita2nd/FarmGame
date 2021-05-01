using System;
using System.Collections.Generic;
using System.Text;

namespace FarmGame.Model
{
    class Ranch
    {
        //動物ID
        public int id { get; set; }
        public bool care { get; set; }
        //成長度
        public int growth { get; set; }
        //品質
        public int quality { get; set; }
    }
}
