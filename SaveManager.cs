using Generic_Text_Based_RPG_Epic_Edition.BaseClasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;

namespace Generic_Text_Based_RPG_Epic_Edition
{
    public class SaveManager
    {
        public static SaveVarStorage SaveVarStorage(SaveVarStorage saveVarStorage)
        {
            saveVarStorage.Player = Program.CurrentPlayer;
            saveVarStorage.Enemy = Program.CurrentEnemy;

            saveVarStorage.PlayerWeaponID = Program.CurrentPlayer.CurrentWeapon.ID;

            return saveVarStorage;
        }

        public static void LoadVarStorage(SaveVarStorage saveVarStorage)
        {
            Program.CurrentPlayer = saveVarStorage.Player;
            Program.CurrentEnemy = saveVarStorage.Enemy;
        }

        public static void SaveGame(SaveVarStorage saveVarStorage)
        {
            saveVarStorage = SaveVarStorage(saveVarStorage);

            File.WriteAllText(Program.FullPath + "\\save.json", JsonSerializer.Serialize(saveVarStorage));
        }

        public static SaveVarStorage LoadGame()
        {
            FileStream save = File.OpenRead(Program.FullPath + "\\save.json");

            SaveVarStorage saveVarStorage = JsonSerializer.Deserialize<SaveVarStorage>(save);
            saveVarStorage.Player.CurrentWeapon = (Weapon)Item.GetByID(saveVarStorage.PlayerWeaponID);

            LoadVarStorage(saveVarStorage);

            save.Close();

            return saveVarStorage;
        }
    }
}
