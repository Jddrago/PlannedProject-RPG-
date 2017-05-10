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
            

<<<<<<< HEAD
            var e = new Enemy(10, 10, 2, 2, 2, "Bort");
=======

            var e = new Enemy(10, 10, 2, 2, 2, "Bort",new Weapon(WeaponType.DAGGER,WeaponAttribute.BASIC),new Armor(ArmorType.CLOTH));
>>>>>>> 08f02d7c7d725675fbea76f7f4f5bb529aca0f90

            var cmbt = new Combat(p, e);
            cmbt.Start();
        }
    }
}
