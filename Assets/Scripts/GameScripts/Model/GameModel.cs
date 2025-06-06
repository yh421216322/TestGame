// Assets/Scripts/GameScripts/Model/GameModel.cs
// 所属模块: 数据层 / 游戏核心Model实现
// 开发状态: 进行中
// 关联需求编号: REQ-CORE-GAMEMODEL
using System.Collections.Generic;
using QFramework;
using UnityEngine; // For Debug.Log in OnInit example

namespace TowerDefense.Game.Model {
    public class GameModel : AbstractModel, IGameModel {
        public BindableProperty<int> CurrentLevelID { get; private set; }
        public BindableProperty<int> PlayerGold { get; private set; }
        public BindableProperty<int> PlayerHealth { get; private set; }
        public BindableProperty<int> CurrentWave { get; private set; }
        public BindableProperty<int> MaxWaves { get; private set; }
        public BindableProperty<bool> IsGamePaused { get; private set; }
        public BindableProperty<bool> IsGameOver { get; private set; }

        public Dictionary<string, TowerTypePermanentUpgrades> TowerPermanentUpgradesData { get; private set; }
        public Dictionary<int, LevelConfigData> LevelConfigs { get; private set; }

        protected override void OnInit() {
            CurrentLevelID = new BindableProperty<int>(0);
            PlayerGold = new BindableProperty<int>(100); // Default starting gold
            PlayerHealth = new BindableProperty<int>(20); // Default starting health
            CurrentWave = new BindableProperty<int>(0);
            MaxWaves = new BindableProperty<int>(0);
            IsGamePaused = new BindableProperty<bool>(false);
            IsGameOver = new BindableProperty<bool>(false);

            TowerPermanentUpgradesData = new Dictionary<string, TowerTypePermanentUpgrades>();
            LevelConfigs = new Dictionary<int, LevelConfigData>();

            // TODO: Load LevelConfigs from Resources (e.g., JSON files or ScriptableObjects)
            // TODO: Load TowerPermanentUpgradesData from DataStorageUtility
            LoadDummyLevelConfigs(); // Placeholder
            Debug.Log("GameModel Initialized. Player Gold: " + PlayerGold.Value);
        }

        // Placeholder for loading level configurations
        private void LoadDummyLevelConfigs() {
            // Example:
            var level1 = new LevelConfigData { LevelID = 1, LevelName = "第一关", InitialGold = 150, InitialHealth = 20, SceneName = "Level01Scene" };
            var wave1_1 = new SubWaveData();
            wave1_1.Enemies.Add(new EnemyWaveEntry { EnemyTypeID = "TriangleEnemy", Count = 5, SpawnDelay = 1f });
            var wave1Data = new WaveData();
            wave1Data.SubWaves.Add(wave1_1);
            wave1Data.DelayAfterWave = 5f;
            level1.Waves.Add(wave1Data);
            LevelConfigs.Add(1, level1);
            MaxWaves.Value = level1.Waves.Count; // Set for current default level or after LoadLevelConfig
        }

        public LevelConfigData GetCurrentLevelConfig() {
            return LevelConfigs.TryGetValue(CurrentLevelID.Value, out var config) ? config : null;
        }

        public void LoadLevelConfig(int levelId) {
            if (LevelConfigs.TryGetValue(levelId, out var config)) {
                CurrentLevelID.Value = levelId;
                PlayerGold.Value = config.InitialGold;
                PlayerHealth.Value = config.InitialHealth;
                MaxWaves.Value = config.Waves.Count;
                CurrentWave.Value = 0; // Reset wave count
                IsGameOver.Value = false;
                IsGamePaused.Value = false;
                Debug.Log($"Level {levelId} loaded. Gold: {PlayerGold.Value}, Health: {PlayerHealth.Value}, Waves: {MaxWaves.Value}");
            } else {
                Debug.LogError($"[GameModel] Level config for ID {levelId} not found!");
            }
        }

        public void AddGold(int amount) {
            if (amount > 0) PlayerGold.Value += amount;
        }

        public bool SpendGold(int amount) {
            if (amount > 0 && PlayerGold.Value >= amount) {
                PlayerGold.Value -= amount;
                return true;
            }
            return false;
        }

        public void DecreaseHealth(int amount) {
            if (amount > 0) {
                PlayerHealth.Value -= amount;
                if (PlayerHealth.Value <= 0) {
                    PlayerHealth.Value = 0;
                    SetGameOver(true); // Assuming loss if health is 0
                }
            }
        }
        public void SetGameOver(bool loss) { // Parameter indicates if it's a loss (true) or win (false might be set by LevelSystem)
            IsGameOver.Value = true;
            // Further logic for win/loss can be handled by systems listening to IsGameOver
            Debug.Log("Game Over. Player " + (loss ? "Lost." : "Won (or level ended)."));
        }
    }
}
