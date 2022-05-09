using Generic_Text_Based_RPG_Epic_Edition.BaseClasses;
using System;
using static System.Console;

namespace Generic_Text_Based_RPG_Epic_Edition.Enemies
{
    public class BasicEnemy : Enemy
    {
        public override string Name { get; set; } = GetName();
        public override int Power { get; set; } = Program.CurrentPlayer.GetPower();
        public override int Health { get; set; } = Program.CurrentPlayer.GetHealth();
        public override int Defense { get; set; } = Program.CurrentPlayer.GetDefense();
        public override int CoinBonus { get; set; } = 0;
        public override int XP { get; set; } = Rand.Next(1, 4);
        public override bool IsBoss { get; set; } = false;
        public override int ID { get; set; } = 0;

        public override void StartBattle()
        {
            PreBattle();
            Encounters.Combat(this);
            PostBattle();
        }

        public override void PreBattle()
        {
            Clear();
            WriteLine("You walk around the great plains and find a monster!");
            ReadKey(true);
        }

        public override void PostBattle(bool bonusCoins = false, int coinBonus = 0)
        {

        }

        public static string GetName()
        {
            switch (Rand.Next(0, 4))
            {
                //Add More Enemies Later
                case 0:
                    return "Skeleton";
                case 1:
                    return "Zombie";
                case 2:
                    return "Low Class Demon";
                case 3:
                    return "Demon Bunny";
                default:
                    break;
            }
            return "Bandit";
        }
    }
}
