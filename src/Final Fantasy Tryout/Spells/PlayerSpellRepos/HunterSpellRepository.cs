using Final_Fantasy_Tryout.Units;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Final_Fantasy_Tryout.Spells
{
   public class HunterSpellRepository : SpellRepos
   {
        private readonly SpellCheck spellCheck;
        private readonly List<Spell> spells;
        public HunterSpellRepository(Unit caster)
        {
            Spell hastingArrow = new Spell("Hasting Arrow",caster.MaxMana*0.2);
            Spell grassHop = new Spell("Grass Hop", caster.MaxMana * 0.5);
            Spell volleyShot = new Spell("Volley Shot", caster.MaxMana * 0.3);
            Spell sharpEye = new Spell("Sharp Eye", caster.MaxMana * 0.5);
            spells = new List<Spell>();
            spellCheck = new SpellCheck();
            spells.Add(hastingArrow);
            spells.Add(grassHop);
            spells.Add(volleyShot);
            spells.Add(sharpEye);
        }

        public override List<Spell> Spells => spells;

        public void HastingArrow(Unit caster,Unit target)
        {
            string spellName = "Hasting Arrow";
            string effectType = "Crit";
            int effect = 5;
            double damage = caster.CurrentAttackPower * 1.2 ;
            double manaRequirment = caster.MaxMana * 0.2;
            spellCheck.PositiveEffectCheck(caster,caster,manaRequirment,effect,effectType);
            spellCheck.PhysicalDamageCheck(caster,target,manaRequirment,damage,spellName);
        }

        public void GrassHop(Unit caster)
        {
            string spellName = "Grass Hop";
            string buffType = "Armor";
            double effect = 0.70 * caster.ArmorValue;
            double manaRequirment = 0.5 * caster.MaxMana;
            spellCheck.BuffCheck(caster,caster,manaRequirment,effect,spellName,buffType);
        }

        public void VolleyShot(Unit caster,Unit target)
        {
            string spellName = "Volley Shot";
            double damage = 1.4 * caster.CurrentAttackPower;
            double manaRequirment = 0.3 * caster.MaxMana;
            spellCheck.PhysicalDamageCheck(caster,target,manaRequirment,damage,spellName);
        }

        public void SharpEye(Unit caster)
        {
            string spellName = "Sharp Eye";
            string buffType = "Attack";
            double effect = 0.3 * caster.AttackPower;
            double manaRequirment = 0.5 * caster.MaxMana;
            spellCheck.BuffCheck(caster,caster,manaRequirment,effect,spellName,buffType);
        }

        public void SpellCast(Unit caster, Unit target)
        {
            while (true)
            {
                var action = Console.ReadKey().Key;
                if (action == ConsoleKey.NumPad1 )
                {
                    if (caster.CurrentMana >= caster.Spells.Spells.FirstOrDefault
                    (s => s.Name == "Hasting Arrow").ManaRequirment)
                    {
                        Console.Write("[Player] ");
                        this.HastingArrow(caster, target);
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
                    (s => s.Name == "Grass Hop").ManaRequirment)
                    {
                        Console.Write("[Player] ");
                        this.GrassHop(caster);
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
                    (s => s.Name == "Volley Shot").ManaRequirment)
                    {
                        Console.Write("[Player] ");
                        this.VolleyShot(caster, target);
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
                    (s => s.Name == "Sharp Eye").ManaRequirment)
                    {
                        Console.Write("[Player] ");
                        this.SharpEye(caster);
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
