using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannedProject_RPG_
{

    public enum WeaponType
    {
        DAGGER,
        SWORD,
        MACE,
        AXE,
        SPEAR
    };
    public enum WeaponAttribute
    {
        BASIC = 0,
        FIRE = 3,
        LIGHTNING = 4,
        POISON = 2,
        DEMON = 5,
        DIVINE = 6,
        ULTIMATE = 8
    };
    public class Weapon
    {
        private string name;
        private WeaponType weapon;
        private WeaponAttribute attribute;
        private string weaponRoll = "";

        public Weapon(WeaponType type, WeaponAttribute attribute)
        {
            weapon = type;
            this.attribute = attribute;
            name = attribute.ToString()+" "+weapon.ToString();
            setWeaponRoll(); 
        }

        public WeaponType getWeaponType()
        {
            return weapon;
        }
        public void setWeaponType(WeaponType type)
        {
            weapon = type;
        }

        public WeaponAttribute getAttribute()
        {
            return this.attribute;
        }

        public void setWeaponAttribute(WeaponAttribute attribute)
        {
            this.attribute = attribute;
        }

        public void setWeaponRoll()
        {
            switch (this.weapon)
            {
                case WeaponType.DAGGER: weaponRoll = "1d4"; break;
                case WeaponType.SWORD: weaponRoll = "1d6"; break;
                case WeaponType.SPEAR: weaponRoll = "1d8"; break;
                case WeaponType.MACE: weaponRoll = "1d10"; break;
                case WeaponType.AXE: weaponRoll = "2d6"; break;
            }
        }

        public int weaponDamage()
        {
            string[] temp = weaponRoll.Split('d');
            return DiceBag.rollDice(int.Parse(temp[0]),int.Parse(temp[1]),(int)attribute);
        }

        public string weaponDetails()
        {
            //return name + ". Attack: " + weaponRoll + "+" + int.Parse(this.attribute.ToString());
            return String.Format("{0}. Attack: {1}+{2}", name, weaponRoll, (int)this.attribute);
        }
    }
}
