using Final_Fantasy_Tryout.Units;
using System;
using System.Collections.Generic;

namespace Final_Fantasy_Tryout.Spells.EnemySpellRepos
{
    public class ZombieSpellRepository : SpellRepos
    {
        private readonly SpellCheck spellCheck;
        private readonly List<Spell> spells;
        public ZombieSpellRepository(Unit caster)
        {
            Spell infectingBite = new Spell("Infecting Bite", 0.4 * caster.MaxMana);
            Spell feed = new Spell("Feed", 0.5 * caster.MaxMana);
            Spell mutation = new Spell("Mutation", 0.5 * caster.MaxMana);
            Spell decay = new Spell("Decay", 0.1 * caster.MaxMana);
            spells = new List<Spell>();
            spellCheck = new SpellCheck();
            spells.Add(infectingBite);
            spells.Add(feed);
            spells.Add(mutation);
            spells.Add(decay);
        }

        public override List<Spell> Spells => spells;

        public void InfectingBite(Unit caster, Unit target)
        {
            string spellName = "Infecting Bite";
            double manaRequirment = 0.4 * caster.MaxMana;
            string negativeEffectType = "hRegen";
            double damage = 1.2 * caster.CurrentAttackPower - target.CurrentArmorValue;
            int negativeEffect = caster.CurrentHealthRegen;
            spellCheck.NegativeEffectCheck(caster, target, manaRequirment, negativeEffect, negativeEffectType);
            spellCheck.PhysicalDamageCheck(caster, target, manaRequirment, damage, spellName);
        }

        public void Feed(Unit caster, Unit target)
        {
            string spellName = "Feed";
            double manaRequirment = 0.5 * caster.MaxMana;
            string possitiveEffectType = "Health";
            double damage = 1.3 * caster.CurrentAttackPower - target.CurrentArmorValue;
            double possitiveEffect = 0.3 * caster.MaxHP;
            spellCheck.PositiveEffectCheck(caster, target, manaRequirment, possitiveEffect, possitiveEffectType);
            spellCheck.PhysicalDamageCheck(caster,target,manaRequirment,damage,spellName);
        }

        public void Mutation(Unit caster)
        {
            string spellName = "Mutation";
            double manaRequirment = 0.5 * caster.MaxMana;
            string buffType = "Attack";
            string possitiveEffectType = "Health";
            double buffEffect = 0.4 * caster.AttackPower;
            double possitiveEffect = 0.3 * caster.MaxHP;
            spellCheck.PositiveEffectCheck(caster, caster, manaRequirment, possitiveEffect, possitiveEffectType);
            spellCheck.BuffCheck(caster, caster, manaRequirment, buffEffect, spellName, buffType);
        }

        public void Decay(Unit caster)
        {
            string spellName = "Decay";
            double manaRequirment = 0.1 * caster.MaxMana;
            string buffType = "Armor";
            string negativeEffectType = "hRegen";
            double buffEffect = 0.3 * caster.ArmorValue;
            double negativeEffect = caster.Level;
            spellCheck.NegativeEffectCheck(caster, caster, manaRequirment, negativeEffect, negativeEffectType);
            spellCheck.BuffCheck(caster, caster, manaRequirment, buffEffect, spellName, buffType);
        }

        public void SpellCast(Unit caster, Unit target)
        {
            var rng = new Random();
            int enemyActionNumber = rng.Next(1, 5);

            if (enemyActionNumber == 1)
            {
                this.InfectingBite(caster,target);
            }

            if (enemyActionNumber == 2)
            {
                this.Feed(caster, target);
            }

            if (enemyActionNumber == 3)
            {
                this.Mutation(caster);
            }

            if (enemyActionNumber == 4)
            {
                this.Decay(caster);
            }
        }
    }
}
