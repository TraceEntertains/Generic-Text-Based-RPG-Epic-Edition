using System;

namespace Text_Based_Game
{
    public class Player
    {
        Random Rand { get; set; } = new Random();

        public string Name { get; set; }
        public int Coins { get; set; } = 0;
        public int Health { get; set; } = 10; // Default Health = 10
        public int Damage { get; set; } = 1; // Default Damage = 1
        public int ArmorValue { get; set; } = 0;
        public int Potion { get; set; } = 5;
        public int WeaponValue { get; set; } = 1; // Default weaponValue = 1

        public int NextLevel { get; set; } = 10;
        public int Level { get; set; } = 1;
        public int XP { get; set; } = 0;

        public int Mods { get; set; } = 0;

        public int GetHealth()
        {
            int upper = (2 * Mods + 5);
            int lower = (Mods + 2);
            return Rand.Next(lower, upper);
        }
        public int GetPower()
        {
            int upper = (2 * Mods + 2);
            int lower = (Mods + 1);
            return Rand.Next(lower, upper);
        }

        public int CoinCalc()
        {
            if (Level > 3)
                return (int)(Rand.Next(10, 50) + ((Math.Log(Level) / Math.Sin(3) + 1) * (Level + Rand.Next(1, 3))));
            else
                return (int)((Math.Log(Level) / Math.Sin(3) + 1) * (Level + Rand.Next(1, 3)));
        }

        public bool LevelCheck(int newxp) 
        {
            XP += newxp;
            NextLevel -= newxp;
            if (NextLevel <= 0)
            {
                NextLevel += (int)Math.Round((double)4 * (Level ^ 3) / 5);
                LevelUp();
                return true;
            }
            return false;
        }

        public void LevelUp()
        {
            Console.WriteLine("You leveled up to level " + (Level + 1) + "!");
            Level += 1;
            int tempdamage = Rand.Next(1, 4);
            int temphealth = Rand.Next(2, 8);
            int temppotion = Rand.Next(3, 6);
            Console.WriteLine("+" + tempdamage + " Damage," + " +" + temphealth + " Health," + " +" + temppotion + " Potions");
            Damage += tempdamage;
            Health += temphealth;
            Potion += temppotion;
        }
    }
}
