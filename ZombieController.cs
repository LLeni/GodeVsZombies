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
                    if (distances[nZombie][nHuman] != -1)
                    {
                        if (nHuman == 0)
                        {
                            distances[nZombie][nHuman] = Math.Sqrt(Math.Pow(problem.zombies[nZombie].x - problem.player.x, 2) + Math.Pow(problem.zombies[nZombie].y - problem.player.y, 2));
                        }
                        else
                        {
                            distances[nZombie][nHuman] = Math.Sqrt(Math.Pow(problem.zombies[nZombie].x - problem.humans[nHuman - 1].x, 2) + Math.Pow(problem.zombies[nZombie].y - problem.humans[nHuman - 1].y, 2));
                        }
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
                    if (distances[nZombie][nHuman] < min && distances[nZombie][nHuman] != -1)
                    {
                     
                        min = distances[nZombie][nHuman];
                        indexHuman = nHuman;
                    }
                }


                double Ax, Ay, Bx, By;

                //TODO: необходимо создать родительский класс для Human и Player DONE
                //TODO: во всех ветвях у зомби есть цель DONE
                //TODO: Отображение кругов перенести в Visualization DONE
                //TODO: В Visualization отображать направления зомби (не работает) 
                //TODO: когда зомби близко к цели - съездает и переключается на следующую  DONE


                if (distances[nZombie][indexHuman] <= 40)
                {
                    if (indexHuman == 0)
                    {
                        problem.zombies[nZombie].x = problem.player.x;
                        problem.zombies[nZombie].y = problem.player.y;
                        //убить игрока невозможно

                    } else
                    {
                        problem.zombies[nZombie].x = problem.humans[indexHuman - 1].x;
                        problem.zombies[nZombie].y = problem.humans[indexHuman - 1].y;
                        Console.WriteLine("СЪЕЛИ");
                        eat(indexHuman);
                    }
                }
                else
                {

                    Ax = problem.zombies[nZombie].x;
                    Ay = problem.zombies[nZombie].y;
                    if (indexHuman == 0)
                    {
                        Bx = problem.player.x;
                        By = problem.player.y;
                        problem.zombies[nZombie].currentHuman = problem.player;
                    }
                    else
                    {

                        Bx = problem.humans[indexHuman - 1].x;
                        By = problem.humans[indexHuman - 1].y;
                        problem.zombies[nZombie].currentHuman = problem.humans[indexHuman - 1];


                    }

                    double dx = Bx - Ax;
                    double dy = By - Ay;

                    // нормализующий вектор
                    double nx = dx / Math.Sqrt(dx * dx + dy * dy);
                    double ny = dy / Math.Sqrt(dx * dx + dy * dy);

                    double shiftX = 40 * nx;
                    double shiftY = 40 * ny;

                    problem.zombies[nZombie].x = shiftX + problem.zombies[nZombie].x;
                    problem.zombies[nZombie].y = shiftY + problem.zombies[nZombie].y;
                }
            }

            

         /*   if(min <= 40)
            {

            }*/
            CalculateDistances();
        }


        //Зомби съездает человека и в матрице весов дистанция до него меняется на -1, что значит он мертв
        private void eat(int indexHuman)
        {
            problem.humans[indexHuman - 1].isAlive = false;
            for(int nZombie = 0; nZombie < problem.zombies.Length; nZombie++)
            {
                distances[nZombie][indexHuman] = -1;
            }
        }
    }
}
