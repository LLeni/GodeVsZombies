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
            int evaluation = 0;

            int maxNeightbors = 0;
            int indexMustProtectedHuman;
            for (int nHuman = 0; nHuman < solution.Humans.Length; nHuman++)
            {
                if(maxNeightbors < solution.Humans[nHuman].amountNeightbors)
                {
                    maxNeightbors = solution.Humans[nHuman].amountNeightbors;
                }
            }

            List<Human> mustProtectedHumans = new List<Human>();

            for(int nZombie = 0; nZombie < solution.Zombies.Length; nZombie++)
            {
                if(solution.Zombies[nZombie].isTargetHuman && solution.Zombies[nZombie].currentHuman.amountNeightbors == maxNeightbors)
                {
                    mustProtectedHumans.Add(solution.Zombies[nZombie].currentHuman);
                }
            }

            for(int nZombie = 0; nZombie < solution.Zombies.Length; nZombie++)
            {
                if (mustProtectedHumans.Contains(solution.Zombies[nZombie].currentHuman))
                {
                    if(solution.Zombies[nZombie] == solution.Player.currentZombie)
                    {
                         evaluation += 20 * maxNeightbors;
                    } else
                    {
                         evaluation += -20 * maxNeightbors;
                    }
                         
                } else
                {
                    if(solution.Zombies[nZombie] == solution.Player.currentZombie)
                    {
                        evaluation += 10 * maxNeightbors;
                    } else
                    {
                        evaluation += -10 * maxNeightbors;
                    }
                }
            }


            //Если зомби идет к игроку, то получаем за это пряню
            for(int nZombie = 0; nZombie < solution.Zombies.Length; nZombie++)
            {
                if (solution.Zombies[nZombie].isTargetHuman)
                {
                    evaluation += 100;
                }
            }

            System.Diagnostics.Debug.WriteLine("Ev: " + evaluation);
            return evaluation;
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
