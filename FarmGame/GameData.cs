using System;
using System.Collections.Generic;
using System.Text;
using Altseed2;
using FarmGame.Model;

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
                if (_gameStatus == null)
                {
                    _gameStatus = new GameStatus();
                }
                return _gameStatus;
            }
        }

        public static PlayerData PlayerData
        {
            get
            {
                if (_playerData == null)
                {
                    _playerData = new PlayerData();
                }
                return _playerData;
            }
        }

    }
}
