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
        private const int DefaultNumOperations = 1000;

        private int numRows;
        private int numColumns;
        private int numPrey;
        private int numPredators;
        private int numObstacles;
        private int numOperations;
        private Random random = new Random();
        private Cell[,] cells;
        private int size;

        public Ocean()
        {
            Initialize();
        }

        public void Initialize() {
            InitCells();
        }

        public int getNumRows() {
            return numRows;
        }

        private void setNumRows(int rowsCount) {
            if (rowsCount > 25 || rowsCount < 0)
            {
                numRows = DefaultNumRows;
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

        private void setNumPrey(int preyCount)
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

        private void setNumPredators(int predatorsCount)
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
                numObstacles = DefaultNumObstacles;
                throw new InvalidInputException();
            }
            else
            {
                numObstacles = obstaclesCount;
            }
        }

        public int getNumOperations() {
            return numOperations;
        }

        private void setNumOperations(int numOperations) {
            if (numOperations < 0 || numOperations > 1000) {
                this.numOperations = DefaultNumOperations;
                throw new InvalidInputException();
            }
        }

        public Cell[,] getCells() {
            return cells;
        }

        public Random getRandom() {
            return random;
        }

        private void InitCells()
        {
            AddEmptyCells();

            try
            {
                Console.Write("Enter the number of obstacles: ");
                setNumObstacles(Convert.ToInt32(Console.ReadLine()));

                Console.Write("Enter the number of predators: ");
                setNumPredators(Convert.ToInt32(Console.ReadLine()));

                Console.Write("Enter the number of prey: ");
                setNumPrey(Convert.ToInt32(Console.ReadLine()));
            }
            catch (InvalidInputException exception) {
                Console.WriteLine(exception.getMessage());
            }

            Console.WriteLine("\nNumber of obstacles is " + numObstacles);
            Console.WriteLine("Number of predators is " + numPredators);
            Console.WriteLine("Number of prey is " + numPrey);

            AddObstacles();
            AddPredators();
            AddPrey();

            DisplayStats(0);
            DisplayCells();
            DisplayBorder();
        }

        private void AddEmptyCells()
        {
            try
            {
                Console.Write("Enter the count of rows: ");
                setNumRows(Convert.ToInt32(Console.ReadLine()));

                Console.Write("Enter the count of columns: ");
                setNumColumns(Convert.ToInt32(Console.ReadLine()));
            }
            catch (InvalidInputException exception) {
                Console.WriteLine(exception.getMessage());
            }

            cells = new Cell[numRows, numColumns];

            size = numColumns * numRows;

            for (int row = 0; row < numRows; row++)
            {
                for (int column = 0; column < numColumns; column++)
                {
                    cells[row, column] = new Cell(new Coordinate(row, column));
                }
            }
        }

        private void AddObstacles()
        {
            Coordinate emptyCell;
            for (int i = 0; i < numObstacles; i++)
            {
                emptyCell = GetEmptyCellCoord();
                cells[emptyCell.X, emptyCell.Y] = new Obstacle(emptyCell);
            }
        }

        private void AddPredators()
        {
            Coordinate emptyCell;
            for (int i = 0; i < numPredators; i++)
            {
                emptyCell = GetEmptyCellCoord();
                cells[emptyCell.X, emptyCell.Y] = new Predator(emptyCell);
            }
        }

        private void AddPrey()
        {
            Coordinate emptyCell;
            for (int i = 0; i < numPrey; i++)
            {
                emptyCell = GetEmptyCellCoord();
                cells[emptyCell.X, emptyCell.Y] = new Prey(emptyCell);
            }
        }

        private Coordinate GetEmptyCellCoord()
        {
            int y = random.Next(0, numColumns - 1);
            int x = random.Next(0, numRows - 1);

            Coordinate emptyCell;

            while (cells[x, y].getImage() != '-') {
                y = random.Next(0, numColumns - 1);
                x = random.Next(0, numRows - 1);
            }

            emptyCell = cells[x, y].getOffset();
            return emptyCell;
        }

        private void DisplayBorder()
        {
            for (int column = 0; column < numColumns; column++)
            {
                if (column == numColumns - 1)
                {
                    Console.WriteLine();
                }
                else if (column == 0)
                {
                    Console.WriteLine();
                    Console.Write(new String(' ', 30));
                    Console.Write("*");
                }
                else
                {
                    Console.Write("*");
                }
            }
        }

        private void DisplayCells()
        {
            for (int row = 0; row < numRows; row++)
            {
                for (int column = 0; column < numColumns; column++)
                {
                    cells[row, column].Display();
                }
            }
        }

        private void DisplayStats(int iteration)
        {
            Console.WriteLine("\nIteration number: " + iteration++);
            Console.WriteLine("Number of obstacles: " + numObstacles);
            Console.WriteLine("Number of predators: " + numPredators);
            Console.WriteLine("Number of prey: " + numPrey);

            DisplayBorder();
        }

        public void Run()
        {
            try
            {
                Console.WriteLine("Enter the number of operations: ");
                setNumOperations(Convert.ToInt32(Console.ReadLine()));
            }
            catch (InvalidInputException exception) {
                Console.WriteLine(exception.getMessage());
            }

            Console.WriteLine("The number of operations: " + numOperations);

            for (int operation = 0; operation < numOperations; operation++) { 
                if (numPredators > 0 && numPrey > 0)
                {
                    for (int row = 0; row < numRows; row++)
                    {
                        for (int column = 0; column < numColumns; column++)
                        {
                            cells[row, column].Process();
                        }
                    }

                    DisplayStats(operation);
                    DisplayCells();
                    DisplayBorder();
                }
            }
        }
    }
}
