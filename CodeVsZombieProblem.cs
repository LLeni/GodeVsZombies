using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeVsZombies2
{
    class CodeVsZombieProblem
    {
        public Zombie[] zombies { get; set; }
        public Human[] humans { get; set; }
        public Player player { get; set; }
        
        public CodeVsZombieProblemRepo codeVsZombieProblemRepo;
        public int indexCurrentProblem;
        public int amountProblems;
        public CodeVsZombieProblem()
        {
            codeVsZombieProblemRepo = new CodeVsZombieProblemRepo();
            amountProblems = codeVsZombieProblemRepo.tests.Length;
            indexCurrentProblem = 0;
            SetProblem();
        }

        public void NextProblem()
        {
            if ((indexCurrentProblem + 1) != codeVsZombieProblemRepo.tests.Length)
            {
                indexCurrentProblem++;
                SetProblem();
            }
        }

        public void PreviousProblem()
        {
            if ((indexCurrentProblem - 1) >= 0)
            {
                indexCurrentProblem--;
                SetProblem();
            }
        }

        //Выглядит довольно странно. Может поработать над именами и сделать один метод, а не два различных
        public void RestartProblem()
        {
            SetProblem();
        }

        private void SetProblem()
        {
            String[] values = codeVsZombieProblemRepo.tests[indexCurrentProblem].Split(' ');

            player = new Player(Double.Parse(values[0]), Double.Parse(values[1]), -1);

            List<Human> humans = new List<Human>();
            List<Zombie> zombies = new List<Zombie>();

            bool isRecordingHumans = true;  //для обнуления numberCreature
            int numberCreature = 0;
            double x = -1;
            double y = -1;
            for (int iValue = 2; iValue < values.Length; iValue++)
            {
                if (values[iValue] == "|")
                {
                    humans.Add(new Human(x, y, numberCreature));
                    numberCreature++;
                    x = -1;
                    continue;
                }

                if (values[iValue] == "&")
                {
                    if (isRecordingHumans)
                    {
                        numberCreature = 0;
                        isRecordingHumans = false;
                    }
                    zombies.Add(new Zombie(x, y, numberCreature));
                    numberCreature++;
                    x = -1;
                    continue;
                }

                if (x == -1)
                {
                    x = Double.Parse(values[iValue]);
                }
                else
                {
                    y = Double.Parse(values[iValue]);
                }

            }

            this.humans = humans.ToArray();
            this.zombies = zombies.ToArray();

            Evaluator.defineNeightbors(this.humans);
        }

    }
}
