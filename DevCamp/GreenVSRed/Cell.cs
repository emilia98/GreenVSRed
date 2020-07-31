namespace GreenVSRed
{
    public class Cell
    {
        /* fields */

        // Cell Coordinates
        private int row;
        private int col;

        // Cell Color 
        private CellColor color;

        public Cell(int row, int col, int color)
        {
            this.row = row;
            this.col = col;
            this.color = (CellColor)color;
        }

        public int Row
        {
            get { return this.row; }
        }

        public int Col
        {
            get { return this.col; }
        }

        public CellColor Color
        {
            get { return this.color; }
            set { this.color = value; }
        }

        public Cell CloneInstance()
        {
            return new Cell(this.Row, this.Col, (int)this.Color);
        }
    }
}
