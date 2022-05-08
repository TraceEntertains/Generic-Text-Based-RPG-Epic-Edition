using Generic_Text_Based_RPG_Epic_Edition.BaseClasses;
using System.IO;
using System.Text.Json;

namespace Generic_Text_Based_RPG_Epic_Edition
{
    public class SaveManager
    {
        public static Player LoadGame()
        {
            FileStream save = File.OpenRead(Program.FullPath + "\\save.json");
            Player player = JsonSerializer.Deserialize<Player>(save);
            player.CurrentWeapon = (Weapon)Item.GetByID((int)player.CurrentWeaponID);
            player.CurrentWeaponID = null;
            save.Close();
            return player;
        }

        public static void SaveGame(Player player)
        {
            File.WriteAllText(Program.FullPath + "\\save.json", JsonSerializer.Serialize(player));
        }
    }
}
