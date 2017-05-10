using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannedProject_RPG_
{
    class Program
    {
        const string death = "__   _______ _   _  ______ _____ ___________  \n" +
"\\ \\ / /  _  | | | | |  _  \\_   _|  ___|  _  \\ \n" +
" \\ V /| | | | | | | | | | | | | | |__ | | | | \n" +
"  \\ / | | | | | | | | | | | | | |  __|| | | | \n" +
"  | | \\ \\_/ / |_| | | |/ / _| |_| |___| |/ /  \n" +
"  \\_/  \\___/ \\___/  |___/  \\___/\\____/|___/   ";


        static void Main(string[] args)
        {

            Enemy[] enemies = {
                new Enemy(5, 10, 10, 3, 3, "Rat", new Weapon(WeaponType.DAGGER, WeaponAttribute.BASIC), new Armor(ArmorType.CLOTH)),
                new Enemy(10, 10, 10, 7, 7, "Thug", new Weapon(WeaponType.DAGGER, WeaponAttribute.BASIC), new Armor(ArmorType.CLOTH)),
                new Enemy(50, 10, 10, 10, 10, "Dragon", new Weapon(WeaponType.AXE, WeaponAttribute.FIRE), new Armor(ArmorType.CLOTH)),
                new Enemy(250, 1000, 50, 50, 50, "Astral Kraken", new Weapon(WeaponType.DAGGER, WeaponAttribute.BASIC), new Armor(ArmorType.CLOTH)),
        };

                    Console.WriteLine();

            Hero p = null;



            bool rolling = true;

            while (rolling)
            {
                p = new Hero();
                Console.WriteLine(p.details());

                Console.WriteLine("=======================\n\nRoll again? (y/n)");
                var resp = Console.ReadLine();

                rolling = resp.Equals("y");
            }

            bool naming = true;
            string name = "";
            while (naming)
            {
                Console.WriteLine("What do you want to name your hero?");
                name = Console.ReadLine();
                Console.WriteLine(String.Format("Are you sure you want to name your hero {0}? (y/n)", name));
                var res = Console.ReadLine();
                naming = !res.Equals("y");
            }

            p.setName(name);

            bool run = true;
            
            for(int i = 0; i < enemies.Length && run; i++){
                var e = enemies[i];
                new Combat(p, e).Start();

                if (p.IsAlive())
                {
                    Console.WriteLine("You killed the "+e.getName());
                } else
                {
                    run = false;
                    Console.WriteLine(death);
                }
                Console.WriteLine(p.details());

            }

            Console.Read();
        }
    }
}
