using System;
using org.mariuszgromada.math.mxparser;
using Generic_Text_Based_RPG_Epic_Edition.BaseClasses;
using Generic_Text_Based_RPG_Epic_Edition.Items;
using System.Text.Json.Serialization;

namespace Generic_Text_Based_RPG_Epic_Edition
{
    public class Player
    {
        public static Random Rand { get; set; } = new Random();

        public string Name { get; set; }
        public int Coins { get; set; } = 0;
        public int Health { get; set; } = 10; // Default Health = 10
        public int Strength { get; set; } = 1; // Default Damage = 1
        public int Defense { get; set; } = 1;

        public Weapon CurrentWeapon { get; set; }

        public int ArmorValue { get; set; } = 0;
        public int Potion { get; set; } = 5;

        public int NextLevel { get; set; } = 10;
        public int Level { get; set; } = 1;
        public int XP { get; set; } = 0;

        public int Mods { get; set; } = 0;

        public static implicit operator Player(SavePlayer sp)
        {
            Player p = new();
            p.Name = sp.Name;
            p.Coins = sp.Coins;
            p.Health = sp.Health;
            p.Strength = sp.Strength;
            p.Defense = sp.Defense;
            p.CurrentWeapon = sp.CurrentWeapon;
            p.ArmorValue = sp.ArmorValue;
            p.Potion = sp.Potion;
            p.NextLevel = sp.NextLevel;
            p.Level = sp.Level;
            p.XP = sp.XP;
            p.Mods = sp.Mods;

            return p;
        }

        public int GetHealth()
        {
            int upper = 2 * Mods + 5;
            int lower = Mods + 2;
            return Rand.Next(lower, upper + 1);
        }
        public int GetPower()
        {
            int upper = 2 * Mods + 5;
            int lower = Mods + 3;
            return Rand.Next(lower, upper + 1);
        }

        public int GetDefense()
        {
            double upper = 1 * ((Mods + 1) / 2) + 3;
            double lower = Mods + 0.5;
            return Rand.Next((int)lower, (int)upper + 1);
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
            int nextLevelCalc;

            XP += newxp;
            NextLevel -= newxp;

            if (NextLevel <= 0)
            {
                while (NextLevel <= 0)
                {
                    nextLevelCalc = XP - ((5 * (Level + 1) ^ 3) / 4) - ((5 * (Level - 1) ^ 3) / 4);

                    NextLevel += nextLevelCalc;
                    Console.WriteLine(NextLevel);
                    LevelUp();
                }
                return true;
            }
            return false;
        }

        public void LevelUp()
        {
            Console.WriteLine("You leveled up to level " + (Level + 1) + "!");
            Level += 1;
            int tempstrength = Rand.Next(1, 2);
            int temphealth = Rand.Next(2, 4);
            int temppotion = Rand.Next(3, 5);
            int tempdefense = Rand.Next(0, 2);
            Console.WriteLine("+" + tempstrength + " Damage," + " +" + temphealth + " Health," + " +" + temppotion + " Potions," + " +" + tempdefense + " Defense");
            Strength += tempstrength;
            Health += temphealth;
            Potion += temppotion;
            Defense += tempdefense;
            if (NextLevel > 0)
            {
                Console.WriteLine("You need " + NextLevel + " XP to get to the next level.");
            }
        }
    }
}
