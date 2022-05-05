using System;
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
        static int difMod;
        public static void LoadShop(Player p)
        {
            RunShop(p);
        }
        public static void RunShop(Player p)
        {
            int potionP = 20 + 10*difMod;
            int armorP = 100 * armorMod;
            int weaponP = 100 * (weaponMod+1);
            int difP = 300 + 100*p.mods;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("         Shop        ");
                Console.WriteLine("=====================");
                Console.WriteLine("(W)eapon:          $" + weaponP);
                Console.WriteLine("(A)rmor            $" + armorP);
                Console.WriteLine("(Potions:          $" + potionP);
                Console.WriteLine("(D)ifficulty Mod:  $" + difP);
                Console.WriteLine("=====================\n");
                Console.WriteLine("(E)xit");


                Console.WriteLine("\n    Player Stats     ");
                Console.WriteLine("=====================");
                Console.WriteLine("Current Health: " + p.health);
                Console.WriteLine("Coins: " + p.coins);
                Console.WriteLine("Weapon Stregenth: " + p.weaponValue);
                Console.WriteLine("Armor Defense: " + p.armorValue);
                Console.WriteLine("Potions: " + p.potion);
                Console.WriteLine("Difficulty Mods: " + p.mods);
                Console.WriteLine("=====================");

                string input = Console.ReadLine().ToLower();
                if (input == "p" || input == "potion")
                {
                    TryBuy("potion", potionP, p);
                }
                else if (input == "w" || input == "weapon")
                {
                    TryBuy("weapon", weaponP, p);
                }
                else if (input == "a" || input == "armor")
                {
                    TryBuy("armor", armorP, p);
                }
                else if (input == "d" || input == "difficulty mod")
                {
                    TryBuy("dif", difP, p);
                }
                else if (input == "e" || input == "exit")
                    break;
                
            }
        }
        static void TryBuy(string item, int cost, Player p)
        {
            if(p.coins >= cost)
            {
                if (item == "potion")
                    p.potion++;
                else if(item == "weapon")
                    p.weaponValue++;
                else if(item == "armor")
                    p.armorValue++;
                else if (item == "dif")
                    p.mods++;

                p.coins -= cost;

            }
            else
            {
                Console.WriteLine("You don't have enough coins.");
                _ = Console.ReadKey(true).Key.ToString();
            }
        }
    }
}
