using System;
using Text_Based_Game.Enemies;
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

        // Encounters

        public static void SlimeEncounter()
        {
            Clear();
            if (rand.Next(0,21) == 1)
            {
                SlimeKing slimeKing = new SlimeKing();
                slimeKing.StartBattle();
            }

            else
            {
                Slime slime = new Slime();
                slime.StartBattle();
            }

        Clear();
        }
        // Encounters Tools
        public static void RandomEncounter()
        {
            switch(rand.Next(0,3))
            {
                case 0:
                    BasicEnemy basicEnemy = new BasicEnemy();
                    basicEnemy.StartBattle();
                    break;
                case 1:
                    SkeletonArcher skeletonArcher = new SkeletonArcher();
                    skeletonArcher.StartBattle();
                    break;
                case 2:
                    //SlimeEncounter();
                    break;
                // Legendary Slime Fight with if else statement small %                                                                                
            }
        }

        public static void Combat(Enemy enemy)
        {

            while (enemy.health > 0)
            {
                Clear();
                WriteLine(enemy.name);
                WriteLine(enemy.power + " Attack" + " / " + enemy.health + " Health");
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
                    WriteLine("You run forward swinging hoping to hit something! As you pass, the " + enemy.name + " strikes you back!");
                    int damage = enemy.power - currentPlayer.armorValue;
                    if (damage < 0)
                        damage = 0;
                    int attack = rand.Next(0, currentPlayer.weaponValue) + rand.Next(1, 4);
                    WriteLine("You lose " + damage + " health and deal " + attack + " damage");
                    currentPlayer.health -= damage;
                    enemy.health -= attack;
                    ReadKey(true);
                }

                else if (input == "d")
                {
                    // Defend
                    WriteLine("");
                    WriteLine("As the " + enemy.name + " prepares to strike, you ready your sword in a defensive stance!");
                    int damage = (enemy.power / 4) - currentPlayer.armorValue;
                    if (damage < 0)
                        damage = 0;
                    int attack = rand.Next(0, currentPlayer.weaponValue) / 2;

                    WriteLine("You lose " + damage + " health and deal " + attack + " damage");
                    currentPlayer.health -= damage;
                    enemy.health -= attack;
                    ReadKey();
                }
                else if (input == "r")
                {
                    // Run
                    WriteLine("");
                    if (rand.Next(0, 2) == 0)
                    { 
                        WriteLine("As you sprint away from the " + enemy.name + ", its strike catches you in the back, sending you sprawling onto the ground!");
                        int damage = enemy.power - currentPlayer.armorValue;
                        if (damage < 0)
                            damage = 0;
                        WriteLine("You lose " + damage + " health and are unable to escape.");
                        currentPlayer.health -= damage;
                        ReadKey();
                    }
                    else
                    {
                        WriteLine("You use your crazy mobility to evade the attacks of " + enemy.name + " and you escape!");
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
                        int damage = enemy.power - currentPlayer.armorValue;
                        if (damage < 0)
                            damage = 0;
                        WriteLine("The " + enemy.name + " strikes you with a mighty blow, and you lose " + damage + " health!");
                    }
                    else
                    {
                        WriteLine("You reach into your bag and pull out a glowing, red flask. You take a swig, you feel your body lighten up.");
                           int potionV = 5;
                        WriteLine("You gain " + potionV + " health");
                        currentPlayer.health += potionV;
                        WriteLine("As you were occupied, the " + enemy.name + " advanced and struck.");
                            int damage = (enemy.power /2)-currentPlayer.armorValue;
                        if(damage<0)
                            damage=0;
                        WriteLine("You lose " + damage + " health. \nOne Potion Consumed.");
                        currentPlayer.potion--; 
                    }
                    ReadKey();
                }
                if (currentPlayer.health <= 0)
                {
                    WriteLine("\nAs the " + enemy.name + " strikes you it hits with a fatal blow!");
                    ReadKey();
                    System.Environment.Exit(0);
                }
            }
            int lootCoins = currentPlayer.CoinCalc();
            // Add A Slime Sword Later!
            WriteLine("\nAs you stand victorious over the " + enemy.name + ", it's body dissolves into " + lootCoins + " gold coins!");
            currentPlayer.coins += lootCoins;
            currentPlayer.LevelCheck(enemy.xp);
            ReadKey();
        }
    }
}
