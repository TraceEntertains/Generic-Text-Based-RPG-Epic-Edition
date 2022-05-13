using Generic_Text_Based_RPG_Epic_Edition.BaseClasses;
using static System.Console;

namespace Generic_Text_Based_RPG_Epic_Edition.Enemies
{
    public class FirstEncounter : Enemy
    {
        public override string Name { get; set; } = "Slime";
        public override int Power { get; set; } = 3;
        public override int Health { get; set; } = 4;
        public override int Defense { get; set; } = 2;
        public override int CoinBonus { get; set; } = 0;
        public override int XP { get; set; } = Rand.Next(1, 4);
        public override bool IsBoss { get; set; } = false;
        public override int EnemyID { get; set; } = 1;

        public override void StartBattle()
        {
            PreBattle();
            Encounters.Combat(this);
            PostBattle();
        }

        public override void PreBattle()
        {
            WriteLine("You see the creature start hopping towards you. You pick up a stick just to be safe.");
            WriteLine("The creature leaps towards you in a fearocious fashion.");
            WriteLine("\n(Press any key to continue)");
            ReadKey(true);
        }

        public override void PostBattle(bool bonusCoins = false, int coinBonus = 0)
        {

        }
    }
}
