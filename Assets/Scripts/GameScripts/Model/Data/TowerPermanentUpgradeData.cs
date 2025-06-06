// Assets/Scripts/GameScripts/Model/Data/TowerPermanentUpgradeData.cs
// 所属模块: 数据层 / 防御塔永久改造
// 开发状态: 进行中
// 关联需求编号: REQ-FEATURE-TOWERPERMAUPGRADE
using System.Collections.Generic;
using QFramework;

namespace TowerDefense.Game.Model {
    public enum PermanentUpgradeType {
        BaseDamageIncrease,
        BaseAttackSpeedIncrease,
        BaseRangeIncrease,
        CostReduction,
        // Add more types as needed
    }

    public class TowerPermanentUpgradeEntry {
        public PermanentUpgradeType UpgradeType;
        public float Value; // e.g., +5 damage, +0.1 attack speed, -10% cost (0.9)
        public int CurrentLevel;
        public int MaxLevel;
        public List<int> UpgradeCosts; // Cost for each level of this specific permanent upgrade
    }

    // This class might store all permanent upgrades for a single tower type
    public class TowerTypePermanentUpgrades : IData {
         public string TowerTypeID;
         public Dictionary<PermanentUpgradeType, TowerPermanentUpgradeEntry> Upgrades;

         public TowerTypePermanentUpgrades(string towerTypeID) {
            TowerTypeID = towerTypeID;
            Upgrades = new Dictionary<PermanentUpgradeType, TowerPermanentUpgradeEntry>();
         }
    }
}
