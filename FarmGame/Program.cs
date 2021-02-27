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
            Engine.Initialize("農場ゲーム(仮)", Parameter.WindowWidth, Parameter.WindowHeight);

            Engine.AddNode(new MainScene());

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
