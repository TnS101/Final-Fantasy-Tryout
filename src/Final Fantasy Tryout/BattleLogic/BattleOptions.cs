using Final_Fantasy_Tryout.PlayingField;
using Final_Fantasy_Tryout.Spells;
using Final_Fantasy_Tryout.Spells.EnemySpellRepos;
using Final_Fantasy_Tryout.Spells.PlayerSpellRepos;
using Final_Fantasy_Tryout.Units;
using System;

namespace Final_Fantasy_Tryout.BattleLogic
{
    public class BattleOptions
    {
        private WarriorSpellRepository warriorSpellRepository;
        private MageSpellRepository mageSpellRepository;
        private HunterSpellRepository hunterSpellRepository;
        private NaturalistSpellRepository naturalistSpellRepository;
        private PaladinSpellRepository paladinSpellRepository;
        private PriestSpellRepository priestSpellRepository;
        private RogueSpellRepository rogueSpellRepository;
        private NecroidSpellRepository necroidSpellRepository;
        private ShamanSpellRepository shamanSpellRepository;
        private BeastSpellRepository beastSpellRepository;
        private DemonSpellRepository demonSpellRepository;
        private GiantSpellRepository giantSpellRepository;
        private GryphonSpellRepository gryphonSpellRepository;
        private ReptileSpellRepository reptileSpellRepository;
        private SaintSpellRepository saintSpellRepository;
        private SkeletonSpellRepository skeletonSpellRepository;
        private WyrmSpellRepository wyrmSpellRepository;
        private ZombieSpellRepository zombieSpellRepository;

        public BattleOptions(Unit caster)
        {
            wyrmSpellRepository = new WyrmSpellRepository(caster);
            zombieSpellRepository = new ZombieSpellRepository(caster);
            skeletonSpellRepository = new SkeletonSpellRepository(caster);
            giantSpellRepository = new GiantSpellRepository(caster);
            saintSpellRepository = new SaintSpellRepository(caster);
            reptileSpellRepository = new ReptileSpellRepository(caster);
            gryphonSpellRepository = new GryphonSpellRepository(caster);
            beastSpellRepository = new BeastSpellRepository(caster);
            demonSpellRepository = new DemonSpellRepository(caster);
            warriorSpellRepository = new WarriorSpellRepository(caster);
            mageSpellRepository = new MageSpellRepository(caster);
            hunterSpellRepository = new HunterSpellRepository(caster);
            naturalistSpellRepository = new NaturalistSpellRepository(caster);
            priestSpellRepository = new PriestSpellRepository(caster);
            paladinSpellRepository = new PaladinSpellRepository(caster);
            rogueSpellRepository = new RogueSpellRepository(caster);
            necroidSpellRepository = new NecroidSpellRepository(caster);
            shamanSpellRepository = new ShamanSpellRepository(caster);
        }

        public void Attack(Unit caster, Unit target)
        {
            if (target.Type == "Enemy" && target.CurrentHP > 0)
            {
                if (target.CurrentArmorValue > caster.CurrentAttackPower)
                {
                    Console.WriteLine($"[Enemy] {target.ClassType} blocked an attack from [Player] {caster.Name}!");
                    target.CurrentArmorValue -= 0.80 * target.CurrentArmorValue;
                    Console.WriteLine();
                    Console.WriteLine($"[Enemy] {target.ClassType}'s Armor fell by 80% (current Armor : {target.CurrentArmorValue:f2})!");
                    Console.WriteLine();
                }
                else
                {
                    target.CurrentHP -= caster.CurrentAttackPower - target.CurrentArmorValue;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"[Enemy] {target.ClassType} got hit by [Player] {caster.Name} for {Math.Abs(caster.CurrentAttackPower - target.CurrentArmorValue):f2} damage!");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine();

                    if (target.CurrentHP <= 0)
                    {
                        Console.WriteLine($"[Enemy] {target.ClassType} Killed!");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine($"[Enemy] {target.ClassType}'s HP : {target.CurrentHP:f2}.");
                        Console.WriteLine();
                    }
                }

            }
            else if (target.Type == "Player" && target.CurrentHP > 0)
            {
                if (target.CurrentArmorValue >= caster.CurrentAttackPower)
                {
                    Console.WriteLine($"[Player] {target.Name} blocked an attack from [Enemy] {caster.ClassType}!");
                    target.CurrentArmorValue -= 0.50 * target.CurrentArmorValue;
                    Console.WriteLine();
                    Console.WriteLine($"[Player] {target.Name}'s Armor fell by 50% (current Armor : {target.CurrentArmorValue:f2})!");
                    Console.WriteLine();
                }
                else
                {
                    target.CurrentHP -= caster.CurrentAttackPower - target.CurrentArmorValue;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"[Player] {target.Name} got hit by [Enemy] {caster.ClassType} for {Math.Abs(caster.CurrentAttackPower - target.CurrentArmorValue):f2} damage!");
                    Console.ResetColor();
                    Console.WriteLine();

                    if (target.CurrentHP <= 0)
                    {
                        Console.WriteLine($"[Player] {target.Name} died!");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine($"[Player] {target.Name}'s HP : {target.CurrentHP:f2}.");
                        Console.WriteLine();
                    }
                }
            }
        }

        public void Defend(Unit target)
        {
            if (target.Type == "Enemy")
            {
                target.CurrentArmorValue += 0.20 * target.CurrentArmorValue;
                Console.WriteLine($"[Enemy] {target.ClassType} defended!");
                Console.WriteLine();
                Console.WriteLine($"[Enemy] {target.ClassType}'s Armor raised by 20%!(current Armor : {target.CurrentArmorValue:f2})");
                Console.WriteLine();
            }
            else if (target.Type == "Player")
            {
                target.CurrentArmorValue += 0.30 * target.CurrentArmorValue;
                Console.WriteLine($"[Player] {target.Name} defended!");
                Console.WriteLine();
                Console.WriteLine($"[Player] {target.Name}'s Armor raised by 30%!(current Armor : {target.CurrentArmorValue:f2})");
                Console.WriteLine();
            }
        }

        public void SpellCast(Unit caster, Unit target, SpellRepos repos)
        {
            if (caster.Type == "Player")
            {
                Console.WriteLine("Select a Spell!");
                Console.WriteLine();
                Console.WriteLine(repos.SpellReposInfo(repos, caster));
                Console.WriteLine();

                if (caster.ClassType == "Warrior")
                {
                    warriorSpellRepository.SpellCast(caster, target);
                }

                if (caster.ClassType == "Mage")
                {
                    mageSpellRepository.SpellCast(caster, target);
                }

                if (caster.ClassType == "Priest")
                {
                    priestSpellRepository.SpellCast(caster, target);
                }

                if (caster.ClassType == "Paladin")
                {
                    paladinSpellRepository.SpellCast(caster, target);
                }

                if (caster.ClassType == "Hunter")
                {
                    hunterSpellRepository.SpellCast(caster, target);
                }

                if (caster.ClassType == "Necroid")
                {
                    necroidSpellRepository.SpellCast(caster, target);
                }

                if (caster.ClassType == "Naturalist")
                {
                    naturalistSpellRepository.SpellCast(caster, target);
                }

                if (caster.ClassType == "Rogue")
                {
                    rogueSpellRepository.SpellCast(caster, target);
                }

                if (caster.ClassType == "Shaman")
                {
                    shamanSpellRepository.SpellCast(caster, target);
                }

            }
            else if (caster.Type == "Enemy")
            {

                Console.Write("[Enemy] ");

                if (caster.ClassType == "Beast")
                {
                    beastSpellRepository.SpellCast(caster, target);
                }

                if (caster.ClassType == "Demon")
                {
                    demonSpellRepository.SpellCast(caster, target);
                }

                if (caster.ClassType == "Giant")
                {
                    giantSpellRepository.SpellCast(caster, target);
                }

                if (caster.ClassType == "Gryphon")
                {
                    gryphonSpellRepository.SpellCast(caster, target);
                }

                if (caster.ClassType == "Reptile")
                {
                    reptileSpellRepository.SpellCast(caster, target);
                }

                if (caster.ClassType == "Saint")
                {
                    saintSpellRepository.SpellCast(caster, target);
                }

                if (caster.ClassType == "Skeleton")
                {
                    skeletonSpellRepository.SpellCast(caster, target);
                }

                if (caster.ClassType == "Wyrm")
                {
                    wyrmSpellRepository.SpellCast(caster, target);
                }

                if (caster.ClassType == "Zombie")
                {
                    zombieSpellRepository.SpellCast(caster, target);
                }
            }
        }

        public void Escape(Unit caster)
        {
            Battle battle = new Battle();
            var escapeRNG = new Random();
            int escapeNum = escapeRNG.Next(0, 2);

            if (escapeNum == 0)
            {
                Console.WriteLine($"You escaped successfuly.");
                Console.WriteLine();
            }
            else if (escapeNum == 1)
            {
                caster.GoldAmount -= 30;
                Console.WriteLine($"You hurt yourself while escaping.");
                Console.WriteLine();
                Console.WriteLine($"You lost 30 gold.");
            }
            Map map = new Map();
            map.Generate(caster);
        }

        public void HealthRegenerate(Unit caster)
        {
            double hpRegen = caster.CurrentHealthRegen;
            if (caster.CurrentHP <= caster.MaxHP - hpRegen)
            {
                if (caster.Type == "Player")
                {
                    caster.CurrentHP += hpRegen;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"{caster.Name} has regenerated ({hpRegen:f2} HP !)");
                    Console.ResetColor();
                    Console.WriteLine();
                }
                else
                {
                    caster.CurrentHP += hpRegen;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"{caster.ClassType} has regenerated ({hpRegen:f2} HP !)");
                    Console.ResetColor();
                    Console.WriteLine();
                }

            }
            else
            {
                if (caster.Type == "Player")
                {
                    caster.CurrentHP = caster.MaxHP;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"{caster.Name} is at full Health!");
                    Console.ResetColor();
                    Console.WriteLine();
                }
                else
                {
                    caster.CurrentHP = caster.MaxHP;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"{caster.ClassType} is at full Health!");
                    Console.ResetColor();
                    Console.WriteLine();
                }

            }
        }

        public void ManaRegenerate(Unit caster)
        {
            double manaRegen = caster.CurrentManaRegen;
            if (caster.CurrentMana <= caster.MaxMana - manaRegen)
            {
                if (caster.Type == "Player")
                {
                    caster.CurrentMana += manaRegen;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"{caster.Name} has regenerated ({manaRegen:f2} Mana !)");
                    Console.ResetColor();
                    Console.WriteLine();
                }
                else
                {
                    caster.CurrentMana += manaRegen;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"{caster.ClassType} has regenerated ({manaRegen:f2} Mana !)");
                    Console.ResetColor();
                    Console.WriteLine();
                }

            }
            else
            {
                if (caster.Type == "Player")
                {
                    caster.CurrentMana = caster.MaxMana;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"{caster.Name} is at full Mana!");
                    Console.ResetColor();
                    Console.WriteLine();
                }
                else
                {
                    caster.CurrentMana = caster.MaxMana;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"{caster.ClassType} is at full Mana!");
                    Console.ResetColor();
                    Console.WriteLine();
                }

            }
        }


        public void EndOfBattle(Unit player)
        {
            player.XP += 10;
            player.CurrentAttackPower = player.AttackPower;
            player.CurrentMagicPower = player.MagicPower;
            player.CurrentArmorValue = player.ArmorValue;
            player.CurrentRessistanceValue = player.RessistanceValue;
            player.CurrentHealthRegen = player.HealthRegen;
            player.CurrentManaRegen = player.ManaRegen;
            player.CurrentCritChance = player.CritChance;
            Console.WriteLine("You have earned 10 xp!");
        }
    }
}
