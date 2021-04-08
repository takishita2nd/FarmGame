using System;
using System.Collections.Generic;
using System.Text;

namespace FarmGame.Common
{
    public static class Parameter
    {
        public const int WindowWidth = 960;
        public const int WindowHeight = 640;

        public static class ZOrder
        {
            public const int BackGround = 1;
            public const int Menu = 5;
            public const int Sign = 5;
            public const int Panel = 5;
            public const int Text = 8;
            public const int Farm = 10;
            public const int Ranch = 10;
            public const int Item = 10;
            public const int Request = 10;
            public const int Dialog = 25;
            public const int Seed = 30;
            public const int ShopList = 30;
            public const int NumberInput = 40;
            public const int Confirm = 40;
            public const int Alarm = 100;
        }

        public enum Quality
        {
            S,
            A,
            B,
            C,
            D,
            E
        }

        public const int FarmPageMaxColumn = 5;
        public const int RequestPageMaxColumn = 5;
        public const int RequestMaxNum = 5;
        public const int QuolityMaxNum = 6;
        public const int SeedIdOffset = 100;
    }
}
