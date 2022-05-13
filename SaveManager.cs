using System.IO;
using System.Text.Json;

namespace Generic_Text_Based_RPG_Epic_Edition
{
    public class SaveManager
    {
        public static JsonSerializerOptions serializeOptions = new();

        public static SaveVarStorage SaveVarStorage(SaveVarStorage saveVarStorage)
        {
            saveVarStorage.Player = Program.CurrentPlayer;
            saveVarStorage.Enemy = Program.CurrentEnemy;

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

            File.WriteAllText(Program.FullPath + Path.DirectorySeparatorChar + "save.json", JsonSerializer.Serialize(saveVarStorage));
        }

        public static SaveVarStorage LoadGame()
        {
            serializeOptions.Converters.Add(new ItemConverter());
            serializeOptions.Converters.Add(new EnemyConverter());

            FileStream save = File.OpenRead(Program.FullPath + Path.DirectorySeparatorChar + "save.json");

            SaveVarStorage saveVarStorage = JsonSerializer.Deserialize<SaveVarStorage>(save, serializeOptions);

            LoadVarStorage(saveVarStorage);

            save.Close();

            return saveVarStorage;
        }
    }
}
