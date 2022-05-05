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
        public Random rand = new Random();

        public string name = "";
        public int power = 1;
        public int health = 1;
        public int coinBonus = 0;
        public int xp = 0;
        public bool isBoss = false;

        public static List<Enemy> enemies = new List<Enemy>();

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
