using System;

namespace textBasedGame
{
    class Program
    {
        static void Main(string[] args)
                 {
                     Game game = new Game();
         
                     while (game.IsRunning)
                     {
                         game.Update();
                     }
                 }
    }
}
