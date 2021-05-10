using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeVsZombies2
{
    class CodeVsZombieProblem
    {
        public Zombie[] zombies;
        public Human[] humans;
        public Player player;

        public CodeVsZombieProblem()
        {
            zombies = new Zombie[5];
            zombies[0] = new Zombie(500, 0, 0);
            for (int i = 1; i < 5; i++)
            {
                zombies[i] = new Zombie(i*100, i*100, i);
            }

            humans = new Human[3];
            humans[0] = new Human(250, 200, 0);
            humans[1] = new Human(500, 200, 1);
            humans[2] = new Human(1200, 200, 2);

            player = new Player(1440, 320, -1);
        }
    }
}
