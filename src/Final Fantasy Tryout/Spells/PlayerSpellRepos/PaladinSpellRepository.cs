using Final_Fantasy_Tryout.Units;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Final_Fantasy_Tryout.Spells
{
    public class PaladinSpellRepository : SpellRepos
    {
        private readonly SpellCheck spellCheck;
        private readonly List<Spell> spells;
        public PaladinSpellRepository(Unit caster)
        {
            Spell holyStrike = new Spell("Holy Strike", 0.15 * caster.MaxMana);
            Spell burningLight = new Spell("Burning Light", 0.15 * caster.MaxMana);
            Spell viciousSpellGuard = new Spell("Vicious Spell-Guard", 0.3 * caster.MaxMana);
            Spell divineRune = new Spell("Divine Rune", 0.15 * caster.MaxMana);
            spells = new List<Spell>();
            spellCheck = new SpellCheck();
            spells.Add(holyStrike);
            spells.Add(burningLight);
            spells.Add(viciousSpellGuard);
            spells.Add(divineRune);
        }

        public override List<Spell> Spells => spells;

        public void HolyStrike(Unit caster, Unit target)
        {
            string spellName = "Holy Strike";
            string effectType = "Magic";
            double effect = 0.10 * caster.MagicPower;
            double manaRequirment = 0.15 * caster.MaxMana;
            double damage = 1.1 * caster.CurrentAttackPower - 0.5 * target.CurrentArmorValue;
            spellCheck.PositiveEffectCheck(caster, caster, manaRequirment, effect, effectType);
            spellCheck.PhysicalDamageCheck(caster, target, manaRequirment, damage, spellName);
        }

        public void BurningLight(Unit caster, Unit target)
        {
            string spellName = "Burning Light";
            double manaRequirment = 0.15 * caster.MaxMana;
            double damage = 1.15 * caster.CurrentMagicPower;
            spellCheck.SpellDamageCheck(caster, target, manaRequirment, damage, spellName);
        }

        public void ViciousSpellGuard(Unit caster)
        {
            string spellName = "Vicious SpellGuard";
            string buffType = "Res";
            double effect = 0.5 * caster.RessistanceValue;
            double manaRequirment = 0.3 * caster.MaxMana;
            spellCheck.BuffCheck(caster, caster, manaRequirment, effect, spellName, buffType);
        }

        public void DivineRune(Unit caster)
        {
            string spellName = "Divine Rune";
            string buffType = "Attack";
            double effect = 0.15 * caster.AttackPower;
            double manaRequirment = 0.15 * caster.MaxMana;
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
                    (s => s.Name == "Holy Strike").ManaRequirment)
                    {
                        Console.Write("[Player] ");
                        this.HolyStrike(caster, target);
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
                    (s => s.Name == "Burning Light").ManaRequirment)
                    {
                        Console.Write("[Player] ");
                        this.BurningLight(caster, target);
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
                    (s => s.Name == "Vicious Spell-Guard").ManaRequirment)
                    {
                        Console.Write("[Player] ");
                        this.ViciousSpellGuard(caster);
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
                    (s => s.Name == "Divine Rune").ManaRequirment)
                    {
                        Console.Write("[Player] ");
                        this.DivineRune(caster);
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
