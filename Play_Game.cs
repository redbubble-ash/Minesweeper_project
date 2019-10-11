using System;
using System.Collections.Generic;
using System.Text;

namespace Minesweeper_Project
{
    public class Play_Game
    {
        private static bool[,] ifClicked = new bool[10, 10];
        private static bool ifGameOver = false;
        private static int countClicked = 0;
        public static bool playAgain;

        public static void ClickCells()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    ifClicked[i, j] = false;
                }
            }

            //allow the user to play multiple times before hit the bomb
            do
            {
                int clickX ;
                int clickY ;
                bool isValidX;
                bool isValidY;


                do
                {
                    Console.WriteLine("Please enter a number from 0 to 9 for row selection.");
                    isValidX = Int32.TryParse(Console.ReadLine(), out clickX);


                } while (!isValidX || clickX < 0 || clickX > 9);

                do
                {
                    Console.WriteLine("Please enter a number from 0 to 9 for column selection.");
                    isValidY = Int32.TryParse(Console.ReadLine(), out clickY);


                } while (!isValidY || clickY < 0 || clickY > 9);
                //Console.Clear();

                ClearCells(clickX, clickY);

                //Game Over if the player hit the bo
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (ifClicked[i, j] && Bomb.state[i, j] == CellState.Bo)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("GAME OVER");
                            ifGameOver = true;
                            Console.ResetColor();
                            Console.WriteLine();
                        }
                    }
                }

                //User wins if clicked cells equal to 90 
                if (countClicked == 90)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("YOU WIN!");
                    ifGameOver = true;
                    Console.ResetColor();
                    Console.WriteLine();
                }


                //Print the board
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("   0    1    2    3    4    5    6    7    8    9");
                Console.ResetColor();

                for (int i = 0; i < 10; i++)
                { 
                    for (int j = 0; j < 10; j++)
                    {   if(j == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write($"{i} ");
                            Console.ResetColor();

                        }
                        if (j < 9 && ifClicked[i, j])
                        {
                            Console.Write($" {Bomb.state[i, j]} |");
                        }
                        if (j == 9 && ifClicked[i, j])
                        {
                            Console.Write($" {Bomb.state[i, j]} \n");
                        }
                        if (j < 9 && !ifClicked[i, j])
                        {
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.Write("    ");
                            Console.ResetColor();
                            Console.Write("|");
                        }
                        if (j == 9 && !ifClicked[i, j])
                        {
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.Write("    ");
                            Console.ResetColor();
                            Console.Write("\n");


                        }
                    }
                    Console.WriteLine("  ----+----+----+----+----+----+----+----+----+----");
                }
            } while (!ifGameOver);

            Console.WriteLine("Type 1 to play again, else exit");
            int tryAgain = Int32.Parse(Console.ReadLine());
            if (tryAgain == 1)
            {
                playAgain = true;
                ifGameOver = false;
            }
            else
            {
                playAgain = false;
            }
        }

        public static void ClearCells(int x, int y)
        {
            //Recursion//
            // checking the clicked cell does not fall outside of the boundary && not been clicked yet.
            if (x >= 0 && x < 10 && y >= 0 && y < 10 && !ifClicked[x, y])
            {
                //asign true to the clicked cells
                ifClicked[x, y] = true;
                countClicked += 1;

                if (Bomb.state[x, y] == CellState.Em)
                {
                    // using recursion to assign True to all the cells which surrounded the empty cells
                    ClearCells(x - 1, y - 1);
                    ClearCells(x - 1, y);
                    ClearCells(x - 1, y + 1);
                    ClearCells(x + 1, y - 1);
                    ClearCells(x + 1, y);
                    ClearCells(x + 1, y + 1);
                    ClearCells(x, y + 1);
                    ClearCells(x, y - 1);
                }
            }
        }
    }
}