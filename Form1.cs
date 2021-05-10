using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeVsZombies2
{
    public partial class Form1 : Form
    {



        CodeVsZombieProblem problem;
        GameController gameController;
        Visualization visualization;

        public Form1()
        {
            problem = new CodeVsZombieProblem();
            gameController = new GameController(problem);
            visualization = new Visualization(problem, gameController);

            InitializeComponent();


            timer1.Interval =  500;
            timer1.Tick += new EventHandler(Update);
            timer1.Start();
        }

/*        1 Zombies move towards their targets.
          2 Ash moves towards his target.
          3 Any zombie within a 2000 unit range around Ash is destroyed.
          4 Zombies eat any human they share coordinates with.*/
          // TODO: Разделить логику перемещения и поедание людей в Zombie
        private void Update(object sender, EventArgs e)
        {
            switch (gameController.numberNextAction) {
                case 1:
                    gameController.MoveZombies();
                    break;
                case 2:
                    gameController.MovePlayer();
                    break;
                case 3:
                    gameController.KillZombies();
                    break;
                case 4:
                    gameController.EatHumans();
                    break;
            }
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.Black);


            visualization.ShowTargets(g);
            visualization.ShowDirections(g);
            visualization.ShowRadiusPlayer(g);
            visualization.ShowHUD(g);



        }
    }
}
