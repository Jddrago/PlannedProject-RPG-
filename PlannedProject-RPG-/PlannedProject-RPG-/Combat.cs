using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannedProject_RPG_
{

    enum CombatAction
    {
        NORMAL_ATTACK,
        SPECIAL_ATTACK,
        CHANGE_EQUIPMENT,
        DRINK_HEALTH_POTION,
        DRINK_MANA_POTION,
        FLEE
    }

    enum CombatRoll
    {
        CRIT_FAIL = -1,
        FAIL = 0,
        PASS = 1,
        CRIT = 2,
        DOUBLT_CRIT = 4
    }


    class Combat
    {
        private bool running;
        private bool playerTurn;
        private Hero player;
        private Enemy enemy;
        public Combat(Hero player, Enemy enemy)
        {
            running = true;
            playerTurn = true;
            this.player = player;
            this.enemy = enemy;
        }

        /* For the Ambush */
        public Combat(Hero player, Enemy enemy, bool playerGoesFirst)
        {
            running = true;
            playerTurn = playerGoesFirst;
            this.player = player;
            this.enemy = enemy;
        }

        public bool Start()
        {
            while (running)
            {
                if (player.IsAlive() && enemy.IsAlive())
                {

                    if (playerTurn)
                    {
                        var action = GetPlayerAction();
                        var dmg = -1;
                        CombatRoll roll;
                        switch (action)
                        {
                            case CombatAction.DRINK_HEALTH_POTION:
                                var PotionHP = player.getInventory().useHealthPotion();
                                player.setCurrentHP(player.getCurrentHP() + PotionHP);
                                Console.WriteLine(String.Format("You drink the potion and heal for {0} HP", PotionHP));
                                break;
                            case CombatAction.DRINK_MANA_POTION:
                                var PotionMP = player.getInventory().useMagicPotion();
                                player.setCurrentMP(player.getCurrentMP() + PotionMP);
                                Console.WriteLine(String.Format("You drink the potion and recover {0} MP", PotionMP));
                                break;
                            case CombatAction.NORMAL_ATTACK:
                                roll = GetCombatRoll(player, enemy, DiceBag.rollDice(1, 20), DiceBag.rollDice(1, 20));
                                switch (roll)
                                {
                                    case CombatRoll.CRIT_FAIL:
                                        dmg = player.normalAttack() / 2;
                                        player.takeDamage(dmg);
                                        Console.WriteLine(String.Format("You miss the {0} and hit yourself for {1} damage", enemy.getName(), dmg));
                                        break;
                                    case CombatRoll.FAIL:
                                        Console.WriteLine(String.Format("You miss the {0}", enemy.getName()));
                                        break;
                                    case CombatRoll.PASS:
                                    case CombatRoll.CRIT:
                                    case CombatRoll.DOUBLT_CRIT:
                                        dmg = player.normalAttack() * (int)roll;
                                        enemy.takeDamage(dmg);
                                        Console.WriteLine(String.Format("You hit the {0} for {1} damage {2}", enemy.getName(), dmg, ((roll == CombatRoll.PASS) ? "" : ((roll == CombatRoll.CRIT) ? "(CRIT)" : "(DOUBLE CRIT)"))));
                                        break;
                                }

                                //if(roll == CombatRoll.FAIL)
                                //{
                                //} else
                                //{
                                //}
                                break;
                            case CombatAction.SPECIAL_ATTACK:
                                roll = GetCombatRoll(player, enemy, DiceBag.rollDice(1, 20), DiceBag.rollDice(1, 20));
                                switch (roll)
                                {
                                    case CombatRoll.CRIT_FAIL:
                                        dmg = player.specialAttack() / 2;
                                        player.takeDamage(dmg);
                                        Console.WriteLine(String.Format("You miss the {0} and hit yourself for {1} damage", enemy.getName(), dmg));
                                        break;
                                    case CombatRoll.FAIL:
                                        Console.WriteLine(String.Format("You miss the {0}", enemy.getName()));
                                        break;
                                    case CombatRoll.PASS:
                                    case CombatRoll.CRIT:
                                    case CombatRoll.DOUBLT_CRIT:
                                        dmg = player.specialAttack() * (int)roll;
                                        enemy.takeDamage(dmg);
                                        Console.WriteLine(String.Format("You hit the {0} for {1} damage {2}", enemy.getName(), dmg, ((roll == CombatRoll.PASS) ? "" : ((roll == CombatRoll.CRIT) ? "(CRIT)" : "(DOUBLE CRIT)"))));
                                        break;
                                }
                                break;
                            case CombatAction.CHANGE_EQUIPMENT:
                                changeEquipment(player);
                                break;
                            //break;
                            case CombatAction.FLEE:

                                break;
                            default:
                                throw new IndexOutOfRangeException();
                        }
                    }
                    else
                    {
                        var dmg = -1;
                        CombatRoll roll;


                        var StatTotal = enemy.getSTR() + enemy.getINT();
                        var r = new Random().NextDouble();

                        double Ratio = (double)enemy.getSTR() / (double)StatTotal;

                        if (r < Ratio)
                        {
                            dmg = enemy.normalAttack();
                        }
                        else
                        {
                            if (enemy.getCurrentMP() >= 10)
                            {
                                dmg = enemy.specialAttack();
                            }
                            else
                            {
                                dmg = enemy.normalAttack();
                            }
                        }

                        roll = GetCombatRoll(enemy, player, DiceBag.rollDice(1, 20), DiceBag.rollDice(1, 20));


                        switch (roll)
                        {
                            case CombatRoll.CRIT_FAIL:
                                enemy.takeDamage(dmg);
                                Console.WriteLine(String.Format("The {0} misses you and hit itself for {1} damage", enemy.getName(), dmg));
                                break;
                            case CombatRoll.FAIL:
                                Console.WriteLine(String.Format("The {0} misses you.", enemy.getName()));
                                break;
                            case CombatRoll.PASS:
                            case CombatRoll.CRIT:
                            case CombatRoll.DOUBLT_CRIT:
                                dmg *= (int)roll;
                                player.takeDamage(dmg);
                                Console.WriteLine(String.Format("The {0} hit you for {1} damage {2}", enemy.getName(), dmg, ((roll == CombatRoll.PASS) ? "" : ((roll == CombatRoll.CRIT) ? "(CRIT)" : "(DOUBLE CRIT)"))));
                                break;
                        }

                    }
                    playerTurn = !playerTurn;
                }
                else
                {
                    running = false;
                }

            }

            if (player.IsAlive())
            {
                player.gainExp(enemy.getExp());
            }

            return player.IsAlive();

        }

        public void changeEquipment(Hero h)
        {
            int index = 0;
            string input;
            int userChoice = -1;
            foreach (Weapon weapon in h.getInventory().getWeapons())
            {
                Console.WriteLine(index + ": " + weapon.weaponDetails());
                index++;
            }
            while (userChoice == -1 || userChoice >= 0 && userChoice < h.getInventory().getWeapons().Length)
            {
                input = Console.ReadLine();
                int.TryParse(input, out userChoice);
            }

            h.setWeapon(h.getInventory().getWeaponAtIndex(userChoice));

        }

        public CombatRoll GetCombatRoll(Character attacker, Character defender, int AtkRoll, int DefRoll)
        {
            var AtkMods = AtkRoll + attacker.getStrikeBonus();
            var DefMods = DefRoll + defender.getDodgeBonus();

            Console.WriteLine(String.Format("==================\n\nATKROLL: {0}\tATKMODS: {1}\nDEFROLL: {2}\tDEFMODS: {3}\n\n==================", AtkRoll, AtkMods, DefRoll, DefMods));

            if (AtkRoll == 20)
            {
                if (DefRoll == 20)
                {
                    //get the stats and find who won
                    if (AtkMods > DefMods)
                    {
                        return CombatRoll.PASS;
                    }
                    else
                    {
                        return CombatRoll.FAIL;
                    }
                }
                else if (DefRoll == 1)
                {
                    //double crit
                    return CombatRoll.DOUBLT_CRIT;
                }
                else
                {
                    //attack passes before bonuses, CRIT
                    return CombatRoll.CRIT;
                }
            }
            else if (AtkRoll == 1)
            {
                //attack fails
                return CombatRoll.CRIT_FAIL;
            }
            else
            {
                if (DefRoll == 20)
                {
                    //fail
                    return CombatRoll.FAIL;
                }
                else
                {
                    //check bonuses and find who won
                    if (AtkMods > DefMods)
                    {
                        return CombatRoll.PASS;
                    }
                    else
                    {
                        return CombatRoll.FAIL;
                    }
                }
            }
        }

        /* Handled internally since it relies on player input and is untestable */
        private CombatAction GetPlayerAction()
        {
            //bool choosing = true;

            //Console.WriteLine(String.Format("Enemy\nHP: {3}/{4}\n===========================\nPLAYER\nHP: {0}/{1}\tMP: {2}/{3}\nInventory:", player.getCurrentHP(), player.getBaseHP(), player.getCurrentMP(), player.getBaseMP(), enemy.getCurrentHP(), enemy.getBaseHP()));
            Console.WriteLine("\n=======Player=======");
            Console.WriteLine(player.details());
            Console.WriteLine("\n=======" + enemy.getName() + "=======");
            Console.WriteLine(enemy.details());
            Console.WriteLine("\nWhat do you do?\n\t1)Normal Attack\n\t2)Special Attack\n\t3)Change Equipment\n\t4)Drink Health Potion\n\t5)Drink Mana Potion");

            while (true)
            {
                var res = Console.ReadLine();
                int choice;
                if (Int32.TryParse(res, out choice))
                {
                    try
                    {
                        return this.ParseAction(choice);
                    }
                    catch (IndexOutOfRangeException e)
                    {
                        Console.WriteLine("Invalid choice; Please try again.");
                    }
                }
            }

            throw new NotImplementedException();
        }

        public CombatAction ParseAction(int choice)
        {
            switch (choice)
            {
                case 1:
                    return CombatAction.NORMAL_ATTACK;
                case 2:
                    return CombatAction.SPECIAL_ATTACK;
                case 3:
                    return CombatAction.CHANGE_EQUIPMENT;
                case 4:
                    return CombatAction.DRINK_HEALTH_POTION;
                case 5:
                    return CombatAction.DRINK_MANA_POTION;
                //case 6:
                //    return CombatAction.FLEE;
                default:
                    throw new IndexOutOfRangeException();
            }
        }
    }
}
