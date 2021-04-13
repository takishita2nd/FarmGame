using System;
using System.Collections.Generic;
using System.Text;
using Altseed2;
using FarmGame.Model;
using FarmGame.Common;
using static FarmGame.Model.GameStatus;

namespace FarmGame
{
    class GameData
    {
        private static PlayerData _playerData = null;
        private static GameStatus _gameStatus = null;

        public static GameStatus GameStatus
        {
            get
            {
                return _gameStatus;
            }
        }

        public static PlayerData PlayerData
        {
            get
            {
                return _playerData;
            }
        }

        public static void Initialize()
        {
            _gameStatus = new GameStatus();
            _playerData = new PlayerData();
            _playerData.Weather = WeatherParameter.Sunny;
            _playerData.Turn = 1;
            _playerData.AgricultureLevel = 1;
            _playerData.DairyLevel = 1;
            _playerData.ProcessingLevel = 1;
            _playerData.ManagementLevel = 1;
            _playerData.AgricultureExperience = 0;
            _playerData.DairyExperience = 0;
            _playerData.ProcessingExperience = 0;
            _playerData.ManagementExperience = 0;
            _playerData.Money = 20000;
            _playerData.MaxPower = 10;
            _playerData.Power = _playerData.MaxPower;
            _playerData.farms = new List<Farm>();
            _playerData.farms.Add(new Farm());
            _playerData.farms.Add(new Farm());
            _playerData.farms.Add(new Farm());
            _playerData.farms.Add(new Farm());
            _playerData.farms.Add(new Farm());
            _playerData.Seed = new int[2];
            _playerData.Seed[0] = 3;
            _playerData.Seed[1] = 3;
            _playerData.ranches = new List<Ranch>();
            _playerData.Requests = new List<Request>();
            int itemNum = 1999;
            _playerData.Item = new int[itemNum, Parameter.QuolityMaxNum];
            for (int i = 0; i < itemNum; i++)
            {
                for (int j = 0; j < Parameter.QuolityMaxNum; j++)
                {
                    _playerData.Item[i, j] = 0;
                }
            }

            for (int i = 0; i < Parameter.RequestMaxNum; i++)
            {
                _playerData.Requests.Add(Function.GetNewRequest());
            }
        }

    }
}
