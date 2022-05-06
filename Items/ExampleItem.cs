using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Text_Based_RPG_Epic_Edition.Items
{
    public class ExampleItem : Item
    {
        new public void DefineItemVars()
        {
            Name = "Example Item";
            Damage = 30;
            Bonus = 1.3;
        }
    }
}
