using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeVsZombies2
{
    class RandomAlgorithm
    {
        public CodeVsZombieProblem problem;
        Random random;
        public RandomAlgorithm(CodeVsZombieProblem problem)
        {
            this.problem = problem;
            random = new Random();
        }


        //TODO: Запретить выходить за рамки
        public void Move()
        {
            // единичный вектор
            double nx = random.NextDouble() * 2 - 1;

            double ny = Math.Sqrt(1 - nx*nx);
            if (random.Next(2) == 0)
            {
                ny = -ny;
            }

            Console.WriteLine("nx = " + nx + " и ny = " + ny);
            Console.WriteLine("Длина единичного вектора: " + Math.Sqrt(nx * nx + ny * ny));

            double shiftX = 100 * nx;
            double shiftY = 100 * ny;

            double potentialX = shiftX + problem.player.x;
            double potentialY = shiftY + problem.player.y;

            //TODO: Не все границы складно работают (дело не здесь, а в форме)
            if (potentialX < 0)
            {
                problem.player.x = 0;
            } else if (potentialX > 1600)
            {
                problem.player.x = 1600;
            } else
            {
                problem.player.x = potentialX;
            }
           
            if(potentialY < 0)
            {
                problem.player.y = 0;
            } else if(potentialY > 900)
            {
                problem.player.y = 900;
            } else
            {
                problem.player.y = potentialY;
            }
         
        }
    }
}
