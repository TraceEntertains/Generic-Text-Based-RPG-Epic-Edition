using System;
using static System.Console;

namespace Text_Based_Game
{
    public class Shop
    {
        static int ArmorMod { get; set; }
        static int WeaponMod { get; set; }
        static int DiffMod { get; set; }

        public static void RunShop(Player player)
        {
            int potionPlayer = 20 + 10 * DiffMod;
            int armorPlayer = 100 * (ArmorMod + 1);
            int weaponPlayer = 100 * (WeaponMod + 1);
            int diffPlayer = 300 + 100 * player.Mods;

            while (true)
            {
                Clear();
                WriteLine("=====================");
                WriteLine("         Shop        ");
                WriteLine("=====================");
                WriteLine("Coins: " + player.Coins);
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
                    SaveManager.SaveGame(Program.CurrentPlayer);
                    Environment.Exit(0);
                }

            }
        }
        static void TryBuy(string item, int cost, Player player)
        {
            if (player.Coins >= cost)
            {
                if (item == "potion")
                    player.Potion++;
                else if (item == "weapon")
                    player.WeaponValue++;
                else if (item == "armor")
                    player.ArmorValue++;
                else if (item == "diff")
                    player.Mods++;

                player.Coins -= cost;
            }
            else
            {
                Clear();
                WriteLine("You don't have enough coins.");
                ReadKey(true);
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
                WriteLine("Player Name: " + player.Name);
                WriteLine("Current Health: " + player.Health);
                WriteLine("Coins: " + player.Coins);
                WriteLine("Weapon Strength: " + player.WeaponValue);
                WriteLine("Armor Defense: " + player.ArmorValue);
                WriteLine("Potions: " + player.Potion);
                WriteLine("Difficulty Mods: " + player.Mods);
                WriteLine("=====================");
                WriteLine("(B)ack");
                WriteLine("(E)xit");
                WriteLine("=====================");

                string input = ReadKey(true).Key.ToString().ToLower();
                if (input == "b")
                    break;
                else if (input == "e")
                    Encounters.RandomEncounter();
            }
        }
    }
}