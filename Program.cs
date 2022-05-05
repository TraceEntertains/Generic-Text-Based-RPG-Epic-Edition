using System;
using static System.Console;
using Text_Based_Game.Enemies;
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

            FirstEncounter firstEncounter = new FirstEncounter();
            firstEncounter.StartBattle();
            while(mainLoop)
            {
                Encounters.RandomEncounter();
            }
        }
        
        static void Start()
        {
            WriteLine("Text-Based Game\n");
            Write("Name (Optional): ");
            currentPlayer.name = ReadLine();
            Clear();
            WriteLine("You awake in a bright field. You're feeling dazed and having trouble remembering what happened.\n");
            if(currentPlayer.name == "")
                WriteLine("You can't even remember your own name...");
            else 
                WriteLine("You remember that your name is " + currentPlayer.name + ".");
            WriteLine("(Press any key to continue)");
            ReadKey();
            Clear();
            WriteLine("You wander around in the fields till you find a creature.");
        }
    }
}
