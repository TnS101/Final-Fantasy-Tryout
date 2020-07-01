using Final_Fantasy_Tryout.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Fantasy_Tryout.ArmorInfo.Trinkets
{
    public  class Trinket : Item
    {
        public Trinket(string name, string type, string slot, int level, string classUsable, int stamina
           , int strength, int intellect, int agility, int spirit)
        {
            this.Name = name;
            this.Type = type;
            this.Slot = slot;
            this.Level = level;
            this.ClassUsable = classUsable;
            this.Stamina = stamina;
            this.Strength = strength;
            this.Intellect = intellect;
            this.Agility = agility;
            this.Spirit = spirit;
        }
    }
}
