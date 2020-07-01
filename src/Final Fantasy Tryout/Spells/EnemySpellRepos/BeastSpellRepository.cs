using Final_Fantasy_Tryout.Units;
using System;
using System.Collections.Generic;

namespace Final_Fantasy_Tryout.Spells.EnemySpellRepos
{
    public class BeastSpellRepository : SpellRepos
    {
        private readonly SpellCheck spellCheck;
        private readonly List<Spell> spells;
        public BeastSpellRepository(Unit caster)
        {
            Spell furiousRoar = new Spell("Furious Roar", 0.2 * caster.MaxMana);
            Spell bite = new Spell("Bite", 0.2 * caster.MaxMana);
            Spell thickHide = new Spell("Thick Hide", 0.5 * caster.MaxMana);
            Spell lickWounds = new Spell("Lick Wounds", 0.4 * caster.MaxMana);
            spells = new List<Spell>();
            spellCheck = new SpellCheck();
            spells.Add(furiousRoar);
            spells.Add(bite);
            spells.Add(thickHide);
            spells.Add(lickWounds);
        }

        public override List<Spell> Spells => spells;

        public void FuriousRoar(Unit caster)
        {
            string spellName = "Furious Roar";
            string buffType = "Attack";
            double effect = 0.2 * caster.AttackPower;
            double manaRequirment = 0.3 * caster.MaxMana;
            spellCheck.BuffCheck(caster, caster, manaRequirment, effect, spellName, buffType);
        }

        public void Bite(Unit caster, Unit target)
        {
            string spellName = "Bite";
            string effectType = "hRegen";
            int effect = 1;
            double manaRequirment = 0.2 * caster.MaxMana;
            double damage = caster.AttackPower * 1.2 - target.CurrentArmorValue;
            spellCheck.NegativeEffectCheck(caster, target, manaRequirment, effect, effectType);
            spellCheck.PhysicalDamageCheck(caster, target, manaRequirment, damage, spellName);
        }

        public void ThickHide(Unit caster)
        {
            string spellName = "Thick Hide";
            string buffType = "Armor";
            double effect = caster.ArmorValue * 0.8;
            double manaRequirment = 0.5 * caster.MaxMana;
            spellCheck.BuffCheck(caster, caster, manaRequirment, effect, spellName, buffType);
        }

        public void LickWounds(Unit caster)
        {
            string spellName = "Lick Wounds";
            string negativeEffectType = "Attack";
            double healEffect = 0.2 * caster.MaxHP;
            double negativeEffect = 0.15 * caster.AttackPower;
            double manaRequirment = 0.4 * caster.MaxMana;
            spellCheck.NegativeEffectCheck(caster, caster, manaRequirment, negativeEffect, negativeEffectType);
            spellCheck.HealCheck(caster, caster, manaRequirment, healEffect, spellName);
        }

        public void SpellCast(Unit caster, Unit target)
        {
            var rng = new Random();
            int enemyActionNumber = rng.Next(1, 5);

            if (enemyActionNumber == 1)
            {
                this.FuriousRoar(caster);
            }

            if (enemyActionNumber == 2)
            {
                this.Bite(caster, target);
            }

            if (enemyActionNumber == 3)
            {
                this.ThickHide(caster);
            }

            if (enemyActionNumber == 4)
            {
                this.LickWounds(caster);
            }
        }
    }
}
