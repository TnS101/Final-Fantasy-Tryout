using Final_Fantasy_Tryout.Units;
using System;
using System.Collections.Generic;

namespace Final_Fantasy_Tryout.Spells.EnemySpellRepos
{
    public class DemonSpellRepository : SpellRepos

    {
        private readonly SpellCheck spellCheck;
        private readonly List<Spell> spells;
        public DemonSpellRepository(Unit caster)
        {
            Spell corruption = new Spell("Corruption", 0.3 * caster.MaxMana);
            Spell shadowBlast = new Spell("Shadow Blast", 0.3 * caster.MaxMana);
            Spell eyeOfTheVoid = new Spell("Eye Of The Void", 0.2 * caster.MaxMana);
            Spell rippingHellFire = new Spell("Ripping Hell-Fire", 0.8 * caster.MaxMana);
            spells = new List<Spell>();
            spellCheck = new SpellCheck();
            spells.Add(corruption);
            spells.Add(shadowBlast);
            spells.Add(eyeOfTheVoid);
            spells.Add(rippingHellFire);
        }

        public override List<Spell> Spells => spells;

        public void Corruption(Unit caster,Unit target)
        {
            string spellName = "Corruption";
            string debuffType = "hRegen";
            int effect = caster.Level;
            double manaRequirment = 0.3 * caster.MaxMana;
            spellCheck.DeBuffCheck(caster, target, manaRequirment, effect, spellName, debuffType);
        }

        public void ShadowBlast(Unit caster, Unit target)
        {
            string spellName = "Shadow Blast";
            double damage = 1.2 * caster.CurrentMagicPower - target.CurrentRessistanceValue;
            double manaRequirment = 0.3 * caster.MaxMana;
            spellCheck.SpellDamageCheck(caster, target, manaRequirment, damage, spellName);
        }

        public void EyeOfTheVoid(Unit caster, Unit target)
        {
            string spellName = "Eye Of The Void";
            string debuffType = "Res";
            double effect = 0.4 * target.RessistanceValue;
            double manaRequirment = 0.2 * caster.MaxMana;
            spellCheck.DeBuffCheck(caster, target, manaRequirment, effect, spellName, debuffType);
        }

        public void RippingHellFire(Unit caster, Unit target)
        {
            string spellName = "Ripping Hell-Fire";
            double damage = 1.5 * caster.CurrentMagicPower - target.RessistanceValue;
            double manaRequirment = 0.8 * caster.MaxMana;
            spellCheck.SpellDamageCheck(caster, target, manaRequirment, damage, spellName);
        }

        public void SpellCast(Unit caster, Unit target)
        {
            var rng = new Random();
            int enemyActionNumber = rng.Next(1, 5);

            if (enemyActionNumber == 1)
            {
                this.Corruption(caster,target);
            }

            if (enemyActionNumber == 2)
            {
                this.ShadowBlast(caster, target);
            }

            if (enemyActionNumber == 3)
            {
               this.EyeOfTheVoid(caster,target);
            }

            if (enemyActionNumber == 4)
            {
                this.RippingHellFire(caster,target);
            }
        }
    }
}
