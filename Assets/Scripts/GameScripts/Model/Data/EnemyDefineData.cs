// Assets/Scripts/GameScripts/Model/Data/EnemyDefineData.cs
// 所属模块: 数据层 / 敌人定义
// 开发状态: 进行中
// 关联需求编号: REQ-CORE-ENEMYDEF
using QFramework;

namespace TowerDefense.Game.Model {
    public class EnemyDefineData : IData {
        public string TypeID; // E.g., "Goblin", "OrcHeavy"
        public string Name;
        public string Description;
        public int MaxHealth;
        public float MoveSpeed; // Units per second
        public int DamageToPlayer; // Damage dealt if it reaches the end
        public int GoldReward;   // Gold awarded on kill
        public string PrefabPath;
        // Add other properties like armor type, special abilities, etc.
    }
}
