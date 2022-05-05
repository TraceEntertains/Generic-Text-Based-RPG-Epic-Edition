using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_Game
{
    public class Shop
    {
        static int armorMod;
        static int weaponMod;
        static int diffMod;
        public static void LoadShop(Player player)
        {
            RunShop(player);
        }
        public static void RunShop(Player player)
        {
            int potionPlayer = 20 + 10 * diffMod;
            int armorPlayer = 100 * armorMod;
            int weaponPlayer = 100 * (weaponMod + 1);
            int diffPlayer = 300 + 100 * player.mods;

            while (true)
            {
                Clear();
                WriteLine("         Shop        ");
                WriteLine("=====================");
                WriteLine("(W)eapon:          $" + weaponPlayer); ;
                WriteLine("(A)rmor            $" + armorPlayer);
                WriteLine("(P)otions:          $" + potionPlayer);
                WriteLine("(D)ifficulty Mod:  $" + diffPlayer);
                WriteLine("=====================\n");
                WriteLine("(E)xit");


                WriteLine("\n    Player Stats     ");
                WriteLine("=====================");
                WriteLine("Current Health: " + player.health);
                WriteLine("Coins: " + player.coins);
                WriteLine("Weapon Stregenth: " + player.weaponValue);
                WriteLine("Armor Defense: " + player.armorValue);
                WriteLine("Potions: " + player.potion);
                WriteLine("Difficulty Mods: " + player.mods);
                WriteLine("=====================");

                string input = ReadKey(true).Key.ToString().ToLower();
                if (input == "p" || input == "potion")
                {
                    TryBuy("potion", potionPlayer, player);
                }
                else if (input == "w" || input == "weapon")
                {
                    TryBuy("weapon", weaponPlayer, player);
                }
                else if (input == "a" || input == "armor")
                {
                    TryBuy("armor", armorPlayer, player);
                }
                else if (input == "d" || input == "difficulty mod")
                {
                    TryBuy("diff", diffPlayer, player);
                }
                else if (input == "e" || input == "exit")
                    break;

            }
        }
        static void TryBuy(string item, int cost, Player player)
        {
            if (player.coins >= cost)
            {
                if (item == "potion")
                    player.potion++;
                else if (item == "weapon")
                    player.weaponValue++;
                else if (item == "armor")
                    player.armorValue++;
                else if (item == "diff")
                    player.mods++;

                player.coins -= cost;

            }
            else
            {
                WriteLine("You don't have enough coins.");
                ReadKey();
            }
        }
    }
}