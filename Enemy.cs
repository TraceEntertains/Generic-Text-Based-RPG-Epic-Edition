using System.Collections.Generic;

namespace Text_Based_Game.Enemies
{
    public abstract class Enemy
    {
        public abstract string Name { get; set; }
        public abstract int Power { get; set; }
        public abstract int Health { get; set; }
        public abstract int CoinBonus { get; set; }
        public abstract int XP { get; set; }
        public abstract bool IsBoss { get; set; }

        public static List<Enemy> Enemies { get; set; }

        public abstract void StartBattle();
        public abstract void PreBattle();
        public abstract void PostBattle(bool bonusCoins = false, int coinBonus = 0);

        public Enemy()
        {
            Enemies.Add(this);
        }
    }
}
