using FarmGame.Common;
using System;
using System.Collections.Generic;
using System.Text;
using static FarmGame.Model.GameStatus;

namespace FarmGame.Model
{
    class PlayerData
    {
        /**
         * <summary>経過ターン</summary>
         * */
        public int Turn { get; set; }
        /**
         * 天候
         * */
        public WeatherParameter Weather { get; set; }
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
         * <summary>牧場データ</summary>
         * */
        public List<Ranch> ranches { get; set; }
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
    }
}
