using Generic_Text_Based_RPG_Epic_Edition.BaseClasses;

namespace Generic_Text_Based_RPG_Epic_Edition.Items
{
    public class Stick : Weapon
    {
        public override int ItemID { get; set; } = 1;

        public override string Name { get; set; } = "Stick";
        public override int Damage { get; set; } = 1;
        public override double Bonus { get; set; } = 1; // 1 is no bonus as the bonus is interpreted as a multiplier.
    }
}
