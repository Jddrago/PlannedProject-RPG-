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
    public enum WeaponAttribute{
        BASIC,
        FIRE,
        LIGHTNING,
        POISON,
        DEMON,
        DIVINE,
        ULTIMATE
    };
    class Weapon
    {
        private string name;
        private WeaponType weapon;
        private WeaponAttribute attribute;
        private int weaponDamage = 0;

        public Weapon(WeaponType type, WeaponAttribute attribute)
        {
            weapon = type;
            this.attribute = attribute;
            name = attribute.ToString()+" "+weapon.ToString();
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

        public int getDamage()
        {
            
            return weaponDamage;
        }

        public void setDamage()
        {
           
        }
    }
}
