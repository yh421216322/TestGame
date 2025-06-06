// Assets/Scripts/GameScripts/Model/Data/EnemyRuntimeData.cs
// 所属模块: 数据层 / 敌人运行时数据
// 开发状态: 进行中
// 关联需求编号: REQ-CORE-ENEMYRUNTIME
using UnityEngine; // For Vector3
using QFramework;

namespace TowerDefense.Game.Model {
    public class EnemyRuntimeData : IData {
        public string InstanceID; // Unique ID for this specific enemy on the field
        public string EnemyDefineID; // Links to EnemyDefineData
        public BindableProperty<int> CurrentHealth { get; set; }
        public Vector3 Position;
        public float CurrentMoveSpeed;
        public int PathIndex; // Current target waypoint index in its path
        // Add status effects list if needed

        public EnemyRuntimeData() {
            CurrentHealth = new BindableProperty<int>(0);
        }
    }
}
