using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannedProject_RPG_
{
    public abstract class Character
    {
        protected int baseHP, currentHP, baseMP, currentMP, STR, DEX, INT, STRMod, DEXMod, INTMod, damageBonus, strikeBonus, dodgeBonus, spellBonus;
        protected string name;
        protected bool isAlive = true;

        public abstract int normalAttack();
        public abstract int specialAttack();
        public abstract void takeDamage(int damage);
        public abstract string details();
    }
}
