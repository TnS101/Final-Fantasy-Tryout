using Final_Fantasy_Tryout.Units;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Final_Fantasy_Tryout.Spells.PlayerSpellRepos
{
    public class ShamanSpellRepository : SpellRepos
    {
        private readonly SpellCheck spellCheck;
        private readonly List<Spell> spells;

        public ShamanSpellRepository(Unit caster)
        {
            Spell thunderStrike = new Spell("Thunder Strike", 0.5 * caster.MaxMana);
            Spell earthStrike = new Spell("Earth Strike", 0.5 * caster.MaxMana);
            Spell flameStrike = new Spell("Flame Strike", 0.25 * caster.MaxMana);
            Spell waterStrike = new Spell("Water Strike", 0.25 * caster.MaxMana);
            spells = new List<Spell>();
            spellCheck = new SpellCheck();
            spells.Add(thunderStrike);
            spells.Add(earthStrike);
            spells.Add(flameStrike);
            spells.Add(waterStrike);
        }

        public override List<Spell> Spells => spells;

        public void ThunderStrike(Unit caster, Unit target)
        {
            string spellName = "Thunder Strike";
            string negativeEffectType = "Res";
            double damage = 1.2 * caster.CurrentMagicPower + 0.25 * caster.CurrentAttackPower - target.CurrentRessistanceValue;
            double negativeEffect = 0.5 * target.RessistanceValue;
            double manaRequirment = 0.5 * caster.MaxMana;
            spellCheck.NegativeEffectCheck(caster, target, manaRequirment, negativeEffect, negativeEffectType);
            spellCheck.SpellDamageCheck(caster, target, manaRequirment, damage, spellName);
        }

        public void EarthStrike(Unit caster, Unit target)
        {
            string spellName = "Earth Strike";
            string possitiveEffectType = "Health";
            double manaRequirment = 0.5 * caster.MaxMana;
            double damage = 1.2 * caster.CurrentAttackPower + 0.20 * caster.CurrentMagicPower - target.CurrentArmorValue;
            double possitiveEffect = 0.5 * caster.CurrentAttackPower;
            spellCheck.PositiveEffectCheck(caster, caster, manaRequirment, possitiveEffect, possitiveEffectType);
            spellCheck.PhysicalDamageCheck(caster, target, manaRequirment, damage, spellName);
        }

        public void FlameStrike(Unit caster, Unit target)
        {
            string spellName = "Flame Strike";
            string possitiveEffectType = "Attack";
            double manaRequirment = 0.25 * caster.MaxMana;
            double damage = 1.2 * caster.CurrentAttackPower - target.CurrentArmorValue;
            double possitiveEffect = 0.15 * caster.AttackPower;
            spellCheck.PositiveEffectCheck(caster, caster, manaRequirment, possitiveEffect, possitiveEffectType);
            spellCheck.PhysicalDamageCheck(caster, target, manaRequirment, damage, spellName);
        }

        public void WaterStrike(Unit caster, Unit target)
        {
            string spellName = "Water Strike";
            string possitiveEffectType = "mRegen";
            double manaRequirment = 0.25 * caster.MaxMana;
            double damage = 1.1 * caster.CurrentMagicPower - target.CurrentRessistanceValue;
            int possitiveEffect = 5 + caster.Level;
            spellCheck.PositiveEffectCheck(caster, caster, manaRequirment, possitiveEffect, possitiveEffectType);
            spellCheck.SpellDamageCheck(caster, target, manaRequirment, damage, spellName);
        }


        public void SpellCast(Unit caster, Unit target)
        {
            double minManaRequirment = caster.Spells.Spells.Min(s=>s.ManaRequirment);
            while (true)
            {
                var action = Console.ReadKey().Key;
                if (action == ConsoleKey.NumPad1)
                {
                    if (caster.CurrentMana >= caster.Spells.Spells.FirstOrDefault
                    (s => s.Name == "Thunder Strike").ManaRequirment)
                    {
                        Console.Write("[Player] ");
                        this.ThunderStrike(caster, target);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Not enough Mana!");
                        break;
                    }
                    
                }
                else if (action == ConsoleKey.NumPad2 )
                {
                    if (caster.CurrentMana >= caster.Spells.Spells.FirstOrDefault
                    (s => s.Name == "Earth Strike").ManaRequirment)
                    {
                        Console.Write("[Player] ");
                        this.EarthStrike(caster, target);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Not enough Mana!");
                        break;
                    }
                    
                }
                else if (action == ConsoleKey.NumPad3 )
                {
                    if (caster.CurrentMana >= caster.Spells.Spells.FirstOrDefault
                    (s => s.Name == "Flame Strike").ManaRequirment)
                    {
                        Console.Write("[Player] ");
                        this.FlameStrike(caster, target);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Not enough Mana!");
                        break;
                    }
                    
                }
                else if (action == ConsoleKey.NumPad4 )
                {
                    if (caster.CurrentMana >= caster.Spells.Spells.FirstOrDefault
                    (s => s.Name == "Water Strike").ManaRequirment)
                    {
                        Console.Write("[Player] ");
                        this.WaterStrike(caster, target);
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
