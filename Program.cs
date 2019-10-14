using System;

namespace Minesweeper_Project
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            do
            {
                Bomb.MakeBombs();
                Play_Game.ClickCells();
            } while (Play_Game.playAgain);
        }
    }
}