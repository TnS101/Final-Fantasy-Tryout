using Final_Fantasy_Tryout.Items;

namespace Final_Fantasy_Tryout.ArmorInfo
{
    public class Armor : Item
    {
        public Armor(string name, string type, string slot, int level
            , string classUsable, int stamina
            , int strength, int intellect, int agility
            , int spirit, double armorValue, double ressistanceValue)
        {
            this.Name = name;
            this.Type = type;
            this.Slot = slot;
            this.Level = level;
            this.ClassUsable = classUsable;
            this.Stamina = stamina;
            this.Strength = strength;
            this.Intellect = intellect;
            this.Agility = agility;
            this.Spirit = spirit;
            this.ArmorValue = armorValue;
            this.RessistanceValue = ressistanceValue;
        }
    }
}
