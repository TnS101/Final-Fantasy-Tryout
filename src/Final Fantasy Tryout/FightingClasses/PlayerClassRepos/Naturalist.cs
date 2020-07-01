namespace Final_Fantasy_Tryout.FightingClasses
{
    public class Naturalist : FightingClass
    {
        private const double critChance = 5;
        private const string classType = "Naturalist";
        private const double maxHP = 220;
        private const int healthRegen = 3;
        private const double maxMana = 200;
        private const int manaRegen = 25;
        private const double attackPower = 15;
        private const double magicPower = 28;
        private const double armorValue = 5;
        private const double ressistanceValue = 2.2;

        public Naturalist()
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
