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

        public bool isEvenUpdate = false;
        public Form1()
        {
            InitializeComponent();

            timer1.Interval = 50;
            timer1.Tick += new EventHandler(Update);
            timer1.Start();
        }

        private void Update(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.Black);

            Pen pen = new Pen(new SolidBrush(Color.Aqua));

            Console.Out.WriteLine(g);

            CodeVsZombieProblem problem = new CodeVsZombieProblem();

            for (int i = 0; i < problem.humans.Length; i++)
            {
                g.DrawImage(HumanSprite, new Rectangle(problem.humans[i].x - 8, problem.humans[i].y - 8, 16, 16));
            }

            for (int i = 0; i < problem.zombies.Length; i++)
            {
                g.DrawImage(ZombieSprite, new Rectangle(problem.zombies[i].x - 8, problem.zombies[i].y - 8, 16, 16));
            }

            g.DrawImage(AshSprite, new Rectangle(problem.player.x - 8, problem.player.y - 8, 16, 16));





            if (isEvenUpdate)
            {
                g.DrawLine(pen, 100, 100, 500, 500);
                isEvenUpdate = false;
            } else
            {
                g.DrawLine(pen, 100, 500, 500, 100);
                isEvenUpdate = true;
            }
        }
    }
}
