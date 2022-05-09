using Generic_Text_Based_RPG_Epic_Edition.Enemies;
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
        public abstract int ID { get; set; }

        public static Random Rand { get; set; } = new();

        public static List<Enemy> Enemies { get; set; } = new();

        public abstract void StartBattle();
        public abstract void PreBattle();
        public abstract void PostBattle(bool bonusCoins = false, int coinBonus = 0);

        public Enemy()
        {
            Enemies.Add(this);
        }

        public static Enemy GetByID(int id)
        {
            List<Enemy> EnemiesLocal = new();
            FirstEncounter fe = new();
            BasicEnemy be = new();
            SkeletonArcher sa = new();
            Slime s = new();
            SlimeKing sk = new();
            EnemiesLocal.Add(fe);
            EnemiesLocal.Add(be);
            EnemiesLocal.Add(sa);
            EnemiesLocal.Add(s);
            EnemiesLocal.Add(sk);

            foreach (var enemy in EnemiesLocal)
            {
                if (enemy.ID == id)
                {
                    return enemy;
                }
            }
            return null;
        }
    }
}
