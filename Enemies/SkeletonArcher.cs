using Generic_Text_Based_RPG_Epic_Edition.BaseClasses;
using System;
using static System.Console;

namespace Generic_Text_Based_RPG_Epic_Edition.Enemies
{
    public class SkeletonArcher : Enemy
    {
        public override string Name { get; set; } = "Skeleton Archer";
        public override int Defense { get; set; } = Rand.Next(3, 5);
        public override int Power { get; set; } = Rand.Next(4, 6);
        public override int Health { get; set; } = Rand.Next(7, 10);
        public override int CoinBonus { get; set; } = Rand.Next(30, 70);
        public override int XP { get; set; } = Rand.Next(3, 6);
        public override bool IsBoss { get; set; } = false;
        public override int ID { get; set; } = 2;

        public override void StartBattle()
        {
            PreBattle();
            Encounters.Combat(this);
            PostBattle(true, CoinBonus);
        }

        public override void PreBattle()
        {
            Clear();
            WriteLine("As you are walking around you found a small fortress. \nYou see a figure perched on the the top with something in hand. \nThe figure starts to fire at you!");
            ReadKey(true);
        }

        public override void PostBattle(bool bonusCoins = false, int coinBonus = 0)
        {
            // Text
            WriteLine("As you collect the coins, its bow dissolves into " + coinBonus + " more coins!");
            ReadKey(true);
            // Code
            Program.CurrentPlayer.Coins += coinBonus;
        }
    }
}
