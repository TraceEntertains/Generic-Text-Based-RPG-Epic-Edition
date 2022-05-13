using System;
using static System.Console;

namespace Generic_Text_Based_RPG_Epic_Edition
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
                //WriteLine("(W)eapon:          $" + weaponPlayer);
                WriteLine("(A)rmor            $" + armorPlayer);
                WriteLine("(P)otions:         $" + potionPlayer);
                WriteLine("(D)ifficulty Mod:  $" + diffPlayer);
                WriteLine("(I)nventory");
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
                /*else if (input == "w")
                {
                    TryBuy("weapon", weaponPlayer, player);
                }*/
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
                else if (input == "i")
                    Inventory(player);
                else if (input == "e")
                {
                    break;
                }

                else if (input == "q")
                {
                    SaveVarStorage saveVarStorage = new();

                    SaveManager.SaveGame(saveVarStorage);
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
                    player.CurrentWeapon.Damage++;
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
        static void Inventory(Player player)
        {
            while (true)
            {
                Clear();
                WriteLine("=====================");
                WriteLine("      Inventory      ");
                WriteLine("=====================");
                WriteLine("Potions: " + player.Potion);
                WriteLine("=====================");
                WriteLine("Slot 1:");
                WriteLine("Slot 2:");
                WriteLine("Slot 3:");
                WriteLine("Slot 4:");
                WriteLine("Slot 5:");
                WriteLine("Slot 6:");
                WriteLine("Slot 7:");
                WriteLine("Slot 8:");
                WriteLine("Slot 9:");
                WriteLine("Slot 10:");
                WriteLine("=====================");
                WriteLine("        (B)ack       ");
                WriteLine("=====================");

                string input = ReadKey(true).Key.ToString().ToLower();
                if (input == "b")
                    break;
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
                WriteLine("Coins: " + player.Coins);
                WriteLine("Current Health: " + player.Health);
                WriteLine("Strength: " + player.Strength);
                WriteLine("Defense: " + player.Defense);
                WriteLine("=====================");
                WriteLine("Current Weapon: " + player.CurrentWeapon.Name);
                WriteLine("Weapon Strength: " + player.CurrentWeapon.Damage);
                WriteLine("Armor Defense: " + player.ArmorValue);
                WriteLine("=====================");
                WriteLine("Level: " + player.Level);
                WriteLine("XP: " + player.XP);
                WriteLine("Next Level: " + player.NextLevel);
                WriteLine("=====================");
                WriteLine("Difficulty Mods: " + player.Mods);
                WriteLine("=====================");
                WriteLine("        (B)ack       ");
                WriteLine("=====================");

                string input = ReadKey(true).Key.ToString().ToLower();
                if (input == "b")
                    break;
            }
        }
    }
}