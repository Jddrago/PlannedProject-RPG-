using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannedProject_RPG_
{
    class Inventory
    {
        private static int numPotions = 5,numWeapons = 3;
        private List<HealthPotion> healthPotions = new List<HealthPotion>(numPotions);
        private List<MagicPotion> magicPotions = new List<MagicPotion>(numPotions);
        private Weapon[] weapons = new Weapon[numWeapons];

        public int useHealthPotion()
        {
            HealthPotion hp = healthPotions.Last();
            healthPotions.RemoveAt(healthPotions.Count());
            return hp.Use();
        }

        public void addHealthPotion(HealthPotion potion)
        {
            if (healthPotions.Count() < 5)
            {
                healthPotions.Add(potion);
            }
        }

        public int useMagicPotion()
        {
            MagicPotion mp = magicPotions.Last();
            magicPotions.RemoveAt(magicPotions.Count());
            return mp.Use();
        }

        public void addMagicPotion(MagicPotion potion)
        {
            if (magicPotions.Count() < 5)
            {
                magicPotions.Add(potion);
            }
        }

        public Weapon getWeaponAtIndex(int index)
        {
            return weapons[index];
        }

        public void addWeapon(Weapon weapon)
        {
            for (int x = 0; x<weapons.Length;x++)
            {
                if (weapons[x]==null)
                {
                    weapons[x] = weapon;
                    break;
                }
            }
        }

        public int numHealthPotions()
        {
            return healthPotions.Count();
        }

        public int numMagicPotions()
        {
            return magicPotions.Count();
        }
    }
}
