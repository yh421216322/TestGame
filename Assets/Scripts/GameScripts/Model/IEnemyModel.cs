// Assets/Scripts/GameScripts/Model/IEnemyModel.cs
// 所属模块: 数据层 / 敌人Model接口
// 开发状态: 进行中
// 关联需求编号: REQ-CORE-ENEMYMODEL
using System.Collections.Generic;
using QFramework;
using UnityEngine;

namespace TowerDefense.Game.Model {
    public interface IEnemyModel : IModel {
        Dictionary<string, EnemyRuntimeData> ActiveEnemies { get; } // Key: InstanceID
        void AddEnemy(EnemyRuntimeData enemyData);
        void RemoveEnemy(string instanceID);
        EnemyRuntimeData GetEnemy(string instanceID);
        void ClearEnemies(); // For level end or wave clear
    }
}
