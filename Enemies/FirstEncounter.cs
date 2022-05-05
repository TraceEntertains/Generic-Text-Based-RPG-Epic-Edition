using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_Game.Enemies
{
    public class FirstEncounter : Enemy
    {
        new public void StartBattle()
        {
            name = "Slime";
            power = 1;
            health = 4;
            xp = rand.Next(3, 5);

            PreBattle();

            Encounters.Combat(this);

            PostBattle();
        }

        new public void PreBattle()
        {
            WriteLine("You see the creature start hopping towards you. You pick up a stick just to be safe.");
            WriteLine("The creature leaps towards you in a fearocious fashion.");
            WriteLine("\n(Press any key to continue)");
            ReadKey();
        }

        new public void PostBattle(bool bonusCoins = false, int coinBonus = 0)
        {

        }
    }
}
