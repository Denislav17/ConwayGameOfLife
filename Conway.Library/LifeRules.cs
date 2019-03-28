using System;
namespace Conway.Library
{
    public enum CellState
    {
        Alive,
        Dead,
    }
    public class LifeRules
    {
        public static CellState GetNewState(CellState currentState, int liveNeighbours)
        {
            switch(currentState)
            {
                case CellState.Alive:
                    if (liveNeighbours < 2 || liveNeighbours > 3)
                        return currentState = CellState.Dead;
                    break;
                case CellState.Dead:
                    if(liveNeighbours == 3)
                        return currentState = CellState.Alive;
                    break;
            }

            return currentState;
        }
    }
}
