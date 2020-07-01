using Final_Fantasy_Tryout.ArmorInfo;
using Final_Fantasy_Tryout.Inventory;
using Final_Fantasy_Tryout.Items;
using Final_Fantasy_Tryout.PlayerInfo;
using Final_Fantasy_Tryout.Spells;
using Final_Fantasy_Tryout.Units.PlayerInfo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Fantasy_Tryout.Units.EnemyUnits
{
    public class EnemyUnit : Unit
    {
        private const int goldAmount = 10;
        private const string type = "Enemy";
        private static SpellRepos spells;
        private static Bag bag;
        private static Equipment equipment;
        public EnemyUnit(string name, string classType, string race, int level, 
            double xp, double xpCap, double maxHP, int healthRegen, double maxMana, int manaRegen,
            double attackPower, double magicPower, double armorValue, double ressistanceValue, double critChance,PlayerInventory inventory)
            : base(name, type, classType, race, level, xp, xpCap, maxHP, healthRegen, maxMana,
                  manaRegen, attackPower, magicPower, armorValue, ressistanceValue, critChance, goldAmount,inventory,spells,bag,equipment)
        {
            spells = new SpellRepos();
        }
    }
}
