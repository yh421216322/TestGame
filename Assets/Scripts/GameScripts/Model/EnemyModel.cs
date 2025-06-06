// Assets/Scripts/GameScripts/Model/EnemyModel.cs
// 所属模块: 数据层 / 敌人Model实现
// 开发状态: 进行中
// 关联需求编号: REQ-CORE-ENEMYMODEL
using System.Collections.Generic;
using QFramework;
using UnityEngine;

namespace TowerDefense.Game.Model {
    public class EnemyModel : AbstractModel, IEnemyModel {
        public Dictionary<string, EnemyRuntimeData> ActiveEnemies { get; private set; }

        protected override void OnInit() {
            ActiveEnemies = new Dictionary<string, EnemyRuntimeData>();
            Debug.Log("EnemyModel Initialized.");
        }

        public void AddEnemy(EnemyRuntimeData enemyData) {
            if (enemyData != null && !ActiveEnemies.ContainsKey(enemyData.InstanceID)) {
                ActiveEnemies.Add(enemyData.InstanceID, enemyData);
            } else {
                Debug.LogWarning($"[EnemyModel] Attempted to add null or duplicate enemy: {enemyData?.InstanceID}");
            }
        }

        public void RemoveEnemy(string instanceID) {
            ActiveEnemies.Remove(instanceID);
        }

        public EnemyRuntimeData GetEnemy(string instanceID) {
            ActiveEnemies.TryGetValue(instanceID, out var enemy);
            return enemy;
        }
         public void ClearEnemies() {
            ActiveEnemies.Clear();
        }
    }
}
