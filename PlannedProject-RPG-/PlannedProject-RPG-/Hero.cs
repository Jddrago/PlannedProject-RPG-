using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannedProject_RPG_
{
    class Hero : Character
    {
        private double expNeeded = 500;

        public Hero()
        {
            calcSTR();
            calcDEX();
            calcINT();
            setBaseHP(STR * 10);
            setCurrentHP(getBaseHP());
            setBaseMP(INT * 5);
            setCurrentMP(getBaseMP());
            calcDamageBonus();
            calcStrikeBonus();
            calcDodgeBonus();
            calcSpellBonus();
        }

        public void setName(string pname)
        {
            if (pname.Equals(null) || pname.Equals(""))
            {
                name = "Hero";
            }
            else
            {
                name = pname;
            }
        }

        public string getName()
        {
            return name;
        }

        public void calcSTR()
        {
            STR = DiceBag.rollDice(3, 6);
            if (STR > 16)
            {
                STR += DiceBag.rollDice(2,6);
            }
        }

        public void calcDEX()
        {
            DEX = DiceBag.rollDice(3, 6);
            if (DEX > 16)
            {
                DEX += DiceBag.rollDice(2, 6);
            }
        }

        public void calcINT()
        {
            INT = DiceBag.rollDice(3, 6);
            if (INT > 16)
            {
                INT += DiceBag.rollDice(2, 6);
            }
        }

        public int getBaseHP()
        {
            return baseHP;
        }

        public void setBaseHP(int hp)
        {
            if (hp > 0)
            {
                baseHP = hp;
            }
        }

        public int getCurrentHP()
        {
            return currentHP;
        }

        public void setCurrentHP(int hp)
        {
            if (hp > 0)
            {
                currentHP = hp;
            }
        }

        public int getBaseMP()
        {
            return baseMP;
        }

        public void setBaseMP(int mp)
        {
            if (mp > 0)
            {
                baseMP = mp;
            }
        }

        public int getCurrentMP()
        {
            return currentMP;
        }

        public void setCurrentMP(int mp)
        {
            if (mp > 0)
            {
                currentMP = mp;
            }
        }

        public int getStrength()
        {
            return STR;
        }

        public void setStrength(int str)
        {
            if (str > 0)
            {
                STR = str;
            }
        }

        public int getDexterity()
        {
            return DEX;
        }

        public void setDexterity(int dex)
        {
            if (dex > 0)
            {
                DEX = dex;
            }
        }

        public int getIntelligence()
        {
            return INT;
        }

        public void setIntelligence(int _int)
        {
            if (_int > 0)
            {
                INT = _int;
            }
        }

        public int getStrengthMod()
        {
            return STRMod;
        }

        public void setStrengthMod(int strMod)
        {
            STRMod = strMod;
        }

        public int getDexterityMod()
        {
            return DEXMod;
        }

        public void setDexterityMod(int dexMod)
        {
            DEXMod = dexMod;
        }

        public int getIntelligenceMod()
        {
            return INTMod;
        }

        public void setIntelligenceMod(int intMod)
        {
            INTMod = intMod;
        }

        public void calcDamageBonus()
        {
            if (STR > 15)
            {
                damageBonus = STR - 15;
            }
            else if (STR < 10)
            {
                damageBonus = STR - 10;
            }
        }

        public void calcStrikeBonus()
        {
            if (DEX > 14)
            {
                strikeBonus = (DEX - 14) / 2;
            }
            else if (DEX < 10)
            {
                strikeBonus = (DEX - 10) / 2;
            }
        }

        public void calcDodgeBonus()
        {
            if (DEX > 15)
            {
                dodgeBonus = (DEX - 15) / 2;
            }
            else if (DEX < 11)
            {
                dodgeBonus = (DEX - 11) / 2;
            }
        }

        public void calcSpellBonus()
        {
            if (INT > 15)
            {
                spellBonus = (INT - 15) * 2;
            }
            else if (INT < 10)
            {
                spellBonus = (INT - 10) * 2;
            }
        }

        public int getDamageBonus()
        {
            return damageBonus;
        }

        public int getStrikeBonus()
        {
            return strikeBonus;
        }

        public int getDodgeBonus()
        {
            return dodgeBonus;
        }

        public int getSpellBonus()
        {
            return spellBonus;
        }

        public void gainExp(double expGained)
        {
            exp += expGained;
            if (exp >= expNeeded)
            {
                levelUp();
                expNeeded *= 1.5;
            }
        }

        private void levelUp()
        {

        }

        public override int normalAttack()
        {
            int result = (10) + damageBonus;
            if (result < 0)
            {
                result = 0;
            }
            return result;
        }

        public override int specialAttack()
        {
            int result = (15) + spellBonus;
            if (result < 0)
            {
                result = 0;
            }
            currentMP -= 10;
            return result;
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
            return "Name: " + getName() + "\nHP: " + getCurrentHP() + "/" + getBaseHP() + "\nMP: " + getCurrentMP() + "/" + getBaseMP() + "\nSTR: " + getStrength() + "\nDEX: " + getDexterity() + "\nINT: " + getIntelligence() + "\nDamage Bonus: " + getDamageBonus() + "\nStrike Bonus: " + getStrikeBonus() + "\nDodge Bonus: " + getDodgeBonus() + "\nSpell Bonus: " + getSpellBonus();
        }
    }
}
