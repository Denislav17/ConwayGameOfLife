using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conway.Library
{
    public class LifeGrid
    {
        int gridHeight;
        int gridWidth;

        public CellState[,] CurrentState;
        private CellState[,] nextState;

        public LifeGrid(int height, int width)
        {
            this.gridHeight = height;
            this.gridWidth = width;

            CurrentState = new CellState[gridHeight, gridWidth];
            nextState = new CellState[gridHeight, gridWidth];

            for(int i = 0; i<gridHeight;i++)
            {
                for(int j = 0; j<gridWidth;j++)
                {
                    CurrentState[i, j] = CellState.Dead;
                }
            }
        }
        public void UpdateState()
        {
            for (int i = 0; i < gridHeight; i++)
            {
                for (int j = 0; j < gridWidth; j++)
                {
                    var liveNeighbours = GetLiveNeighbours(i, j);
                    nextState[i, j] =
                        LifeRules.GetNewState(CurrentState[i, j], liveNeighbours);
                }
            }
            CurrentState = nextState;
            nextState = new CellState[gridHeight, gridWidth];
        }

        public void Randomize()
        {
            Random r = new Random();

            for (int i = 0; i < gridHeight; i++)
            {
                for (int j = 0; j < gridWidth; j++)
                {
                    var next = r.Next(2);
                    var newState = next < 1 ? CellState.Dead : CellState.Alive;
                    CurrentState[i, j] = newState;
                }
            }
        }

        private int GetLiveNeighbours(int posX, int posY)
        {
            int liveNeighbours = 0;
            for(int i = -1;i<=1;i++)
            {
                for(int j = -1;j <=1;j++)
                {
                    if (i == 0 && j == 0)
                        continue;

                    int neighbourX = posX + i;
                    int neighbourY = posY + j;

                    if(neighbourX >= 0 && neighbourX < gridHeight &&
                        neighbourY >= 0 && neighbourY < gridWidth)
                    {
                        if (CurrentState[neighbourX, neighbourY] == CellState.Alive)
                            liveNeighbours++;
                    }
                }
            }

            return liveNeighbours;
        }
    }

   
}
