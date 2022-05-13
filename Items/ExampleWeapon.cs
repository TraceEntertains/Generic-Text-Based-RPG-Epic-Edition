using Generic_Text_Based_RPG_Epic_Edition.BaseClasses;

namespace Generic_Text_Based_RPG_Epic_Edition.Items
{
    public class ExampleWeapon : Weapon
    {
        public override int ItemID { get; set; } = 0;

        public override string Name { get; set; } = "Example Item";
        public override int Damage { get; set; } = 30;
        public override double Bonus { get; set; } = 1.3;
    }
}
