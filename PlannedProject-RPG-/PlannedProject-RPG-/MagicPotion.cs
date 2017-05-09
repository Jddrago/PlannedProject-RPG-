using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannedProject_RPG_
{
    class MagicPotion
    {
        private int value = 0;
        public MagicPotion()
        {
            int valueNum = 0;
            Random rand = new Random();
            valueNum = rand.Next(1, 11);
            value = valueNum + (valueNum * 7);
        }

        public int Use()
        {
            int valueNum = value;
            value = 0;
            return valueNum;
        }
    }
}
