using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeVsZombies2
{
    // Управляет игроком (используя для этого алгоритм) и ведет счет очков
    class GameController
    {

        public CodeVsZombieProblem problem;
        public ZombieController zombieController;
        public int countZombies;
        public int countHumans;

        public int numberRound;
        public String action; // то действие, которое выполнилось
        public int numberNextAction;

        public int score;

        public RandomAlgorithm randomAlgorithm;

        // В своем радиусе
        public bool isPlayerHasTargets;
        public GameController(CodeVsZombieProblem problem)
        {
            this.problem = problem;
            zombieController = new ZombieController(problem);

            countZombies = problem.zombies.Length;
            countHumans = problem.humans.Length;

            numberRound = 0;
            numberNextAction = 1;
            score = 0;
            

            

            randomAlgorithm = new RandomAlgorithm(problem);
        }

        public void KillZombies()
        {
            action = "убийство зомби";
            numberNextAction = 4;

            int countKilledZombies = 0;
            //Вектор
            double vX, vY, lengthV;
            for(int nZombie = 0; nZombie < problem.zombies.Length; nZombie++)
            {
                if (problem.zombies[nZombie].isAlive)
                {
                    vX = problem.zombies[nZombie].x - problem.player.x;
                    vY = problem.zombies[nZombie].y - problem.player.y;

                    lengthV = Math.Sqrt(vX * vX + vY * vY);
                    Console.WriteLine("Длина вектора у зомби " + nZombie + " равна " + lengthV);
                    if (lengthV <= 200)
                    {
                        problem.zombies[nZombie].isAlive = false;
                        countKilledZombies++;
                    }

                }
            }
            if (countKilledZombies > 0)
            {
                countZombies -= countKilledZombies;
                IncreaseScore(countKilledZombies);
            }
        }

        private void IncreaseScore(int countKilledZombies)
        {

            Console.WriteLine("Мыыыы здесььь ");
            int worthZombie = 10 * countHumans * countHumans ;

            score += worthZombie;
            if (countKilledZombies == 1)
                return;
            
            score += worthZombie * 2;
            if (countKilledZombies == 2)
                return;

            int[] multipliers = new int[countKilledZombies];
            multipliers[0] = 1;
            multipliers[1] = 2;
            for (int nKilledZombie = 2; nKilledZombie < countKilledZombies; nKilledZombie++)
            {
                multipliers[nKilledZombie] = multipliers[nKilledZombie - 2] + multipliers[nKilledZombie - 1];
                score += worthZombie * multipliers[nKilledZombie];
            }

        }

        public void MovePlayer()
        {
            action = "перемещение игрока";
            numberNextAction = 3;

            randomAlgorithm.Move();
        }


        public void MoveZombies()
        {
            numberRound++;
            action = "перемещение зомби";
            numberNextAction = 2;
            zombieController.Move();
            

        }
        public void EatHumans()
        {
            action = "поедание людей";
            numberNextAction = 1;
            int countKilledHumans= zombieController.Eat();
            countHumans -= countKilledHumans;
            
        }
    }
}
