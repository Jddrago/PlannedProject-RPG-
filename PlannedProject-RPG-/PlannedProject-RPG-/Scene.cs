using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannedProject_RPG_
{
    class Scene
    {
        public readonly string Description;
        public readonly Choice[] choices;
        public readonly int Reference;

        public Scene(string Description, Choice[] choices)
        {
            this.Description = Description;
            this.choices = choices;
        }

        public Scene(string Description, int Reference)
        {
            this.Description = Description;
            this.Reference = Reference;
        }
    }

    public class Choice
    {
        public readonly string Description;
        public readonly int Reference;

        public Choice(string Description, int Reference)
        {
            this.Description = Description;
            this.Reference = Reference;
        }


    }
}
