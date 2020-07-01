using Final_Fantasy_Tryout.Units.PlayerInfo;

namespace Final_Fantasy_Tryout.Inventory
{
    public class Bag : PlayerInventory
    {
        private const string name = "Bag";
        private const int capacity = 50;
        public Bag()
        {
            this.Name = name;
            this.Capacity = capacity;
        }
    }
}
