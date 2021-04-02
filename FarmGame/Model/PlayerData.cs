using System;
using System.Collections.Generic;
using System.Text;

namespace FarmGame.Model
{
    class PlayerData
    {
        /**
         * <summary>農業レベル</summary>
         * */
        public int AgricultureLevel { get; set; }
        /**
         * <summary>酪農レベル</summary>
         * */
        public int DairyLevel { get; set; }
        /**
         * <summary>工房レベル</summary>
         * */
        public int ProcessingLevel { get; set; }
        /**
         * <summary>経営レベル</summary>
         * */
        public int ManagementLevel { get; set; }
        /**
         * <summary>農業経験値</summary>
         * */
        public int AgricultureExperience { get; set; }
        /**
         * <summary>酪農経験値</summary>
         * */
        public int DairyExperience { get; set; }
        /**
         * <summary>工房経験値</summary>
         * */
        public int ProcessingExperience { get; set; }
        /**
         * <summary>経営経験値</summary>
         * */
        public int ManagementExperience { get; set; }
        /**
         * <summary>お金</summary>
         * */
        public int Money { get; set; }
        /**
         * <summary>体力値</summary>
         * */
        public int Power { get; set; }
        /**
         * <summary>最大体力値</summary>
         * */
        public int MaxPower { get; set; }
        /**
         * <summary>農場データ</summary>
         * */
        public List<Farm> farms { get; set; }
        /**
         * <summary>種データ</summary>
         * */
        public int[] Seed { get; set; }
        /**
         * <summary>所持アイテム[アイテムID,品質]</summary>
         * */
        public int[,] Item { get; set; }
        /**
         * <summary>依頼リスト</summary>
         * */
        public List<Request> Requests { get; set; }
        public PlayerData()
        {
            AgricultureLevel = 1;
            DairyLevel = 1;
            ProcessingLevel = 1;
            ManagementLevel = 1;
            AgricultureExperience = 0;
            DairyExperience = 0;
            ProcessingExperience = 0;
            ManagementExperience = 0;
            Money = 100;
            MaxPower = 10;
            Power = MaxPower;
            farms = new List<Farm>();
            farms.Add(new Farm());
            farms.Add(new Farm());
            farms.Add(new Farm());
            farms.Add(new Farm());
            farms.Add(new Farm());
            Seed = new int[2];
            Seed[0] = 3;
            Seed[1] = 3;
            Requests = new List<Request>();
            Requests.Add(new Request() { ItemId = 100, Num = 2, Money = 100 });
            Requests.Add(new Request() { ItemId = 1001, Num = 2, Money = 150 });
            int itemNum = 1999;
            Item = new int[itemNum, Common.Parameter.QuolityMaxNum];
            for(int i = 0; i < itemNum; i++)
            {
                for(int j = 0; j < Common.Parameter.QuolityMaxNum; j++)
                {
                    Item[i, j] = 0;
                }
            }
        }
    }
}
