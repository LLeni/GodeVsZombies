using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeVsZombies2
{
    class Player : IHuman
    {
        public Zombie currentZombie;
        public double x;
        public double y;

        public Player(double x, double y)
        {
            this.x = x;
            this.y = y;
        }


        public void setCurrentZombie(Zombie zombie)
        {
            this.currentZombie = zombie;
        }
    }
}
