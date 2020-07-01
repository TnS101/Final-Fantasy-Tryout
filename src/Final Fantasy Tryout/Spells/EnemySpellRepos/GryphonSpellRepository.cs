using Final_Fantasy_Tryout.Units;
using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Fantasy_Tryout.Spells.EnemySpellRepos
{
   public class GryphonSpellRepository : SpellRepos
    {
        private readonly SpellCheck spellCheck;
        private readonly List<Spell> spells;
        public GryphonSpellRepository(Unit caster)
        {
            Spell divingClaw = new Spell("Diving Claw", 0.3 * caster.MaxMana);
            Spell petrifyingGaze = new Spell("Petryfying Gaze", 0.5 * caster.MaxMana);
            Spell gust = new Spell("Gust", 0.3 * caster.MaxMana);
            Spell peck = new Spell("Peck", 0.2 * caster.MaxMana);
            spells = new List<Spell>();
            spellCheck = new SpellCheck();
            spells.Add(divingClaw);
            spells.Add(petrifyingGaze);
            spells.Add(gust);
            spells.Add(peck);
        }

        public override List<Spell> Spells => spells;

        public void DivingClaw(Unit caster,Unit target)
        {
            string spellName = "Diving Claw";
            double damage = 1.2 * caster.CurrentArmorValue - 0.5 * target.CurrentArmorValue;
            double manaRequirment = 0.3* caster.MaxMana;
            spellCheck.PhysicalDamageCheck(caster,target,manaRequirment,damage,spellName);
        }

        public void PetrifyingGaze(Unit caster,Unit target)
        {
            string spellName = "Petryfying Gaze";
            string debuffType = "hRegen";
            int effect = target.CurrentHealthRegen;
            double manaRequirment = 0.5 * caster.MaxMana;
            spellCheck.DeBuffCheck(caster, target, manaRequirment, effect, spellName, debuffType);
        }

        public void Gust(Unit caster, Unit target)
        {
            string spellName = "Gust";
            string debuffType = "Attack";
            double effect = 0.2 * target.AttackPower;
            double manaRequirment = 0.3 * caster.MaxMana;
            spellCheck.DeBuffCheck(caster, target, manaRequirment, effect, spellName, debuffType);
        }

        public void Peck(Unit caster , Unit target)
        {
            string spellName = "Peck";
            double damage = 1.2 * caster.CurrentAttackPower - target.CurrentArmorValue;
            double manaRequirment = 0.2 * caster.MaxMana;
            spellCheck.PhysicalDamageCheck(caster, target, manaRequirment, damage, spellName);
        }

        public void SpellCast(Unit caster, Unit target)
        {
            var rng = new Random();
            int enemyActionNumber = rng.Next(1, 5);

            if (enemyActionNumber == 1)
            {
                this.DivingClaw(caster,target);
            }

            if (enemyActionNumber == 2)
            {
                this.PetrifyingGaze(caster, target);
            }

            if (enemyActionNumber == 3)
            {
                this.Gust(caster,target);
            }

            if (enemyActionNumber == 4)
            {
                this.Peck(caster,target);
            }
        }
    }
}
