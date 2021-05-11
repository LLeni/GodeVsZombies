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
        Simulation visualization;

        private bool isPaused;
        private bool isStarted;
        public Form1()
        {


            isPaused = true;
            isStarted = false;

            problem = new CodeVsZombieProblem();

            InitializeComponent();

            timer1.Interval =  trackBar1.Value  * 100;
            timer1.Tick += new EventHandler(Update);
            timer1.Start();

            label1.Text = "Скорость ходов: " + trackBar1.Value * 100 + " мс";
            label2.Text = "Проблема N0/" + (problem.amountProblems - 1);
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
                if (!gameController.isGameOver && !gameController.isWin)
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
                visualization.ShowMultiplierAndReceivedScore(g);
                visualization.ShowHUD(g);

                if (gameController.isGameOver)
                    visualization.ShowGameOverText(g);
                if(gameController.isWin)
                    visualization.ShowWinText(g);

            }
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

            problem.RestartProblem();
            gameController = new GameController(problem);
            visualization = new Simulation(problem, gameController);

            isStarted = true;

            button1.Enabled = true;
            button1.Text = "Пауза";
            isPaused = false;

            button2.Text = "Перезапустить";

        }

        //Кнопка предыдущего решения
        private void button3_Click(object sender, EventArgs e)
        {
            if (problem.indexCurrentProblem - 1 >= 0)
            {
                SwitchProblem(-1);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (problem.amountProblems != problem.indexCurrentProblem + 1)
            {
                SwitchProblem(1);
            }
        }

        private void SwitchProblem(int offsetProblem)
        {
            isPaused = true;
            label2.Text = "Проблема N" + (problem.indexCurrentProblem + offsetProblem) + "/" + (problem.amountProblems - 1);
            button2.Text = "Запустить";
            button1.Enabled = false;

            if(offsetProblem == 1)
            {
                problem.NextProblem();
            }
            if(offsetProblem == -1)
            {
                problem.PreviousProblem();
            }
        }


    }
}
