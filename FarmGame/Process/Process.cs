using FarmGame.Common;
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
    }
}
