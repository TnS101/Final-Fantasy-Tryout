using Final_Fantasy_Tryout.PlayerInfo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Fantasy_Tryout.ArmorInfo
{
   public interface IItem 
    {
        string Name { get; }

        string Type { get; }

        int Level { get; }

        string ClassUsable { get; }

        int Stamina { get; }

        int Strength { get; }

        int Agility { get; }

        int Intellect { get; }

        int Spirit { get; }

        string Slot { get; }
    }
}
