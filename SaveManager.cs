using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Text_Based_Game
{
    public class SaveManager
    {
        public static Player LoadGame()
        {
            FileStream save = File.OpenRead(Directory.GetCurrentDirectory() + "\\save.json");
            Player player = JsonSerializer.Deserialize<Player>(save);
            save.Close();
            return player;
        }

        public static void SaveGame(Player player)
        {
            File.WriteAllText(Directory.GetCurrentDirectory() + "\\save.json", JsonSerializer.Serialize(player));
        }
    }
}
