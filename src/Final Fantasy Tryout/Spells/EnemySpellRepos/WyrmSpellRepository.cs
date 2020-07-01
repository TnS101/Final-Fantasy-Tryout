using Final_Fantasy_Tryout.Units;
using System;
using System.Collections.Generic;

namespace Final_Fantasy_Tryout.Spells.EnemySpellRepos
{
    public class WyrmSpellRepository : SpellRepos
    {
        private readonly SpellCheck spellCheck;
        private readonly List<Spell> spells;
        public WyrmSpellRepository(Unit caster)
        {
            Spell tidalSlash = new Spell("Tidal Slash", 0.15 * caster.MaxMana);
            Spell dive = new Spell("Dive", 0.3 * caster.MaxMana);
            Spell hyperSpeed = new Spell("Hyper Speed", 0.3 * caster.MaxMana);
            Spell thunder = new Spell("Thunder", 0.5 * caster.MaxMana);
            spells = new List<Spell>();
            spellCheck = new SpellCheck();
            spells.Add(tidalSlash);
            spells.Add(dive);
            spells.Add(hyperSpeed);
            spells.Add(thunder);
        }

        public override List<Spell> Spells => spells;

        public void TidalSlash(Unit caster, Unit target)
        {
            string spellName = "Tidal Slash";
            string positiveEffectType = "Magic";
            double damage = 1.1 * caster.CurrentMagicPower - target.CurrentRessistanceValue;
            double possitiveEffect = 0.15 * caster.MagicPower;
            double manaRequirment = 0.15 * caster.MaxMana;
            spellCheck.PositiveEffectCheck(caster, caster, manaRequirment, possitiveEffect, positiveEffectType);
            spellCheck.SpellDamageCheck(caster, target, manaRequirment, damage, spellName);
        }

        public void Dive(Unit caster)
        {
            string spellName = "Dive";
            double manaRequirment = 0.3 * caster.MaxMana;
            string buffType = "Armor";
            string possitiveEffectType = "Res";
            double buffEffect = 0.2 * caster.ArmorValue;
            double possitiveEffect = 0.3 * caster.RessistanceValue;
            spellCheck.PositiveEffectCheck(caster, caster, manaRequirment, possitiveEffect, possitiveEffectType);
            spellCheck.BuffCheck(caster, caster, manaRequirment, buffEffect, spellName, buffType);
        }

        public void HyperSpeed(Unit caster)
        {
            string spellName = "Hyper Speed";
            double manaRequirment = 0.3 * caster.MaxMana;
            string buffType = "hRegen";
            string possitiveEffectType = "mRegen";
            int buffEffect = caster.Level;
            int possitiveEffect = caster.ManaRegen - caster.Level;
            spellCheck.PositiveEffectCheck(caster, caster, manaRequirment, possitiveEffect, possitiveEffectType);
            spellCheck.BuffCheck(caster, caster, manaRequirment, buffEffect, spellName, buffType);
        }

        public void Thunder(Unit caster ,Unit target)
        {
            string spellName = "Thunder";
            double manaRequirment = 0.5 * caster.MaxMana;
            string negativeEffectType = "Res";
            double damage = 1.3 * caster.CurrentMagicPower - caster.CurrentRessistanceValue;
            double negativeEffect = 0.4 * target.RessistanceValue;
            spellCheck.NegativeEffectCheck(caster, target, manaRequirment, negativeEffect, negativeEffectType);
            spellCheck.SpellDamageCheck(caster, target, manaRequirment, damage, spellName);
        }

        public void SpellCast(Unit caster, Unit target)
        {
            var rng = new Random();
            int enemyActionNumber = rng.Next(1, 5);

            if (enemyActionNumber == 1)
            {
                this.TidalSlash(caster,target);
            }

            if (enemyActionNumber == 2)
            {
                this.Dive(caster);
            }

            if (enemyActionNumber == 3)
            {
                this.HyperSpeed(caster);
            }

            if (enemyActionNumber == 4)
            {
                this.Thunder(caster,target);
            }
        }
    }
}
