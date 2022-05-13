using Generic_Text_Based_RPG_Epic_Edition.BaseClasses;

namespace Generic_Text_Based_RPG_Epic_Edition.Items
{
    public class SlimeSword : Weapon
    {
        public override int ItemID { get; set; } = 2;

        public override string Name { get; set; } = "Slime Sword";
        public override int Damage { get; set; } = 10;
        public override double Bonus { get; set; } = 1;
    }
}
