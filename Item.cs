using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Text_Based_RPG_Epic_Edition
{
    public class Item
    {
        public string Name { get; set; } = "";
        public int Damage { get; set; } = 0;
        public double Bonus { get; set; } = 1.50; // interpret as a multiplier

        public void DefineItemVars()
        {

        }
    }
}
