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
        public static int numberOfBombs;
        public static int difficulty;
        public static bool checkDifficulty = false;

        public static void MakeBombs()
        {
            state = new CellState[10, 10];

            do
            {
                Console.Clear();
                Console.WriteLine("Please choose a difficulty level");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("1 = Easy");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("2 = Medium");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("3 = Hard");
                Console.ResetColor();
                difficulty = Convert.ToInt32(Console.ReadLine());

                if (difficulty == 1)
                {
                    numberOfBombs = 10;
                    checkDifficulty = true;
                }
                if (difficulty == 2)
                {
                    numberOfBombs = 15;
                    checkDifficulty = true;
                }
                if (difficulty == 3)
                {
                    numberOfBombs = 20;
                    checkDifficulty = true;
                }
            } while (checkDifficulty == false);


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
                        
                        for (int k = 0; k < 3; k++)
                        {
                            nearBombX = bombPlacementX - 1 + k;
                            nearBombY = bombPlacementY - 1 + j;

                            if (nearBombX < 0 || nearBombX > 10 || nearBombY < 0 || nearBombY > 10)
                            {
                                continue;
                            }
                            state[nearBombX, nearBombY] = GetNextEnum(state[nearBombX, nearBombY]);

                        }

                    }
                }
                else
                {
                    i--;
                }
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
