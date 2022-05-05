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
        public static void RunShop(Player player)
        {
            int potionPlayer = 20 + 10 * diffMod;
            int armorPlayer = 100 * (armorMod + 1);
            int weaponPlayer = 100 * (weaponMod + 1);
            int diffPlayer = 300 + 100 * player.mods;

            while (true)
            {
                Clear();
                WriteLine("=====================");
                WriteLine("         Shop        ");
                WriteLine("=====================");
                WriteLine("Coins: " + player.coins);
                WriteLine("=====================");
                WriteLine("(W)eapon:          $" + weaponPlayer);
                WriteLine("(A)rmor            $" + armorPlayer);
                WriteLine("(P)otions:         $" + potionPlayer);
                WriteLine("(D)ifficulty Mod:  $" + diffPlayer);
                WriteLine("(S)tats");
                WriteLine("=====================");
                WriteLine("(E)xit");
                WriteLine("Save and (Q)uit");
                WriteLine("=====================");

                string input = ReadKey(true).Key.ToString().ToLower();
                if (input == "p")
                {
                    TryBuy("potion", potionPlayer, player);
                }
                else if (input == "w")
                {
                    TryBuy("weapon", weaponPlayer, player);
                }
                else if (input == "a")
                {
                    TryBuy("armor", armorPlayer, player);
                }
                else if (input == "d")
                {
                    TryBuy("diff", diffPlayer, player);
                }
                else if (input == "s")
                {
                    StatsScreen(player);
                }
                else if (input == "e")
                {
                    break;
                }
                else if (input == "q")
                {
                    SaveManager.SaveGame(Program.currentPlayer);
                    Environment.Exit(0);
                }

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

        static void StatsScreen(Player player)
        {
            while (true)
            {
                Clear();
                WriteLine("=====================");
                WriteLine("    Player Stats     ");
                WriteLine("=====================");
                WriteLine("Player Name: " + player.name);
                WriteLine("Current Health: " + player.health);
                WriteLine("Coins: " + player.coins);
                WriteLine("Weapon Strength: " + player.weaponValue);
                WriteLine("Armor Defense: " + player.armorValue);
                WriteLine("Potions: " + player.potion);
                WriteLine("Difficulty Mods: " + player.mods);
                WriteLine("=====================");
                WriteLine("(B)ack");
                WriteLine("(E)xit");
                WriteLine("=====================");

                string input = ReadKey(true).Key.ToString().ToLower();
                if (input == "b")
                    RunShop(player);
                else if (input == "e")
                    Encounters.RandomEncounter();
            }
        }
    }
}