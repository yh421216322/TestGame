// Assets/Scripts/GameScripts/Model/Data/TowerDefineData.cs
// 所属模块: 数据层 / 防御塔定义
// 开发状态: 进行中
// 关联需求编号: REQ-CORE-TOWERDEF
using System.Collections.Generic;
using QFramework; // Assuming BindableProperty might be used here or in runtime data

namespace TowerDefense.Game.Model {
    public class TowerLevelData { // Defines stats for a specific level of a tower
        public int Cost; // Cost to build or upgrade to this level
        public int SellValue;
        public float AttackRate; // Attacks per second
        public int Damage;
        public float Range;
        public string PrefabPath; // Prefab for this specific level (optional, could be one prefab with visual changes)
        // Add other level-specific properties, e.g., special abilities unlocked
    }

    public class TowerDefineData : IData { // Base definition for a tower type
        public string TypeID; // Unique identifier for this tower type, e.g., "ArrowTower", "CannonTower"
        public string Name;
        public string Description;
        public string IconPath; // Path to UI icon
        public List<TowerLevelData> Levels; // Data for each upgrade level

        public TowerDefineData() {
            Levels = new List<TowerLevelData>();
        }

        public TowerLevelData GetLevelData(int level) { // Level is 0-indexed
            if (level >= 0 && level < Levels.Count) {
                return Levels[level];
            }
            return null;
        }
    }
}
