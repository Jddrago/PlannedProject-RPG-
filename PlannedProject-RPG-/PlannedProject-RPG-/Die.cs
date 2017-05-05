using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannedProject_RPG_
{
    public class Die
    {
        private int numSides,lastRoll;

        public Die(int numOfSides)
        {
            numSides = numOfSides;
        }
        public void roll()
        {
            Random roller = new Random();
            lastRoll = roller.Next(numSides)+1;
        }

        public int getLastRoll()
        {
            return lastRoll;
        }
    }
}
