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
        ZombieController zombieController;
        Visualization visualization;

        public Form1()
        {
            problem = new CodeVsZombieProblem();
            zombieController = new ZombieController(problem);
            visualization = new Visualization(problem);

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


            visualization.showTargets(g);
            visualization.showDirections(g);
    



        }
    }
}
