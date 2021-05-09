using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeVsZombies2
{
    class Zombie
    {

        public Human currentHuman;
        public double x;
        public double y;

        public Zombie(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
