using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_Game.Enemies
{
    public class BasicEnemy : Enemy
    {
        new public void StartBattle()
        {
            Name = GetName();
            Power = Program.currentPlayer.GetPower();
            Health = Program.currentPlayer.GetPower();
            xp = rand.Next(3, 5);

            PreBattle();

            Encounters.Combat(this);

            PostBattle();
        }

        new public void PreBattle()
        {
            Clear();
            WriteLine("You walk around the great plains and find a monster!");
            ReadKey();
        }

        new public void PostBattle(bool bonusCoins = false, int coinBonus = 0)
        {

        }

        public string GetName()
        {
            switch (rand.Next(0, 4))
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
            }
            return "Bandit";
        }
    }
}
