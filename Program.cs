﻿using Generic_Text_Based_RPG_Epic_Edition.BaseClasses;
using Generic_Text_Based_RPG_Epic_Edition.Enemies;
using Generic_Text_Based_RPG_Epic_Edition.Items;
using System;
using System.IO;
using System.Runtime.InteropServices;
using static System.Console;

namespace Generic_Text_Based_RPG_Epic_Edition
{
    internal class Program
    {
        public static Player CurrentPlayer { get; set; } = new Player();
        public static Enemy CurrentEnemy { get; set; }

        public static string AppDataDirectory { get; set; } = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static string AppDataFolderName { get; set; } = Path.DirectorySeparatorChar + "GTBRPGEE";
        public static string FullPath { get; set; }
        public static bool MainLoop { get; set; } = true;

        [STAThread]
        static void Main()
        {
            Start();

            while (MainLoop)
            {
                Encounters.RandomEncounter();
            }
        }

        static void Start()
        {
            Enemy.RuntimeGetChildren();
            Weapon.RuntimeGetChildren();
            Item.RuntimeGetChildren();

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
                if (File.Exists(FullPath + Path.DirectorySeparatorChar + "save.json"))
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
            else
            {
                Clear();
                WriteLine("Invalid Input (Press Any Button)");
                ReadKey();
                Start();
            }
        }

        static void NewGame()
        {
            CurrentPlayer.CurrentWeapon = new Stick();

            Clear();
            WriteLine("Generic Text Based RPG - Epic Edition\n");
            Write("Name (Optional): ");
            CurrentPlayer.Name = ReadLine();
            Clear();

            Write("Do you want to customize your game? \n(YES) (NO) \n");
            string customizationInput = ReadLine().ToLower();
            if (customizationInput == "yes")
            {
                Write("Young Traveler, how do you want to see the world? (COLOR NAME)\n");
                string Color = ReadLine().ToLower();
                if (Color == "red")
                    BackgroundColor = ConsoleColor.Red;
                else if (Color == "blue")
                    BackgroundColor = ConsoleColor.Blue;
                else if (Color == "green")
                    BackgroundColor = ConsoleColor.Green;
                else if (Color == "Cyan")
                    BackgroundColor = ConsoleColor.Cyan;
                else if (Color == "DarkBlue")
                    BackgroundColor = ConsoleColor.DarkBlue;
                else if (Color == "DarkGray")
                    BackgroundColor = ConsoleColor.DarkGray;
                else if (Color == "DarkGreen")
                    BackgroundColor = ConsoleColor.DarkGreen;
                else if (Color == "DarkMagenta")
                    BackgroundColor = ConsoleColor.DarkMagenta;
                else if (Color == "DarkRed")
                    BackgroundColor = ConsoleColor.DarkRed;
                else if (Color == "DarkYellow")
                    BackgroundColor = ConsoleColor.DarkYellow;
                else if (Color == "Gray")
                    BackgroundColor = ConsoleColor.Gray;
                else if (Color == "Magenta")
                    BackgroundColor = ConsoleColor.Magenta;
                else if (Color == "white")
                    BackgroundColor = ConsoleColor.White;
                else if (Color == "Yellow")
                    BackgroundColor = ConsoleColor.Yellow;
            }
            else
                Clear();
            WriteLine("You awake in a bright field. You're feeling dazed and having trouble remembering what happened.\n");
            if (CurrentPlayer.Name == "")
                WriteLine("You can't even remember your own name...");
#if DEBUG
            else if (CurrentPlayer.Name == "Dev Mode")
            {
                CurrentPlayer.Health = 1000000;
                CurrentPlayer.Coins = 1000000;

                WriteLine("You remember you are a god.");
            }
#endif
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