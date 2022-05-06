﻿using System;
using static System.Console;

namespace Text_Based_Game.Enemies
{
    public class BasicEnemy : Enemy
    {
        public override string Name { get; set; } = GetName();
        public override int Power { get; set; } = Program.CurrentPlayer.GetPower();
        public override int Health { get; set; } = Program.CurrentPlayer.GetPower();
        public override int CoinBonus { get; set; } = 0;
        public override int XP { get; set; } = Rand.Next(3, 5);
        public override bool IsBoss { get; set; } = false;

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
            ReadKey();
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
