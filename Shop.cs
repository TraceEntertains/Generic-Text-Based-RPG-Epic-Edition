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
                Console.WriteLine("=====================");
                //Wait For Input
                string input = Console.ReadLine().ToLower();
                if (input == "p" || input == "potion")
                {

                }
                else if (input == "w" || input == "weapon")
                {

                }
                else if (input == "a" || input == "armor")
                {

                }
                else if (input == "d" || input == "difficulty mod")
                {

                }
                
            }
        }
        static void Buy(string item, int cost, Player p)
        {
            if(p.coins >= cost)
            {

            }
            else
            {
                Console.WriteLine"You don't have enough coins.";
                Console.ReadKey();
            }
        }
    }
}
