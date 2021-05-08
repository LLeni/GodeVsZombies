using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeVsZombies2
{
    class ZombieController
    {
        CodeVsZombieProblem problem;
        double[][] distances;

        public ZombieController(CodeVsZombieProblem problem)
        {
            distances = new double[problem.zombies.Length][];
            for(int i = 0; i < problem.zombies.Length; i++)
            {
                distances[i] = new double[problem.humans.Length + 1];
            }

            CalculateDistances();
        }

        private void CalculateDistances()
        {
            for(int nZombie = 0; nZombie < problem.zombies.Length; nZombie++)
            {
                for(int nHuman = 0; nHuman < problem.humans.Length; nHuman++)
                {
                    if(nHuman == 0)
                    {
                        distances[nZombie][nHuman] = Math.Sqrt(Math.Pow(problem.zombies[nZombie].x  - problem.player.x, 2) + Math.Pow(problem.zombies[nZombie].y - problem.player.y, 2));
                    } else
                    {
                        distances[nZombie][nHuman] = Math.Sqrt(Math.Pow(problem.zombies[nZombie].x - problem.humans[nHuman - 1].x, 2) + Math.Pow(problem.zombies[nZombie].y - problem.humans[nHuman - 1].y, 2));
                    }
                }
            }
        }


        public void Move()
        {
            double min = -1;
            int indexHuman = -1;
            for (int nZombie = 0; nZombie < problem.zombies.Length; nZombie++)
            {
                min = -1;
                for (int nHuman = 0; nHuman < problem.humans.Length; nHuman++)
                {
                    if (distances[nZombie][nHuman] < min)
                    {
                        min = distances[nZombie][nHuman];
                        indexHuman = nHuman;
                    }


                }
            }

            
            if(indexHuman == 0)
            {
               problem.player.x
            } else
            {

            }

         /*   if(min <= 40)
            {

            }*/
            CalculateDistances();
        }
    }
}
