using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannedProject_RPG_
{
    class DiceBag
    {
        private static Die[] dice;

        public static int rollDice(int numDice,int numSidesPerDice)
        {
            int total=0;
            dice = new Die[numDice];
            for (int i=0;i<numDice;i++)
            {
                dice[i] = new Die(numSidesPerDice);
            }
            foreach (Die die in dice)
            {
                die.roll();
                total += die.getLastRoll();
            }

            return total;
        }

        public static int rollDice(int numDice, int numSidesPerDice,int mod)
        {
            int total = 0;
            dice = new Die[numDice];
            for (int i = 0; i < numDice; i++)
            {
                dice[i] = new Die(numSidesPerDice);
            }
            foreach (Die die in dice)
            {
                die.roll();
                total += die.getLastRoll();
            }

            return total+mod;
        }
    }
}
