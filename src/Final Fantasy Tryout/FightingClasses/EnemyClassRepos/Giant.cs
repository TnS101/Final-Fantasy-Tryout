namespace Final_Fantasy_Tryout.FightingClasses.EnemyClassRepos
{
    public class Giant : FightingClass
    {
        private const string classType = "Giant";
        private const double maxHP = 200;
        private const int healthRegen = 2;
        private const double maxMana = 50;
        private const int manaRegen = 5;
        private const double attackPower = 9;
        private const double magicPower = 8;
        private const double armorValue = 5;
        private const double ressistanceValue = 5;
        private const double critChance = 5;

        public Giant()
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
