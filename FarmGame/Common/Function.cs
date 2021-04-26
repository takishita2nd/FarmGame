using System;
using System.Collections.Generic;
using System.Text;
using Altseed2;
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
                case 2:
                    return FarmIcon.Type.Carrot;
                case 3:
                    return FarmIcon.Type.Pumpkin;
                case 4:
                    return FarmIcon.Type.Tomato;
                case 5:
                    return FarmIcon.Type.Strawberry;
                case 6:
                    return FarmIcon.Type.Potato;
                case 7:
                    return FarmIcon.Type.Pineapple;
                case 8:
                    return FarmIcon.Type.Rice;
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
        public static Quality String2Quolity(string quality)
        {
            switch (quality)
            {
                case "S":
                    return Quality.S;
                case "A":
                    return Quality.A;
                case "B":
                    return Quality.B;
                case "C":
                    return Quality.C;
                case "D":
                    return Quality.D;
                case "E":
                    return Quality.E;
                default:
                    return Quality.Empty;
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
        public static float Quolity2Bonus(Quality quality)
        {
            switch (quality)
            {
                case Quality.S:
                    return 2.5f;
                case Quality.A:
                    return 2.0f;
                case Quality.B:
                    return 1.5f;
                case Quality.C:
                    return 1.2f;
                case Quality.D:
                    return 1.0f;
                case Quality.E:
                    return 0.8f;
                default:
                    return 1.0f;
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

        public static Request GetNewRequest()
        {
            //リクエスト対象となるアイテムを検索
            List<Item> items = new List<Item>();
            foreach(var i in GameData.GameStatus.Items)
            {
                if(i.level >= 1 && i.level <= GameData.PlayerData.ManagementLevel)
                {
                    items.Add(i);
                }
            }
            Request request = new Request();
            int index = GetRandomValue(0, items.Count - 1);
            request.Valid = true;
            request.ItemId = items[index].id;
            request.Num = GetRandomValue(1, RequestMaxNum);
            request.Money = items[index].level * request.Num * 10;

            return request;
        }

        public static RanchIcon.Type GetId2RanchType(int id)
        {
            if(id == 200)
            {
                return RanchIcon.Type.Chicken;
            }
            else if(id == 201)
            {
                return RanchIcon.Type.Cow;
            }
            else
            {
                return RanchIcon.Type.Empty;
            }
        }

        public static Livestock SearchAnimalById(int id)
        {
            foreach(var a in GameData.GameStatus.Animals)
            {
                if(a.id == id)
                {
                    return a;
                }
            }
            return null;
        }

        private static Sound _soundOK = null;
        public static void PlaySoundOK()
        {
            if(_soundOK == null)
            {
                _soundOK = Sound.Load("button.wav", true);
            }
            Engine.Sound.Play(_soundOK);
        }
        private static Sound _soundCancel = null;
        public static void PlaySoundCancel()
        {
            if (_soundCancel == null)
            {
                _soundCancel = Sound.Load("cancel.wav", true);
            }
            Engine.Sound.Play(_soundCancel);
        }

    }
}
