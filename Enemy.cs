using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_Game.Enemies
{
    public class Enemy
    {
        public Random rand = new();

        public string Name { get; set; } = "";
        public int Power { get; set; } = 1;
        public int Health { get; set; } = 1;
        public int coinBonus = 0;
        public int XP = 0;
        public bool isBoss = false;

        public static List<Enemy> enemies = new();

        public Enemy()
        {
            enemies.Add(this);
        }

        public static Enemy Find<TClass>()
        {
            foreach (Enemy enemy in enemies)
            {
                if (enemy.GetType() == typeof(TClass))
                {
                    return enemy;
                }
            }
            return null;
        }

        public void StartBattle()
        {

        }
        
        public void PreBattle()
        {

        }

        public void PostBattle(bool bonusCoins = false, int coinBonus = 0)
        {
            
        }
    }
}
