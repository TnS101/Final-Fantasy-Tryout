﻿namespace Final_Fantasy_Tryout.FightingClasses.EnemyClassRepos
{
    public class Zombie : FightingClass
    {
        private const string classType = "Zombie";
        private const double maxHP = 100;
        private const int healthRegen = 5;
        private const double maxMana = 50;
        private const int manaRegen = 2;
        private const double attackPower = 10;
        private const double magicPower = 5;
        private const double armorValue = 2.2;
        private const double ressistanceValue = 3;
        private const double critChance = 8;

        public Zombie()
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
