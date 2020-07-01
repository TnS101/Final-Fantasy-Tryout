using Final_Fantasy_Tryout.Units;
using System;
using System.Collections.Generic;

namespace Final_Fantasy_Tryout.Spells.EnemySpellRepos
{
    public class ReptileSpellRepository : SpellRepos
    {
        private readonly SpellCheck spellCheck;
        private readonly List<Spell> spells;
        public ReptileSpellRepository(Unit caster)
        {
            Spell poisonSpit = new Spell("Poison Spit", 0.3 * caster.MaxMana);
            Spell reflectingScales = new Spell("Reflelcting Scales", 0.3 * caster.MaxMana);
            Spell skinChange = new Spell("Skin Change", 0.4 * caster.MaxMana);
            Spell scratch = new Spell("Scratch",0.15 * caster.MaxMana);
            spells = new List<Spell>();
            spellCheck = new SpellCheck();
            spells.Add(poisonSpit);
            spells.Add(reflectingScales);
            spells.Add(skinChange);
            spells.Add(scratch);
        }

        public override List<Spell> Spells => spells;

        public void PoisonSpit(Unit caster,Unit target)
        {
            string spellName = "Poison Spit";
            double damage = 1.2 * caster.CurrentMagicPower - target.CurrentRessistanceValue;
            double manaRequirment = 0.3 * caster.MaxMana;
            spellCheck.SpellDamageCheck(caster, target, manaRequirment, damage, spellName);
        }

        public void ReflectingScales(Unit caster, Unit target)
        {
            string spellName = "Reflecting Scales";
            string effectType = "Armor";
            double damage = 0.5 * target.CurrentAttackPower;
            double manaRequirment = 0.3 * caster.MaxMana;
            double effect = 0.2 * caster.ArmorValue;
            spellCheck.PositiveEffectCheck(caster, caster, manaRequirment, effect, effectType);
            spellCheck.PhysicalDamageCheck(caster, target, manaRequirment, damage, spellName);
        }

        public void SkinChange(Unit caster)
        {
            string spellName = "Skin Change";
            string buffType = "Res";
            string negativeEffectType = "Armor";
            double buffEffect = 0.5 * caster.RessistanceValue;
            double negativeEffect = 0.25 * caster.ArmorValue;
            double manaRequirment = 0.4 * caster.MaxMana;
            spellCheck.NegativeEffectCheck(caster, caster, manaRequirment, negativeEffect, negativeEffectType);
            spellCheck.BuffCheck(caster, caster, manaRequirment, buffEffect, spellName, buffType);
        }

        public void Scratch(Unit caster, Unit target)
        {
            string spellName = "Scratch";
            double damage = 1.3 * caster.CurrentAttackPower - target.CurrentArmorValue;
            double manaRequirment = 0.15 * caster.MaxMana;
            spellCheck.PhysicalDamageCheck(caster, target, manaRequirment, damage, spellName);
        }

        public void SpellCast(Unit caster, Unit target)
        {
            var rng = new Random();
            int enemyActionNumber = rng.Next(1, 5);

            if (enemyActionNumber == 1)
            {
                this.PoisonSpit(caster,target);
            }

            if (enemyActionNumber == 2)
            {
                this.ReflectingScales(caster, target);
            }

            if (enemyActionNumber == 3)
            {
                this.SkinChange(caster);
            }

            if (enemyActionNumber == 4)
            {
                this.Scratch(caster,target);
            }
        }
    }
}
