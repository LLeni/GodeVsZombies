using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeVsZombies2
{
    class Player : Target
    {
        public Zombie currentZombie;


        public Player(double x, double y, int index):base(x, y, index, TypeTarget.Player, -1) // -1 - значит игрок
        {
  
        }


        public void setCurrentZombie(Zombie zombie)
        {
            this.currentZombie = zombie;
        }
    }
}
