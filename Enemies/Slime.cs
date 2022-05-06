using System;
using static System.Console;

namespace Text_Based_Game.Enemies
{
    public class Slime : Enemy
    {
        public override string Name { get; set; } = "Slime";
        public override int Power { get; set; } = Rand.Next(1, 4);
        public override int Health { get; set; } = Rand.Next(5, 10);
        public override int CoinBonus { get; set; } = 0;
        public override int XP { get; set; } = Rand.Next(2, 5);
        public override bool IsBoss { get; set; } = false;

        public override void StartBattle()
        {
            PreBattle();
            Encounters.Combat(this);
            PostBattle();
        }

        public override void PreBattle()
        {
            WriteLine("You spot a blue little blob in the distance that is hastily approaching!.");
            ReadKey();
        }

        public override void PostBattle(bool bonusCoins = false, int coinBonus = 0)
        {

        }
    }
}
