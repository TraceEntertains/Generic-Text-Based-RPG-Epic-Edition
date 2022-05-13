using Generic_Text_Based_RPG_Epic_Edition.BaseClasses;
using Generic_Text_Based_RPG_Epic_Edition.Enemies;
using Microsoft.Xna.Framework.Input;
using System;
using static Generic_Text_Based_RPG_Epic_Edition.Program;
using static System.Console;

namespace Generic_Text_Based_RPG_Epic_Edition
{
    public class Encounters
    {

        public static ConsoleKey input;
        public static int SleepTime = 50;

        public static bool TextSkip = false;
        static Random Rand { get; set; } = new();
        static int UsedPotions = 0;

        public static void Print(string text, int msgap = 20)
        {
            var remaining = text;
            if (TextSkip == false)
            {
                foreach (char c in text)
                {
                    Write(c);
                    remaining = remaining.Remove(0, 1);

                    System.Threading.Thread.Sleep(msgap); // TODO: Fix IsKeyDown()
                    /*if (kbs.IsKeyDown(Keys.Space)|| kbs.IsKeyDown(Keys.Enter))
                    {
                        Write(remaining);

                        TextSkip = true;
                        break;
                    }*/
                }
            }
            else
                Write(text);
            WriteLine();
        }

        // Encounters

        public static void SlimeEncounter()
        {
            Clear();
            if (Rand.Next(0, 21) == 1)
            {
                if (CurrentPlayer.Level >= 20)
                {
                    SlimeKing slimeKing = new();
                    slimeKing.StartBattle();
                }
                else
                {
                    Slime slime = new();
                    slime.StartBattle();
                }
            }
            else
            {
                Slime slime = new();
                slime.StartBattle();
            }
        }

        // Encounters Tools
        public static void RandomEncounter()
        {
            switch (Rand.Next(0, 3))
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
            }
        }

        public static void Combat(Enemy enemy)
        {
            CurrentEnemy = enemy;

            while (enemy.Health > 0)
            {
                TextSkip = true;
                Clear();
                Print(enemy.Name, 10);
                Print(enemy.Power + " Attack" + " / " + enemy.Health + " Health" + " / " + enemy.Defense + " Defense", 10);
                Print("\n=====================", 0);
                Print("| (A)ttack (D)efend |", 0);
                Print("|   (R)un   (H)eal  |", 0);
                Print("=====================", 0);
                Print("Potions:  " + CurrentPlayer.Potion + "  Health:  " + CurrentPlayer.Health + "/" + CurrentPlayer.MaxHealth, 10);
                while (true)
                {
                    input = ReadKey(true).Key;
                    if (input == ConsoleKey.A)
                    {
                        TextSkip = false;
                        Attack(enemy);
                        break;
                    }
                    else if (input == ConsoleKey.D)
                    {
                        TextSkip = false;
                        Defend(enemy);
                        break;
                    }
                    else if (input == ConsoleKey.R)
                    {
                        TextSkip = false;
                        Run(enemy);
                        break;
                    }
                    else if (input == ConsoleKey.H)
                    {
                        TextSkip = false;
                        Heal(enemy);
                        break;
                    }
                }
                if (CurrentPlayer.Health <= 0)
                {
                    TextSkip = false;

                    CurrentEnemy = enemy;

                    Print("\nAs the " + enemy.Name + " strikes you it hits with a fatal blow!");
                    Print("\n (Press R To Restart) \n (Press Enter to Exit Game)");
                    while (true)
                    {
                        input = ReadKey(true).Key;
                        if (input == ConsoleKey.Enter)
                            Environment.Exit(0); //Restart System
                    }


                }
            }
            int lootCoins = CurrentPlayer.CoinCalc();
            TextSkip = false;
            Print("\nAs you stand victorious over the " + enemy.Name + ", its body dissolves into " + lootCoins + " gold coins!");
            ReadKey(true);
            CurrentPlayer.Coins += lootCoins;
            CurrentPlayer.LevelCheck(enemy.XP);
            UsedPotions = 0;
        }

        public static void Attack(Enemy enemy)
        {
            Print("\nYou run forward swinging hoping to hit something! As you pass, the " + enemy.Name + " strikes you back!");
            int damage = enemy.Power - (CurrentPlayer.ArmorValue + CurrentPlayer.Defense + Rand.Next(1, 4));
            if (damage < 0)
                damage = 0;
            int attack = Rand.Next(0, CurrentPlayer.CurrentWeapon.Damage + CurrentPlayer.Strength) + Rand.Next(1, 4) - enemy.Defense;
            if (attack < 0)
                attack = 1;
            Print("You lose " + damage + " health and deal " + attack + " damage");
            Print("\n(Press Enter To Continue)");
            while (true)
            {
                input = ReadKey(true).Key;
                if (input == ConsoleKey.Enter)
                    break;
            }
            CurrentPlayer.Health -= damage;
            enemy.Health -= attack;
        }

        public static void Defend(Enemy enemy)
        {
            Print("\nAs the " + enemy.Name + " prepares to strike, you ready your sword in a defensive stance!");
            int damage = (enemy.Power / 4) + 1 - (CurrentPlayer.ArmorValue - 1 + CurrentPlayer.Defense + Rand.Next(1, 4));
            int attack = 0;
            if (damage < 0)
                damage = 0;

            Print("You lose " + damage + " health.");
            if (Rand.Next(1, 11) == 7)
            {
                attack = Rand.Next(3, CurrentPlayer.CurrentWeapon.Damage + CurrentPlayer.Strength + 5) - enemy.Defense;
                Print("\nYou get an opportunity to counterattack! The enemy takes " + attack + " damage.");

            }
            Print("\n(Press Enter To Continue)");
            while (true)
            {
                input = ReadKey(true).Key;
                if (input == ConsoleKey.Enter)
                    break;
            }
            CurrentPlayer.Health -= damage;
            enemy.Health -= attack;
        }

        public static void Run(Enemy enemy)
        {
            if (Rand.Next(0, 2) == 0)
            {
                Print("\nAs you sprint away from the " + enemy.Name + ", its strike catches you in the back, sending you sprawling onto the ground!");
                int damage = enemy.Power - (CurrentPlayer.ArmorValue + CurrentPlayer.Defense + Rand.Next(1, 4));
                if (damage < 0)
                    damage = 0;
                Print("You lose " + damage + " health and are unable to escape.");
                Print("\n(Press Enter To Continue)");
                while (true)
                {
                    input = ReadKey(true).Key;
                    if (input == ConsoleKey.Enter)
                        break;
                }
                CurrentPlayer.Health -= damage;
            }
            else
            {
                Print("\nYou use your crazy mobility to evade the attacks of " + enemy.Name + " and you escape!");
                Print("\n(Press Enter To Continue)");
                while (true)
                {
                    input = ReadKey(true).Key;
                    if (input == ConsoleKey.Enter)
                        break;
                }

                CurrentEnemy = enemy;
                Shop.RunShop(CurrentPlayer);
            }
        }

        public static void Heal(Enemy enemy)
        {
            if (CurrentPlayer.Potion == 0)
            {
                Print("\nAs you desperately grasp for a potion in your bag, all that you can find is empty glass flasks!");
                int damage = enemy.Power - (CurrentPlayer.ArmorValue + CurrentPlayer.Defense + Rand.Next(1, 4));
                if (damage < 0)
                    damage = 0;
                Print("The " + enemy.Name + " strikes you with a mighty blow, and you lose " + damage + " health!");
                CurrentPlayer.Health -= damage;
            }
            else
            {
                if (UsedPotions < 3)
                {
                    Print("\nYou reach into your bag and pull out a glowing, red flask. You take a swig, you feel your body lighten up.");
                    int potionV = 5;
                    if (potionV + CurrentPlayer.Health > CurrentPlayer.MaxHealth)
                    {
                        potionV = CurrentPlayer.MaxHealth - CurrentPlayer.Health;
                    }
                    Print("You gain " + potionV + " health");
                    CurrentPlayer.Health += potionV;
                    Print("\nAs you were occupied, the " + enemy.Name + " advanced and struck.");
                    int damage = (enemy.Power / 2) - (CurrentPlayer.ArmorValue + CurrentPlayer.Defense + Rand.Next(1, 4));
                    if (damage < 0)
                        damage = 0;
                    UsedPotions += 1;
                    Print("You lose " + damage + " health.");
                    if (UsedPotions == 1)
                        Print("\n1/3 Potions Used.");
                    else if (UsedPotions == 2)
                        Print("\n2/3 Potions Used");
                    else if (UsedPotions == 3)
                        Print("\n3/3 Potions Used");

                    CurrentPlayer.Health -= damage;
                    CurrentPlayer.Potion--;
                }
                else
                {
                    Print("\nThe thought of drinking even one more potion sickens you.");
                }
            }
            Print("\n(Press Enter To Continue)");
            while (true)
            {
                input = ReadKey(true).Key;
                if (input == ConsoleKey.Enter)
                    break;
            }
        }
    }
}
