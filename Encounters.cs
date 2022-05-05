using System;
using static System.Console;
using static Text_Based_Game.Program;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_Game
{
    public class Encounters
    {
        static Random rand = new Random();
        static int coinExponential = (int)1.2;
        //Encounter Generic

        // Encounters
        public static void FirstEncounter()
        {
            WriteLine("You see the creature start hopping towards you. You pick up a stick just to be safe.");
            WriteLine("The creature leaps towards you in a fearocious fashion.");
            WriteLine("\n(Press any key to continue)");
            ReadKey();
            Combat(false, "Slime", 1, 4);
        }
        public static void BasicFightEncounter()
        {
            Clear();
            WriteLine("You walk around the great plains and find a monster!");
            ReadKey();
            Combat(true, "", 0, 0);
        }
        public static void SkeletonArcherEncounter()
        {
            Clear();
            WriteLine("As you are walking around you found a small fortress. \nYou see a figure perched on the the top with something in hand. \nThe figure starts to fire at you!");
            ReadKey();
            int skeleArchPower = rand.Next(3, 5);
            int skeleArchHealth = rand.Next(7, 10);
            Combat(false, "Skeleton Archer", skeleArchPower, skeleArchHealth);
        }
        public static void SlimeEncounter()
        {
            Clear();
            Random slimeRNG = new Random();
            int slimePower = rand.Next(1, 4);
            int slimeHealth = rand.Next(5, 10);
            int kingSlimePower = rand.Next(20, 50);
            int kingSlimeHealth = rand.Next(50, 100);

            if (slimeRNG.Next(0,21) == 1)
            {
                WriteLine("Loud thuds pounce towards your wake. Fear trembles down your spine. Then you spot it! \n KING SLIME HAS APPEARED!");
                ReadKey();
                Combat(false, "King Slime", kingSlimePower, kingSlimeHealth);
            }

            else
            {
                WriteLine("You spot a slime in the distance.");
                ReadKey();
                Combat(false, "Slime", slimePower, slimeHealth);
            }

        Clear();
        }
        // Encounters Tools
        public static void RandomEncounter()
        {
            switch(rand.Next(0,3))
            {
                case 0:
                    BasicFightEncounter();
                    break;
                case 1:
                    SkeletonArcherEncounter();
                    break;
                case 2:
                    SlimeEncounter();
                    break;
                // Legendary Slime Fight with if else statement small %                                                                                
            }
        }
        public static void Combat(bool random, string name = "", int power = 0, int health = 0)
        {
            if (random)
            {
                name = GetName();
                power = currentPlayer.GetPower();
                health = currentPlayer.GetHealth();
            }

            while (health > 0)
            {
                Clear();
                WriteLine(name);
                WriteLine(power + " Attack" + " / " + health + " Health");
                WriteLine("\n=====================");
                WriteLine("| (A)ttack (D)efend |");
                WriteLine("|   (R)un   (H)eal  |");
                WriteLine("=====================");
                WriteLine("Potions:  " + currentPlayer.potion + "  Health:  " + currentPlayer.health);
                string input = ReadKey(true).Key.ToString().ToLower();
                if (input == "a" || input == "attack")
                {
                    // Attack
                    WriteLine("");
                    WriteLine("You run forward swinging hoping to hit something! As you pass, the " + name + " strikes you back!");
                    int damage = power - currentPlayer.armorValue;
                    if (damage < 0)
                        damage = 0;
                    int attack = rand.Next(0, currentPlayer.weaponValue) + rand.Next(1, 4);
                    WriteLine("You lose " + damage + " health and deal " + attack + " damage");
                    currentPlayer.health -= damage;
                    health -= attack;
                    ReadKey(true);
                }

                else if (input == "d")
                {
                    // Defend
                    WriteLine("");
                    WriteLine("As the " + name + " prepares to strike, you ready your sword in a defensive stance!");
                    int damage = (power / 4) - currentPlayer.armorValue;
                    if (damage < 0)
                        damage = 0;
                    int attack = rand.Next(0, currentPlayer.weaponValue) / 2;

                    WriteLine("You lose " + damage + " health and deal " + attack + " damage");
                    currentPlayer.health -= damage;
                    health -= attack;
                    ReadKey();
                }
                else if (input == "r")
                {
                    // Run
                    WriteLine("");
                    if (rand.Next(0, 2) == 0)
                    { 
                        WriteLine("As you sprint away from the " + name + ", its strike catches you in the back, sending you sprawling onto the ground!");
                        int damage = power - currentPlayer.armorValue;
                        if (damage < 0)
                            damage = 0;
                        WriteLine("You lose " + damage + " health and are unable to escape.");
                        currentPlayer.health -= damage;
                        ReadKey();
                    }
                    else
                    {
                        WriteLine("You use your crazy mobility to evade the attacks of " + name + " and you escape!");
                        ReadKey();

                        Shop.RunShop(currentPlayer);
                    }
                }
                else if (input == "h")
                {
                    // Heal
                    WriteLine("");
                    if (currentPlayer.potion == 0)
                    {
                        WriteLine("As you desperately grasp for a potion in your bag, all that you can find is empty glass flasks!");
                        int damage = power - currentPlayer.armorValue;
                        if (damage < 0)
                            damage = 0;
                        WriteLine("The " + name + " strikes you with a mighty blow, and you lose " + damage + " health!");
                    }
                    else
                    {
                        WriteLine("You reach into your bag and pull out a glowing, red flask. You take a swig, you feel your body lighten up.");
                           int potionV = 5;
                        WriteLine("You gain " + potionV + " health");
                        currentPlayer.health += potionV;
                        WriteLine("As you were occupied, the " + name + " advanced and struck.");
                            int damage = (power/2)-currentPlayer.armorValue;
                        if(damage<0)
                            damage=0;
                        WriteLine("You lose " + damage + " health. \nOne Potion Consumed.");
                        currentPlayer.potion--; 
                    }
                    ReadKey();
                }
                if (currentPlayer.health <= 0)
                {
                    WriteLine("\nAs the " + name + " strikes you it hits with a fatal blow!");
                    ReadKey();
                    System.Environment.Exit(0);
                }
            }
            int coins = (int)Math.Pow(currentPlayer.level * coinExponential, 1.5) * rand.Next(10, 50);
            // Add A Slime Sword Later!
            WriteLine("\nAs you stand victorious over the " + name + ", it's body dissolves into " + coins + " gold coins!");
            currentPlayer.coins += coins;
            ReadKey();
        }

        public static void LevelCheck()
        {

        }

        public static string GetName()
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
