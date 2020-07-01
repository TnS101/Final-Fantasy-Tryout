using Final_Fantasy_Tryout.ArmorInfo;
using Final_Fantasy_Tryout.FightingClasses;
using Final_Fantasy_Tryout.FightingClasses.EnemyClassRepos;
using Final_Fantasy_Tryout.FightingClasses.PlayerClassRepos;
using Final_Fantasy_Tryout.Inventory;
using Final_Fantasy_Tryout.PlayerInfo;
using Final_Fantasy_Tryout.Spells;
using Final_Fantasy_Tryout.Spells.EnemySpellRepos;
using Final_Fantasy_Tryout.Spells.PlayerSpellRepos;
using Final_Fantasy_Tryout.Units.PlayerInfo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Fantasy_Tryout.Units
{
    public abstract class Unit : IUnit
    {
        public Unit(string name, string type, string classType, string race, int level
                    , double xp, double xpCap, double maxHP, int healthRegen, double maxMana, int manaRegen, double attackPower
                    , double magicPower, double armorValue, double ressistanceValue, double critChance
                    , int goldAmount, PlayerInventory inventory, SpellRepos spells,Bag bag,Equipment equipment)
        {
            this.Name = name;
            this.Type = type;
            this.Level = level;
            this.XP = xp;
            this.MaxHP = maxHP;
            this.CurrentHP = this.MaxHP;
            this.HealthRegen = healthRegen;
            this.CurrentHealthRegen = this.HealthRegen;
            this.MaxMana = maxMana;
            this.CurrentMana = this.MaxMana;
            this.ManaRegen = manaRegen;
            this.CurrentManaRegen = this.ManaRegen;
            this.AttackPower = attackPower;
            this.CurrentAttackPower = this.AttackPower;
            this.MagicPower = magicPower;
            this.CurrentMagicPower = this.MagicPower;
            this.ArmorValue = armorValue;
            this.CurrentArmorValue = this.ArmorValue;
            this.RessistanceValue = ressistanceValue;
            this.CurrentRessistanceValue = this.RessistanceValue;
            this.GoldAmount = goldAmount;
            this.XPCap = xpCap;
            this.CritChance = critChance;
            this.CurrentCritChance = this.CritChance;
            inventory = new PlayerInventory();
            Spells = new SpellRepos();
            bag = new Bag();
            equipment = new Equipment();
        }

        public string Name { get; set; }

        public string Type { get; set; }

        public string ClassType { get; set; }

        public string RarityType { get; set; }

        public string Race { get; set; }

        public int Level { get; set; }

        public double XP { get; set; }

        public double XPCap { get; set; }

        public double MaxHP { get; set; }

        public double CurrentHP { get; set; }

        public int HealthRegen { get; set; }

        public int CurrentHealthRegen { get; set; }

        public double MaxMana { get; set; }

        public double CurrentMana { get; set; }

        public int ManaRegen { get; set; }

        public int CurrentManaRegen { get; set; }

        public double AttackPower { get; set; }

        public double CurrentAttackPower { get; set; }

        public double MagicPower { get; set; }

        public double CurrentMagicPower { get; set; }

        public double ArmorValue { get; set; }

        public double CurrentArmorValue { get; set; }

        public double RessistanceValue { get; set; }

        public double CurrentRessistanceValue { get; set; }

        public double CritChance { get; set; }

        public double CurrentCritChance { get; set; }

        public int GoldAmount { get; set; }

        public SpellRepos Spells { get; set; }

        public PlayerInventory Inventory { get; set; }

        public Bag Bag { get; set; }

        public Equipment Equipment { get; set; }

        public void LevelUp(Unit player)
        {
            while (player.XP >= player.XPCap)
            {
                player.Level++;
                player.AttackPower += 2;
                player.CurrentAttackPower += 2;
                player.ArmorValue += 1;
                player.CurrentArmorValue += 1;
                player.CritChance += 0.05;
                player.CurrentCritChance += 0.05;
                player.HealthRegen += 1;
                player.CurrentHealthRegen += 1;
                player.MaxHP += 10;
                player.CurrentHP += 10;
                player.MaxMana += 5;
                player.CurrentMana += 5;
                player.MagicPower += 3;
                player.CurrentMagicPower += 3;
                player.ManaRegen += 1;
                player.CurrentManaRegen += 1;
                player.RessistanceValue += 1.5;
                player.CurrentRessistanceValue += 0.5;
                player.XPCap += player.XPCap * 0.3;
                player.XP = player.XP - player.XPCap;
                player.CurrentHP = player.MaxHP;
                player.CurrentMana = player.CurrentMana;

                if (this.XP < 0)
                {
                    this.XP = 0;
                }
            }
        }

        public string GetInfo(Unit player)
        {
            var sb = new StringBuilder();
            sb.AppendLine($" *Name : {player.Name}");
            sb.AppendLine($" *Gold : {player.GoldAmount}");
            if (this.Type == "Player")
            {
                sb.AppendLine($" *Race : {player.Race}");
            }
            else if (this.Type == "Enemy")
            {
                sb.AppendLine($" *Rarity : {player.RarityType}");
            }
            sb.AppendLine($" *Class : {player.ClassType}");
            sb.AppendLine($" *Level : {player.Level}");
            sb.AppendLine($" *XP : {player.XP:f2}/{player.XPCap:f2}");
            sb.AppendLine($" *Max HP : {player.MaxHP:f2}");
            sb.AppendLine($" *Max Mana : {player.MaxMana:f2}");
            sb.AppendLine($" *Mana regen : {player.ManaRegen}");
            sb.AppendLine($" *HP regen : {player.HealthRegen}");
            sb.AppendLine($" *Attack Power : {player.AttackPower:f2}");
            sb.AppendLine($" *Magic Power : {player.MagicPower:f2}");
            sb.AppendLine($" *Armor Value : {player.ArmorValue:f2}");
            sb.AppendLine($" *Ressistance Value : {player.RessistanceValue:f2}");
            sb.AppendLine($" *Critical Chance : {player.CritChance:f2} %");

            return sb.ToString().TrimEnd();
        }

        public void BeastSetClass(Unit enemy)
        {
            var rng = new Random();
            int beastNumber = rng.Next(0, 27);

            if (beastNumber == 0 || beastNumber == 1 || beastNumber == 2
               || beastNumber == 3 || beastNumber == 4 || beastNumber == 5)
            {
                Beast beast = new Beast();
                beast.StatIncrement(enemy, beast);
                beast.RarityRng(enemy);
                BeastSpellRepository repos = new BeastSpellRepository(enemy);
                repos.SpellRepositoryInitilization(enemy, repos);
            }

            if (beastNumber == 6 || beastNumber == 7 || beastNumber == 8
               || beastNumber == 9 || beastNumber == 10)
            {
                Reptile reptile = new Reptile();
                reptile.StatIncrement(enemy, reptile);
                reptile.RarityRng(enemy);
                ReptileSpellRepository repos = new ReptileSpellRepository(enemy);
                repos.SpellRepositoryInitilization(enemy, repos);
            }

            if (beastNumber == 19 || beastNumber == 20)
            {
                Wyrm wyrm = new Wyrm();
                wyrm.StatIncrement(enemy, wyrm);
                wyrm.RarityRng(enemy);
                WyrmSpellRepository repos = new WyrmSpellRepository(enemy);
                repos.SpellRepositoryInitilization(enemy, repos);
            }

            if (beastNumber == 21 || beastNumber == 22)
            {
                Giant giant = new Giant();
                giant.StatIncrement(enemy, giant);
                giant.RarityRng(enemy);
                GiantSpellRepository repos = new GiantSpellRepository(enemy);
                repos.SpellRepositoryInitilization(enemy, repos);
            }

            if (beastNumber == 11 || beastNumber == 12 || beastNumber == 13
                || beastNumber == 14)
            {
                Zombie zombie = new Zombie();
                zombie.StatIncrement(enemy, zombie);
                zombie.RarityRng(enemy);
                ZombieSpellRepository repos = new ZombieSpellRepository(enemy);
                repos.SpellRepositoryInitilization(enemy, repos);
            }

            if (beastNumber == 23 || beastNumber == 24)
            {
                Gryphon gryphon = new Gryphon();
                gryphon.StatIncrement(enemy, gryphon);
                gryphon.RarityRng(enemy);
                GryphonSpellRepository repos = new GryphonSpellRepository(enemy);
                repos.SpellRepositoryInitilization(enemy, repos);
            }

            if (beastNumber == 15 || beastNumber == 16 || beastNumber == 17
                || beastNumber == 18)
            {
                Skeleton skeleton = new Skeleton();
                skeleton.StatIncrement(enemy, skeleton);
                skeleton.RarityRng(enemy);
                SkeletonSpellRepository repos = new SkeletonSpellRepository(enemy);
                repos.SpellRepositoryInitilization(enemy, repos);
            }

            if (beastNumber == 25)
            {
                Saint saint = new Saint();
                saint.StatIncrement(enemy, saint);
                saint.RarityRng(enemy);
                SaintSpellRepository repos = new SaintSpellRepository(enemy);
                repos.SpellRepositoryInitilization(enemy, repos);
            }

            if (beastNumber == 26)
            {
                Demon demon = new Demon();
                demon.StatIncrement(enemy, demon);
                demon.RarityRng(enemy);
                DemonSpellRepository repos = new DemonSpellRepository(enemy);
                repos.SpellRepositoryInitilization(enemy, repos);
            }
        }

        public void SetClass(Unit player)
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Warrior")
                {
                    Warrior warrior = new Warrior();
                    warrior.StatIncrement(player, warrior);
                    WarriorSpellRepository repos = new WarriorSpellRepository(player);
                    repos.SpellRepositoryInitilization(player, repos);
                    break;
                }

                if (input == "Mage")
                {
                    Mage mage = new Mage();
                    mage.StatIncrement(player, mage);
                    MageSpellRepository repos = new MageSpellRepository(player);
                    repos.SpellRepositoryInitilization(player, repos);
                    break;
                }

                if (input == "Paladin")
                {
                    Paladin paladin = new Paladin();
                    paladin.StatIncrement(player, paladin);
                    PaladinSpellRepository repos = new PaladinSpellRepository(player);
                    repos.SpellRepositoryInitilization(player, repos);
                    break;
                }

                if (input == "Necroid")
                {
                    Necroid necroid = new Necroid();
                    necroid.StatIncrement(player, necroid);
                    NecroidSpellRepository repos = new NecroidSpellRepository(player);
                    repos.SpellRepositoryInitilization(player, repos);
                    break;
                }

                if (input == "Hunter")
                {
                    Hunter hunter = new Hunter();
                    hunter.StatIncrement(player, hunter);
                    HunterSpellRepository repos = new HunterSpellRepository(player);
                    repos.SpellRepositoryInitilization(player, repos);
                    break;
                }

                if (input == "Rogue")
                {
                    Rogue rogue = new Rogue();
                    rogue.StatIncrement(player, rogue);
                    RogueSpellRepository repos = new RogueSpellRepository(player);
                    repos.SpellRepositoryInitilization(player, repos);
                    break;
                }

                if (input == "Naturalist")
                {
                    Naturalist naturalist = new Naturalist();
                    naturalist.StatIncrement(player, naturalist);
                    NaturalistSpellRepository repos = new NaturalistSpellRepository(player);
                    repos.SpellRepositoryInitilization(player, repos);
                    break;
                }

                if (input == "Priest")
                {
                    Priest priest = new Priest();
                    priest.StatIncrement(player, priest);
                    PriestSpellRepository repos = new PriestSpellRepository(player);
                    repos.SpellRepositoryInitilization(player, repos);
                    break;
                }

                if (input == "Shaman")
                {
                    Shaman shaman = new Shaman();
                    shaman.StatIncrement(player, shaman);
                    ShamanSpellRepository repos = new ShamanSpellRepository(player);
                    repos.SpellRepositoryInitilization(player, repos);
                    break;
                }
                else
                {
                    Console.WriteLine($"{input} is not a valid class!Please insert a valid class.");
                    continue;
                }
            }

        }

        public void SetRace(Unit player)
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Human")
                {
                    player.Race = "Human";
                    player.MaxHP += this.MaxHP * 0.15;
                    break;
                }
                if (input == "Dwarf")
                {
                    this.Race = "Dwarf";
                    this.ArmorValue += this.ArmorValue * 0.20;
                    break;
                }
                if (input == "Elf")
                {
                    this.Race = "Elf";
                    this.MagicPower += this.MagicPower * 0.15;
                    break;
                }
                if (input == "Orc")
                {
                    this.Race = "Orc";
                    this.AttackPower += 0.10 * this.AttackPower;
                    break;
                }
                if (input == "Goblin")
                {
                    this.Race = "Goblin";
                    this.ManaRegen += (int)MaxMana / 10;
                    break;
                }
                if (input == "Troll")
                {
                    this.Race = "Troll";
                    this.RessistanceValue += 0.30 * this.RessistanceValue;
                    break;
                }
                else
                {
                    Console.WriteLine($"{input} is not a valid race!Please insert a valid race.");
                    continue;
                }
            }
        }
    }
}

