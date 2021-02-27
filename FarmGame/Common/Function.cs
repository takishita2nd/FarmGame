using System;
using System.Collections.Generic;
using System.Text;
using FarmGame.UI.Parts;

namespace FarmGame.Common
{
    class Function
    {
        public static FarmIcon.Type SeedId2Type(int id)
        {
            switch (id)
            {
                case 0:
                    return FarmIcon.Type.Wheat;
                default:
                    return FarmIcon.Type.Empty;
            }
        }
    }
}
