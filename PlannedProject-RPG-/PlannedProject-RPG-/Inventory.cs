﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannedProject_RPG_
{
    class Inventory
    {
        private HealthPotion[] healthPotions;
        private MagicPotion[] magicPotions;
        private Weapon[] weapons;

        public int useHealthPotion()
        {
            int healthpotion = 0;
            for (int x = 0; x<healthPotions.Length;x++)
            {
                if (healthPotions[x]!=null)
                {
                    healthpotion = healthPotions[x].Use();
                    healthPotions[x] = null;
                    break;
                }
            }
            return healthpotion;
        }

        public void addHealthPotion(HealthPotion potion)
        {
            for (int x = 0; x<healthPotions.Length;x++)
            {
                if (healthPotions[x]==null)
                {
                    healthPotions[x] = new HealthPotion();
                    break;
                }
            }
        }

        public int useMagicPotion()
        {
            int potion = 0;
            for (int x = 0; x < magicPotions.Length; x++)
            {
                if (magicPotions[x] != null)
                {
                    potion = magicPotions[x].Use();
                   magicPotions[x] = null;
                    break;
                }
            }
            return potion;
        }

        public void addMagicPotion(MagicPotion potion)
        {
            for (int x = 0; x < magicPotions.Length; x++)
            {
                if (magicPotions[x] == null)
                {
                    magicPotions[x] = new MagicPotion();
                    break;
                }
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
    }
}
