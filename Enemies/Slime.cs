using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_Game.Enemies
{
    public class Slime : Enemy
    {
        new public void StartBattle()
        {
            name = "Slime";
            power = rand.Next(1, 4);
            health = rand.Next(5, 10);
            xp = rand.Next(3, 5);

            PreBattle();

            Encounters.Combat(this);

            PostBattle();
        }

        new public void PreBattle()
        {
            WriteLine("You spot a blue little blob in the distance that is hastily approaching!.");
            ReadKey();
        }

        new public void PostBattle(bool bonusCoins = false, int coinBonus = 0)
        {

        }
    }
}
