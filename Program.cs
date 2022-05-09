using System;
using static System.Console;
using Generic_Text_Based_RPG_Epic_Edition.Enemies;
using Generic_Text_Based_RPG_Epic_Edition.BaseClasses;
using System.IO;
using Generic_Text_Based_RPG_Epic_Edition.Items;
using System.Text.Json.Serialization;

namespace Generic_Text_Based_RPG_Epic_Edition
{
    internal class Program
    {
        public static Player CurrentPlayer { get; set; } = new Player();
        public static Enemy CurrentEnemy { get; set; }

        public static string AppDataDirectory { get; set; } = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        public static string AppDataFolderName { get; set; } = "\\GTBRPGEE";
        public static string FullPath { get; set; }
        public static bool MainLoop { get; set; } = true;
        static void Main()
        {
            CurrentPlayer.CurrentWeapon = new Stick();

            Start();

            while (MainLoop)
            {
                Encounters.RandomEncounter();
            }
        }

        static void Start()
        {
            if (Directory.Exists(AppDataDirectory + AppDataFolderName) == false)
                Directory.CreateDirectory(AppDataDirectory + AppDataFolderName);
            FullPath = AppDataDirectory + AppDataFolderName;
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
                if (File.Exists(FullPath + "\\save.json"))
                {
                    SaveManager.LoadVarStorage(SaveManager.LoadGame());
                    Shop.RunShop(CurrentPlayer);
                    Clear();
                    CurrentEnemy.StartBattle();
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
            CurrentPlayer.Name = ReadLine();
            Clear();
            WriteLine("You awake in a bright field. You're feeling dazed and having trouble remembering what happened.\n");
            if (CurrentPlayer.Name == "")
                WriteLine("You can't even remember your own name...");
            else
                WriteLine("You remember that your name is " + CurrentPlayer.Name + ".");
            WriteLine("(Press any key to continue)");
            ReadKey();
            Clear();
            WriteLine("You wander around in the fields till you find a creature.");

            FirstEncounter firstEncounter = new();
            firstEncounter.StartBattle();
        }
    }
}