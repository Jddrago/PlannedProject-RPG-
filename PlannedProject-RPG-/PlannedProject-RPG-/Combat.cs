using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannedProject_RPG_
{

    enum CombatAction
    {
        DRINK_HEALTH_POTION,
        DRINK_MANA_POTION,
        NORMAL_ATTACK,
        SPECIAL_ATTACK,
        CHANGE_EQUIPMENT,
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
                        var action = GetAction();

                        switch (action)
                        {
                            default:
                                throw new NotImplementedException();
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

        public CombatAction GetAction()
        {
            //bool choosing = true;

            //Console.WriteLine(String.Format("Enemy\nHP: {3}/{4}\n===========================\nPLAYER\nHP: {0}/{1}\tMP: {2}/{3}\nInventory:", player.getCurrentHP(), player.getBaseHP(), player.getCurrentMP(), player.getBaseMP(), enemy.getCurrentHP(), enemy.getBaseHP()));
            Console.WriteLine(player.details());
            Console.WriteLine(enemy.details());
            Console.WriteLine("\nWhat do you do?\n1)Drink Health Potion\n2)Drink Mana Potion\n3)Normal Attack\n4)Special Attack\n5)Change Equipment");

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
                    return CombatAction.DRINK_HEALTH_POTION;
                case 2:
                    return CombatAction.DRINK_MANA_POTION;
                case 3:
                    return CombatAction.NORMAL_ATTACK;
                case 4:
                    return CombatAction.SPECIAL_ATTACK;
                case 5:
                    return CombatAction.CHANGE_EQUIPMENT;
                case 6:
                    return CombatAction.FLEE;
                default:
                    throw new IndexOutOfRangeException();
            }
        }
    }
}
