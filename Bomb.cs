using System;
using System.Drawing;
using System.Timers;
using System.Linq;

namespace Minesweeper_Project
{
    public enum CellState { Empty, M1, M2, M3, M4, M5, M6, M7, M8, M9, Bomb };

    public class Bomb
    {
        
        private CellState[,] state;
        public int numberOfBombs = 10;
        Random rnd;


        void MakeBombs()
        {
            rnd = new Random();
            state = new CellState[10, 10];
            PlaceBombs();

        }
        void PlaceBombs()
        {
            int bombPlacementX;
            int bombPlacementY;
            int nearBombX;
            int nearBombY;

            for (int i = 0; i < numberOfBombs; i++)
            {
                bombPlacementX = rnd.Next(0, 10);
                bombPlacementY = rnd.Next(0, 10);

                if (state[bombPlacementX, bombPlacementY] != CellState.Bomb)
                {
                    state[bombPlacementX, bombPlacementY] = CellState.Bomb;
                    
                    for (int j = 0; i < 3; j++)
                    {
                        nearBombX = bombPlacementX - 1;
                        nearBombY = bombPlacementY - 1 + j;
                        if (nearBombX < 0 || nearBombX > 10 || nearBombY < 0 || nearBombY > 10)
                        {
                            continue;
                        }
                        state[nearBombX, nearBombY] = GetNextEnum(state);
                        state[nearBombX + 1, nearBombY] = GetNextEnum(state);
                        state[nearBombX + 2, nearBombY] = GetNextEnum(state);
                    }
                }
                else
                {
                    i--;
                }
            }
        }
        public CellState GetNextEnum(CellState state)
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
                    return CellState.Bomb;
                case CellState.Bomb:
                    return CellState.Bomb;
                default:
                    return CellState.Empty;
            }
        }

    }
}
