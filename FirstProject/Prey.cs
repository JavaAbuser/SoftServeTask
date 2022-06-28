using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject
{
    internal class Prey : Cell
    {
        private new Ocean ocean1 = new Ocean();
        protected int timeToReproduce;
        public Prey(int timeToReproduce = 6) : base(new Coordinate(0, 0)) {
            this.timeToReproduce = timeToReproduce;
            image = 'f';
        }
        protected void MoveFrom(Coordinate from, Coordinate to)
        {
            Cell cell = null;
            if (from != to) {
                cell = getCellAt(to);
                setOffset(to);
                assignCellAt(to, this);
                if (timeToReproduce <= 0)
                {
                    timeToReproduce = 6;
                    assignCellAt(from, Reproduce(from));
                }
                else {
                    assignCellAt(from, new Cell(from));
                }
            }
        }

        public virtual Cell Reproduce(Coordinate coordinate)
        {
            return getCellAt(coordinate);
        }

        protected override void Process() {
            this.timeToReproduce--;
        }
    }
}
