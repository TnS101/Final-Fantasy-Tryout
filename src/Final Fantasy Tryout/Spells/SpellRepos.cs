using Final_Fantasy_Tryout.Units;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Final_Fantasy_Tryout.Spells
{
   public class SpellRepos
   {
        private readonly List<Spell> spells;

        public SpellRepos()
        {
            spells = new List<Spell>();
        }

        public virtual List<Spell> Spells => spells;

        public string SpellReposInfo(SpellRepos repos,Unit caster)
        {
            var sb = new StringBuilder();
            int counter = 1;
            foreach (var item in repos.Spells)
            {
                sb.AppendLine($"Spell name: [{counter}]{item.Name}, Mana Requirment: {item.ManaRequirment}/{caster.CurrentMana}");
                counter++;
            }
            return sb.ToString();
        }

        public void SpellRepositoryInitilization(Unit player,SpellRepos repos)
        {
            foreach (Spell item in repos.Spells)
            {
                player.Spells.Spells.Add(item);
            }
        }
       
    }
}
