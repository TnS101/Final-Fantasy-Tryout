using Final_Fantasy_Tryout.ArmorInfo;
using Final_Fantasy_Tryout.Inventory;
using Final_Fantasy_Tryout.Spells;
using Final_Fantasy_Tryout.Units;
using Final_Fantasy_Tryout.Units.PlayerInfo;
using System.Collections.Generic;
using System.Text;

namespace Final_Fantasy_Tryout.PlayerInfo
{
    public class Player : Unit
    {
        private const string classType = "";
        private static SpellRepos spells;
        private const string race = "";
        private const int level = 1;
        private const int xp = 0;
        private const int xpCap = 100;
        private static double maxHP = 0;
        private const int healthRegen = 0;
        private const double maxMana = 0;
        private const int manaRegen = 0;
        private const double attackPower = 0;
        private const double magicPower = 0;
        private const double armorValue = 0;
        private const double ressistanceValue = 0;
        private const double critChance = 0;
        private const int goldAmount = 100;
        private static PlayerInventory inventory;
        private static Bag bag;
        private static Equipment equipment;
        private const string type = "Player";
        public Player(string name) 

            : base(name, type, classType, race, level, xp, xpCap, maxHP, healthRegen, maxMana,
                  manaRegen, attackPower, magicPower, armorValue, ressistanceValue, critChance, goldAmount, inventory,spells,bag,equipment)
        {
            this.Name = name;
            this.Level = level;
            inventory = new PlayerInventory();
            spells = new SpellRepos();
            bag = new Bag();
            equipment = new Equipment();
        }
    }
}
