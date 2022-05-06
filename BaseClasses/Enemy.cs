using System;
using System.Collections.Generic;

namespace Generic_Text_Based_RPG_Epic_Edition.BaseClasses
{
    public abstract class Enemy
    {
        public abstract string Name { get; set; }
        public abstract int Power { get; set; }
        public abstract int Health { get; set; }
        public abstract int Defense { get; set; }
        public abstract int CoinBonus { get; set; }
        public abstract int XP { get; set; }
        public abstract bool IsBoss { get; set; }

        public static Random Rand { get; set; } = new();

        public static List<Enemy> Enemies { get; set; } = new();

        public abstract void StartBattle();
        public abstract void PreBattle();
        public abstract void PostBattle(bool bonusCoins = false, int coinBonus = 0);

        public Enemy()
        {
            Enemies.Add(this);
        }
    }
}
