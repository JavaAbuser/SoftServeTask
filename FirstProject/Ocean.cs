using System;

namespace FirstProject
{
    internal class Ocean
    {
        private const int DefaultNumRows = 25;
        private const int DefaultNumColumns = 70;
        private const int DefaultNumPrey = 150;
        private const int DefaultNumPredators = 20;
        private const int DefaultNumObstacles = 75;

        private int numRows;
        private int numColumns;
        private int numPrey;
        private int numPredators;
        private int numObstacles;
        private Random random = new Random();
        private Cell[,] cells;
        private int size;

        public Ocean(int numRows, int numColumns, int numPrey, int numPredators, int numObstacles)
        {
            this.numRows = numRows;
            this.numColumns = numColumns;
            this.numPrey = numPrey;
            this.numPredators = numPredators;
            this.numObstacles = numObstacles;

            Initialize();
        }

        private void Initialize() {
            size = this.numRows * this.numColumns;
            cells = new Cell[this.numRows, this.numColumns];

            InitCells();
        }

        public int getNumRows() {
            return numRows;
        }

        private void setNumRows(int rowsCount) {
            if (rowsCount > 25 || rowsCount < 0)
            {
                numRows = DefaultNumColumns;
                throw new InvalidInputException();
            }
            else
            {
                numRows = rowsCount;
            }
        }

        public int getNumColumns()
        {
            return numColumns;
        }

        private void setNumColumns(int columnsCount)
        {
            if (columnsCount > 70 || columnsCount < 0)
            {
                numColumns = DefaultNumColumns;
                throw new InvalidInputException();
            }
            else
            {
                numColumns = columnsCount;
            }
        }

        public int getNumPrey()
        {
            return numPrey;
        }

        private void setPreyCount(int preyCount)
        {
            if (preyCount < 0 || preyCount > size - numObstacles)
            {
                numPrey = DefaultNumPrey;
                throw new InvalidInputException();
            }
            else
            {
                numPrey = preyCount;
            }
        }

        public int getNumPredators()
        {
            return numPredators;
        }

        private void setPredatorsCount(int predatorsCount)
        {
            if (predatorsCount < 0 || predatorsCount > size - numObstacles)
            {
                numPredators = DefaultNumPredators;
                throw new InvalidInputException();
            }
            else
            {
                numPredators = predatorsCount;
            }
        }

        public int getNumObstacles(){
            return numObstacles;
        }

        private void setNumObstacles(int obstaclesCount) {
            if (obstaclesCount > size || obstaclesCount < 0)
            {
                numObstacles = size;
                throw new InvalidInputException();
            }
            else
            {
                numObstacles = obstaclesCount;
            }
        }

        private void InitCells()
        {
            AddEmptyCells();

            try
            {
                Console.WriteLine("Enter the number of obstacles: ");
                numObstacles = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter the number of predators: ");
                numPredators = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter the number of prey: ");
                numPrey = Convert.ToInt32(Console.ReadLine());
            }
            catch (InvalidInputException exception) {
                Console.WriteLine(exception.getMessage());
            }

            Console.WriteLine("Number of obstacles is " + numObstacles);
            Console.WriteLine("Number of predators is " + numPredators);
            Console.WriteLine("Number of prey is " + numPrey);

            AddObstacles();
            AddPredators();
            AddPrey();

            DisplayStats(-1);
            DisplayCells();
            DisplayBorder();
        }

        private void AddEmptyCells()
        {
            for (int row = 0; row < numRows; row++)
            {
                for (int column = 0; column < numColumns; column++)
                {
                    Cell cell = new Cell(new Coordinate(column, row));
                    cells[row, column] = cell;
                    cell.owner = this;
                }
            }
        }

        private void AddObstacles()
        {
            Coordinate emptyCell;
            for (int i = 0; i < numObstacles; i++)
            {
                emptyCell = GetEmptyCellCoord();
                cells[emptyCell.Y, emptyCell.X] = new Obstacle(emptyCell);
            }
        }

        private void AddPredators()
        {
            Coordinate emptyCell;
            for (int i = 0; i < numPredators; i++)
            {
                emptyCell = GetEmptyCellCoord();
                cells[emptyCell.Y, emptyCell.X] = new Predator(emptyCell);
            }
        }

        private void AddPrey()
        {
            Coordinate emptyCell;
            for (int i = 0; i < numPrey; i++)
            {
                emptyCell = GetEmptyCellCoord();
                cells[emptyCell.Y, emptyCell.X] = new Prey(emptyCell);
            }
        }

        private Coordinate GetEmptyCellCoord()
        {
            int y = random.Next(0, numRows - 1);
            int x = random.Next(0, numColumns - 1);

            Coordinate emptyCell;

            while (cells[y, x].image != '-') {
                y = random.Next(0, numRows - 1);
                x = random.Next(0, numColumns - 1);
            }

            emptyCell = cells[y, x].offset;
            return emptyCell;
        }

        private void DisplayBorder()
        {

        }

        private void DisplayCells()
        {

        }

        private void DisplayStats(int iteration)
        {

        }

        public void Run()
        {

        }
    }
}
