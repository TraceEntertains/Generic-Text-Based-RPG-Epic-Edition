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
            while (mainLoop)
            {
                Encounters.RandomEncounter();
            }
        }

        static void Start()
        {
            Clear();
            WriteLine("Generic Text Based RPG - Epic Edition\n");
            WriteLine("(N)ew Game");
            WriteLine("(L)oad Game");
            string input = ReadKey(true).Key.ToString().ToLower();
            if (input == "n")
            {
                NewGame();
            }
            else if (input == "l")
            {
                currentPlayer = SaveManager.LoadGame();
                Shop.RunShop(currentPlayer);
                Clear();
            }
        }

        static void NewGame()
        {
            Clear();
            WriteLine("Generic Text Based RPG - Epic Edition\n");
            Write("Name (Optional): ");
            currentPlayer.name = ReadLine();
            Clear();
            WriteLine("You awake in a bright field. You're feeling dazed and having trouble remembering what happened.\n");
            if (currentPlayer.name == "")
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