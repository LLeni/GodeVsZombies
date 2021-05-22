using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeVsZombies2
{
    class CodeVsZombieProblemRepo
    {
        //Первые два значения - координаты игрока, затем идут координаты людей и после символа | идут координаты зомби (пробелы обязательны)
        public readonly string[] tests =
        {
            "500 600 250 200 | 500 200 | 1200 200 | 500 0 & 100 100 & 200 200 & 300 300 & 400 400 &",
            "100 400 300 300 | 100 800 & 250 500 & 100 700 &",
            "800 500 200 200 | 800 800 | 400 200 & 425 225 & 450 225 & 1200 500 & 700 700 &"
        };

    }
}
