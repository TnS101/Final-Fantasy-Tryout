using Final_Fantasy_Tryout.ArmorInfo;
using Final_Fantasy_Tryout.FightingClasses;
using Final_Fantasy_Tryout.Inventory;
using Final_Fantasy_Tryout.PlayerInfo;
using Final_Fantasy_Tryout.PlayingField;
using System;
using System.Collections.Generic;

namespace Final_Fantasy_Tryout
{
    public class Startup
    {
        static void Main(string[] args)
        {
            //test : good!!

            //TODO : ,enemy and team field,inventory,
            Map map = new Map();
            Player player = new Player("Goshkata");
            
            Console.WriteLine("Pick your class!");
            Console.WriteLine();
            Console.WriteLine("[♦] Warrior"); Console.WriteLine("(█) Mage"); Console.WriteLine("[♠] Paladin");
            Console.WriteLine("(↑) Naturalist"); Console.WriteLine("[►◄] Rogue"); Console.WriteLine("(▬▬) Necroid");
            Console.WriteLine("[☼] Hunter"); Console.WriteLine("(╬) Priest"); Console.WriteLine("[♣] Shaman"); Console.WriteLine();
            player.SetClass(player);
            
            Console.Clear();

            Console.WriteLine("Pick your race!");
            Console.WriteLine();
            Console.WriteLine("[Human]"); Console.WriteLine("[Dwarf]"); Console.WriteLine("[Elf]");
            Console.WriteLine("[Orc]"); Console.WriteLine("[Troll]"); Console.WriteLine("[Goblin]");
            Console.WriteLine();
            player.SetRace(player);

            Console.Clear();
            Console.WriteLine(player.GetInfo(player));
            map.Generate(player);
        }
    }
}
