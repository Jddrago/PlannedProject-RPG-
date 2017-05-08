using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannedProject_RPG_
{
    class HealthPotion
    {
        private int value = 0;
        public HealthPotion()
        {
            int valueNum = 0;
            Random rand = new Random();
            valueNum = rand.Next(1,11);
            value = valueNum + (valueNum * 10);
        }

        public int Use()
        {
            int valueNum = value;
            value = 0;
            return valueNum;
        }


    }
}
