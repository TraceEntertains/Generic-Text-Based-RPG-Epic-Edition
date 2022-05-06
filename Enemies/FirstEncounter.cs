using static System.Console;

namespace Text_Based_Game.Enemies
{
    public class FirstEncounter : Enemy
    {
        public override string Name { get; set; } = "Slime";
        public override int Power { get; set; } = 1;
        public override int Health { get; set; } = 4;
        public override int CoinBonus { get; set; } = 0;
        public override int XP { get; set; } = Rand.Next(1, 4);
        public override bool IsBoss { get; set; } = false;

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
            ReadKey();
        }

        public override void PostBattle(bool bonusCoins = false, int coinBonus = 0)
        {

        }
    }
}
