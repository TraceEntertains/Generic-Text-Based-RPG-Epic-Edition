using Generic_Text_Based_RPG_Epic_Edition.BaseClasses;
using System;
using static System.Console;

namespace Generic_Text_Based_RPG_Epic_Edition.Enemies
{
    public class SlimeKing : Enemy
    {
        public override string Name { get; set; } = "Slime King";
        public override int Power { get; set; } = Rand.Next(20, 50);
        public override int Health { get; set; } = Rand.Next(50, 100);
        public override int Defense { get; set; } = Rand.Next(20, 40);
        public override int CoinBonus { get; set; } = Rand.Next(100, 150);
        public override int XP { get; set; } = Rand.Next(46, 70);
        public override bool IsBoss { get; set; } = true;
        public override int ID { get; set; } = 4;

        public override void StartBattle()
        {
            PreBattle();
            Encounters.Combat(this);
            PostBattle(true, CoinBonus);
        }

        public override void PreBattle()
        {
            WriteLine("Loud thuds pounce towards your wake. Fear trembles down your spine. Then you spot it! \nKING SLIME HAS APPEARED!");
            ReadKey(true);
        }

        public override void PostBattle(bool bonusCoins = false, int coinBonus = 0)
        {
            // Text
            WriteLine("As you collect the coins, its crown dissolves into " + coinBonus + " more coins!");
            ReadKey(true);
            // Code
            Program.CurrentPlayer.Coins += coinBonus;
        }
    }
}
