using Final_Fantasy_Tryout.ArmorInfo;
using Final_Fantasy_Tryout.Items;
using Final_Fantasy_Tryout.PlayerInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Final_Fantasy_Tryout.Units.PlayerInfo
{
    public class PlayerInventory
    {
        private List<Item> inventory;
        public PlayerInventory()
        {
            inventory = new List<Item>();
        }

        public virtual List<Item> Inventory => inventory;

        public virtual int Capacity {get;set;}

        public virtual int CurrentCapacity { get; set; }

        public virtual string Name { get; set; }

        public virtual void AddItem(Item item,PlayerInventory inventory)
        {
            if (inventory.CurrentCapacity >= inventory.Capacity)
            {
                Console.WriteLine($"{inventory.Name}'s Capacity limit reached!");
                Console.WriteLine();
                Console.WriteLine($"Remove an item from your {inventory.Name}?");
                Console.WriteLine();
                Console.WriteLine("Yes?(Press Enter) / No?(Press Escape)");

                while (true)
                {
                    var key = Console.ReadKey().Key;
                    if (key == ConsoleKey.Enter)
                    {
                        inventory.RemoveItem(item, inventory);
                        break;
                    }
                    else if (key == ConsoleKey.Escape)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input! Please insert a valid input!");
                        continue;
                    }
                }
                
            }
            else
            {
                inventory.Inventory.Add(item);
                inventory.CurrentCapacity++;
                Console.WriteLine($"{item.Name} added to {inventory.Name}!");
            }
        }

        public virtual void RemoveItem(Item item,PlayerInventory inventory)
        {
            int counter = 1;
            foreach (IItem itemI in inventory.Inventory)
            {
                Console.WriteLine($"[{counter}]{item.Name} -> Class : {item.ClassUsable}, iLevel : {item.Level}, Slot : {item.Slot}.");
                counter++;
            }

            while (true)
            {
                string itemDeletion = Console.ReadLine();
                if (inventory.Inventory.Any(i=>i.Name == itemDeletion))
                {
                    item = (Item)inventory.Inventory.FirstOrDefault(i=>i.Name == itemDeletion);
                    Console.WriteLine($"Are you sure you want to delete {item.Name}?");
                    Console.WriteLine();
                    Console.WriteLine("Yes?(Press Enter) / No?(Press Escape)");
                    var key = Console.ReadKey().Key;
                    if (key == ConsoleKey.Enter)
                    {
                        inventory.Inventory.Remove(item);
                        inventory.CurrentCapacity--;
                        Console.WriteLine($"You have removed {item.Name} from your {inventory.Name}!");
                        break;
                    }
                    else if (key == ConsoleKey.Escape)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid command! Please insert a valid command!");
                        Console.WriteLine();
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid item! Please insert a valid item!");
                    Console.WriteLine();
                    continue;
                }
            }
        }

        public virtual void InventoryInfo(PlayerInventory inventory)
        {
            foreach (var item in inventory.Inventory)
            {
                Console.WriteLine($"{item.Name}");
            }
            Console.WriteLine($"Your {inventory.Name} capacity status : {inventory.CurrentCapacity}/{inventory.Capacity}");
        }
        
    }
}
