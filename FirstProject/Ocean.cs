using System;

namespace FirstProject
{
    internal class Ocean
    {
        private int numRows;
        private int numColumns;
        private int numPrey;
        private int numPredators;
        private int numObstacles;
        private Random random = new Random();
        private Cell[,] cells;
        private int size;

        public Ocean(int numRows = 25, int numColumns = 70, int numPrey = 150, int numPredators = 20, int numObstacles = 75)
        {
            this.numColumns = numColumns;
            this.numRows = numRows;
            this.numPredators = numPredators;
            this.numObstacles = numObstacles;
            this.numPrey = numPrey;
            size = numRows * numColumns;
            cells = new Cell[numRows, numColumns];
        }
    }
}
