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
        private int numPreyEaten;
        private int numObstacles;
        private int numOperations;
        private Random random = new Random();
        private Cell[,] cells;
        private int size;

        public int numPredators;
        public int numPrey;

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

        public void setNumRows(int rowsCount) {
            if (rowsCount > DefaultNumRows || rowsCount < 0)
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

        public void setNumColumns(int columnsCount)
        {
            if (columnsCount > DefaultNumColumns || columnsCount < 0)
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

        public void setNumPrey(int preyCount)
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

        public int getNumPreyEaten() {
            return numPreyEaten;
        }

        public void setNumPreyEaten(int count) {
            numPreyEaten = count;
        }

        public int getNumPredators()
        {
            return numPredators;
        }

        public void setNumPredators(int predatorsCount)
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

        public void setNumObstacles(int obstaclesCount) {
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

        public void setNumOperations(int numOperations) {
            if (numOperations < 0 || numOperations > 1000)
            {
                this.numOperations = DefaultNumOperations;
                throw new InvalidInputException();
            }
            else {
                this.numOperations = numOperations;
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
                ViewResolver.EnterNumOfEntities(this);
            }
            catch (InvalidInputException exception) {
                Console.WriteLine(exception.getMessage());
            }

            ViewResolver.PrintInfo(this);

            AddObstacles();
            AddPredators();
            AddPrey();
        }

        private void AddEmptyCells()
        {
            try
            {
                ViewResolver.EnterNumOfRowsAndColumns(this);
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
                cells[emptyCell.getX(), emptyCell.getY()] = new Obstacle(emptyCell);
            }
        }

        private void AddPredators()
        {
            Coordinate emptyCell;
            for (int i = 0; i < numPredators; i++)
            {
                emptyCell = GetEmptyCellCoord();
                cells[emptyCell.getX(), emptyCell.getY()] = new Predator(emptyCell);
            }
        }

        private void AddPrey()
        {
            Coordinate emptyCell;
            for (int i = 0; i < numPrey; i++)
            {
                emptyCell = GetEmptyCellCoord();
                cells[emptyCell.getX(), emptyCell.getY()] = new Prey(emptyCell);
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
                    Console.Write(new String(' ', 50));
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
                Console.Write(new String(' ', 50));
                for (int column = 0; column < numColumns; column++)
                {
                    cells[row, column].Display();
                }
                Console.Write("\n");
            }
        }

        private void DisplayStats(int operation)
        {
            ViewResolver.PrintInfo(this);

            DisplayBorder();
        }

        public void Run()
        {
            try
            {
                ViewResolver.EnterOperations(this);
            }
            catch (InvalidInputException exception) {
                Console.WriteLine(exception.getMessage());
            }

            ViewResolver.PrintNumOfOperations(this);

            for (int operation = 1; operation <= numOperations; operation++) {
                if (numPredators > 0 && numPrey > 0)
                {
                    for (int row = 0; row < numRows; row++)
                    {
                        for (int column = 0; column < numColumns; column++)
                        {
                            Cell cell = cells[row, column];
                            cell.setOcean(this);
                            cell.Process();
                        }
                    }

                    DisplayStats(operation);
                    DisplayCells();
                    DisplayBorder();
                }
            }

            Console.ReadLine();
        }
    }
}
