using Generic_Text_Based_RPG_Epic_Edition.BaseClasses;
using System;
using System.Text.Json.Serialization;

namespace Generic_Text_Based_RPG_Epic_Edition
{
    public struct SaveVarStorage
    {
        public SavePlayer Player { get; set; }
        public SaveEnemy Enemy { get; set; }
    }

    public struct SaveEnemy
    {
        public string Name { get; set; }
        public int Power { get; set; }
        public int Health { get; set; }
        public int Defense { get; set; }
        public int CoinBonus { get; set; }
        public int XP { get; set; }
        public int ID { get; set; }

        public Random Rand { get; set; }

        public static implicit operator SaveEnemy(Enemy v)
        {
            SaveEnemy se = new SaveEnemy();
            se.Power = v.Power;
            se.Health = v.Health;
            se.Defense = v.Defense;
            se.CoinBonus = v.CoinBonus;
            se.XP = v.XP;
            se.ID = v.ID;
            se.Rand = Enemy.Rand;
            return se;
        }
    }

    public struct SavePlayer
    {
        public static Random Rand { get; set; }

        public string Name { get; set; }
        public int Coins { get; set; }
        public int Health { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }

        public SaveWeapon CurrentWeapon { get; set; }

        public int ArmorValue { get; set; }
        public int Potion { get; set; }

        public int NextLevel { get; set; }
        public int Level { get; set; }
        public int XP { get; set; }

        public int Mods { get; set; }
    }

    public struct SaveWeapon
    {

    }
}
