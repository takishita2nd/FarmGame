using FarmGame.Common;
using FarmGame.Model;
using FarmGame.Scene;
using FarmGame.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmGame.Process
{
    static class Process
    {
        public static void Run(IScene scene)
        {
            GameData.PlayerData.Power = GameData.PlayerData.MaxPower;

            farmProcess();
            ShopProcess();

            scene.Update();
        }

        private static void farmProcess()
        {
            foreach(var farm in GameData.PlayerData.farms)
            {
                if(farm.valid)
                {
                    farm.growth += 100 / GameData.GameStatus.Plants[farm.id].cost + Function.GetRandomValue(0, 10);
                    farm.quality += GameData.PlayerData.AgricultureLevel;
                    if (!farm.water)
                    {
                        farm.quality /= 2;
                    }
                    farm.water = false;
                    farm.care = false;
                }
            }
        }

        private static void ShopProcess()
        {
            //削除されているリクエストがあればリクエストを追加する
            for(int index = 0; index < Parameter.RequestPageMaxColumn; index++)
            {
                if(!GameData.PlayerData.Requests[index].Valid)
                {
                    GameData.PlayerData.Requests[index] = Function.GetNewRequest();
                }
                index++;
            }
        }
    }
}
