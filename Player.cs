using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeVsZombies2
{
    class Player
    {
        public Zombie currentZombie;
        public int x;
        public int y;

        public Player(int x, int y)
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
