using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannedProject_RPG_
{
    class Hero : Character
    {
        public Hero()
        {
            
        }

        public int getbaseHP()
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

        public int getbaseMP()
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

        public int DamageBonus()
        {
            int result = 0;
            if (STR > 15)
            {
                result = STR - 15;
            }
            else if (STR < 10)
            {
                result = STR-10;
            }
            return result;
        }
    }
}
