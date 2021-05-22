using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeVsZombies2
{
    //Класс, который отображает то, что используе данные из условия
    class Simulation
    {


        private Bitmap ZombieSprite = Properties.Resources.ZombieSprite,
                      HumanSprite = Properties.Resources.HumanSprite,
                      AshSprite = Properties.Resources.AshSprite;

        private CodeVsZombieProblem problem;
        private GameController gameController;

        private const int WIDTH_FIELD = 1600;
        private const int HEIGHT_FIELD = 900;

        public Simulation(CodeVsZombieProblem problem, GameController gameController)
        {
            this.problem = problem;
            this.gameController = gameController;
        }

        public Graphics ShowTargets(Graphics g) {


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
                if (problem.zombies[i].isAlive)
                {
                    g.DrawImage(ZombieSprite, new Rectangle((int)problem.zombies[i].x - 8, (int)problem.zombies[i].y - 8, 16, 16));
                }
            }


            //Игрок
            g.DrawImage(AshSprite, new Rectangle((int)problem.player.x - 8, (int)problem.player.y - 8, 16, 16));


            return g;
        }

        public Graphics ShowDirections(Graphics g)
        {
            Pen pen = new Pen(new SolidBrush(Color.Red));

            for (int nZombie = 0; nZombie < problem.zombies.Length; nZombie++) {
                if (problem.zombies[nZombie].isAlive)
                {
                    if (problem.zombies[nZombie].isTargetHuman)
                    {
                        g.DrawLine(pen, (int)problem.zombies[nZombie].x, (int)problem.zombies[nZombie].y, (int)problem.humans[problem.zombies[nZombie].currentHuman.index].x, (int)problem.humans[problem.zombies[nZombie].currentHuman.index].y);
                    
                        }
                    else
                    {
                        g.DrawLine(pen, (int)problem.zombies[nZombie].x, (int)problem.zombies[nZombie].y, (int)problem.player.x, (int)problem.player.y);
                    
                    }
                }
            }
            return g;
        }


        public Graphics ShowRadiusPlayer(Graphics g)
        {
            Pen pen = new Pen(new SolidBrush(Color.Yellow));
            g.DrawEllipse(pen, new Rectangle((int)problem.player.x - 200, (int)problem.player.y - 200, 400, 400));
            return g;
        }

        public Graphics ShowHUD(Graphics g)
        {

            Font drawFont = new Font("Arial", 16);
            SolidBrush drawBrush = new SolidBrush(Color.White);

            String countZombiesString= "Количество зомби: ";
            g.DrawString(countZombiesString, drawFont, drawBrush, 5, 5, new StringFormat());
            g.DrawString("" + gameController.countZombies, drawFont, new SolidBrush(Color.Red), 200, 5, new StringFormat());

            String countHumansString = "Количество людей: ";
            g.DrawString(countHumansString, drawFont, drawBrush, 5, 25, new StringFormat());
            g.DrawString("" + gameController.countHumans, drawFont, new SolidBrush(Color.LightGreen), 200, 25, new StringFormat());

            String scoreString = "Очки: ";
            g.DrawString(scoreString, drawFont, drawBrush, 5, 45, new StringFormat());
            g.DrawString("" + gameController.score, drawFont, new SolidBrush(Color.Yellow), 65, 45, new StringFormat());



            String numberRoundString = "Раунд: " + gameController.numberRound;
            g.DrawString(numberRoundString, drawFont, drawBrush, 1400, 5, new StringFormat());

            String actionString = "Ход: " + gameController.action;
            g.DrawString(actionString, drawFont, drawBrush, 1300, 25, new StringFormat());

            return g;
        }
     

        public Graphics ShowDirectionsShots(Graphics g)
        {
            return g;
        }


        //TODO: правильно централизовать надписи по центру
        public Graphics ShowGameOverText(Graphics g)
        {
            Font drawFont = new Font("Arial", 30);
            SolidBrush drawBrush = new SolidBrush(Color.Red);


            String actionString = "GAME OVER";
            g.DrawString(actionString, drawFont, drawBrush, 800, 450, new StringFormat());
            return g;
        }

        public Graphics ShowWinText(Graphics g)
        {
            Font drawFont = new Font("Arial", 30);
            SolidBrush drawBrush = new SolidBrush(Color.Green);

            g.DrawString("WIN", drawFont, drawBrush, 800, 450, new StringFormat());
            g.DrawString("Набранное количество очков " + gameController.score, drawFont, drawBrush, 800, 500, new StringFormat());
            return g;
        }

        public Graphics ShowMultiplierAndReceivedScore(Graphics g)
        {
            if(gameController.multiplier != 0)
            {
                Font drawFont = new Font("Arial", 12);
                SolidBrush drawBrush = new SolidBrush(Color.Yellow);
                
                g.DrawString("x"+gameController.multiplier, drawFont, drawBrush, (int)problem.player.x + 8, (int)problem.player.y - 16, new StringFormat());
                g.DrawString("" + gameController.receivedScore, drawFont, drawBrush, (int)problem.player.x + 8, (int)problem.player.y + 8, new StringFormat());
            }

            
            return g;
        }
    }
}
