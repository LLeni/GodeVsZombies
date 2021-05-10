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

        private bool isPaused;
        private bool isStarted;
        public Form1()
        {


            isPaused = true;
            isStarted = false;

            InitializeComponent();

            timer1.Interval =  trackBar1.Value  * 100;
            timer1.Tick += new EventHandler(Update);
            timer1.Start();

            label1.Text = "Скорость ходов: " + trackBar1.Value * 100 + " мс";
        }

/*        1 Zombies move towards their targets.
          2 Ash moves towards his target.
          3 Any zombie within a 2000 unit range around Ash is destroyed.
          4 Zombies eat any human they share coordinates with.*/
          // TODO: Разделить логику перемещения и поедание людей в Zombie
        private void Update(object sender, EventArgs e)
        {
            if (!isPaused)
            {
                switch (gameController.numberNextAction)
                {
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
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
            Graphics g = e.Graphics;
            g.Clear(Color.Black);


            if (isStarted)
            {
                visualization.ShowTargets(g);
                visualization.ShowDirections(g);
                visualization.ShowRadiusPlayer(g);
                visualization.ShowHUD(g);
            }



        }

        private void SetRemotePanel()
        {

        }

        //Пауза/ 
        private void button1_Click(object sender, EventArgs e)
        {
            if(button1.Text == "Пауза")
            {
                isPaused = true;
                button1.Text = "Продолжить";
            }
            else
            {
                isPaused = false;
                button1.Text = "Пауза";
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = "Скорость ходов: " + trackBar1.Value  * 100 + " мс";
            timer1.Interval = trackBar1.Value * 100;
        }


        //Запуск решения/Повторный запуск
        private void button2_Click(object sender, EventArgs e)
        {
            problem = new CodeVsZombieProblem();
            gameController = new GameController(problem);
            visualization = new Visualization(problem, gameController);

            isStarted = true;

            button1.Enabled = true;
            button1.Text = "Пауза";
            isPaused = false;

            button2.Text = "Перезапустить";
        }
    }
}
