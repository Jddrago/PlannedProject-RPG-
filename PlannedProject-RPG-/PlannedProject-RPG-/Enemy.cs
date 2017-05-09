using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannedProject_RPG_
{
    class Enemy : Character
    {
       
        public Enemy(int hp, int mp, int str, int dex, int intel, string name)
        {
            this.name = name;
            baseHP = hp;
            currentHP = baseHP;
            baseMP = mp;
            currentMP = baseMP;
            STR = str;
            DEX = dex;
            INT = intel;
            setExp((new Random().Next(20) +1 )*10);
        }

        public string getName()
        {
            return name;
        }
        public void setName(string name)
        {
            this.name = name;
        }
        public int getBaseHP()
        {
            return baseHP;
        }
        public void setBaseHP(int hp)
        {
            baseHP = hp;
        }
        public int getCurrentHP()
        {
            return currentHP;
        }
        public void setCurrentHP(int hp)
        {
            currentHP = hp;
        }
        public int getBaseMP()
        {
            return baseMP;
        }
        public void setBaseMP(int mp)
        {
            baseMP = mp;
        }

        public int getCurrentMP()
        {
            return currentMP;
        }
        public void setCurrentMP(int mp)
        {
            currentMP = mp;
        }
        public int getSTR()
        {
            return STR;
        }
        public void setSTR(int str)
        {
            STR = str;
        }

        public int getDEX()
        {
            return DEX;
        }
        public void setDEX(int dex)
        {
            DEX = dex;
        }
        public int getINT()
        {
            return INT;
        }
        public void setINT(int intel)
        {
            INT = intel;
        }
        public int getSTRMod()
        {
            return STRMod;
        }
        public void setSTRMod(int mod)
        {
            STRMod = mod;
        }
        public int getDEXMod()
        {
            return DEXMod;
        }
        public void setDEXMod(int mod)
        {
            DEXMod = mod;
        }
        public int getINTMod()
        {
            return INTMod;
        }
        public void setINTMod(int mod)
        {
            INTMod = mod;
        }
        public int getDamageBonus()
        {
            return damageBonus;
        }
        public void setDamageBonus(int bonus)
        {
            damageBonus = bonus;
        }
        public int getStrikeBonus()
        {
            return strikeBonus;
        }
        public void setStrikeBonus(int bonus)
        {
            strikeBonus = bonus;
        }
        public int getDodgeBonus()
        {
            return dodgeBonus;
        }
        public void setDodgeBonus(int bonus)
        {
            dodgeBonus = bonus;
        }
        public int getSpellBonus()
        {
            return spellBonus;
        }
        public void setSpellBonus(int bonus)
        {
            spellBonus = bonus;
        }

        public double getExp()
        {
            return exp;
        }

        public void setExp(double expAmount)
        {
            if (expAmount > 0)
            {
                exp = expAmount;
            }
            else
            {
                exp = 0;
            }
            
        }

        public override int normalAttack()
        {
            int damage = (10) + damageBonus;
            return damage;
        }

        public override int specialAttack()
        {
            int damage = 0;
            if (currentMP > 10)
            {
                currentMP -= 10;
                damage = (15) + spellBonus;
               }
            return damage;
        }

        public override void takeDamage(int damage)
        {
            currentHP -= damage;
            if (currentHP < 0)
            {
                isAlive = false;
            }
        }

        public override string details()
        {
            String status = name+"Current Health: "+currentHP+"\n Current Mana: "+currentMP+"\n Strength: "+STR+
                "\n Dexterity: "+ DEX+"\n Intelligence: "+INT;
            return status; 
        }
    }
}
