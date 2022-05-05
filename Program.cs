using System;
using static System.Console;
using Text_Based_Game.Enemies;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Text_Based_Game
{
    internal class Program
    {
        public static Player currentPlayer = new Player();
        public static string appDataDirectory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        public static string appDataFolderName = "\\GTBRPGEE";
        public static string fullPath;
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
            if (Directory.Exists(appDataDirectory + appDataFolderName) == false)
                Directory.CreateDirectory(appDataDirectory + appDataFolderName);
            fullPath = appDataDirectory + appDataFolderName;
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
                Clear();
                if (File.Exists(fullPath + "\\save.json"))
                {
                    currentPlayer = SaveManager.LoadGame();
                    Shop.RunShop(currentPlayer);
                    Clear();
                }
                else
                {
                    WriteLine("You do not have a save.");
                    ReadKey(true);
                    Clear();
                    Start();
                }
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