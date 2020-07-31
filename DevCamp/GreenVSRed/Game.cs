using System;
using System.Linq;

namespace GreenVSRed
{
    public class Game
    {
        public int cols;
        public int rows;
        public Grid grid;

        private int counter;

        public Game()
        {
            this.counter = 0;
        }

        // User Input
        public void Input()
        {
            var gridSizeInput = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            cols = int.Parse(gridSizeInput[0]);
            rows = int.Parse(gridSizeInput[1]);

            var cellsGrid = new Cell[rows, cols];

            // Generation Zero
            for (int row = 0; row < rows; row++)
            {
                string genZerInput = Console.ReadLine();
                var splitInput = genZerInput.ToCharArray();

                for (int col = 0; col < splitInput.Length; col++)
                {
                    char ch = splitInput[col];
                    var cell = new Cell(row, col, ((int)ch - 48));
                    cellsGrid[row, col] = cell;
                }
            }

            string cellInput = Console.ReadLine();
            var cellInputSeparated = cellInput.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(v => int.Parse(v)).ToArray();
            int x1 = cellInputSeparated[1];
            int y1 = cellInputSeparated[0];
            int n = cellInputSeparated[2];

            grid = new Grid(rows, cols, x1, y1, n);
            grid.Cells = cellsGrid;
        }

        // Calling the method, in which is the main logic for creating new generations
        public void Play()
        {
            this.counter = grid.FormNextGenerations();
        }

        // Outputting the result
        public void Output()
        {
            Console.WriteLine($"#result: {this.counter}");
        }
    }
}
