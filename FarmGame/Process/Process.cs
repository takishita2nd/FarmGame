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
            GameData.PlayerData.Turn++;
            GameData.PlayerData.Power = GameData.PlayerData.MaxPower;

            farmProcess();
            ranchProcess();
            shopProcess();

            wether();

            scene.Update();
        }

        private static void farmProcess()
        {
            foreach(var farm in GameData.PlayerData.farms)
            {
                if(farm.valid)
                {
                    farm.growth += 100 / GameData.GameStatus.Plants[farm.id].cost + Function.GetRandomValue(0, 10);
                    farm.growth = (int)(farm.growth * Function.wetherValue(GameData.PlayerData.Weather));
                    if (!farm.water)
                    {
                        farm.quality /= 2;
                    }
                    farm.water = false;
                    farm.care = false;
                }
            }
        }

        private static void ranchProcess()
        {
            foreach (var ranch in GameData.PlayerData.ranches)
            {
                if(ranch.growth <= 100)
                {
                    ranch.growth += 100 / Function.SearchAnimalById(ranch.id).cost + Function.GetRandomValue(0, 10);
                }
                ranch.care = false;
            }
        }

        private static void shopProcess()
        {
            //削除されているリクエストがあればリクエストを追加する
            for(int index = 0; index < Parameter.RequestPageMaxColumn; index++)
            {
                if(!GameData.PlayerData.Requests[index].Valid)
                {
                    GameData.PlayerData.Requests[index] = Function.GetNewRequest();
                }
            }
        }

        private static void wether()
        {
            var r = Common.Function.GetRandomValue(0, 3);
            switch(r)
            {
                case 0:
                    GameData.PlayerData.Weather = GameStatus.WeatherParameter.Sunny;
                    break;
                case 1:
                    GameData.PlayerData.Weather = GameStatus.WeatherParameter.Cloudy;
                    break;
                case 2:
                    GameData.PlayerData.Weather = GameStatus.WeatherParameter.Rain;
                    foreach(var f in GameData.PlayerData.farms)
                    {
                        f.water = true;
                    }
                    break;
                default:
                    GameData.PlayerData.Weather = GameStatus.WeatherParameter.Sunny;
                    break;
            }
        }
    }
}
