using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_Game.Enemies
{
    public class SlimeKing : Enemy
    {
        new public void StartBattle()
        {
            name = "Slime King";
            isBoss = true;
            coinBonus = rand.Next(100, 150);
            power = rand.Next(20, 50);
            health = rand.Next(50, 100);
            xp = rand.Next(46, 70);

            PreBattle();

            Encounters.Combat(this);

            PostBattle(true, coinBonus);
        }

        new public void PreBattle()
        {
            WriteLine("Loud thuds pounce towards your wake. Fear trembles down your spine. Then you spot it! \n KING SLIME HAS APPEARED!");
            ReadKey();
        }

        new public void PostBattle(bool bonusCoins = false, int coinBonus = 0)
        {
            // Text
            WriteLine("As you collect the coins, its crown dissolves into " + coinBonus + " more coins!");
            ReadKey();
            // Code
            Program.currentPlayer.coins += coinBonus;
        }
    }
}
