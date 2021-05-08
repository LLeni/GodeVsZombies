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
        public int x;
        public int y;

        public Zombie(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
