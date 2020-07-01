using Final_Fantasy_Tryout.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Final_Fantasy_Tryout.Spells
{
   public class NaturalistSpellRepository : SpellRepos
   {
        private readonly SpellCheck spellCheck;
        private readonly List<Spell> spells;

        public NaturalistSpellRepository(Unit caster)
        {
            Spell naturesTouch = new Spell("Nature's Touch", 0.5 * caster.MaxMana);
            Spell thornBlast = new Spell("Thorn Blast", 0.35 * caster.MaxMana);
            Spell naturesGift = new Spell("Nature's Gift",0);
            Spell pouringRain = new Spell("Pouring Raind",0);
            spells = new List<Spell>();
            spellCheck = new SpellCheck();
            spells.Add(naturesTouch);
            spells.Add(thornBlast);
            spells.Add(naturesGift);
            spells.Add(pouringRain);
        }

        public override List<Spell> Spells => spells;

        public void NaturesTouch(Unit caster, Unit target)
        {
            string spellName = "Nature's Touch";
            string effectType = "Armor";
            double armorIncrease = target.ArmorValue * 0.2;
            double manaRequirment = 0.5 * caster.MaxMana;
            double effect = caster.CurrentMagicPower * 0.5 + caster.CurrentManaRegen;
            spellCheck.PositiveEffectCheck(caster, caster, manaRequirment, armorIncrease, effectType);
            spellCheck.HealCheck(caster, target, manaRequirment, effect, spellName);
        }

        public void ThornBlast(Unit caster, Unit target)
        {
            string spellName = "Thorn Blast";
            string effectType = "Armor";
            double manaRequirment = 0.35 * caster.MaxMana;
            double effect = target.ArmorValue * 0.3;
            double damage = target.MaxHP * 0.05 + caster.CurrentMagicPower * 0.8 - target.CurrentRessistanceValue;
            spellCheck.NegativeEffectCheck(caster, target, manaRequirment, effect, effectType);
            spellCheck.SpellDamageCheck(caster, target, manaRequirment, damage, spellName);
        }

        public void NaturesGift(Unit caster)
        {
            string spellName = "Nature's Gift";
            string buffEffectType = "hRegen";
            string possitiveEffectType = "Magic";
            string negativeEffectType = "Damage";
            double manaRequirment = 0;
            int buffEffect = caster.HealthRegen;
            double possitiveEffect = 0.1 * caster.MagicPower;
            double negativeEffect = 0.05 * caster.MaxHP;
            spellCheck.NegativeEffectCheck(caster,caster,manaRequirment,negativeEffect,negativeEffectType);
            spellCheck.PositiveEffectCheck(caster, caster, manaRequirment, possitiveEffect, possitiveEffectType);
            spellCheck.BuffCheck(caster, caster, manaRequirment, buffEffect,spellName ,buffEffectType);
        }

        public void PouringRain(Unit caster)
        {
            string spellname = "Pouring Rain";
            string buffType = "Mana";
            string negativeEffectType = "mRegen";
            double manaRequirment = 0;
            double possitiveEffect = 0.3 * caster.MaxMana;
            int negativeEffect = caster.Level;
            spellCheck.NegativeEffectCheck(caster, caster, manaRequirment, negativeEffect, negativeEffectType);
            spellCheck.BuffCheck(caster, caster, manaRequirment, possitiveEffect, spellname, buffType);
        }

        public void SpellCast(Unit caster, Unit target)
        {
            while (true)
            {
                var action = Console.ReadKey().Key;
                if (action == ConsoleKey.NumPad1 )
                {
                    if (caster.CurrentMana >= caster.Spells.Spells.FirstOrDefault
                    (s => s.Name == "Nature's Touch").ManaRequirment)
                    {
                        Console.Write("[Player] ");
                        this.NaturesTouch(caster, target);
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
                    (s => s.Name == "Thorn Blast").ManaRequirment)
                    {
                        Console.Write("[Player] ");
                        this.ThornBlast(caster, target);
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
                    (s => s.Name == "Nature's Gift").ManaRequirment)
                    {
                        Console.Write("[Player] ");
                        this.NaturesGift(caster);
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
                    (s => s.Name == "Pouring Rain").ManaRequirment)
                    {
                        Console.Write("[Player] ");
                        this.PouringRain(caster);
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
