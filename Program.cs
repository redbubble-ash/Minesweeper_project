using System;

namespace Minesweeper_Project
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Bomb.MakeBombs();
            Play_Game.ClickCells();
        }
    }
}