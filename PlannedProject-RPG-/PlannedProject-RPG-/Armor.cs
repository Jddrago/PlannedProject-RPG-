using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannedProject_RPG_
{
    public enum ArmorType
    {
        CLOTH,
        LEATHER,
        CHAIN,
        PLATE
    }

    public class Armor
    {
        private ArmorType type;
        private int defenseRating, agilityMod;

        public Armor(ArmorType t)
        {
            type = t;
            calcMods();
        }

        public int getDefenseRating()
        {
            return defenseRating;
        }

        public int getAgilityMod()
        {
            return agilityMod;
        }

        private void calcMods()
        {
            switch (this.type)
            {
                case ArmorType.CLOTH: defenseRating = 2; agilityMod = 4; break;
                case ArmorType.LEATHER: defenseRating = 4; agilityMod = 2; break;
                case ArmorType.CHAIN: defenseRating = 6; agilityMod = -2; break;
                case ArmorType.PLATE: defenseRating = 10; agilityMod = -4; break; 
            }
        }

        public string armorDetails()
        {
            return type.ToString() + " Armor. Defense: " + getDefenseRating() + ". Agility: " + getAgilityMod();
        }
    }
}
