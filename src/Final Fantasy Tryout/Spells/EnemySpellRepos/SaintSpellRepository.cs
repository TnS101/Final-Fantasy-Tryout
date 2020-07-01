using Final_Fantasy_Tryout.Units;
using System;
using System.Collections.Generic;

namespace Final_Fantasy_Tryout.Spells.EnemySpellRepos
{
    public class SaintSpellRepository : SpellRepos
    {
        private readonly SpellCheck spellCheck;
        private readonly List<Spell> spells;
        public SaintSpellRepository(Unit caster)
        {
            Spell sacredWords = new Spell("Sacred Words", 0.4 * caster.MaxMana);
            Spell illumination = new Spell("Illumination", 0.3 * caster.MaxMana);
            Spell holySmite = new Spell("Holy Smite", 0.15 * caster.MaxMana);
            Spell judgementDay = new Spell("Judgement Day", 0.5 * caster.MaxMana);
            spells = new List<Spell>();
            spellCheck = new SpellCheck();
            spells.Add(sacredWords);
            spells.Add(illumination);
            spells.Add(holySmite);
            spells.Add(judgementDay);
        }

        public override List<Spell> Spells => spells;

        public void SacredWords(Unit caster)
        {
            string spellName = "Sacred Words";
            double effect = caster.MagicPower + 0.5 * caster.MaxHP;
            double manaRequirment = 0.4 * caster.MaxMana;
            spellCheck.HealCheck(caster, caster, manaRequirment, effect, spellName);
        }

        public void Illumination(Unit caster, Unit target)
        {
            string spellName = "Illumination";
            string debuffType = "Magic";
            string negativeEffectType = "mRegen";
            double debuffEffect = 0.3 * caster.MagicPower;
            int negativeEffect = caster.Level + 2;
            double manaRequirment = 0.3 * caster.MaxMana;
            spellCheck.NegativeEffectCheck(caster, target, manaRequirment, negativeEffect, negativeEffectType);
            spellCheck.DeBuffCheck(caster, target, manaRequirment, debuffEffect, spellName, debuffType);
        }

        public void HolySmite(Unit caster, Unit target)
        {
            string spellName = "Holy Smite";
            double damage = caster.MagicPower - target.CurrentRessistanceValue;
            double manaRequirment = 0.15 * caster.MaxMana;
            spellCheck.SpellDamageCheck(caster, target, manaRequirment, damage, spellName);
        }

        public void JudgementDay(Unit caster, Unit target)
        {
            string spellName = "Judgement Day";
            string negativeEffectType = "Mana";
            double damage = 1.3 * caster.CurrentMagicPower - target.CurrentRessistanceValue;
            double negativeEffect = 0.2 * caster.MaxMana;
            double manaRequirment = 0.5 * caster.MaxMana;
            spellCheck.NegativeEffectCheck(caster, target, manaRequirment, negativeEffect, negativeEffectType);
            spellCheck.SpellDamageCheck(caster, target, manaRequirment, damage, spellName);
        }

        public void SpellCast(Unit caster, Unit target)
        {
            var rng = new Random();
            int enemyActionNumber = rng.Next(1, 5);

            if (enemyActionNumber == 1)
            {
                this.SacredWords(caster);
            }

            if (enemyActionNumber == 2)
            {
                this.Illumination(caster, target);
            }

            if (enemyActionNumber == 3)
            {
                this.HolySmite(caster,target);
            }

            if (enemyActionNumber == 4)
            {
                this.JudgementDay(caster,target);
            }
        }
    }
}
