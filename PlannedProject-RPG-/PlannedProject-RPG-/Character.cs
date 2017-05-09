using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannedProject_RPG_
{
    public abstract class Character
    {
        protected int baseHP, currentHP, baseMP, currentMP, STR, DEX, INT, STRMod, DEXMod, INTMod, damageBonus, strikeBonus, dodgeBonus, spellBonus,lvl;
        protected string name;
        protected bool isAlive = true;
        protected double exp = 0;
        protected Weapon currentWeapon;
        protected Armor currentArmor;


        public bool IsAlive()
        {
            return this.isAlive;
        }

        public abstract int normalAttack();
        public abstract int specialAttack();
        public abstract void takeDamage(int damage);
        public abstract string details();
    }
}
