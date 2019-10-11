using System;
using System.Drawing;
using System.Timers;
using System.Linq;

namespace Minesweeper_Project
{
    public enum CellState { Em, M1, M2, M3, M4, M5, M6, M7, M8, M9, Bo };

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

                        state[nearBombX, nearBombY] = GetNextEnum(state[nearBombX, nearBombY]);
                        state[nearBombX + 1, nearBombY] = GetNextEnum(state[nearBombX + 1, nearBombY]);
                        state[nearBombX + 2, nearBombY] = GetNextEnum(state[nearBombX + 2, nearBombY]);
                    }
                }
                else
                {
                    i--;
                }
            }

            //Print the board
            Console.Clear();

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (j < 9)
                    {
                        Console.Write($" {state[i, j]} |");
                    }
                    else
                    {
                        Console.Write($" {state[i, j]} \n");
                    }
                }
                Console.WriteLine("----+----+----+----+----+----+----+----+----+----");
            }
        }

        public static CellState GetNextEnum(CellState state)
        {
            switch (state)
            {
                case CellState.Em:
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
                    return CellState.Em;
            }
        }
    }
}