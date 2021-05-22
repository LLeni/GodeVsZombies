using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeVsZombies2
{
    class Target
    {
        public double x;
        public double y;
        public int index;

        public TypeTarget typeTarget;

        private int amountNeightbors;
        
        public enum TypeTarget {
            Player,
            Human
        }

        public Target(double x, double y, int index, TypeTarget typeTarget) {
            this.x = x;
            this.y = y;
            this.index = index;
            this.typeTarget = typeTarget;
        }
        public Target(double x, double y, int index, TypeTarget typeTarget, int amountNeightbors):this(x, y, index, typeTarget)
        {
            this.amountNeightbors = amountNeightbors;
        }


        public void SetAmountNeightbors(int amountNeightbors)
        {
            this.amountNeightbors
        }
    }
}
