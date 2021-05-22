using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeVsZombies2
{
    class Solution
    {
        public Zombie[] Zombies { get; set; }

        public Human[] Humans { get; set; }
        public Player Player { get; set; }

        public int Evaluation { get; }

        public String action;

        public Solution(Zombie[] zombies, Human[] humans, Player player)
        {
            Zombies = zombies;
            Humans = humans;
            Player = player;

            Evaluation = Evaluator.evaluate(this);
        }
    }
}
