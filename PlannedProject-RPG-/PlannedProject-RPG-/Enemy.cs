using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannedProject_RPG_
{
    class Enemy : Character
    {
        public Enemy(int hp, int mp, int str, int dex, int intel, string name, Weapon w, Armor a)
        {
            this.name = name;
            baseHP = hp;
            currentHP = baseHP;
            baseMP = mp;
            currentMP = baseMP;
            STR = str;
            DEX = dex;
            INT = intel;
            calcDamageBonus();
            calcDodgeBonus();
            calcSpellBonus();
            calcStrikeBonus();
            setExp((new Random().Next(40) +1 )*10);
            currentWeapon = w;
            currentArmor = a;
        }

        public static Enemy GenerateEnemy(string e)
        {
            switch (e)
            {
                case "Thug":
                    return new Enemy(10, 10, 10, 7, 7, "Thug", new Weapon(WeaponType.DAGGER, WeaponAttribute.BASIC), new Armor(ArmorType.CLOTH));
                case "Bandit":
                    return new Enemy(10, 10, 10, 7, 7, "Thug", new Weapon(WeaponType.MACE, WeaponAttribute.BASIC), new Armor(ArmorType.LEATHER));
                case "Dragon":
                    return new Enemy(50, 10, 10, 10, 10, "Dragon", new Weapon(WeaponType.AXE, WeaponAttribute.FIRE), new Armor(ArmorType.CLOTH));
                case "Astral Kraken":
                    return new Enemy(250, 1000, 50, 25, 30, "Astral Kraken", new Weapon(WeaponType.DAGGER, WeaponAttribute.BASIC), new Armor(ArmorType.CLOTH));
                default:
                    return new Enemy(10, 30, 12, 12, 12, e, new Weapon(WeaponType.DAGGER, WeaponAttribute.BASIC), new Armor(ArmorType.LEATHER));
            }
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
            if (hp > 0)
            {
                currentHP = hp;
            }
            if (currentHP > baseHP)
            {
                currentHP = baseHP;
            }
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
            if (mp > 0)
            {
                currentMP = mp;
            }
            if (currentMP > baseMP)
            {
                currentMP = baseMP;
            }
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

        public override int getStrikeBonus()
        {
            return strikeBonus;
        }

        public override int getDodgeBonus()
        {
            return dodgeBonus;
        }

        public int getSpellBonus()
        {
            return spellBonus;
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
            int damage = (currentWeapon.weaponDamage()) + damageBonus;
            return damage;
        }

        public override int specialAttack()
        {
            int damage = 0;
            if (currentMP >= 10)
            {
                damage = (15) + spellBonus;
            }
            currentMP -= 10;
            return damage;
        }

        public override void takeDamage(int damage)
        {
            currentHP -= damage;
            if (currentHP <= 0)
            {
                isAlive = false;
            }
        }

        public override string details()
        {
            String status = name + "Current Health: " + currentHP + "\n Current Mana: " + currentMP + "\n Strength: " + STR +
                "\n Dexterity: " + DEX + "\n Intelligence: " + INT;
            return status;
        }
    }
}
