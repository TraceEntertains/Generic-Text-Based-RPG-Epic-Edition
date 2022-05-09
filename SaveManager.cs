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
        public static SaveVarStorage LoadGame()
        {
            FileStream save = File.OpenRead(Program.FullPath + "\\save.json");

            // Restore weapon

            SaveVarStorage saveVarStorage = JsonSerializer.Deserialize<SaveVarStorage>(save);
            saveVarStorage.Player.CurrentWeapon = (Weapon)Item.GetByID(saveVarStorage.PlayerWeaponID);

            // Restore enemy data
            saveVarStorage.Enemy = LoadEnemyStats(saveVarStorage);

            save.Close();

            return saveVarStorage;
        }

        public static void LoadVarStorage(SaveVarStorage saveVarStorage)
        {
            Program.CurrentPlayer = saveVarStorage.Player;
            Program.CurrentEnemy = saveVarStorage.Enemy;
        }

        public static EnemyStatsStruct SaveEnemyStats(Enemy enemy)
        {
            EnemyStatsStruct enemyStatsStruct = new();

            enemyStatsStruct.Health = enemy.Health;
            enemyStatsStruct.Defense = enemy.Defense;
            enemyStatsStruct.CoinBonus = enemy.CoinBonus;
            enemyStatsStruct.Power = enemy.Power;
            enemyStatsStruct.XP = enemy.XP;

            return enemyStatsStruct;
        }

        public static Enemy LoadEnemyStats(SaveVarStorage saveVarStorage)
        {
            Enemy temp = Enemy.GetByID(saveVarStorage.EnemyID);

            temp.Health = saveVarStorage.EnemyStats.Health;
            temp.Defense = saveVarStorage.EnemyStats.Defense;
            temp.CoinBonus = saveVarStorage.EnemyStats.CoinBonus;
            temp.Power = saveVarStorage.EnemyStats.Power;
            temp.XP = saveVarStorage.EnemyStats.XP;

            return temp;
        }

        public static void SaveGame(SaveVarStorage saveVarStorage)
        {
            saveVarStorage.Player = Program.CurrentPlayer;
            saveVarStorage.Enemy = Program.CurrentEnemy;

            saveVarStorage.PlayerWeaponID = Program.CurrentPlayer.CurrentWeapon.ID;
            saveVarStorage.EnemyID = Program.CurrentEnemy.ID;

            saveVarStorage.EnemyStats = SaveEnemyStats(Program.CurrentEnemy);

            File.WriteAllText(Program.FullPath + "\\save.json", JsonSerializer.Serialize(saveVarStorage));
        }
    }
}
