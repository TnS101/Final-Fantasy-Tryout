using Final_Fantasy_Tryout.Units;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Final_Fantasy_Tryout.Spells
{
    public class RogueSpellRepository : SpellRepos
    {
        private readonly SpellCheck spellCheck;
        private readonly List<Spell> spells;
        public RogueSpellRepository(Unit caster)
        {
            Spell stab = new Spell("Stab", 0.12 * caster.MaxMana);
            Spell poisonDagger = new Spell("Poison Dagger", 0.3 * caster.MaxMana);
            Spell evasion = new Spell("Evasion", 0.5 * caster.MaxMana);
            Spell thievery = new Spell("Thievery", 0.5 * caster.MaxMana);
            spells = new List<Spell>();
            spellCheck = new SpellCheck();
            spells.Add(stab);
            spells.Add(poisonDagger);
            spells.Add(evasion);
            spells.Add(thievery);
        }

        public override List<Spell> Spells => spells;

        public void Stab(Unit caster, Unit target)
        {
            string spellName = "Stab";
            string posssitiveEffectType = "Attack";
            double effect = 0.1 * caster.AttackPower;
            double damage = 1.1 * caster.CurrentAttackPower - target.CurrentArmorValue;
            double manaRequirment = 0.12 * caster.MaxMana;
            spellCheck.PositiveEffectCheck(caster, target, manaRequirment, effect, posssitiveEffectType);
            spellCheck.PhysicalDamageCheck(caster, target, manaRequirment, damage, spellName);
        }

        public void PoisonDagger(Unit caster, Unit target)
        {
            string spellName = "Poison Dagger";
            double damage = (0.2 * caster.CurrentAttackPower + 1.2 * caster.CurrentMagicPower);
            double manaRequirment = 0.3 * caster.MaxMana;
            spellCheck.SpellDamageCheck(caster, target, manaRequirment, damage, spellName);
        }

        public void Evasion(Unit caster)
        {
            string spellName = "Evasion";
            string buffType = "Armor";
            string effectType = "mRegen";
            double manaRequirment = 0.5 * caster.MaxHP;
            double buffEffect = 0.5 * caster.ArmorValue;
            double effect = caster.Level;
            spellCheck.PositiveEffectCheck(caster, caster, manaRequirment, effect, effectType);
            spellCheck.BuffCheck(caster, caster, manaRequirment, buffEffect, spellName, buffType);
        }

        public void Thievery(Unit caster)
        {
            string spellName = "Thievery";
            string buffType = "Gold";
            double effect = 10 + caster.Level * 2;
            double manaRequirment = 0.5 * caster.MaxMana;
            spellCheck.BuffCheck(caster, caster, manaRequirment, effect, spellName, buffType);
        }

        public void SpellCast(Unit caster, Unit target)
        {
            while (true)
            {
                var action = Console.ReadKey().Key;
                if (action == ConsoleKey.NumPad1 )
                {
                    if (caster.CurrentMana >= caster.Spells.Spells.FirstOrDefault
                    (s => s.Name == "Stab").ManaRequirment)
                    {
                        Console.Write("[Player] ");
                        this.Stab(caster, target);
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
                    (s => s.Name == "Poison Dagger").ManaRequirment)
                    {
                        Console.Write("[Player] ");
                        this.PoisonDagger(caster, target);
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
                    (s => s.Name == "Evasion").ManaRequirment)
                    {
                        Console.Write("[Player] ");
                        this.Evasion(caster);
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
                    (s => s.Name == "Thievery").ManaRequirment)
                    {
                        Console.Write("[Player] ");
                        this.Thievery(caster);
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
