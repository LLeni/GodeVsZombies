using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeVsZombies2
{
    class Visualization
    {


        public Bitmap ZombieSprite = Properties.Resources.ZombieSprite,
                      HumanSprite = Properties.Resources.HumanSprite,
                      AshSprite = Properties.Resources.AshSprite;

        public CodeVsZombieProblem problem;

        public Visualization(CodeVsZombieProblem problem)
        {
            this.problem = problem;
        }

        public Graphics showTargets(Graphics g) {


            //Люди
            for (int i = 0; i < problem.humans.Length; i++)
            {
                if (problem.humans[i].isAlive)
                {
                    g.DrawImage(HumanSprite, new Rectangle((int)problem.humans[i].x - 8, (int)problem.humans[i].y - 8, 16, 16));
                }
            }

            //Зомби
            for (int i = 0; i < problem.zombies.Length; i++)
            {
                g.DrawImage(ZombieSprite, new Rectangle((int)problem.zombies[i].x - 8, (int)problem.zombies[i].y - 8, 16, 16));
            }


            //Игрок
            g.DrawImage(AshSprite, new Rectangle((int)problem.player.x - 8, (int)problem.player.y - 8, 16, 16));


            return g;
        }

        public Graphics showDirections(Graphics g)
        {
            Pen pen = new Pen(new SolidBrush(Color.Red));

            for (int nZombie = 0; nZombie < problem.zombies.Length; nZombie++) {
                if (problem.zombies[0].currentHuman != null)
                {
                    if (problem.zombies[0].currentHuman.index == -1)
                    {
                        g.DrawLine(pen, (int)problem.zombies[nZombie].x, (int)problem.zombies[nZombie].y, (int)problem.player.x, (int)problem.player.y);
                    }
                    else
                    {
                        g.DrawLine(pen, (int)problem.zombies[nZombie].x, (int)problem.zombies[nZombie].y, (int)problem.humans[problem.zombies[nZombie].currentHuman.index].x, (int)problem.humans[problem.zombies[nZombie].currentHuman.index].y);
                    }
                }
            }
            return g;
        }
     
    }
}
