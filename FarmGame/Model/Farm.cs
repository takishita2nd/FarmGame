using System;
using System.Collections.Generic;
using System.Text;

namespace FarmGame.Model
{
    class Farm
    {
        List<FarmField> farmFields;
    }

    class FarmField
    {
        //植えているかどうか
        public bool valid { get; set; }
        //種ID
        public int id { get; set; }
        //水
        public bool water { get; set; }
        //成長度
        public int growth { get; set; }
        //品質
        public int quality { get; set; }
    }
}
