using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject
{
    internal class Prey : Cell
    {
        private const int DefaultTimeToReproduce = 6;

        protected int timeToReproduce;

        public Prey(Coordinate coordinate, int timeToReproduce = DefaultTimeToReproduce) : base(coordinate)
        {
            setImage('f');
            this.timeToReproduce = timeToReproduce;
        }

        public override void Process()
        {

            Coordinate coordinate = GetEmptyNeighborCoord();
            Coordinate preyCoordinate = GetEmptyNeighborCoord();

            if (timeToReproduce <= 0)
            {
                Reproduce(preyCoordinate);
                return;
            }
            else
            {
                MoveFrom(getOffset(), coordinate);
                timeToReproduce--;
            }

        }

        protected void MoveFrom(Coordinate from, Coordinate to)
        {
            if ((from.getX() != to.getX() || from.getY() != to.getY())
                    || (from.getX() != to.getX() & from.getY() != to.getY()))
            {
                setOffset(to);

                AssignCellAt(to, this);
                AssignCellAt(from, new Cell(from));
            }
        }

        protected override void Reproduce(Coordinate coordinate)
        {
            ocean.numPrey++;
            AssignCellAt(coordinate, new Prey(coordinate));
        }
    }
}
