using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_Game.Enemies
{
    public class SkeletonArcher : Enemy
    {

        new public void StartBattle()
        {
            name = "Skeleton Archer";
            coinBonus = rand.Next(30, 70);
            power = rand.Next(3, 5);
            health = rand.Next(7, 10);
            xp = rand.Next(3, 5);

            PreBattle();

            Encounters.Combat(this);

            PostBattle(true, coinBonus);
        }

        new public void PreBattle()
        {
            Clear();
            WriteLine("As you are walking around you found a small fortress. \nYou see a figure perched on the the top with something in hand. \nThe figure starts to fire at you!");
            ReadKey();
        }

        new public void PostBattle(bool bonusCoins = false, int coinBonus = 0)
        {
            // Text
            WriteLine("As you collect the coins, its bow dissolves into " + coinBonus + " more coins!");
            ReadKey();
            // Code
            Program.currentPlayer.coins += coinBonus;
        }
    }
}
