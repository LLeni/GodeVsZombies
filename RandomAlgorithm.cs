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
            double nx = random.NextDouble() * 2;
            double ny = random.NextDouble() * 2;


            nx = nx <= 1 ? -nx - 1 : nx - 1;
            ny = ny <= 1 ? -ny - 1 : ny - 1;

            double shiftX = 100 * nx;
            double shiftY = 100 * ny;

            problem.player.x = shiftX + problem.player.x;
            problem.player.y = shiftY + problem.player.y;
        }
    }
}
