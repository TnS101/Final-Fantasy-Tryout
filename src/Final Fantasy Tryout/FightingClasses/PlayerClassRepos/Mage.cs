namespace Final_Fantasy_Tryout.FightingClasses
{
    public class Mage : FightingClass
    {
        private const double critChance = 5;
        private const string classType = "Mage";
        private const double maxHP = 200;
        private const int healthRegen = 3;
        private const double maxMana = 150;
        private const int manaRegen = 25;
        private const double attackPower = 18;
        private const double magicPower = 30;
        private const double armorValue = 2;
        private const double ressistanceValue = 6;

        public Mage()
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
