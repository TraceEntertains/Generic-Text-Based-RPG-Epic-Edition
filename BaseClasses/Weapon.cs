namespace Generic_Text_Based_RPG_Epic_Edition.BaseClasses
{
    public abstract class Weapon
    {
        public abstract string Name { get; set; }
        public abstract int Damage { get; set; }
        public abstract double Bonus { get; set; } // interpret as a multiplier
    }
}
