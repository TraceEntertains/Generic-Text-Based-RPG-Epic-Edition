using System;
using Generic_Text_Based_RPG_Epic_Edition.BaseClasses;
using Generic_Text_Based_RPG_Epic_Edition.Enemies;
using static System.Console;
using static Generic_Text_Based_RPG_Epic_Edition.Program;
using System.Windows.Input;

namespace Generic_Text_Based_RPG_Epic_Edition
{
    public class Encounters
    {
        public static bool TextSkip = false;
        static Random Rand { get; set; } = new();
        static int UsedPotions = 0;

        public static bool IsAnyKeyDown()
        {
            var values = Enum.GetValues(typeof(Key));

            foreach (var v in values)
                if (((Key)v) != Key.None && Keyboard.IsKeyDown((Key)v))
                    return true;

            return false;
        }

        public static void Print(string text, int msgap = 30)
        {
            var remaining = text;
            if (TextSkip == false)
            {
                foreach (char c in text)
                {
                    Write(c);
                    remaining = remaining.Remove(0, 1);

                    System.Threading.Thread.Sleep(msgap);
                    if (IsAnyKeyDown())
                    {
                        Write(remaining);

                        TextSkip = true;
                        break;
                    }
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
            if (Rand.Next(0,21) == 1)
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
            CurrentEnemy = enemy;

            while (enemy.Health > 0)
            {
                Clear();
                Print(enemy.Name, 10);
                Print(enemy.Power + " Attack" + " / " + enemy.Health + " Health" + " / " + enemy.Defense + " Defense", 10);
                Print("\n=====================", 10);
                Print("| (A)ttack (D)efend |", 10);
                Print("|   (R)un   (H)eal  |", 10);
                Print("=====================", 10);
                Print("Potions:  " + CurrentPlayer.Potion + "  Health:  " + CurrentPlayer.Health);
                while (true)
                {
                    string input = ReadKey(true).Key.ToString().ToLower();
                    if (input == "a")
                    {
                        Attack(enemy);
                        break;
                    }
                    else if (input == "d")
                    {
                        Defend(enemy);
                        break;
                    }
                    else if (input == "r")
                    {
                        Run(enemy);
                        break;
                    }
                    else if (input == "h")
                    {
                        Heal(enemy);
                        break;
                    }
                }
                if (CurrentPlayer.Health <= 0)
                {
                    CurrentEnemy = enemy;

                    Print("\nAs the " + enemy.Name + " strikes you it hits with a fatal blow!");
                    ReadKey(true);
                    Environment.Exit(0);
                }
            }
            int lootCoins = CurrentPlayer.CoinCalc();
            // Add A Slime Sword Later!
            Print("\nAs you stand victorious over the " + enemy.Name + ", it's body dissolves into " + lootCoins + " gold coins!");
            CurrentPlayer.Coins += lootCoins;
            CurrentPlayer.LevelCheck(enemy.XP);
            UsedPotions = 0;
            ReadKey(true);
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
            CurrentPlayer.Health -= damage;
            enemy.Health -= attack;
            ReadKey(true);
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
                Print("You get an opportunity to counterattack! The enemy takes " + attack + " damage.");
            }
            CurrentPlayer.Health -= damage;
            enemy.Health -= attack;
            ReadKey(true);
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
                CurrentPlayer.Health -= damage;
                ReadKey(true);
            }
            else
            {
                Print("\nYou use your crazy mobility to evade the attacks of " + enemy.Name + " and you escape!");
                ReadKey(true);

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
                    Print("You gain " + potionV + " health");
                    CurrentPlayer.Health += potionV;
                    Print("\nAs you were occupied, the " + enemy.Name + " advanced and struck.");
                    int damage = (enemy.Power / 2) - (CurrentPlayer.ArmorValue + CurrentPlayer.Defense + Rand.Next(1, 4));
                    if (damage < 0)
                        damage = 0;
                    Print("You lose " + damage + " health. \n\nOne Potion Consumed.");
                    CurrentPlayer.Health -= damage;
                    CurrentPlayer.Potion--;
                    UsedPotions += 1;
                }
                else
                {
                    Print("\nThe thought of drinking even one more potion sickens you.");
                }
            }
            ReadKey(true);
        }
    }
}
