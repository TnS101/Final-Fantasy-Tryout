using Final_Fantasy_Tryout.Units;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Final_Fantasy_Tryout.Spells
{
    public class MageSpellRepository : SpellRepos
    {
        private readonly SpellCheck spellCheck;
        private readonly List<Spell> spells;
        public MageSpellRepository(Unit caster)
        {
            Spell waterBall = new Spell("Water Ball", 0.30 * caster.MaxMana);
            Spell fireBall = new Spell("Fire Ball", 0.25 * caster.MaxMana);
            Spell manaConversion = new Spell("Mana Conversion", 0);
            Spell allOutBlast = new Spell("All-Out Blast!", caster.MaxMana);
            spells = new List<Spell>();
            spellCheck = new SpellCheck();
            spells.Add(waterBall);
            spells.Add(fireBall);
            spells.Add(manaConversion);
            spells.Add(allOutBlast);
        }

        public override List<Spell> Spells => spells;

        public void WaterBall(Unit caster, Unit target)
        {
            string spellName = "Water Ball";
            string effectType = "mRegen";
            double manaRequirment = 0.30 * caster.MaxMana;
            int effect = (int)caster.MaxMana / 10;
            double damage = caster.CurrentMagicPower * 0.7 - target.CurrentRessistanceValue;
            spellCheck.PositiveEffectCheck(caster, caster, manaRequirment, effect, effectType);
            spellCheck.SpellDamageCheck(caster, target, manaRequirment, damage, spellName);
        }

        public void FireBall(Unit caster, Unit target)
        {
            string spellName = "Fire Ball";
            string effectType = "hRegen";
            double manaRequirment = 0.25 * caster.MaxMana;
            int effect = 1;
            double damage = target.MaxHP * 0.05 + caster.CurrentMagicPower * 0.7 - target.CurrentRessistanceValue * 0.8;
            spellCheck.NegativeEffectCheck(caster, target, manaRequirment, effect, effectType);
            spellCheck.SpellDamageCheck(caster, target, manaRequirment, damage, spellName);
        }

        public void ManaConversion(Unit caster)
        {
            string spellName = "Mana Conversion";
            string buffType = "Mana";
            string negativeEffectType = "Armor";
            double manaRequirment = 0;
            double effect = 0.25 * caster.MaxMana;
            double negativeEffect = 0.25 * caster.ArmorValue;
            spellCheck.NegativeEffectCheck(caster, caster, manaRequirment, negativeEffect, negativeEffectType);
            spellCheck.BuffCheck(caster, caster, manaRequirment, effect, spellName, buffType);
        }

        public void AllOutBlast(Unit caster, Unit target)
        {
            string spellName = "All-Out Blast!";
            double damage = caster.CurrentMagicPower * 2 - target.CurrentRessistanceValue * 0.8;
            double manaRequirment = caster.MaxMana;
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
                    (s => s.Name == "Water Ball").ManaRequirment)
                    {
                        Console.Write("[Player] ");
                        this.WaterBall(caster, target);
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
                    (s => s.Name == "Fire Ball").ManaRequirment)
                    {
                        Console.Write("[Player] ");
                        this.FireBall(caster, target);
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
                    (s => s.Name == "Mana Conversion").ManaRequirment)
                    {
                        Console.Write("[Player] ");
                        this.ManaConversion(caster);
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
                    (s => s.Name == "All-Out Blast!").ManaRequirment)
                    {
                        Console.Write("[Player] ");
                        this.AllOutBlast(caster, target);
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
