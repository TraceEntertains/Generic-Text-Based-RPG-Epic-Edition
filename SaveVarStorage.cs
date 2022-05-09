using Generic_Text_Based_RPG_Epic_Edition.BaseClasses;
using System.Text.Json.Serialization;

namespace Generic_Text_Based_RPG_Epic_Edition
{
    public struct SaveVarStorage
    {
        public Player Player { get; set; }
        public int PlayerWeaponID { get; set; }
        public EnemyStatsStruct EnemyStats { get; set; }
        public int EnemyID { get; set; }

        [JsonIgnore]
        public Enemy Enemy { get; set; }
    }

    public struct EnemyStatsStruct
    {
        public int Power { get; set; }
        public int Health { get; set; }
        public int Defense { get; set; }
        public int CoinBonus { get; set; }
        public int XP { get; set; }
    }
}
