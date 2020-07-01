using Final_Fantasy_Tryout.ArmorInfo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Fantasy_Tryout.Items
{
    public abstract class Item : IItem
    {
        public  string Name { get; set; }

        public  string Type { get; set; }

        public  int Level { get; set; }

        public  string ClassUsable { get; set; }

        public  int Stamina { get; set; }

        public  int Strength { get; set; }

        public  int Agility { get; set; }

        public  int Intellect { get; set; }

        public  int Spirit { get; set; }

        public double AttackPower { get; set; }

        public double ArmorValue { get; set; }

        public double RessistanceValue { get; set; }

        public string Slot { get; set; }

        public string GetInfo()
        {
            var sb = new StringBuilder();
            sb.AppendLine($" Name : {this.Name}");
            sb.AppendLine($" Level : {this.Level}");
            sb.AppendLine($" Type : {this.Type}");
            sb.AppendLine($" Type : {this.Slot}");
            sb.AppendLine($" Usable for : {this.ClassUsable}");
            sb.AppendLine($" Stamina : {this.Stamina}");
            sb.AppendLine($" Strength : {this.Strength}");
            sb.AppendLine($" Agility : {this.Agility}");
            sb.AppendLine($" Intellect : {this.Intellect}");
            sb.AppendLine($" Spirit : {this.Spirit}");
            if (this.Type == "Weapon")
            {
                sb.AppendLine($" Attack Power : {this.AttackPower:f2}");
            }
            else if (this.Type == "Armor")
            {
                sb.AppendLine($" Armor Value : {this.ArmorValue:f2}");
                sb.AppendLine($" Ressistance Value : {this.RessistanceValue:f2}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
