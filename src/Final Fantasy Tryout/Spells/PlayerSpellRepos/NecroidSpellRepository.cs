using Final_Fantasy_Tryout.Units;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Final_Fantasy_Tryout.Spells
{
    public class NecroidSpellRepository : SpellRepos
    {
        private readonly SpellCheck spellCheck;
        private readonly List<Spell> spells;
        public NecroidSpellRepository(Unit caster)
        {
            Spell shadowTouch = new Spell("Shadow Touch", 0.25 * caster.MaxMana);
            Spell lifeDrain = new Spell("Life Drain", 0.35 * caster.MaxMana);
            Spell blind = new Spell("Blind", 0.15 * caster.MaxMana);
            Spell mutualDarkness = new Spell("Mutual Darkness", 0);
            spells = new List<Spell>();
            spellCheck = new SpellCheck();
            spells.Add(shadowTouch);
            spells.Add(lifeDrain);
            spells.Add(blind);
            spells.Add(mutualDarkness);
        }

        public override List<Spell> Spells => spells;

        public void ShadowTouch(Unit caster, Unit target)
        {
            string spellName = "Shadow Touch";
            string effectType = "Res";
            double manaRequirment = 0.25 * caster.MaxMana;
            double effect = 3;
            double damage = target.MaxHP * 0.08 + caster.CurrentMana * 0.10 - target.CurrentRessistanceValue;
            spellCheck.NegativeEffectCheck(caster, target, manaRequirment, effect, effectType);
            spellCheck.SpellDamageCheck(caster, target, manaRequirment, damage, spellName);
        }

        public void LifeDrain(Unit caster, Unit target)
        {
            string spellName = "Life Drain";
            string effectType = "SelfHP";
            double manaRequirment = 0.35 * caster.MaxMana;
            double effect = target.MaxHP * 0.5 + caster.CurrentMagicPower * 0.5;
            double damage = effect - target.CurrentRessistanceValue;
            spellCheck.NegativeEffectCheck(caster, target, manaRequirment, damage, effectType);
            spellCheck.HealCheck(caster, target, manaRequirment, effect, spellName);
        }

        public void Blind(Unit caster, Unit target)
        {
            string spellName = "Blind";
            string debuffType = "Attack";
            double manaRequirment = 0.15 * caster.MaxMana;
            double negativeEffect = 0.2 * target.CurrentAttackPower;
            spellCheck.DeBuffCheck(caster, target, manaRequirment, negativeEffect, spellName, debuffType);
        }

        public void MutualDarkness(Unit caster, Unit target)
        {
            string spellName = "Mutual Darkness";
            string negativeEffectType = "Damage";
            double manaRequirment = 0;
            double negativeEffect = 0.08 * caster.MaxHP;
            double damage = 0.15 * caster.MaxHP - target.CurrentRessistanceValue;
            spellCheck.NegativeEffectCheck(caster, caster, manaRequirment, negativeEffect, negativeEffectType);
            spellCheck.SpellDamageCheck(caster, target, manaRequirment, damage, spellName);
        }

        public void SpellCast(Unit caster, Unit target)
        {
            while (true)
            {
                var action = Console.ReadKey().Key;
                if (action == ConsoleKey.NumPad1)
                {
                    if (caster.CurrentMana >= caster.Spells.Spells.FirstOrDefault
                    (s => s.Name == "Shadow Touch").ManaRequirment)
                    {
                        Console.Write("[Player] ");
                        this.ShadowTouch(caster, target);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Not enough Mana!");
                        break;
                    }

                }
                else if (action == ConsoleKey.NumPad2)
                {
                    if (caster.CurrentMana >= caster.Spells.Spells.FirstOrDefault
                    (s => s.Name == "Life Drain").ManaRequirment)
                    {
                        Console.Write("[Player] ");
                        this.LifeDrain(caster, target);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Not enough Mana!");
                        break;
                    }

                }
                else if (action == ConsoleKey.NumPad3)
                {
                    if (caster.CurrentMana >= caster.Spells.Spells.FirstOrDefault
                    (s => s.Name == "Blind").ManaRequirment)
                    {
                        Console.Write("[Player] ");
                        this.Blind(caster, target);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Not enough Mana!");
                        break;
                    }

                }
                else if (action == ConsoleKey.NumPad4)
                {
                    if (caster.CurrentMana >= caster.Spells.Spells.FirstOrDefault
                    (s => s.Name == "Mutual Darkness").ManaRequirment)
                    {
                        Console.Write("[Player] ");
                        this.MutualDarkness(caster, target);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Not enough Mana!");
                        break;
                    }

                }
                else
                {
                    Console.WriteLine("Invalid Action!Try again!");
                    continue;
                }
            }
        }
    }
}
