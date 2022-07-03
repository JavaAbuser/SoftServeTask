using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject
{
    internal class Cell
    {
        public Ocean ocean;
        private char image;
        private Coordinate offset;

        public Cell(Coordinate offset, char image = '-')
        {
            this.image = image;
            this.offset = offset;
        }

        public void setOcean(Ocean ocean) {
            this.ocean = ocean;
        }

        public Coordinate getOffset() {
            return offset;
        }

        protected void setOffset(Coordinate value) {
            offset = value;
        }

        public char getImage() {
            return image;
        }

        public void setImage(char image) {
            this.image = image;
        }

        public void Display()
        {
            Console.Write(image);
        }

        public virtual void Process()
        {
            //TODO: process
        }

        protected virtual Cell Reproduce(Coordinate coordinate)
        {
            return new Cell(coordinate);
        }

        private Cell GetNeighborWithImage(char image)
        {
            char westNeightbor = West().getImage();
            char southNeightbor = South().getImage();
            char northNeightbor = North().getImage();
            char eastNeightbor = East().getImage();

            int neightborCount = 0;

            Cell[] neightbors = new Cell[4];

            Cell cell;

            if (westNeightbor.Equals(image))
            {
                neightbors[neightborCount++] = West();
            }
            if (southNeightbor.Equals(image)) 
            {
                neightbors[neightborCount++] = South();
            }
            if (northNeightbor.Equals(image))
            {
                neightbors[neightborCount++] = North();
            }
            if (eastNeightbor.Equals(image))
            {
                neightbors[neightborCount++] = East();
            }

            if (neightborCount != 0)
            {
                cell = neightbors[ocean.getRandom().Next(0, neightbors.Length - 1)];
            }
            else {
                cell = this;
            }

            return cell;

        }

        protected Coordinate GetEmptyNeighborCoord()
        {
            char westNeightbor = West().getImage();
            char southNeightbor = South().getImage();
            char northNeightbor = North().getImage();
            char eastNeightbor = East().getImage();

            char empty = '-';

            Cell[] emptyNeightbors = new Cell[4];

            Cell cell;

            int count = 0;


            if (westNeightbor.Equals(empty)) {
                emptyNeightbors[count++] = West();
            }
            if (southNeightbor.Equals(empty))
            {
                emptyNeightbors[count++] = South();
            }
            if (northNeightbor.Equals(empty))
            {
                emptyNeightbors[count++] = North();
            }
            if (eastNeightbor.Equals(empty))
            {
                emptyNeightbors[count++] = East();
            }

            if (count != 0)
            {
                cell = emptyNeightbors[ocean.getRandom().Next(0, emptyNeightbors.Length - 1)];
            }
            else
            {
                cell = this;
            }

            return cell.getOffset();
        }
        protected Coordinate getPreyCoord()
        {
            return GetNeighborWithImage('f').getOffset();
        }

        protected Cell GetCellAt(Coordinate coordinate)
        {
            return ocean.getCells()[coordinate.X, coordinate.Y];
        }

        protected void AssignCellAt(Coordinate coordinate, Cell cell)
        {
            ocean.getCells()[coordinate.X, coordinate.Y] = cell;
        }

        private Cell East()
        {
            Cell cell = this;
            if (this.getOffset().X == ocean.getNumRows() - 1)
            {
                cell = this;
            }
            else 
            {
                Coordinate coordinate = new Coordinate(this.getOffset().X + 1, this.getOffset().Y);
                cell = GetCellAt(coordinate);
            }

            return cell;
        }

        private Cell West()
        {
            Cell cell = this;
            if (this.getOffset().X == 0)
            {
                cell = this;
            }
            else {
                Coordinate coordinate = new Coordinate(this.getOffset().X - 1, this.getOffset().Y);
                cell = GetCellAt(coordinate);
            }

            return cell;
        }

        private Cell North()
        {
            Cell cell = this;
            if (this.getOffset().Y == 0)
            {
                cell =  this;
            }
            else
            {
                Coordinate coordinate = new Coordinate(this.getOffset().X, this.getOffset().Y - 1);
                cell = GetCellAt(coordinate);
            }

            return cell;
        }

        private Cell South()
        {
            Cell cell = this;
            if (this.getOffset().Y == ocean.getNumColumns() - 1)
            {
                cell = this;
            }
            else
            {
                Coordinate coordinate = new Coordinate(this.getOffset().X, this.getOffset().Y + 1);
                cell = GetCellAt(coordinate);
            }

            return cell;
        }
    }
}
