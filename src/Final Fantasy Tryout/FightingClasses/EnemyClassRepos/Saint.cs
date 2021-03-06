﻿namespace Final_Fantasy_Tryout.FightingClasses.EnemyClassRepos
{
    public class Saint : FightingClass
    {
        private const string classType = "Saint";
        private const double maxHP = 180;
        private const int healthRegen = 5;
        private const double maxMana = 50;
        private const int manaRegen = 5;
        private const double attackPower = 10;
        private const double magicPower = 22;
        private const double armorValue = 3;
        private const double ressistanceValue = 8;
        private const double critChance = 8;

        public Saint()
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
