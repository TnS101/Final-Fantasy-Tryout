using Final_Fantasy_Tryout.Units;
using System;
using System.Collections.Generic;

namespace Final_Fantasy_Tryout.Spells.EnemySpellRepos
{
    public class SkeletonSpellRepository : SpellRepos
    {
        private readonly SpellCheck spellCheck;
        private readonly List<Spell> spells;
        public SkeletonSpellRepository(Unit caster)
        {
            Spell tombStone = new Spell("Tombstone", 0.3 * caster.MaxMana);
            Spell wrathOfTheNecropolis = new Spell("Wrath Of The Necropolis", 0.5 * caster.MaxMana);
            Spell suffocation = new Spell("Suffocation", 0.3 * caster.MaxMana);
            Spell horrifyingScream = new Spell("Horrifying Scream", 0.3 * caster.MaxMana);
            spells = new List<Spell>();
            spellCheck = new SpellCheck();
            spells.Add(tombStone);
            spells.Add(wrathOfTheNecropolis);
            spells.Add(suffocation);
            spells.Add(horrifyingScream);
        }

        public override List<Spell> Spells => spells;

        public void TombStone(Unit caster)
        {
            string spellName = "Tomb Stone";
            string buffType = "Armor";
            string negativeEffectType = "hRegen";
            double buffEffect = caster.ArmorValue;
            int negativeEffect = caster.HealthRegen - caster.Level - 2;
            double manaRequirment = 0.3 * caster.MaxMana;
            spellCheck.NegativeEffectCheck(caster, caster, manaRequirment, negativeEffect, negativeEffectType);
            spellCheck.BuffCheck(caster, caster, manaRequirment, buffEffect, spellName, buffType);
        }

        public void WrathOfTheNecropolis(Unit caster, Unit target)
        {
            string spellName = "Wrath Of The Necropolis";
            double damage = caster.CurrentAttackPower + caster.CurrentMagicPower - target.CurrentArmorValue;
            double manaRequirment = 0.5 * caster.MaxMana;
            spellCheck.PhysicalDamageCheck(caster, target, manaRequirment, damage, spellName);
        }

        public void Suffocation(Unit caster, Unit target)
        {
            string spellName = "Suffocation";
            string negativeEffectType = "hRegen";
            double damage = 1.1 * caster.CurrentAttackPower - target.CurrentArmorValue;
            int negativeEffect = caster.CurrentHealthRegen;
            double manaRequirment = 0.3 * caster.MaxMana;
            spellCheck.NegativeEffectCheck(caster, target, manaRequirment, negativeEffect, negativeEffectType);
            spellCheck.PhysicalDamageCheck(caster, target, manaRequirment, damage, spellName);
        }

        public void HorrifyingScream(Unit caster, Unit target)
        {
            string spellName = "Horrifying Scream";
            string debuffType = "Attack";
            double effect = 0.2 * target.AttackPower;
            double manaRequirment = 0.3 * caster.MaxMana;
            spellCheck.DeBuffCheck(caster, target, manaRequirment, effect, spellName, debuffType);
        }

        public void SpellCast(Unit caster, Unit target)
        {
            var rng = new Random();
            int enemyActionNumber = rng.Next(1, 5);

            if (enemyActionNumber == 1)
            {
                this.TombStone(caster);
            }

            if (enemyActionNumber == 2)
            {
                this.WrathOfTheNecropolis(caster, target);
            }

            if (enemyActionNumber == 3)
            {
                this.Suffocation(caster,target);
            }

            if (enemyActionNumber == 4)
            {
                this.HorrifyingScream(caster,target);
            }
        }
    }
}
