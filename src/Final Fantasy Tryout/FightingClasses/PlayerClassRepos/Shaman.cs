using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Fantasy_Tryout.FightingClasses.PlayerClassRepos
{
   public class Shaman : FightingClass
   {
        private const double critChance = 5;
        private const string classType = "Shaman";
        private const double maxHP = 180;
        private const int healthRegen = 2;
        private const double maxMana = 100;
        private const int manaRegen = 15;
        private const double attackPower = 20;
        private const double magicPower = 20;
        private const double armorValue = 3;
        private const double ressistanceValue = 5;

        public Shaman()
        {
        }

        public override string ClassType => classType;
        public override double MaxHP => maxHP;
        public override int HealthRegen => healthRegen;
        public override double MaxMana => maxMana;
        public override int ManaRegen => manaRegen;
        public override double AttackPower => attackPower;
        public override double ArmorValue => armorValue;
        public override double RessistanceValue => ressistanceValue;
        public override double MagicPower => magicPower;
        public override double CritChance => critChance;
    }
}
