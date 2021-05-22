using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeVsZombies2
{
    class PlayerController
    {
        public Solution solution;

        public PlayerController(Solution solution)
        {
            this.solution = solution;
        }

        public void Move()
        {

        }

        //возвращается количество убитых зомби
        public int Kill()
        {

            int countKilledZombies = 0;
            //Вектор
            double vX, vY, lengthV;
            for (int nZombie = 0; nZombie < solution.Zombies.Length; nZombie++)
            {
                if (solution.Zombies[nZombie].isAlive)
                {
                    vX = solution.Zombies[nZombie].x - solution.Player.x;
                    vY = solution.Zombies[nZombie].y - solution.Player.y;

                    lengthV = Math.Sqrt(vX * vX + vY * vY);
                    Console.WriteLine("Длина вектора у зомби " + nZombie + " равна " + lengthV);
                    if (lengthV <= 200)
                    {
                        solution.Zombies[nZombie].isAlive = false;
                        countKilledZombies++;
                    }

                }
            }
            return countKilledZombies;

        }
    }
}
