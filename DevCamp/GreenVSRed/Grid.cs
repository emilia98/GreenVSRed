using System;

namespace GreenVSRed
{
    public class Grid
    {
        private readonly int rows;
        private readonly int cols;
        private Cell[,] cells;

        private readonly int x1;
        private readonly int y1;

        private readonly int generations;
        private Cell[,] currentGridState = null;

        public Grid(int rows, int cols, int x1, int y1, int generations)
        {
            this.rows = rows;
            this.cols = cols;
            this.cells = new Cell[rows, cols];
            this.y1 = x1;
            this.x1 = y1;
            this.generations = generations;
        }

        public Cell[,] Cells
        {
            get { return this.cells; }
            set { this.cells = value; }
        }

        // Gets the current state of the grid
        private Cell[,] GetCurrentGridState()
        {   
            var currentGrid = new Cell[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    var cell = this.Cells[row, col].CloneInstance();
                    currentGrid[row, col] = cell;
                }
            }

            return currentGrid;
        }

        // Creates the new generation of the grid
        public void CreateNextGeneration()
        {
            this.currentGridState = this.GetCurrentGridState();

            for (int row = 0; row < this.rows; row++)
            {
                for (int col = 0; col < this.cols; col++)
                {
                    var cell = this.currentGridState[row, col];
                    var greenNeighbours = this.GetGreenNeighbours(row, col);

                    if (cell.Color == CellColor.Red)
                    {
                        if (greenNeighbours == 3 || greenNeighbours == 6)
                        {
                            this.Cells[row, col].Color = CellColor.Green;
                        }
                    }
                    else if (cell.Color == CellColor.Green)
                    {
                        if (greenNeighbours != 2 && greenNeighbours != 3 && greenNeighbours != 6)
                        {
                            this.Cells[row, col].Color = CellColor.Red;
                        }
                    }
                }
            }
        }

        // Gets all the green neighbours of the current cell in the grid
        private int GetGreenNeighbours(int row, int col)
        {
            int greenNeighbours = 0;
            for (int currentRow = Math.Max(0, row - 1); currentRow <= Math.Min(rows - 1, row + 1); currentRow++)
            {
                for (int currentCol = Math.Max(0, col - 1); currentCol <= Math.Min(cols - 1, col + 1); currentCol++)
                {
                    if (currentRow != row || currentCol != col)
                    {
                        if (this.currentGridState[currentRow, currentCol].Color == CellColor.Green)
                        {
                            greenNeighbours++;
                        }
                    }
                }
            }

            return greenNeighbours;
        }


        // Forms the next generations of the grid
        // Returns the counter which is responsible for storing
        // all the generations through the target cell is being green
        public int FormNextGenerations()
        {
            int counter = 0;

            for (int gen = 0; gen <= this.generations; gen++)
            {
                if (this.Cells[y1, x1].Color == CellColor.Green)
                {
                    counter++;
                }
                this.CreateNextGeneration();
            }

            return counter;
        }
    }
}
