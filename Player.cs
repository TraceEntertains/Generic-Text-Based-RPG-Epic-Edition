using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_Game
{
    public class Player
    {
        Random rand { get; set; } = new Random();

        public string name { get; set; }
        public int coins { get; set; } = 0;
        public int health { get; set; } = 10; // Default Health = 10
        public int damage { get; set; } = 1; // Default Damage = 1
        public int armorValue { get; set; } = 0;
        public int potion { get; set; } = 5;
        public int weaponValue { get; set; } = 1; // Default weaponValue = 1

        public int nextLevel { get; set; } = 10;
        public int level { get; set; } = 1;
        public int xp { get; set; } = 0;

        public int mods { get; set; } = 0;

        public int GetHealth()
        {
            int upper = (2 * mods + 5);
            int lower = (mods + 2);
            return rand.Next(lower, upper);
        }
        public int GetPower()
        {
            int upper = (2 * mods + 2);
            int lower = (mods + 1);
            return rand.Next(lower, upper);
        }

        public int CoinCalc()
        {
            if (level > 3)
                return (int)(rand.Next(10, 50) + ((Math.Log(level) / Math.Sin(3) + 1) * (level + rand.Next(1, 3))));
            else
                return (int)((Math.Log(level) / Math.Sin(3) + 1) * (level + rand.Next(1, 3)));
        }

        public bool LevelCheck(int newxp) 
        {
            xp += newxp;
            nextLevel -= newxp;
            if (nextLevel <= 0)
            {
                nextLevel += (int)Math.Round((double)4 * (level ^ 3) / 5);
                LevelUp();
                return true;
            }
            return false;
        }

        public void LevelUp()
        {
            Console.WriteLine("You leveled up to level " + (level + 1) + "!");
            level += 1;
            int tempdamage = rand.Next(1, 4);
            int temphealth = rand.Next(2, 8);
            int temppotion = rand.Next(3, 6);
            Console.WriteLine("+" + tempdamage + " Damage," + " +" + temphealth + " Health," + " +" + temppotion + " Potions");
            damage += tempdamage;
            health += temphealth;
            potion += temppotion;
        }
    }
}
