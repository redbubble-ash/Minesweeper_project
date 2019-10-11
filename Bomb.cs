using System;
using System.Drawing;
using System.Timers;
using System.Linq;

namespace Minesweeper_Project
{
    public enum CellState { Empty, M1, M2, M3, M4, M5, M6, M7, M8, M9, Bo };

    public class Bomb
    {
        public static CellState[,] state;
        public static int numberOfBombs = 10;

        public static void MakeBombs()
        {
            state = new CellState[10, 10];
            PlaceBombs();
        }

        public static void PlaceBombs()
        {
            int bombPlacementX;
            int bombPlacementY;
            int nearBombX;
            int nearBombY;
            Random rnd = new Random();

            for (int i = 0; i < numberOfBombs; i++)
            {
                bombPlacementX = rnd.Next(0, 9);
                bombPlacementY = rnd.Next(0, 9);

                if (state[bombPlacementX, bombPlacementY] != CellState.Bo)
                {
                    state[bombPlacementX, bombPlacementY] = CellState.Bo;
                    //Console.WriteLine(CellState.Bomb);

                    for (int j = 0; j < 3; j++)
                    {
                        nearBombX = bombPlacementX - 1;
                        nearBombY = bombPlacementY - 1 + j;
                        if (nearBombX < 0 || nearBombX > 10 || nearBombY < 0 || nearBombY > 10)
                        {
                            continue;
                        }
                        GetNextEnum(state[nearBombX, nearBombY]);
                        GetNextEnum(state[nearBombX + 1, nearBombY]);
                        GetNextEnum(state[nearBombX + 2, nearBombY]);
                    }
                }
                else
                {
                    i--;
                }
            }

            //Console.WriteLine(GetNextEnum(state[3, 3]));

            //Print the board
            Console.Clear();

            Console.WriteLine($" {GetNextEnum(state[0, 0])} | {GetNextEnum(state[0, 1])} | {GetNextEnum(state[0, 2])} | {GetNextEnum(state[0, 3])} | {GetNextEnum(state[0, 4])} | {GetNextEnum(state[0, 5])} | {GetNextEnum(state[0, 6])} | {GetNextEnum(state[0, 7])} | {GetNextEnum(state[0, 8])} | {GetNextEnum(state[0, 9])}");
            Console.WriteLine("----+----+----+----+----+----+----+----+----+----");

            Console.WriteLine($" {GetNextEnum(state[1, 0])} | {GetNextEnum(state[1, 1])} | {GetNextEnum(state[1, 2])} | {GetNextEnum(state[1, 3])} | {GetNextEnum(state[1, 4])} | {GetNextEnum(state[1, 5])} | {GetNextEnum(state[1, 6])} | {GetNextEnum(state[1, 7])} | {GetNextEnum(state[1, 8])} | {GetNextEnum(state[1, 9])}");
            Console.WriteLine("----+----+----+----+----+----+----+----+----+----");

            Console.WriteLine($" {GetNextEnum(state[2, 0])} | {GetNextEnum(state[2, 1])} | {GetNextEnum(state[2, 2])} | {GetNextEnum(state[2, 3])} | {GetNextEnum(state[2, 4])} | {GetNextEnum(state[2, 5])} | {GetNextEnum(state[2, 6])} | {GetNextEnum(state[2, 7])} | {GetNextEnum(state[2, 8])} | {GetNextEnum(state[2, 9])}");
            Console.WriteLine("----+----+----+----+----+----+----+----+----+----");

            Console.WriteLine($" {GetNextEnum(state[3, 0])} | {GetNextEnum(state[3, 1])} | {GetNextEnum(state[3, 2])} | {GetNextEnum(state[3, 3])} | {GetNextEnum(state[3, 4])} | {GetNextEnum(state[3, 5])} | {GetNextEnum(state[3, 6])} | {GetNextEnum(state[3, 7])} | {GetNextEnum(state[3, 8])} | {GetNextEnum(state[3, 9])}");
            Console.WriteLine("----+----+----+----+----+----+----+----+----+----");

            Console.WriteLine($" {GetNextEnum(state[4, 0])} | {GetNextEnum(state[4, 1])} | {GetNextEnum(state[4, 2])} | {GetNextEnum(state[4, 3])} | {GetNextEnum(state[4, 4])} | {GetNextEnum(state[4, 5])} | {GetNextEnum(state[4, 6])} | {GetNextEnum(state[4, 7])} | {GetNextEnum(state[4, 8])} | {GetNextEnum(state[4, 9])}");
            Console.WriteLine("----+----+----+----+----+----+----+----+----+----");

            Console.WriteLine($" {GetNextEnum(state[5, 0])} | {GetNextEnum(state[5, 1])} | {GetNextEnum(state[5, 2])} | {GetNextEnum(state[5, 3])} | {GetNextEnum(state[5, 4])} | {GetNextEnum(state[5, 5])} | {GetNextEnum(state[5, 6])} | {GetNextEnum(state[5, 7])} | {GetNextEnum(state[5, 8])} | {GetNextEnum(state[5, 9])}");
            Console.WriteLine("----+----+----+----+----+----+----+----+----+----");

            Console.WriteLine($" {GetNextEnum(state[6, 0])} | {GetNextEnum(state[6, 1])} | {GetNextEnum(state[6, 2])} | {GetNextEnum(state[6, 3])} | {GetNextEnum(state[6, 4])} | {GetNextEnum(state[6, 5])} | {GetNextEnum(state[6, 6])} | {GetNextEnum(state[6, 7])} | {GetNextEnum(state[6, 8])} | {GetNextEnum(state[6, 9])}");
            Console.WriteLine("----+----+----+----+----+----+----+----+----+----");

            Console.WriteLine($" {GetNextEnum(state[7, 0])} | {GetNextEnum(state[7, 1])} | {GetNextEnum(state[7, 2])} | {GetNextEnum(state[7, 3])} | {GetNextEnum(state[7, 4])} | {GetNextEnum(state[7, 5])} | {GetNextEnum(state[7, 6])} | {GetNextEnum(state[7, 7])} | {GetNextEnum(state[7, 8])} | {GetNextEnum(state[7, 9])}");
            Console.WriteLine("----+----+----+----+----+----+----+----+----+----");

            Console.WriteLine($" {GetNextEnum(state[8, 0])} | {GetNextEnum(state[8, 1])} | {GetNextEnum(state[8, 2])} | {GetNextEnum(state[8, 3])} | {GetNextEnum(state[8, 4])} | {GetNextEnum(state[8, 5])} | {GetNextEnum(state[8, 6])} | {GetNextEnum(state[8, 7])} | {GetNextEnum(state[8, 8])} | {GetNextEnum(state[8, 9])}");
            Console.WriteLine("----+----+----+----+----+----+----+----+----+----");

            Console.WriteLine($" {GetNextEnum(state[9, 0])} | {GetNextEnum(state[9, 1])} | {GetNextEnum(state[9, 2])} | {GetNextEnum(state[9, 3])} | {GetNextEnum(state[9, 4])} | {GetNextEnum(state[9, 5])} | {GetNextEnum(state[9, 6])} | {GetNextEnum(state[9, 7])} | {GetNextEnum(state[9, 8])} | {GetNextEnum(state[9, 9])}");
        }

        public static CellState GetNextEnum(CellState state)
        {
            switch (state)
            {
                case CellState.Empty:
                    return CellState.M1;

                case CellState.M1:
                    return CellState.M2;

                case CellState.M2:
                    return CellState.M3;

                case CellState.M3:
                    return CellState.M4;

                case CellState.M4:
                    return CellState.M5;

                case CellState.M5:
                    return CellState.M6;

                case CellState.M6:
                    return CellState.M7;

                case CellState.M7:
                    return CellState.M8;

                case CellState.M8:
                    return CellState.M9;

                case CellState.M9:
                    return CellState.Bo;

                case CellState.Bo:
                    return CellState.Bo;

                default:
                    return CellState.Empty;
            }
        }

        //public static void PrintBoard()
        //{
        //    Console.Clear();

        //    Console.WriteLine($" {GetNextEnum(state[0, 0])} | {GetNextEnum(state[0, 1])} | {GetNextEnum(state[0, 2])} || {GetNextEnum(state[0, 3])} || {GetNextEnum(state[0, 4])} || {GetNextEnum(state[0, 5])} || {GetNextEnum(state[0, 6])} || {GetNextEnum(state[0, 7])} || {GetNextEnum(state[0, 8])} || {GetNextEnum(state[0, 9])}");
        //    Console.WriteLine("---+---+---+---+---+---+---+---+---+---");

        //    Console.WriteLine($" {GetNextEnum(state[1, 0])} | {GetNextEnum(state[1, 1])} | {GetNextEnum(state[1, 2])} || {GetNextEnum(state[1, 3])} || {GetNextEnum(state[1, 4])} || {GetNextEnum(state[1, 5])} || {GetNextEnum(state[1, 6])} || {GetNextEnum(state[1, 7])} || {GetNextEnum(state[1, 8])} || {GetNextEnum(state[1, 9])}");
        //    Console.WriteLine("---+---+---+---+---+---+---+---+---+---");

        //    Console.WriteLine($" {GetNextEnum(state[2, 0])} | {GetNextEnum(state[2, 1])} | {GetNextEnum(state[2, 2])} || {GetNextEnum(state[2, 3])} || {GetNextEnum(state[2, 4])} || {GetNextEnum(state[2, 5])} || {GetNextEnum(state[2, 6])} || {GetNextEnum(state[2, 7])} || {GetNextEnum(state[2, 8])} || {GetNextEnum(state[2, 9])}");
        //    Console.WriteLine("---+---+---+---+---+---+---+---+---+---");

        //    Console.WriteLine($" {GetNextEnum(state[3, 0])} | {GetNextEnum(state[3, 1])} | {GetNextEnum(state[3, 2])} || {GetNextEnum(state[3, 3])} || {GetNextEnum(state[3, 4])} || {GetNextEnum(state[3, 5])} || {GetNextEnum(state[3, 6])} || {GetNextEnum(state[3, 7])} || {GetNextEnum(state[3, 8])} || {GetNextEnum(state[3, 9])}");
        //    Console.WriteLine("---+---+---+---+---+---+---+---+---+---");

        //    Console.WriteLine($" {GetNextEnum(state[4, 0])} | {GetNextEnum(state[4, 1])} | {GetNextEnum(state[4, 2])} || {GetNextEnum(state[4, 3])} || {GetNextEnum(state[4, 4])} || {GetNextEnum(state[4, 5])} || {GetNextEnum(state[4, 6])} || {GetNextEnum(state[4, 7])} || {GetNextEnum(state[4, 8])} || {GetNextEnum(state[4, 9])}");
        //    Console.WriteLine("---+---+---+---+---+---+---+---+---+---");

        //    Console.WriteLine($" {GetNextEnum(state[5, 0])} | {GetNextEnum(state[5, 1])} | {GetNextEnum(state[5, 2])} || {GetNextEnum(state[5, 3])} || {GetNextEnum(state[5, 4])} || {GetNextEnum(state[5, 5])} || {GetNextEnum(state[5, 6])} || {GetNextEnum(state[5, 7])} || {GetNextEnum(state[5, 8])} || {GetNextEnum(state[5, 9])}");
        //    Console.WriteLine("---+---+---+---+---+---+---+---+---+---");

        //    Console.WriteLine($" {GetNextEnum(state[6, 0])} | {GetNextEnum(state[6, 1])} | {GetNextEnum(state[6, 2])} || {GetNextEnum(state[6, 3])} || {GetNextEnum(state[6, 4])} || {GetNextEnum(state[6, 5])} || {GetNextEnum(state[6, 6])} || {GetNextEnum(state[6, 7])} || {GetNextEnum(state[6, 8])} || {GetNextEnum(state[6, 9])}");
        //    Console.WriteLine("---+---+---+---+---+---+---+---+---+---");

        //    Console.WriteLine($" {GetNextEnum(state[7, 0])} | {GetNextEnum(state[7, 1])} | {GetNextEnum(state[7, 2])} || {GetNextEnum(state[7, 3])} || {GetNextEnum(state[7, 4])} || {GetNextEnum(state[7, 5])} || {GetNextEnum(state[7, 6])} || {GetNextEnum(state[7, 7])} || {GetNextEnum(state[7, 8])} || {GetNextEnum(state[7, 9])}");
        //    Console.WriteLine("---+---+---+---+---+---+---+---+---+---");

        //    Console.WriteLine($" {GetNextEnum(state[8, 0])} | {GetNextEnum(state[8, 1])} | {GetNextEnum(state[8, 2])} || {GetNextEnum(state[8, 3])} || {GetNextEnum(state[8, 4])} || {GetNextEnum(state[8, 5])} || {GetNextEnum(state[8, 6])} || {GetNextEnum(state[8, 7])} || {GetNextEnum(state[8, 8])} || {GetNextEnum(state[8, 9])}");
        //    Console.WriteLine("---+---+---+---+---+---+---+---+---+---");

        //    Console.WriteLine($" {GetNextEnum(state[9, 0])} | {GetNextEnum(state[9, 1])} | {GetNextEnum(state[9, 2])} || {GetNextEnum(state[9, 3])} || {GetNextEnum(state[9, 4])} || {GetNextEnum(state[9, 5])} || {GetNextEnum(state[9, 6])} || {GetNextEnum(state[9, 7])} || {GetNextEnum(state[9, 8])} || {GetNextEnum(state[9, 9])}");
        //}
    }
}