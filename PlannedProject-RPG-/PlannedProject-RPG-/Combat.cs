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

        public void Start()
        {
            while (running)
            {

                if (player.IsAlive() && enemy.IsAlive())
                {

                    if (playerTurn)
                    {
                        var action = GetPlayerAction();

                        switch (action)
                        {
                            case CombatAction.DRINK_HEALTH_POTION:
                                break;
                            case CombatAction.DRINK_MANA_POTION:
                                break;
                            case CombatAction.NORMAL_ATTACK:
                                break;
                            case CombatAction.SPECIAL_ATTACK:
                                break;
                            case CombatAction.CHANGE_EQUIPMENT:
                                break;
                            case CombatAction.FLEE:
                                break;
                            default:
                                throw new IndexOutOfRangeException();
                        }
                    }
                    else
                    {

                    }
                    playerTurn = !playerTurn;
                }
                else
                {
                    running = false;
                }

            }
        }

        /* Handled internally since it relies on player input and is untestable */
        private CombatAction GetPlayerAction()
        {
            //bool choosing = true;

            //Console.WriteLine(String.Format("Enemy\nHP: {3}/{4}\n===========================\nPLAYER\nHP: {0}/{1}\tMP: {2}/{3}\nInventory:", player.getCurrentHP(), player.getBaseHP(), player.getCurrentMP(), player.getBaseMP(), enemy.getCurrentHP(), enemy.getBaseHP()));
            Console.WriteLine(player.details());
            Console.WriteLine(enemy.details());
            Console.WriteLine("\nWhat do you do?\n\t1)Normal Attack\n\t2)Special Attack\n\t3)Change Equipment\n\t4)Drink Health Potion\n\t5)Drink Mana Potion\n\t6)Flee");

            while (true)
            {
                var res = Console.ReadLine();
                int choice;
                if (Int32.TryParse(res, out choice))
                {
                    try
                    {
                        return this.ParseAction(choice);
                    } catch (IndexOutOfRangeException e)
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
                case 6:
                    return CombatAction.FLEE;
                default:
                    throw new IndexOutOfRangeException();
            }
        }
    }
}
