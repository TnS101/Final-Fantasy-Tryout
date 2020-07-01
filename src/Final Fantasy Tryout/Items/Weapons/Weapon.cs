using Final_Fantasy_Tryout.Items;
using System.Text;

namespace Final_Fantasy_Tryout.ArmorInfo
{
    public class Weapon : Item
    {
        public Weapon(string name, string type, string slot, int level, string classUsable, double attackPower, int stamina
            , int strength, int intellect, int agility, int spirit)
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
            this.AttackPower = attackPower;
        }
    }
}
