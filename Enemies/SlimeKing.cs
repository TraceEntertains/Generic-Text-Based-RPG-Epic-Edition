using System;
using static System.Console;

namespace Text_Based_Game.Enemies
{
    public class SlimeKing : Enemy
    {
        public static Random Rand { get; set; } = new();

        public override string Name { get; set; } = "Slime King";
        public override int Power { get; set; } = Rand.Next(20, 50);
        public override int Health { get; set; } = Rand.Next(50, 100);
        public override int CoinBonus { get; set; } = Rand.Next(100, 150);
        public override int XP { get; set; } = Rand.Next(46, 70);
        public override bool IsBoss { get; set; } = true;

        public override void StartBattle()
        {
            PreBattle();
            Encounters.Combat(this);
            PostBattle(true, CoinBonus);
        }

        public override void PreBattle()
        {
            WriteLine("Loud thuds pounce towards your wake. Fear trembles down your spine. Then you spot it! \n KING SLIME HAS APPEARED!");
            ReadKey();
        }

        public override void PostBattle(bool bonusCoins = false, int coinBonus = 0)
        {
            // Text
            WriteLine("As you collect the coins, its crown dissolves into " + coinBonus + " more coins!");
            ReadKey();
            // Code
            Program.CurrentPlayer.Coins += coinBonus;
        }
    }
}
