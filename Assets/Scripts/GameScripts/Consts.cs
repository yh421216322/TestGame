// Assets/Scripts/GameScripts/Consts.cs
namespace TowerDefense.Game {
    public static partial class Consts { // Made partial
        // 常量将在此处定义
        public const string GameVersion = "0.0.1";

        // Data Paths
        public const string TOWER_DEFINE_DATA_PATH = "Data/Towers/"; // Example if loading ScriptableObjects or JSON from Resources/Data/Towers
        public const string ENEMY_DEFINE_DATA_PATH = "Data/Enemies/";
        public const string LEVEL_CONFIG_DATA_PATH = "Data/Levels/";

        // Default IDs (example)
        public const string DEFAULT_PLAYER_ID = "Player01";
    }
}
