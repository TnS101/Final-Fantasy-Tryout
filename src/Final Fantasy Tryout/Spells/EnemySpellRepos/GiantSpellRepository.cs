using Final_Fantasy_Tryout.Units;
using System;
using System.Collections.Generic;

namespace Final_Fantasy_Tryout.Spells.EnemySpellRepos
{
    public class GiantSpellRepository : SpellRepos
    {
        private readonly SpellCheck spellCheck;
        private readonly List<Spell> spells;
        public GiantSpellRepository(Unit caster)
        {
            Spell overGrowth = new Spell("Overgrowth", 0.4 * caster.MaxMana);
            Spell calmingMind = new Spell("Calming Mind", 0.1 * caster.MaxMana);
            Spell ragingMind = new Spell("Raging Mind", 0.5 * caster.MaxMana);
            Spell overpoweringFist = new Spell("Overpowering Fist", 0.5 * caster.MaxMana);
            spells = new List<Spell>();
            spellCheck = new SpellCheck();
            spells.Add(overGrowth);
            spells.Add(calmingMind);
            spells.Add(ragingMind);
            spells.Add(overpoweringFist);
        }

        public override List<Spell> Spells => spells;

        public void OverGrowth(Unit caster)
        {
            string spellName = "Overgrowth";
            string buffType = "Attack";
            string negativeEffectType = "hRegen";
            double effect = 0.35 * caster.ArmorValue;
            int negativeEffect = caster.Level;
            double manaRequirment = 0.4 * caster.MaxMana;
            spellCheck.NegativeEffectCheck(caster, caster, manaRequirment, negativeEffect, negativeEffectType);
            spellCheck.BuffCheck(caster, caster, manaRequirment, effect, spellName, buffType);
        }

        public void CalmingMind(Unit caster)
        {
            string spellName = "Calming Mind";
            string buffType = "mRegen";
            int effect = 2 + caster.Level;
            double manaRequirment = 0.1 * caster.MaxMana;
            spellCheck.BuffCheck(caster, caster, manaRequirment, effect, spellName, buffType);
        }

        public void RagingMind(Unit caster)
        {
            string spellName = "Raging Mind";
            string buffType = "Attack";
            string negativeEffectType = "Damage";
            double buffEffect = 0.30 * caster.AttackPower;
            double negativeEffect = 0.20 * caster.MaxHP;
            double manaRequirment = 0.5 * caster.MaxMana;
            spellCheck.NegativeEffectCheck(caster, caster, manaRequirment, negativeEffect, negativeEffectType);
            spellCheck.BuffCheck(caster,caster,manaRequirment,buffEffect,spellName,buffType);
        }

        public void OverpoweringFist(Unit caster, Unit target)
        {
            string spellName = "Overpowering Fist";
            double damage = 1.2 * caster.CurrentAttackPower - 0.5 * target.CurrentArmorValue;
            double manaRequirment = 0.5 * caster.MaxMana;
            spellCheck.PhysicalDamageCheck(caster, target, manaRequirment, damage, spellName);
        }

        public void SpellCast(Unit caster, Unit target)
        {
            var rng = new Random();
            int enemyActionNumber = rng.Next(1, 5);

            if (enemyActionNumber == 1)
            {
                this.OverGrowth(caster);
            }

            if (enemyActionNumber == 2)
            {
                this.CalmingMind(caster);
            }

            if (enemyActionNumber == 3)
            {
                this.RagingMind(caster);
            }

            if (enemyActionNumber == 4)
            {
                this.OverpoweringFist(caster,target);
            }
        }
    }
}
