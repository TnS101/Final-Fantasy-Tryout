﻿namespace Final_Fantasy_Tryout.FightingClasses
{
    public class Paladin : FightingClass
    {
        private const double critChance = 5;
        private const string classType = "Paladin";
        private const double maxHP = 220;
        private const int healthRegen = 2;
        private const double maxMana = 100;
        private const int manaRegen = 5;
        private const double attackPower = 22;
        private const double magicPower = 18;
        private const double armorValue = 4;
        private const double ressistanceValue = 5;

        public Paladin()
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
