using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Text_Based_RPG_Epic_Edition.Items
{
    public class slimeSword : Generic_Text_Based_RPG_Epic_Edition.BaseClasses.Weapon
    {
        public override int ID { get; set; } = 2;

        public override string Name { get; set; } = "Slime Sword";
        public override int Damage { get; set; } = 10;
        public override double Bonus { get; set; } = 1;
    }
}
