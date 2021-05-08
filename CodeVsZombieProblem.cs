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
            for(int i = 0; i < 5; i++)
            {
                zombies[i] = new Zombie(i*100, i*100);
            }

            humans = new Human[2];
            humans[0] = new Human(200, 200);
            humans[1] = new Human(500, 200);

            player = new Player(400, 100);
        }
    }
}
