using Final_Fantasy_Tryout.Items;
using Final_Fantasy_Tryout.Units;
using Final_Fantasy_Tryout.Units.PlayerInfo;
using System;
using System.Linq;

namespace Final_Fantasy_Tryout.Inventory
{
    public class Equipment : PlayerInventory
    {
        private const string name = "Equipment";
        private const int capacity = 9;
        public Equipment()
        {
            this.Name = name;
            this.Capacity = capacity;
        }

        public void StatSum(Unit player)
        {
            foreach (var item in this.Inventory)
            {
                player.ArmorValue += item.ArmorValue;
                player.AttackPower += item.Strength;
                player.AttackPower += item.AttackPower;
                player.MagicPower += item.Intellect;
                player.ManaRegen += item.Spirit;
                player.MaxHP += item.Stamina;
            }
            player.GetInfo(player);
        }

        public bool HelmetSlotIsTaken { get; set; }

        public bool ChestplateSlotIsTaken { get; set; }

        public bool ShoulderSlotIsTaken { get; set; }

        public bool BracerSlotIsTaken { get; set; }

        public bool BootsSlotIsTaken { get; set; }

        public bool LeggingsSlotIsTaken { get; set; }

        public bool TrinketSlotIsTaken { get; set; }

        public bool GlovesSlotIsTaken { get; set; }

        public bool WeaponSlotIsTaken { get; set; }

        public void Equip(Unit player, Item item, PlayerInventory inventory)
        {
            Console.WriteLine("Choose an item to equip!");
            int counter = 1;
            foreach (var thing in inventory.Inventory)
            {
                Console.WriteLine($"[{counter}]{item.Name} -> Class : {item.ClassUsable}, iLevel : {item.Level}, Slot : {item.Slot}.");
                counter++;
            }
            while (true)
            {
                string input = Console.ReadLine();
                if (inventory.Inventory.Any(i => i.Name == input))
                {
                    if (player.ClassType != item.ClassUsable)
                    {
                        Console.WriteLine($"{item.Name} is not available for the {player.ClassType} class!");
                        break;
                    }
                    else
                    {
                        if (item.Type == "Weapon" && item.Level <= player.Level && !this.WeaponSlotIsTaken)
                        {
                            this.AddItem(item, this);
                            this.CurrentCapacity++;
                            this.WeaponSlotIsTaken = true;
                            this.StatSum(player);
                            break;
                        }

                        else if (item.Type == "Weapon" && item.Level <= player.Level && this.WeaponSlotIsTaken)
                        {
                            this.SlotIsAlreadyUsedMessage(item);
                            break;
                        }

                        if (item.Type == "Trinket" && item.Level <= player.Level && !this.TrinketSlotIsTaken)
                        {
                            this.AddItem(item, this);
                            this.CurrentCapacity++;
                            this.TrinketSlotIsTaken = true;
                            this.StatSum(player);
                            break;
                        }

                        else if (item.Type == "Trinket" && item.Level <= player.Level && this.TrinketSlotIsTaken)
                        {
                            this.SlotIsAlreadyUsedMessage(item);
                            break;
                        }

                        if (item.Type == "Armor" && item.Level <= player.Level)
                        {
                            if (item.Slot == "Helmet" && !this.HelmetSlotIsTaken)
                            {
                                this.AddItem(item, this);
                                this.CurrentCapacity++;
                                this.HelmetSlotIsTaken = true;
                                this.StatSum(player);
                                break;
                            }

                            else if (item.Slot == "Chestplate" && !this.ChestplateSlotIsTaken)
                            {
                                this.AddItem(item, this);
                                this.CurrentCapacity++;
                                this.ChestplateSlotIsTaken = true;
                                this.StatSum(player);
                                break;
                            }

                            else if (item.Slot == "Shoulder" && !this.ShoulderSlotIsTaken)
                            {
                                this.AddItem(item, this);
                                this.CurrentCapacity++;
                                this.ShoulderSlotIsTaken = true;
                                this.StatSum(player);
                                break;
                            }

                            else if (item.Slot == "Bracer" && !this.BracerSlotIsTaken)
                            {
                                this.AddItem(item, this);
                                this.CurrentCapacity++;
                                this.BracerSlotIsTaken = true;
                                this.StatSum(player);
                                break;
                            }

                            else if (item.Slot == "Boots" && !this.BootsSlotIsTaken)
                            {
                                this.AddItem(item, this);
                                this.CurrentCapacity++;
                                this.BootsSlotIsTaken = true;
                                this.StatSum(player);
                                break;
                            }

                            else if (item.Slot == "Leggings" && !this.LeggingsSlotIsTaken)
                            {
                                this.AddItem(item, this);
                                this.CurrentCapacity++;
                                this.LeggingsSlotIsTaken = true;
                                this.StatSum(player);
                                break;
                            }

                            else if (item.Slot == "Gloves" && !this.GlovesSlotIsTaken)
                            {
                                this.AddItem(item, this);
                                this.CurrentCapacity++;
                                this.GlovesSlotIsTaken = true;
                                this.StatSum(player);
                                break;
                            }
                        }
                        else if (item.Level > player.Level)
                        {
                            Console.WriteLine($"{item.Name}'s level is to high to equip!(iLevel : {item.Level} > curren level : {player.Level})");
                            break;
                        }

                    }
                }
                else
                {
                    this.ItemDoesntExistMessage(item, input, inventory);
                    break;
                }
            }
        }

        public void UnEquip(Unit player, Item item, PlayerInventory inventory)
        {
            Console.WriteLine("Choose an item to uneqip!");
            int counter = 1;
            foreach (var thing in this.Inventory)
            {
                Console.WriteLine($"[{counter}]({thing.Slot} Slot.)");
            }
            while (true)
            {
                string input = Console.ReadLine();
                if (this.Inventory.Any(i => i.Name == input))
                {
                    if (item.Slot == "Helmet" && this.HelmetSlotIsTaken)
                    {
                        this.Inventory.Remove(item);
                        this.CurrentCapacity--;
                        this.HelmetSlotIsTaken = false;
                        this.StatSum(player);
                        Console.WriteLine($"You have unequipped {item.Name} from your {item.Slot} Slot!");
                        break;
                    }
                    else if (item.Slot == "Chestplate" && this.ChestplateSlotIsTaken)
                    {
                        this.Inventory.Remove(item);
                        this.CurrentCapacity--;
                        this.ChestplateSlotIsTaken = false;
                        this.StatSum(player);
                        Console.WriteLine($"You have unequipped {item.Name} from your {item.Slot} Slot!");
                        break;
                    }

                    else if (item.Slot == "Bracer" && this.BracerSlotIsTaken)
                    {
                        this.Inventory.Remove(item);
                        this.CurrentCapacity--;
                        this.BracerSlotIsTaken = false;
                        this.StatSum(player);
                        Console.WriteLine($"You have unequipped {item.Name} from your {item.Slot} Slot!");
                        break;
                    }

                    else if (item.Slot == "Boots" && this.BootsSlotIsTaken)
                    {
                        this.Inventory.Remove(item);
                        this.CurrentCapacity--;
                        this.BootsSlotIsTaken = false;
                        this.StatSum(player);
                        Console.WriteLine($"You have unequipped {item.Name} from your {item.Slot} Slot!");
                        break;
                    }

                    else if (item.Slot == "Leggings" && this.LeggingsSlotIsTaken)
                    {
                        this.Inventory.Remove(item);
                        this.CurrentCapacity--;
                        this.LeggingsSlotIsTaken = false;
                        this.StatSum(player);
                        Console.WriteLine($"You have unequipped {item.Name} from your {item.Slot} Slot!");
                        break;
                    }

                    else if (item.Slot == "Gloves" && this.GlovesSlotIsTaken)
                    {
                        this.Inventory.Remove(item);
                        this.CurrentCapacity--;
                        this.GlovesSlotIsTaken = false;
                        this.StatSum(player);
                        Console.WriteLine($"You have unequipped {item.Name} from your {item.Slot} Slot!");
                        break;
                    }

                }
                else
                {
                    this.ItemDoesntExistMessage(item, input, inventory);
                    break;
                }
            }
        }

        public void SlotIsAlreadyUsedMessage(Item item)
        {
            Console.WriteLine($"The {item.Slot} slot is already being used!");
            Console.WriteLine();
        }

        public void ItemDoesntExistMessage(Item item, string input, PlayerInventory inventory)
        {
            Console.WriteLine($"No item with name: ({input}) exists in {inventory.Name}.");
        }
    }
}
