using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conway.Library;

namespace ConwaysGameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            var grid = new LifeGrid(25, 65);
            grid.Randomize();

            ShowGrid(grid.CurrentState);

            while(Console.ReadLine() != "q")
            {
                grid.UpdateState();
                ShowGrid(grid.CurrentState);
            }
        }

        private static void ShowGrid(CellState[,] currentState)
        {
            Console.Clear();
            int x = 0;
            int rowLenght = currentState.GetUpperBound(1) + 1;

            var output = new StringBuilder();

            foreach(var state in currentState)
            {
                output.Append(state == CellState.Alive ? "0" : ".");
                x++;

                if (x >= rowLenght)
                {
                    x = 0;
                    output.AppendLine();
                }
            }

            Console.WriteLine(output.ToString());
        }
    }
}
