using System;
using System.Collections.Generic;
using System.Text;

namespace Minesweeper_Project
{
    public class Play_Game
    {
        private static bool[,] ifClicked = new bool[10, 10];

        public static void ClickCells()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    ifClicked[i, j] = false;
                }
            }

            Console.WriteLine("Please enter two number from 0 to 9");
            int clickX = Int32.Parse(Console.ReadLine());
            int clickY = Int32.Parse(Console.ReadLine());

            ClearCells(clickX, clickY);

            //Print the board
            Console.Clear();

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
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
                        Console.Write("    |");
                    }
                    if (j == 9 && !ifClicked[i, j])
                    {
                        Console.Write("    \n");
                    }
                }
                Console.WriteLine("----+----+----+----+----+----+----+----+----+----");
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
                {
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
}