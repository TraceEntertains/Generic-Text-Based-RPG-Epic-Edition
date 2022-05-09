using Generic_Text_Based_RPG_Epic_Edition.BaseClasses;
using System;
using static System.Console;

namespace Generic_Text_Based_RPG_Epic_Edition.Enemies
{
    public class Slime : Enemy
    {
        public override string Name { get; set; } = "Slime";
        public override int Power { get; set; } = Rand.Next(3, 6);
        public override int Health { get; set; } = Rand.Next(5, 10);
        public override int Defense { get; set; } = Rand.Next(1, 4);
        public override int CoinBonus { get; set; } = 0;
        public override int XP { get; set; } = Rand.Next(2, 5);
        public override bool IsBoss { get; set; } = false;
        public override int ID { get; set; } = 3;

        public override void StartBattle()
        {
            PreBattle();
            Encounters.Combat(this);
            PostBattle();
        }

        public override void PreBattle()
        {
            WriteLine("You spot a blue little blob in the distance that is hastily approaching!.");
            ReadKey(true);
        }

        public override void PostBattle(bool bonusCoins = false, int coinBonus = 0)
        {

        }
    }
}
