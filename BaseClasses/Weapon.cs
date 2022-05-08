using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Generic_Text_Based_RPG_Epic_Edition.BaseClasses
{
    public abstract class Weapon : Item
    {
        public Weapon() : base()
        {

        }

        public override ItemTypes ItemType { get; set; } = ItemTypes.Weapon;

        public abstract int Damage { get; set; }
        public abstract double Bonus { get; set; } // interpret as a multiplier
    }
}
