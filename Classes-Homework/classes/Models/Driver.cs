using System;
using System.Collections.Generic;
using System.Text;

namespace classes.Models
{
   public class Driver
    {
        public string Name { get; set; }
        public int Skill { get; set; }
      
        public Driver(string name, int skill)
        {
            Name = name;
            Skill = skill;
        }
    }
}
