using Final_Fantasy_Tryout.Units;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Final_Fantasy_Tryout.Spells
{
    public class PriestSpellRepository : SpellRepos
    {
        private readonly SpellCheck spellCheck;
        private readonly List<Spell> spells;
        public PriestSpellRepository(Unit caster)
        {
            Spell holyLight = new Spell("Holy Light", 0.3 * caster.MaxMana);
            Spell manaDrain = new Spell("Mana Drain", 0.1 * caster.MaxMana);
            Spell staffSmash = new Spell("Staff Smash", 0.12 * caster.MaxMana);
            Spell blessing = new Spell("Blessing", 0.5 * caster.MaxMana);
            spells = new List<Spell>();
            spellCheck = new SpellCheck();
            spells.Add(holyLight);
            spells.Add(manaDrain);
            spells.Add(staffSmash);
            spells.Add(blessing);
        }

        public override List<Spell> Spells => spells;

        public void HolyLight(Unit caster)
        {
            string spellName = "Holy Light";
            double manaRequirment = 0.3 * caster.MaxMana;
            double effect = 0.1 * caster.MaxHP + caster.CurrentMagicPower;
            spellCheck.HealCheck(caster, caster, manaRequirment, effect, spellName);
        }

        public void ManaDrain(Unit caster, Unit target)
        {
            string spellName = "Mana Drain";
            string buffType = "Mana";
            string negativeEffectType = "Mana";
            double buffEffect = 0.25 * target.MaxMana;
            double negativeEffect = 0.25 * target.MaxMana;
            double manaRequirment = 0.10 * caster.MaxHP;
            spellCheck.NegativeEffectCheck(caster, target, manaRequirment, negativeEffect, negativeEffectType);
            spellCheck.BuffCheck(caster, caster, manaRequirment, buffEffect, spellName, buffType);
        }

        public void StaffSmash(Unit caster, Unit target)
        {
            string spellName = "Staff Smash";
            string negativeEffectType = "Armor";
            double manaRequirment = 0.12 * caster.MaxMana;
            double damage = 1.3 * caster.CurrentAttackPower - target.CurrentArmorValue;
            double negativeEffect = 0.2 * target.ArmorValue;
            spellCheck.NegativeEffectCheck(caster, target, manaRequirment, negativeEffect, negativeEffectType);
            spellCheck.PhysicalDamageCheck(caster, target, manaRequirment, damage, spellName);
        }

        public void Blessing(Unit caster)
        {
            string spellName = "Blessing";
            string buffType = "Magic";
            string effectType = "hRegen";
            double buffEffect = 0.25 * caster.MagicPower;
            double effect = caster.Level + 1;
            double manaRequirment = 0.5 * caster.MaxMana;
            spellCheck.PositiveEffectCheck(caster, caster, manaRequirment, effect, effectType);
            spellCheck.BuffCheck(caster, caster, manaRequirment, effect, spellName, buffType);
        }

        public void SpellCast(Unit caster, Unit target)
        {
            while (true)
            {
                var action = Console.ReadKey().Key;
                if (action == ConsoleKey.NumPad1)
                {
                    if (caster.CurrentMana >= caster.Spells.Spells.FirstOrDefault
                    (s => s.Name == "Holy Light").ManaRequirment)
                    {
                        Console.Write("[Player] ");
                        this.HolyLight(caster);
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
                    (s => s.Name == "Mana Drain").ManaRequirment)
                    {
                        Console.Write("[Player] ");
                        this.ManaDrain(caster, target);
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
                    (s => s.Name == "Staff Smash").ManaRequirment)
                    {
                        Console.Write("[Player] ");
                        this.StaffSmash(caster, target);
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
                    (s => s.Name == "Blessing").ManaRequirment)
                    {
                        Console.Write("[Player] ");
                        this.Blessing(caster);
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
