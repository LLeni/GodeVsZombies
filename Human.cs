using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeVsZombies2
{
    class Human : Target
    {
        public bool isAlive;

        public int amountNeightbors;

        public Human(double x, double y, int index):base(x, y, index, TypeTarget.Human)
        {
            isAlive = true;

        }
    }
}
