using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject
{
    internal class Predator : Prey
    {
        private const int DefaultTimeToFeed = 6;
        private const int TimeToReproduce = 6;

        private int timeToFeed;

        public Predator(Coordinate coordinate, int timeToFeed = DefaultTimeToFeed) : base(coordinate)
        {
            setImage('S');
            this.timeToFeed = timeToFeed;
        }

        public override void Process()
        {
            Coordinate shouldBeEatenPreyCoordinate = getPreyCoord();
            Coordinate predatorCoordinate = GetEmptyNeighborCoord();

            if (timeToFeed <= 0)
            {
                AssignCellAt(getOffset(), new Cell(getOffset()));

                ocean.numPredators--;
            }
            else if (timeToReproduce <= 0) {
                Reproduce(predatorCoordinate);
            }

            else
            {
                if ((shouldBeEatenPreyCoordinate.getX() != getOffset().getX() || shouldBeEatenPreyCoordinate.getY() != getOffset().getY())
                    || (shouldBeEatenPreyCoordinate.getX() != getOffset().getX() & shouldBeEatenPreyCoordinate.getY() != getOffset().getY()))
                {
                    int numPrey = ocean.getNumPrey();
                    int numPreyEaten = ocean.getNumPreyEaten();

                    ocean.numPrey--;
                    ocean.setNumPreyEaten(numPreyEaten++);

                    timeToFeed = DefaultTimeToFeed;
                    timeToReproduce = TimeToReproduce;

                    MoveFrom(getOffset(), shouldBeEatenPreyCoordinate);
                }

                else
                {
                    MoveFrom(getOffset(), predatorCoordinate);
                    timeToReproduce--;
                    timeToFeed--;
                }
            }
        }

        protected override void Reproduce(Coordinate coordinate)
        {
            ocean.numPredators++;
            AssignCellAt(coordinate, new Predator(coordinate));
        }
    }
}
