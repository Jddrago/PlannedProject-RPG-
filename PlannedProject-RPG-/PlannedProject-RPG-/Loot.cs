using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannedProject_RPG_
{
    public class Loot
    {

        public static Weapon generateWeapon()
        {
            Random rand = new Random();
            WeaponType wt;
            WeaponAttribute wa;
            switch (rand.Next(Enum.GetNames(typeof(WeaponType)).Length))
            {
                case 0: wt = WeaponType.DAGGER; break;
                case 1: wt = WeaponType.SWORD; break;
                case 2: wt = WeaponType.MACE; break;
                case 3: wt = WeaponType.AXE; break;
                case 4: wt = WeaponType.SPEAR; break;
                default: wt = WeaponType.DAGGER; break;
            }
            switch (rand.Next(Enum.GetNames(typeof(WeaponAttribute)).Length))
            {
                case 0: wa = WeaponAttribute.BASIC; break;
                case 1: wa = WeaponAttribute.POISON; break;
                case 2: wa = WeaponAttribute.FIRE; break;
                case 3: wa = WeaponAttribute.LIGHTNING; break;
                case 4: wa = WeaponAttribute.DEMON; break;
                case 5: wa = WeaponAttribute.DIVINE; break;
                case 6: wa = WeaponAttribute.ULTIMATE; break;
                default: wa = WeaponAttribute.BASIC; break;
            }
            return new Weapon(wt,wa);
        }

        public static Armor generateArmor()
        {
            Random rand = new Random();
            ArmorType at;
            switch (rand.Next(Enum.GetNames(typeof(ArmorType)).Length))
            {
                case 0: at = ArmorType.CLOTH; break;
                case 1: at = ArmorType.LEATHER; break;
                case 2: at = ArmorType.CHAIN; break;
                case 3: at = ArmorType.PLATE; break;
                default: at = ArmorType.CLOTH; break;
            }
            return new Armor(at);
        }

        public static void generateHealthPotions()
        {

        }

        public static void generateMagicPotions()
        {

        }
    }
}
