﻿namespace Final_Fantasy_Tryout.FightingClasses
{
    public class Wyrm : FightingClass
    {
        private const string classType = "Wyrm";
        private const double maxHP = 100;
        private const int healthRegen = 2;
        private const double maxMana = 50;
        private const int manaRegen = 15;
        private const double attackPower = 12;
        private const double magicPower = 15;
        private const double armorValue = 2;
        private const double ressistanceValue = 5;
        private const double critChance = 5;

        public Wyrm()
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
