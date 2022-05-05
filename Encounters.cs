using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_Game
{
    public class Encounters
    {
        static Random rand = new Random();
        //Ecounter Genertic

        // Ecounters
        public static void FirstEncounter()
        {
            Console.WriteLine("You see the creature start hopping towards you. You pick up a stick just to be safe.");
            Console.WriteLine("The creature leaps towards you in a fearious fasion.");
            Console.WriteLine("\n(press any key to countine)");
            Console.ReadKey();
            Combat(false, "Slime", 1, 4);
        }
        public static void BasicFightEncounter()
        {
            Console.Clear();
            Console.WriteLine("You walk around the great plans and find a monster!");
            Console.ReadKey();
            Combat(true, "", 0, 0);
        }
        public static void SkeletonArcherEncounter()
        {
            Console.Clear();
            Console.WriteLine("As you are walking around you found a small fortress. \nYou see a figured purched on the the top with something in hand. \nThe figure starts to fire at you!");
            Console.ReadKey();
            int SkeleArchPower = rand.Next(3, 5);
            int SkeleArchHealth = rand.Next(7, 10);
            Combat(false, "Skeleton Archer", SkeleArchPower, SkeleArchHealth);
        }
        public static void SlimeEncounter()
        {
            Console.Clear();
            Random slimeRNG = new Random();
            int slimePower = rand.Next(1, 4);
            int slimeHealth = rand.Next(5, 10);
            int kingSlimePower = rand.Next(20, 50);
            int kingSlimeHealth = rand.Next(50, 100);

            if (slimeRNG.Next(0,21) == 1)
            {
                Console.WriteLine("Loud thuds pounce towards your wake. Fear trembels down your spine. Then you spot it! \n KING SLIME HAS APPEARED!");
                Console.ReadKey();
                Combat(false, "King Slime", kingSlimePower, kingSlimeHealth);
            }

            else
            {
                Console.WriteLine("You spot a slime in the distance.");
                Console.ReadKey();
                Combat(false, "Slime", slimePower, slimeHealth);
            }

        Console.Clear();
        }
        // Ecounters Tools
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
        public static void Combat(bool random, string name, int power, int health)
        {
            string n = "";
            int p = 0;
            int h = 0;

            if (random)
            {
                n = GetName();
                p = Program.currentPlayer.GetPower();
                h = Program.currentPlayer.GetHealth();
            }
            else
            {
                n = name;
                p = power;
                h = health;
            }
            while (h > 0)
            {
                Console.Clear();
                Console.WriteLine(n);
                Console.WriteLine(p + " Attack" + " / " + h + " Health");
                Console.WriteLine("\n=====================");
                Console.WriteLine("| (A)ttack (D)efend |");
                Console.WriteLine("|   (R)un   (H)eal  |");
                Console.WriteLine("=====================");
                Console.WriteLine("Potions:  " + Program.currentPlayer.potion + "  Health:  " + Program.currentPlayer.health);
                string input = Console.ReadKey(true).Key.ToString();
                if (input.ToLower() == "a" || input.ToLower() == "attack")
                {
                    // Attack
                    Console.WriteLine("\nYou run foward swinging hoping to hit something! As you pass, the " + n + " strikes you back!");
                    int damage = p - Program.currentPlayer.armorValue;
                    if (damage < 0)
                        damage = 0;
                    int attack = rand.Next(0, Program.currentPlayer.weaponValue) + rand.Next(1, 4);
                    Console.WriteLine("You lose " + damage + " health and deal " + attack + " damage");
                    Program.currentPlayer.health -= damage;
                    h -= attack;
                    _ = Console.ReadKey(true).Key.ToString();
                }

                else if (input.ToLower() == "d" || input.ToLower() == "defend")
                {
                    // Defend
                    Console.WriteLine("As the " + n + " prepares to strike, you ready your sword in a defensive stance!");
                    int damage = (p / 4) - Program.currentPlayer.armorValue;
                    if (damage < 0)
                        damage = 0;
                    int attack = rand.Next(0, Program.currentPlayer.weaponValue) / 2;

                    Console.WriteLine("You lose " + damage + " health and deal " + attack + " damage");
                    Program.currentPlayer.health -= damage;
                    h -= attack;
                    _ = Console.ReadKey(true).Key.ToString();
                }
                else if (input.ToLower() == "r" || input.ToLower() == "run")
                {
                    // Run
                    if(rand.Next(0, 2) == 0)
                    { 
                        Console.WriteLine("As you sprint away from the " + n + "'s strike catches you in the back, sending you sprawling onto the ground");
                        int damage = p - Program.currentPlayer.armorValue;
                        if (damage < 0)
                            damage = 0;
                        Console.WriteLine("You lose " + damage + " health and are unable to escape.");
                        _ = Console.ReadKey(true).Key.ToString();
                    }
                    else
                    {
                            Console.WriteLine("You use your crazy mobility to evade the attacks of " + n + " and you fully escape");
                        _ = Console.ReadKey(true).Key.ToString();
                        Shop.LoadShop(Program.currentPlayer);

                    }
                }
                else if (input.ToLower() == "h" || input.ToLower() == "heal")
                {
                    // Heal
                    if (Program.currentPlayer.potion == 0)
                    {
                        Console.WriteLine("As you desperatly grasp for a potion in your bag, all that you can find is empty glass flask");
                        int damage = p - Program.currentPlayer.armorValue;
                        if (damage < 0)
                            damage = 0;
                        Console.WriteLine("The " + n + " strikes you with a mighty blow, and you lose " + damage + " health!");
                    }
                    else
                    {
                        Console.WriteLine("You reach into your bag and pull out a glowing, red flask. You take a swig, you feel your body lighten up.");
                           int potionV = 5;
                        Console.WriteLine("You gain " + potionV + " health");
                        Program.currentPlayer.health += potionV;
                        Console.WriteLine("As you were occupied, the " + n + " advanced and struck.");
                            int damage = (p/2)-Program.currentPlayer.armorValue;
                        if(damage<0)
                            damage=0;
                        Console.WriteLine("You lose " + damage + " health. \nOne Potion Consumed.");
                        Program.currentPlayer.potion--; 
                    }

                    _ = Console.ReadKey(true).Key.ToString();
                }
                if (Program.currentPlayer.health <= 0)
                {
                    Console.WriteLine("\nAs the " + n + " strikes you it hits with a fatal blow!");
                    Console.ReadKey();
                    System.Environment.Exit(0);
                }
       
            }
            int c = rand.Next(10, 50);
            // Add A Slime Sword Later!
            Console.WriteLine("\nAs you stand victorious over the " + n + ", it's body dissolves into " + c + " gold coins!");
            Program.currentPlayer.coins += c;
            Console.ReadKey();
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
