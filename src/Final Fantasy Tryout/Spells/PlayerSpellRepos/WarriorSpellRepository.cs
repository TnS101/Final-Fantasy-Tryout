using Final_Fantasy_Tryout.Units;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Final_Fantasy_Tryout.Spells
{
    public class WarriorSpellRepository : SpellRepos
    {
        private readonly SpellCheck spellCheck;

        public WarriorSpellRepository(Unit caster)
        {
            Spell headSmash = new Spell("Head Smash", 0.5 * caster.MaxMana);
            Spell hyperStrength = new Spell("Hyper Strength", 0.5 * caster.MaxMana);
            Spell ragingBlow = new Spell("Raging Blow", 0.12 * caster.MaxMana);
            Spell disarm = new Spell("Disarm", 0.5 * caster.MaxMana);
            Spells = new List<Spell>();
            spellCheck = new SpellCheck();
            Spells.Add(headSmash);
            Spells.Add(hyperStrength);
            Spells.Add(ragingBlow);
            Spells.Add(disarm);
        }

        public override List<Spell> Spells { get; }

        public void HeadSmash(Unit caster, Unit target)
        {
            string spellName = "Head Smash";
            string effectType = "SelfHP";
            double manaRequirment = 0.5 * caster.MaxMana;
            double effect = 0.08 * caster.MaxHP;
            double damage = caster.CurrentAttackPower * 1.5 - target.CurrentArmorValue;
            if (caster.CurrentHP > effect)
            {
                spellCheck.NegativeEffectCheck(caster, caster, manaRequirment, effect, effectType);
                spellCheck.PhysicalDamageCheck(caster, target, manaRequirment, damage, spellName);
                Console.WriteLine($"{caster.Name} lost HP : {effect:f2} due to the effect of {spellName}!!");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"Cannot use {spellName}!");
                Console.WriteLine();
            }
        }

        public void HyperStrength(Unit caster)
        {
            string spellName = "Hyper Strength";
            string buffType = "Attack";
            double effect = 0.3 * caster.CurrentAttackPower;
            double manaRequirment = 0.5 * caster.MaxMana;
            spellCheck.BuffCheck(caster, caster, manaRequirment, effect, spellName, buffType);
        }

        public void RagingBlow(Unit caster, Unit target)
        {
            string spellName = "Raging Blow";
            string effectType = "mRegen";
            double damage = 1 * caster.AttackPower - 0.8 * target.CurrentArmorValue;
            int effect = caster.Level;
            double manaRequirment = 0.15 * caster.MaxMana;
            spellCheck.PositiveEffectCheck(caster, caster, manaRequirment, effect, effectType);
            spellCheck.PhysicalDamageCheck(caster, target, manaRequirment, damage, spellName);
        }

        public void Disarm(Unit caster, Unit target)
        {
            string spellName = "Disarm";
            string debuffType = "Armor";
            double effect = 0.75 * target.ArmorValue;
            double manaRequirment = 0.5 * caster.MaxMana;
            spellCheck.DeBuffCheck(caster, target, manaRequirment, effect, spellName, debuffType);
        }

        public void SpellCast(Unit caster, Unit target)
        {
            while (true)
            {
                var action = Console.ReadKey().Key;
                if (action == ConsoleKey.NumPad1)

                {
                    if (caster.CurrentMana >= caster.Spells.Spells.FirstOrDefault
                    (s => s.Name == "Head Smash").ManaRequirment)
                    {
                        Console.Write("[Player] ");
                        this.HeadSmash(caster, target);
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
                    (s => s.Name == "Hyper Strength").ManaRequirment)
                    {
                        Console.Write("[Player] ");
                        this.HyperStrength(caster);
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
                    (s => s.Name == "Raging Blow").ManaRequirment)
                    {
                        Console.Write("[Player] ");
                        this.RagingBlow(caster, target);
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
                    (s => s.Name == "Disarm").ManaRequirment)
                    {
                        Console.Write("[Player] ");
                        this.Disarm(caster, target);
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
