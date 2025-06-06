// Assets/Scripts/GameScripts/Model/Data/TowerRuntimeData.cs
// 所属模块: 数据层 / 防御塔运行时数据
// 开发状态: 进行中
// 关联需求编号: REQ-CORE-TOWERRUNTIME
using UnityEngine; // For Vector3
using QFramework;

namespace TowerDefense.Game.Model {
    public class TowerRuntimeData : IData {
        public string InstanceID; // Unique ID for this specific tower on the field
        public string TowerDefineID; // Links to TowerDefineData
        public int CurrentLevel; // In-game upgrade level (0-indexed)
        public Vector3 Position;
        public BindableProperty<string> TargetEnemyInstanceID { get; set; } // Current target
        public BindableProperty<float> AttackCooldown { get; set; } // Remaining cooldown

        public TowerRuntimeData() {
            TargetEnemyInstanceID = new BindableProperty<string>(null);
            AttackCooldown = new BindableProperty<float>(0f);
        }
    }
}
