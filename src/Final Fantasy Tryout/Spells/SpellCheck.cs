using Final_Fantasy_Tryout.Units;
using System;
using System.Collections.Generic;

namespace Final_Fantasy_Tryout.Spells
{
    public class SpellCheck
    {
        public SpellCheck()
        {
        }

        //Spell checks
        public void HealCheck(Unit caster, Unit target, double manaRequirment, double healEffect, string spellName)
        {
            if (this.SpellManaCheck(caster, manaRequirment) == true)
            {
                this.SuccessfulCastMessage(caster, target, spellName);
                if (target.CurrentHP <= target.MaxHP - healEffect)
                {
                    target.CurrentHP += healEffect;
                    Console.WriteLine($"{target.Name} healed for {healEffect:f2}! {target.Name}'s HP : {target.CurrentHP:f2}");
                    Console.WriteLine();
                }
                else
                {
                    double overHeal = target.CurrentHP + healEffect - target.MaxHP;
                    target.CurrentHP += target.MaxHP - target.CurrentHP;
                    Console.WriteLine($"{target.Name} overhealed!({overHeal:f2} overheal)!");
                    Console.WriteLine();
                }
            }
            else
            {
                this.UnSuccessfulCastMessage(spellName);
            }
        }

        public void SpellDamageCheck(Unit caster, Unit target, double manaRequirment, double damage, string spellName)
        {
            if (this.SpellManaCheck(caster, manaRequirment) == true)
            {
                this.SuccessfulCastMessage(caster, target, spellName);
                if (damage > target.CurrentRessistanceValue)
                {
                    target.CurrentHP -= damage;
                    if (target.CurrentHP > damage)
                    {
                        Console.WriteLine($"{target.Name} recieved {damage:f2} damage from {caster.Name} ({target.Name}'HP : {target.CurrentHP})!");
                        Console.WriteLine();
                    }
                    else
                    {
                        this.TargetKilledMessage(target);
                    }
                }
                else
                {
                    target.CurrentRessistanceValue -= target.CurrentRessistanceValue * 0.25;
                    Console.WriteLine($"{spellName}' damage immuned!");
                    Console.WriteLine();
                    Console.WriteLine($"{target.Name}'s Ressitance fell by 25%({target.CurrentRessistanceValue * 0.25})!");
                    Console.WriteLine();
                }

            }
            else
            {
                this.UnSuccessfulCastMessage(spellName);
            }
        }

        public void PhysicalDamageCheck(Unit caster, Unit target, double manaRequirment, double damage, string spellName)
        {
            if (this.SpellManaCheck(caster, manaRequirment) == true)
            {
                this.SuccessfulCastMessage(caster, target, spellName);
                if (damage > target.CurrentArmorValue)
                {
                    target.CurrentHP -= damage;
                    if (target.CurrentHP > damage)
                    {
                        Console.WriteLine($"{target.Name} recieved {damage:f2} damage from {caster.Name} ({target.Name}'HP : {target.CurrentHP})!");
                        Console.WriteLine();
                    }
                    else
                    {
                        this.TargetKilledMessage(target);
                    }
                }
                else
                {
                    target.CurrentArmorValue -= target.CurrentArmorValue * 0.25;
                    Console.WriteLine($"{spellName}' damage immuned!");
                    Console.WriteLine();
                    Console.WriteLine($"{target.Name}'s Armor fell by 25%({target.CurrentArmorValue * 0.25})!");
                    Console.WriteLine();
                }

            }
            else
            {
                this.UnSuccessfulCastMessage(spellName);
            }
        }

        //Messages

        public void SuccessfulCastMessage(Unit caster, Unit target, string name)
        {
            Console.WriteLine($"{caster.Name} has casted {name} on {target.Name}!");
            Console.WriteLine();
            Console.WriteLine($"{caster.Name}'s remaining Mana : {caster.CurrentMana}.");
            Console.WriteLine();
        }

        public void UnSuccessfulCastMessage(string name)
        {
            Console.WriteLine($"Not enough mana to cast {name}!");
            Console.WriteLine();
        }

        public void TargetKilledMessage(Unit target)
        {
            Console.WriteLine($"{target.Name} killed!");
            target.CurrentHP = 0;
            Console.WriteLine();
        }

        //Mana checks

        public bool SpellManaCheck(Unit caster, double manaRequirment)
        {
            if (caster.CurrentMana >= manaRequirment)
            {
                caster.CurrentMana -= manaRequirment;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool EffectManaCheck(Unit caster, double manaRequirment)
        {
            if (caster.CurrentMana >= manaRequirment)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Effects check

        public void PositiveEffectCheck(Unit caster, Unit target, double manaRequirment
            , double possitiveEffect, string possitiveEffectType)
        {
            if (this.EffectManaCheck(caster, manaRequirment))
            {
                if (possitiveEffectType == "Attack")
                {
                    caster.CurrentAttackPower += possitiveEffect;
                }
                else if (possitiveEffectType == "hRegen")
                {
                    caster.CurrentHealthRegen += (int)possitiveEffect;
                }
                else if (possitiveEffectType == "mRegen")
                {
                    caster.CurrentManaRegen += (int)possitiveEffect;
                }
                else if (possitiveEffectType == "Armor")
                {
                    caster.CurrentArmorValue += possitiveEffect;
                }
                else if (possitiveEffectType == "Res")
                {
                    caster.CurrentArmorValue += possitiveEffect;
                }
                else if (possitiveEffectType == "Crit")
                {
                    caster.CurrentCritChance += possitiveEffect;
                }
                else if (possitiveEffectType == "Mana")
                {
                    if (caster.CurrentMana >= possitiveEffect)
                    {
                        Console.WriteLine($"{caster.Name} is already at full Mana!");
                    }
                    else
                    {
                        caster.CurrentMana += possitiveEffect;
                    }
                }
                else if (possitiveEffectType == "Magic")
                {
                    caster.CurrentMagicPower += possitiveEffect;
                }
                else if (possitiveEffectType == "Health")
                {
                    caster.CurrentHP += possitiveEffect;
                }
            }
            else
            {

            }
        }

        public void NegativeEffectCheck(Unit caster, Unit target, double manaRequirment
            , double negativeEffect, string negativeEffectType)
        {
            if (this.EffectManaCheck(caster, manaRequirment) == true)
            {
                if (negativeEffectType == "Attack")
                {
                    if (target.CurrentAttackPower < negativeEffect)
                    {
                        target.CurrentAttackPower = 0;
                    }
                    else
                    {
                        target.CurrentAttackPower -= negativeEffect;
                    }
                }
                else if (negativeEffectType == "hRegen")
                {
                    if (target.CurrentHealthRegen < (int)negativeEffect)
                    {
                        target.CurrentHealthRegen = 0;
                    }
                    else
                    {
                        target.CurrentHealthRegen -= (int)negativeEffect;
                    }
                }
                else if (negativeEffectType == "mRegen")
                {
                    if (target.CurrentManaRegen < (int)negativeEffect)
                    {
                        target.CurrentManaRegen = 0;
                    }
                    else
                    {
                        target.CurrentManaRegen -= (int)negativeEffect;
                    }
                }
                else if (negativeEffectType == "Armor")
                {
                    if (target.CurrentArmorValue < negativeEffect)
                    {
                        target.CurrentArmorValue = 0;
                    }
                    else
                    {
                        target.CurrentArmorValue -= negativeEffect;
                    }
                }
                else if (negativeEffectType == "Res")
                {
                    if (target.CurrentRessistanceValue < negativeEffect)
                    {
                        target.CurrentRessistanceValue = 0;
                    }
                    else
                    {
                        target.CurrentRessistanceValue -= negativeEffect;
                    }
                }
                else if (negativeEffectType == "SelfHP")
                {
                    caster.CurrentHP -= negativeEffect;
                }
                else if (negativeEffectType == "Damage")
                {
                    if (target.CurrentHP <= negativeEffect)
                    {
                        this.TargetKilledMessage(target);
                    }
                    else
                    {
                        target.CurrentHP -= negativeEffect;
                        Console.WriteLine($"{target.Name} got damaged by a damage effect ({negativeEffect:f2} : damage)! (Current HP : {target.CurrentHP}).");
                    }
                }
                else if (negativeEffectType == "Mana")
                {
                    if (target.CurrentMana <= negativeEffect)
                    {
                        Console.WriteLine($"{target.Name} has no Mana left!");
                    }
                    else
                    {
                        target.CurrentMana -= negativeEffect;
                    }
                }
                else if (negativeEffectType == "Magic")
                {
                    if (target.CurrentMagicPower <= negativeEffect)
                    {
                        Console.WriteLine($"{target.Name} has no Magic Power left!");
                    }
                    else
                    {
                        target.CurrentMagicPower -= negativeEffect;
                    }
                }
            }
            else
            {

            }
        }

        //Buffs'/DeBuffs' check

        public void BuffCheck(Unit caster, Unit target, double manaRequirment, double buffEffect, string spellName, string buffType)
        {
            if (this.SpellManaCheck(caster, manaRequirment) == true)
            {
                this.SuccessfulCastMessage(caster, target, spellName);

                Console.WriteLine($"{caster.Name} has increased its {buffType} by : {buffEffect:f2}!!");
                Console.WriteLine();

                if (buffType == "Attack")
                {
                    caster.CurrentAttackPower += buffEffect;
                }
                else if (buffType == "hRegen")
                {
                    caster.CurrentHealthRegen += (int)buffEffect;
                }
                else if (buffType == "mRegen")
                {
                    caster.CurrentManaRegen += (int)buffEffect;
                }
                else if (buffType == "Armor")
                {
                    caster.CurrentArmorValue += buffEffect;
                }
                else if (buffType == "Res")
                {
                    caster.CurrentArmorValue += buffEffect;
                }
                else if (buffType == "Mana")
                {
                    caster.CurrentMana += buffEffect;
                }
                else if (buffType == "Gold")
                {
                    caster.GoldAmount += (int)buffEffect;
                }
                else if (buffType == "Magic")
                {
                    caster.CurrentMagicPower += buffEffect;
                }
            }
            else
            {
                this.UnSuccessfulCastMessage(spellName);
            }
        }

        public void DeBuffCheck(Unit caster, Unit target, double manaRequirment, double debuffEffect, string spellName, string deBuffType)
        {
            if (this.SpellManaCheck(caster, manaRequirment) == true)
            {
                this.SuccessfulCastMessage(caster, target, spellName);
                if (deBuffType == "Attack")
                {
                    if (target.CurrentAttackPower < debuffEffect)
                    {
                        Console.WriteLine($"{debuffEffect - target.CurrentAttackPower:f2} Effect points asborbed.");
                        Console.WriteLine();
                        target.CurrentAttackPower = 0;
                    }
                    else
                    {
                        target.CurrentAttackPower -= debuffEffect;
                        Console.WriteLine($"{target.Name}'s Attack fell by : {debuffEffect:f2}!!");
                        Console.WriteLine();
                    }
                }
                else if (deBuffType == "hRegen")
                {
                    if (target.CurrentHealthRegen < (int)debuffEffect)
                    {
                        Console.WriteLine($"{(int)debuffEffect - target.CurrentHealthRegen:f2} Effect points asborbed.");
                        Console.WriteLine();
                        target.CurrentHealthRegen = 0;
                    }
                    else
                    {
                        target.CurrentHealthRegen -= (int)debuffEffect;
                        Console.WriteLine($"{target.Name}'s Health Regen fell by : {debuffEffect:f2}!!");
                        Console.WriteLine();
                    }
                }
                else if (deBuffType == "mRegen")
                {
                    if (target.CurrentManaRegen < (int)debuffEffect)
                    {
                        Console.WriteLine($"{(int)debuffEffect - target.CurrentManaRegen:f2} Effect points asborbed.");
                        Console.WriteLine();
                        target.CurrentManaRegen = 0;
                    }
                    else
                    {
                        target.CurrentManaRegen -= (int)debuffEffect;
                        Console.WriteLine($"{target.Name}'s Mana Regen fell by : {debuffEffect:f2}!!");
                        Console.WriteLine();
                    }
                }
                else if (deBuffType == "Armor")
                {
                    if (target.CurrentArmorValue < debuffEffect)
                    {
                        Console.WriteLine($"{debuffEffect - target.CurrentArmorValue:f2} Effect points asborbed.");
                        Console.WriteLine();
                        target.CurrentArmorValue = 0;
                    }
                    else
                    {
                        target.CurrentArmorValue -= debuffEffect;
                        Console.WriteLine($"{target.Name}'s Armor Value fell by : {debuffEffect:f2}!!");
                        Console.WriteLine();
                    }
                }
                else if (deBuffType == "Res")
                {
                    if (target.CurrentRessistanceValue < debuffEffect)
                    {
                        Console.WriteLine($"{debuffEffect - target.CurrentRessistanceValue:f2} Effect points asborbed.");
                        Console.WriteLine();
                        target.CurrentRessistanceValue = 0;
                    }
                    else
                    {
                        target.CurrentRessistanceValue -= debuffEffect;
                        Console.WriteLine($"{target.Name}'s Ressistance Value fell by : {debuffEffect:f2}!!");
                        Console.WriteLine();
                    }
                }
                else if (deBuffType == "SelfHP")
                {
                    if (caster.CurrentHP < debuffEffect)
                    {
                        Console.WriteLine($"Cannot use {spellName}!");
                        Console.WriteLine();
                    }
                    else
                    {
                        caster.CurrentHP -= debuffEffect;
                        Console.WriteLine($"{caster.Name} lost HP : {debuffEffect:f2} due to effect of {spellName}!!");
                        Console.WriteLine();
                    }
                }
                else if (deBuffType == "Magic")
                {
                    if (target.CurrentMagicPower < debuffEffect)
                    {
                        Console.WriteLine($"{debuffEffect - target.CurrentMagicPower:f2} Effect points asborbed.");
                        Console.WriteLine();
                        target.CurrentMagicPower = 0;
                    }
                    else
                    {
                        target.CurrentMagicPower -= debuffEffect;
                        Console.WriteLine($"{target.Name}'s Magic Power fell by : {debuffEffect:f2}!!");
                        Console.WriteLine();
                    }
                }
            }
            else
            {
                this.UnSuccessfulCastMessage(spellName);
            }
        }
    }
}
