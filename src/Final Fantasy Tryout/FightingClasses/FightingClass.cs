using Final_Fantasy_Tryout.Spells;
using Final_Fantasy_Tryout.Units;
using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Fantasy_Tryout.FightingClasses
{
   public abstract class FightingClass
   {
        public FightingClass()
        {

        }

        public virtual string ClassType { get;}
        public virtual double MaxHP { get;}
        public virtual int HealthRegen { get;}
        public virtual double MaxMana { get;}
        public virtual int ManaRegen { get; }
        public virtual double AttackPower { get; }
        public virtual double ArmorValue { get; }
        public virtual double RessistanceValue { get; }
        public virtual double MagicPower { get; }
        public virtual double CritChance { get; }

        public void StatIncrement(Unit player,FightingClass fightingClass)
        {
            player.ClassType = fightingClass.ClassType;
            player.MaxHP = fightingClass.MaxHP;
            player.CurrentHP = fightingClass.MaxHP;
            player.HealthRegen = fightingClass.HealthRegen;
            player.CurrentHealthRegen = fightingClass.HealthRegen;
            player.MaxMana = fightingClass.MaxMana;
            player.CurrentMana = fightingClass.MaxMana;
            player.ManaRegen = fightingClass.ManaRegen;
            player.CurrentManaRegen = fightingClass.ManaRegen;
            player.AttackPower = fightingClass.AttackPower;
            player.CurrentAttackPower = fightingClass.AttackPower;
            player.MagicPower = fightingClass.MagicPower;
            player.CurrentMagicPower = fightingClass.MagicPower;
            player.ArmorValue = fightingClass.ArmorValue;
            player.CurrentArmorValue = fightingClass.ArmorValue;
            player.RessistanceValue = fightingClass.RessistanceValue;
            player.CurrentRessistanceValue = fightingClass.RessistanceValue;
            player.CritChance = fightingClass.CritChance;
            player.CurrentCritChance = fightingClass.CritChance;
        }

        public void RarityRng(Unit enemy)
        {
            var rng = new Random();
            int number = rng.Next(1,11);
            if (number == 1)
            {
                enemy.RarityType = "Heroic";
                enemy.MaxHP += 0.15 * enemy.MaxHP;
                enemy.AttackPower += 0.3 * enemy.AttackPower;
                enemy.MagicPower += 0.3 * enemy.MagicPower;
                enemy.ArmorValue += 0.3 * enemy.ArmorValue;
                enemy.CurrentHP += 0.15 * enemy.CurrentHP;
                enemy.CurrentAttackPower += 0.3 * enemy.CurrentAttackPower;
                enemy.CurrentMagicPower += 0.3 * enemy.CurrentMagicPower;
                enemy.CurrentArmorValue += 0.3 * enemy.CurrentArmorValue;
                enemy.CurrentHealthRegen += 1;
            }
            else if (number == 2 || number == 3 || number == 4)
            {
                enemy.RarityType = "Rare";
                enemy.MaxHP += 0.10 * enemy.MaxHP;
                enemy.AttackPower += 0.15 * enemy.AttackPower;
                enemy.MagicPower += 0.15 * enemy.MagicPower;
                enemy.ArmorValue += 0.15 * enemy.ArmorValue;
                enemy.CurrentHP += 0.10 * enemy.CurrentHP;
                enemy.CurrentAttackPower += 0.15 * enemy.CurrentAttackPower;
                enemy.CurrentMagicPower += 0.15 * enemy.CurrentMagicPower;
                enemy.CurrentArmorValue += 0.15 * enemy.CurrentArmorValue;
            }
            else
            {
                enemy.RarityType = "Common";
            }
        }
    }
}
