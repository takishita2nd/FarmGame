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
                case 1:
                    return FarmIcon.Type.Cone;
                default:
                    return FarmIcon.Type.Empty;
            }
        }

        private static Random random = null;
        public static int GetRandomValue(int min, int max)
        {
            if (random == null)
            {
                random = new Random();
            }
            return random.Next(min, max);
        }
    }
}
