using System;
using System.Collections.Generic;
using System.Text;
using FarmGame.Model;
using FarmGame.UI.Parts;
using static FarmGame.Common.Parameter;

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

        public static int Quolity2Index(Quality quality)
        {
            switch (quality)
            {
                case Quality.S:
                    return 0;
                case Quality.A:
                    return 1;
                case Quality.B:
                    return 2;
                case Quality.C:
                    return 3;
                case Quality.D:
                    return 4;
                case Quality.E:
                    return 5;
                default:
                    return 6;
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

        public static Item SearchItemById(int id)
        {
            foreach(var item in GameData.GameStatus.Items)
            {
                if(item.id == id)
                {
                    return item;
                }
            }
            return null;
        }

        public static int Quolity2Value(int quality)
        {
            switch(quality)
            {
                case 0:
                    return 100;
                case 1:
                    return 80;
                case 2:
                    return 60;
                case 3:
                    return 40;
                case 4:
                    return 20;
                case 5:
                    return 0;
                default:
                    return 0;
            }
        }

        public static Quality QualityByValue(int quolity)
        {
            if (quolity >= 100)
            {
                return Quality.S;
            }
            else if (quolity < 100 && quolity >= 80)
            {
                return Quality.A;
            }
            else if (quolity < 80 && quolity >= 60)
            {
                return Quality.B;
            }
            else if (quolity < 60 && quolity >= 40)
            {
                return Quality.C;
            }
            else if (quolity < 40 && quolity >= 20)
            {
                return Quality.D;
            }
            else
            {
                return Quality.E;
            }
        }

        public static int GetItemNum(int itemId)
        {
            int num = 0;
            for(int i = 0; i < Parameter.QuolityMaxNum; i++)
            {
                num += GameData.PlayerData.Item[itemId, i];
            }

            return num;
        }
    }
}
