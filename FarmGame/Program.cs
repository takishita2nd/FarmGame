using Altseed2;
using FarmGame.Common;
using FarmGame.Scene;
using System;

namespace FarmGame
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Engine.Initialize("農場ゲーム(仮)", Common.Parameter.WindowWidth, Common.Parameter.WindowHeight);

            Engine.AddNode(new MainScene());

            //ゲームデータの初期化
            GameData.Initialize(FileAccess.GameDataLoad());

            while (Engine.DoEvents())
            {
                // エンジンを更新
                Engine.Update();
            }

            // エンジンの終了処理を行う
            Engine.Terminate();
        }
    }
}
