using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeVsZombies2
{
    class Zombie
    {

       
        public double x;
        public double y;
        public int index;
        public bool isAlive;

        public Human currentHuman;
        public bool isTargetHuman;

        public Zombie(double x, double y, int index)
        {
            this.x = x;
            this.y = y;
            this.index = index;
            isAlive = true;
        }
    }
}
