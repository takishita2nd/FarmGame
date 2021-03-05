using System;
using System.Collections.Generic;
using System.Text;
using FarmGame.UI.Parts;
using static FarmGame.Parameter;

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

        public static string Quolity2String(Quality quality)
        {
            switch(quality)
            {
                case Quality.S:
                    return "S";
                case Quality.A:
                    return "A";
                case Quality.B:
                    return "B";
                case Quality.C:
                    return "C";
                case Quality.D:
                    return "D";
                case Quality.E:
                    return "E";
                default:
                    return string.Empty;
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
