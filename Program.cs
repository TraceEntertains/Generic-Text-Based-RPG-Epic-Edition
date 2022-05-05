using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_Game
{
    internal class Program
    {
        public static Player currentPlayer = new Player();
        public static bool mainLoop = true;
        static void Main(string[] args)
        {
            Start();
            Encounters.FirstEncounter();
            while(mainLoop)
            {
                Encounters.RandomEncounter();
            }

        }
        
        static void Start()
        {
            Console.WriteLine("Text-Based Game\n");
            Console.Write("Name: ");
            currentPlayer.name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("You awake in await bright field. You're feeling dazed and having trouble remebering what happened.\n");
            if(currentPlayer.name == "")
                Console.WriteLine("You can't even remeber your own name...");
                else 
                Console.WriteLine("You remeber your name is " + currentPlayer.name + ".");
            Console.WriteLine("(press any key to countine)");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("You wonder around in the fields till you find a creature.");
        }
    }
}
