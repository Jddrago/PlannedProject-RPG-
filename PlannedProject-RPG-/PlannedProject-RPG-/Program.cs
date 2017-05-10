using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannedProject_RPG_
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Hero();

            var e = new Enemy(10, 10, 2, 2, 2, "Bort");

            var cmbt = new Combat(p, e);
            cmbt.Start();
        }
    }
}
