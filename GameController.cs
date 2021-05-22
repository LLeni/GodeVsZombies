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
        public PlayerController playerController;
        public int countZombies;
        public int countHumans;

        public int numberRound;
        public Action action; // то действие, которое выполнилось
        public int numberNextAction;

        public int score;

        public bool isGameOver;
        public bool isWin;

        // необходимо для эмуляции
        public int multiplier; 
        public int receivedScore;

        public RandomAlgorithm randomAlgorithm;

        // В своем радиусе. Для эмуляции (необязательно )
        public bool isPlayerHasTargets;


        public enum Action
        {
            MoveZombies = 1,
            MovePlayer = 2,
            KillZombies = 3,
            EatHumans = 4
        }

        public GameController(CodeVsZombieProblem problem)
        {
            this.problem = problem;
            zombieController = new ZombieController(problem);
            playerController = new PlayerController();

            countZombies = problem.zombies.Length;
            countHumans = problem.humans.Length;

            numberRound = 0;
            numberNextAction = 1;

            score = 0;

            isGameOver = false;
            isWin = false;

            multiplier = 0;

            randomAlgorithm = new RandomAlgorithm(problem);
        }

        public void KillZombies()
        {
            action = Action.KillZombies;
            numberNextAction = 4;
            int countKilledZombies = playerController.Kill();
            if (countKilledZombies > 0)
            {
                countZombies -= countKilledZombies;
                IncreaseScore(countKilledZombies);

                if (countZombies == 0)
                {
                    isWin = true;
                }
            }

        }

        private void IncreaseScore(int countKilledZombies)
        {

            int[] multipliers = new int[countKilledZombies];
            int worthZombie = 10 * countHumans * countHumans ;
            int receivedScore = 0;

            receivedScore += worthZombie;
            if (countKilledZombies == 1)
            {
                multiplier = 1;
                score += receivedScore;
                this.receivedScore = receivedScore;
                return;
            }

            receivedScore += worthZombie * 2;
            if (countKilledZombies == 2)
            {
                multiplier = 2;
                score += receivedScore;
                this.receivedScore = receivedScore;
                return;
            }

            if (countKilledZombies >= 3)
            {
                multipliers[0] = 1;
                multipliers[1] = 2;
                for (int nKilledZombie = 2; nKilledZombie < countKilledZombies; nKilledZombie++)
                {
                    multipliers[nKilledZombie] = multipliers[nKilledZombie - 2] + multipliers[nKilledZombie - 1];
                    receivedScore += worthZombie * multipliers[nKilledZombie];
                }
      
            }
            multiplier = multipliers[countKilledZombies - 1];
            score += receivedScore;
            this.receivedScore = receivedScore;
        }

        public void MovePlayer()
        {
            action = Action.MovePlayer;
            numberNextAction = 3;

            playerController.Move();
            //randomAlgorithm.Move();
        }


        public void MoveZombies()
        {
            numberRound++;
            action = Action.MoveZombies;
            numberNextAction = 2;
            zombieController.Move();
           
        }
        public void EatHumans()
        {
            multiplier = 0;
            action = Action.EatHumans;
            numberNextAction = 1;
            int countKilledHumans= zombieController.Eat();
            countHumans -= countKilledHumans;
            if(countHumans == 0)
            {
                isGameOver = true;
            }
        }
    }
}
