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

           
            if (potentialX < 0 || potentialX > 1600)
            {
                shiftX = -shiftX;
            }
           
            if(potentialY < 0 || potentialY > 900)
            {
                shiftY = -shiftY;
            }

            problem.player.x = shiftX + problem.player.x;
            problem.player.y = shiftY + problem.player.y;


        }
    }
}
