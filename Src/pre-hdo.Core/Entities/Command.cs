using System;
using System.Collections.Generic;
using System.Text;

namespace pre_hdo.Core.Entities
{
    public class Command
    {
        public Command(int number, string name)
        {
            Number = number;
            Name = name;
        }

        public string Name { get; set; }
        public int Number { get; set; }

        public override string ToString()
        {
            return $"{Number} - {Name}";
        }
    }
}
