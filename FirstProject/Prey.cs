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
        public Prey(Ocean ocean1 , Coordinate offset, int timeToReproduce = 6) {
            this.timeToReproduce = timeToReproduce;
            image = 'f';
        }
    }
}
