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
            this.problem = problem;
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
                for(int nHuman = 0; nHuman < problem.humans.Length + 1; nHuman++)
                {
                    if(nHuman == 0)
                    {
                        distances[nZombie][nHuman] = Math.Sqrt(Math.Pow(problem.zombies[nZombie].x  - problem.player.x, 2) + Math.Pow(problem.zombies[nZombie].y - problem.player.y, 2));
                    } else
                    {
                        distances[nZombie][nHuman] = Math.Sqrt(Math.Pow(problem.zombies[nZombie].x - problem.humans[nHuman - 1].x, 2) + Math.Pow(problem.zombies[nZombie].y - problem.humans[nHuman - 1].y, 2));
                    }
                    Console.Write(distances[nZombie][nHuman] + " ");
                }
                Console.WriteLine();
            }
        }


        public void Move()
        {
            double min = int.MaxValue;
            int indexHuman = -1;
            for (int nZombie = 0; nZombie < problem.zombies.Length; nZombie++)
            {
                min = int.MaxValue;
                for (int nHuman = 0; nHuman < problem.humans.Length + 1; nHuman++)
                {
                    if (distances[nZombie][nHuman] < min)
                    {
                     
                        min = distances[nZombie][nHuman];
                        indexHuman = nHuman;
                    }
                }

                // узнаем угол между гипотенузой и горизонтальным катетом
                // AB - гипотенуза
                // AC - горизонтальный катет


                double Ax, Ay, Bx, By;
                if (indexHuman == 0)
                {


                    Ax = problem.zombies[nZombie].x;
                    Ay = problem.zombies[nZombie].y;

                    Bx = problem.player.x;
                    By = problem.player.y;

                }
                else
                {
                    Ax = problem.zombies[nZombie].x;
                    Ay = problem.zombies[nZombie].y;

                    Bx = problem.humans[indexHuman-1].x;
                    By = problem.humans[indexHuman - 1].y;

                }

                double dx = Bx - Ax;
                double dy = By - Ay;

                // нормализующий вектор
                double nx = dx / Math.Sqrt(dx * dx + dy * dy);
                double ny = dy / Math.Sqrt(dx * dx + dy * dy);
                Console.WriteLine("Нормализующий вектор " + nx + " и " + ny);
                /*double ex = Cx - Ax;
                double ey = Cy - Ay;
                d
                double angle = (dx * ex + dy * ey) / (Math.Sqrt(dx * dx + dy * dy) + Math.Sqrt(ex * ex + ey * ey));
                Console.WriteLine(angle + " ddddd");*/

                double newX = 40 * nx;
                double newY = 40 * ny;

                problem.zombies[nZombie].x = newX;
                problem.zombies[nZombie].y = newY;
            }

            

         /*   if(min <= 40)
            {

            }*/
            CalculateDistances();
        }
    }
}
