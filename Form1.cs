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


        public Bitmap ZombieSprite = Properties.Resources.ZombieSprite,
                      HumanSprite = Properties.Resources.HumanSprite,
                      AshSprite = Properties.Resources.AshSprite;

        CodeVsZombieProblem problem;
        ZombieController zombieController;
        public Form1()
        {

            problem = new CodeVsZombieProblem();
            zombieController = new ZombieController(problem);

            InitializeComponent();



            timer1.Interval = 2000;
            timer1.Tick += new EventHandler(Update);
            timer1.Start();
        }

        private void Update(object sender, EventArgs e)
        {
            zombieController.Move();
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.Black);

            Pen pen = new Pen(new SolidBrush(Color.Aqua));

            Console.Out.WriteLine(g);



            for (int i = 0; i < problem.humans.Length; i++)
            {
                if (problem.humans[i].isAlive)
                {
                    g.DrawImage(HumanSprite, new Rectangle((int)problem.humans[i].x - 8, (int)problem.humans[i].y - 8, 16, 16));
                }
            }

            for (int i = 0; i < problem.zombies.Length; i++)
            {
                g.DrawImage(ZombieSprite, new Rectangle((int) problem.zombies[i].x - 8, (int) problem.zombies[i].y - 8, 16, 16));
            }

            g.DrawImage(AshSprite, new Rectangle((int) problem.player.x - 8, (int) problem.player.y - 8, 16, 16));




        }
    }
}
