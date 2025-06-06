// Assets/Scripts/GameScripts/Model/Data/LevelConfigData.cs
// 所属模块: 数据层 / 关卡配置
// 开发状态: 进行中
// 关联需求编号: REQ-CORE-LEVELCFG
using System.Collections.Generic;
using QFramework;

namespace TowerDefense.Game.Model {
    public class EnemyWaveEntry { // Defines a single enemy type in a sub-wave
        public string EnemyTypeID;
        public int Count;
        public float SpawnDelay; // Delay before spawning this group after the previous one in the sub-wave
    }

    public class SubWaveData { // A sub-wave can have multiple enemy groups spawning sequentially
        public List<EnemyWaveEntry> Enemies;
        public float DelayAfterSubWave; // Delay before next sub-wave starts

        public SubWaveData() {
            Enemies = new List<EnemyWaveEntry>();
        }
    }

    public class WaveData { // A full wave can consist of multiple sub-waves
        public List<SubWaveData> SubWaves;
        public float DelayAfterWave; // Delay before next wave can be manually started or auto-starts

        public WaveData() {
            SubWaves = new List<SubWaveData>();
        }
    }

    public class LevelConfigData : IData {
        public int LevelID;
        public string LevelName;
        public int InitialGold;
        public int InitialHealth;
        public List<WaveData> Waves; // Defines all waves for this level
        public string SceneName; // Scene to load for this level
        public List<string> AvailableTowerTypeIDs; // Towers player can build in this level

        public LevelConfigData() {
            Waves = new List<WaveData>();
            AvailableTowerTypeIDs = new List<string>();
        }
    }
}
