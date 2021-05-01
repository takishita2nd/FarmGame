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
            if(args.Length >= 2 && args[0] == "enc")
            {
                Encrypt.Encode(args[1], args[2]);

                return;
            }

            Engine.Initialize("農場ゲーム(仮)", Common.Parameter.WindowWidth, Common.Parameter.WindowHeight);

            Engine.AddNode(new MainScene());

            //ゲームデータの初期化
            GameData.Initialize(FileAccess.GameDataLoad());

            //Zipファイルの読み込み
            Engine.File.AddRootPackage("resource.zip");

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
