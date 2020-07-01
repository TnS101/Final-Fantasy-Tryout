namespace Final_Fantasy_Tryout.FightingClasses
{
    public class Priest : FightingClass
    {
        private const double critChance = 5;
        private const string classType = "Priest";
        private const double maxHP = 170;
        private const int healthRegen = 5;
        private const double maxMana = 200;
        private const int manaRegen = 15;
        private const double attackPower = 15;
        private const double magicPower = 35;
        private const double armorValue = 2.8;
        private const double ressistanceValue = 5.3;

        public Priest()
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
