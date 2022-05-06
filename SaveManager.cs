using System.IO;
using System.Text.Json;

namespace Text_Based_Game
{
    public class SaveManager
    {
        public static Player LoadGame()
        {
            FileStream save = File.OpenRead(Program.FullPath + "\\save.json");
            Player player = JsonSerializer.Deserialize<Player>(save);
            save.Close();
            return player;
        }

        public static void SaveGame(Player player)
        {
            File.WriteAllText(Program.FullPath + "\\save.json", JsonSerializer.Serialize(player));
        }
    }
}
