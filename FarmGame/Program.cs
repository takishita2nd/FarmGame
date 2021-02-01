using Altseed2;
using FarmGame.Scene;
using System;

namespace FarmGame
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Engine.Initialize("農場ゲーム(仮)", CommonParameter.WindowWidth, CommonParameter.WindowHeight);

            Engine.AddNode(new Main());

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
