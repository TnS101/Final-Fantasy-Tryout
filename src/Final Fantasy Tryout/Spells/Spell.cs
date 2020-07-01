using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Fantasy_Tryout.Spells
{
   public class Spell
    {
        public Spell(string name,double manaRequirment)
        {
            this.Name = name;
            this.ManaRequirment = manaRequirment;
        }
        
        public string Name { get; set; }
        public double ManaRequirment { get; set; }
    }
}
