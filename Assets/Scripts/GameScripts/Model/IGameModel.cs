// Assets/Scripts/GameScripts/Model/IGameModel.cs
// 所属模块: 数据层 / 游戏核心Model接口
// 开发状态: 进行中
// 关联需求编号: REQ-CORE-GAMEMODEL
using System.Collections.Generic;
using QFramework;

namespace TowerDefense.Game.Model {
    public interface IGameModel : IModel {
        BindableProperty<int> CurrentLevelID { get; }
        BindableProperty<int> PlayerGold { get; }
        BindableProperty<int> PlayerHealth { get; }
        BindableProperty<int> CurrentWave { get; }
        BindableProperty<int> MaxWaves { get; } // From LevelConfigData
        BindableProperty<bool> IsGamePaused { get; }
        BindableProperty<bool> IsGameOver { get; } // True if PlayerHealth <= 0 or all waves cleared

        Dictionary<string, TowerTypePermanentUpgrades> TowerPermanentUpgradesData { get; } // Key: TowerTypeID
        Dictionary<int, LevelConfigData> LevelConfigs { get; } // Key: LevelID
        LevelConfigData GetCurrentLevelConfig();
        void LoadLevelConfig(int levelId); // Sets CurrentLevelID, MaxWaves, potentially initial gold/health
        void AddGold(int amount);
        bool SpendGold(int amount);
        void DecreaseHealth(int amount);
        void SetGameOver(bool win);
    }
}
