using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeVsZombies2
{
    class Evaluator
    {

        public static int evaluate(Solution solution)
        {
            int maxNeightbors = 0;
            int indexMustProtectedHuman
            for (int nHuman = 0; nHuman < solution.Humans.Length; nHuman++)
            {
                if(maxNeightbors < solution.Humans[nHuman].amountNeightbors)
                {
                    maxNeightbors = solution.Humans[nHuman].amountNeightbors;
                }
            }

            Human mustProtectedHuman;

            for(int nZombie = 0; nZombie < solution.Zombies.Length; nZombie++)
            {
                if(solution.Zombies[nZombie].currentHuman.)
            }

            return 0;
        }

        public static void defineNeightbors(Human[] humans)
        {
            double vX, vY, lengthV;
            for(int nHuman = 0; nHuman < humans.Length; nHuman++)
            {
                for(int nNeightbor = nHuman + 1; nNeightbor < humans.Length; nNeightbor++)
                {
                    vX = humans[nHuman].x - humans[nNeightbor].x;
                    vY = humans[nHuman].y - humans[nNeightbor].y;

                    lengthV = Math.Sqrt(vX * vX + vY * vY);

                    if(lengthV <= 200)
                    {
                        humans[nHuman].amountNeightbors++;
                    }
                }
            }
        } 
    }
}
