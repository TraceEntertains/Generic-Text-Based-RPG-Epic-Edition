using System;
using Text_Based_Game.Enemies;
using static System.Console;
using static Text_Based_Game.Program;

namespace Text_Based_Game
{
    public class Encounters
    {
        static Random Rand { get; set; } = new();
        static int UsedPotions = 0;

        // Encounters

        public static void SlimeEncounter()
        {
            Clear();
            if (Rand.Next(0,21) == 1)
            {
                SlimeKing slimeKing = new();
                slimeKing.StartBattle();
            }
            else
            {
                Slime slime = new();
                slime.StartBattle();
            }

        Clear();
        }
        // Encounters Tools
        public static void RandomEncounter()
        {
            switch(Rand.Next(0,3))
            {
                case 0:
                    BasicEnemy basicEnemy = new();
                    basicEnemy.StartBattle();
                    break;
                case 1:
                    SkeletonArcher skeletonArcher = new();
                    skeletonArcher.StartBattle();
                    break;
                case 2:
                    SlimeEncounter();
                    break;
                // Legendary Slime Fight with if else statement small %                                                                                
            }
        }

        public static void Combat(Enemy enemy)
        {

            while (enemy.Health > 0)
            {
                Clear();
                WriteLine(enemy.Name);
                WriteLine(enemy.Power + " Attack" + " / " + enemy.Health + " Health");
                WriteLine("\n=====================");
                WriteLine("| (A)ttack (D)efend |");
                WriteLine("|   (R)un   (H)eal  |");
                WriteLine("=====================");
                WriteLine("Potions:  " + CurrentPlayer.Potion + "  Health:  " + CurrentPlayer.Health);
                string input = ReadKey(true).Key.ToString().ToLower();
                if (input == "a")
                {
                    Attack(enemy);
                }

                else if (input == "d")
                {
                    Defend(enemy);
                }
                else if (input == "r")
                {
                    Run(enemy);
                }
                else if (input == "h")
                {
                    Heal(enemy);
                }
                if (CurrentPlayer.Health <= 0)
                {
                    WriteLine("\nAs the " + enemy.Name + " strikes you it hits with a fatal blow!");
                    ReadKey(true);
                    System.Environment.Exit(0);
                }
            }
            int lootCoins = CurrentPlayer.CoinCalc();
            // Add A Slime Sword Later!
            WriteLine("\nAs you stand victorious over the " + enemy.Name + ", it's body dissolves into " + lootCoins + " gold coins!");
            CurrentPlayer.Coins += lootCoins;
            CurrentPlayer.LevelCheck(enemy.XP);
            UsedPotions = 0;
            ReadKey(true);
        }

        public static void Attack(Enemy enemy)
        {
            WriteLine("\nYou run forward swinging hoping to hit something! As you pass, the " + enemy.Name + " strikes you back!");
            int damage = enemy.Power - CurrentPlayer.ArmorValue;
            if (damage < 0)
                damage = 0;
            int attack = Rand.Next(0, CurrentPlayer.WeaponValue) + Rand.Next(1, 4);
            WriteLine("You lose " + damage + " health and deal " + attack + " damage");
            CurrentPlayer.Health -= damage;
            enemy.Health -= attack;
            ReadKey(true);
        }

        public static void Defend(Enemy enemy)
        {
            WriteLine("\nAs the " + enemy.Name + " prepares to strike, you ready your sword in a defensive stance!");
            int damage = (enemy.Power / 4) + 1 - (CurrentPlayer.ArmorValue - 1);
            int attack = 0;
            if (damage < 0)
                damage = 0;

            WriteLine("You lose " + damage + " health.");
            if (Rand.Next(1, 11) == 7)
            {
                attack = Rand.Next(0, CurrentPlayer.WeaponValue + 5) / 2;
                WriteLine("You get an opportunity to counterattack! The enemy takes " + attack + " damage.");
            }
            CurrentPlayer.Health -= damage;
            enemy.Health -= attack;
            ReadKey(true);
        }

        public static void Run(Enemy enemy)
        {
            if (Rand.Next(0, 2) == 0)
            {
                WriteLine("\nAs you sprint away from the " + enemy.Name + ", its strike catches you in the back, sending you sprawling onto the ground!");
                int damage = enemy.Power - CurrentPlayer.ArmorValue;
                if (damage < 0)
                    damage = 0;
                WriteLine("You lose " + damage + " health and are unable to escape.");
                CurrentPlayer.Health -= damage;
                ReadKey(true);
            }
            else
            {
                WriteLine("\nYou use your crazy mobility to evade the attacks of " + enemy.Name + " and you escape!");
                ReadKey(true);

                Shop.RunShop(CurrentPlayer);
            }
        }

        public static void Heal(Enemy enemy)
        {
            if (CurrentPlayer.Potion == 0)
            {
                WriteLine("\nAs you desperately grasp for a potion in your bag, all that you can find is empty glass flasks!");
                int damage = enemy.Power - CurrentPlayer.ArmorValue;
                if (damage < 0)
                    damage = 0;
                WriteLine("The " + enemy.Name + " strikes you with a mighty blow, and you lose " + damage + " health!");
                CurrentPlayer.Health -= damage;
            }
            else
            {
                if (UsedPotions < 3)
                {
                    WriteLine("\nYou reach into your bag and pull out a glowing, red flask. You take a swig, you feel your body lighten up.");
                    int potionV = 5;
                    WriteLine("You gain " + potionV + " health");
                    CurrentPlayer.Health += potionV;
                    WriteLine("As you were occupied, the " + enemy.Name + " advanced and struck.");
                    int damage = (enemy.Power / 2) - CurrentPlayer.ArmorValue;
                    if (damage < 0)
                        damage = 0;
                    WriteLine("You lose " + damage + " health. \nOne Potion Consumed.");
                    CurrentPlayer.Health -= damage;
                    CurrentPlayer.Potion--;
                    UsedPotions += 1;
                }
                else
                {
                    WriteLine("\nThe thought about drinking another potion sickens you.");
                }
            }
            ReadKey(true);
        }
    }
}
