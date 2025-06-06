// Assets/Scripts/GameScripts/Model/ITowerModel.cs
// 所属模块: 数据层 / 防御塔Model接口
// 开发状态: 进行中
// 关联需求编号: REQ-CORE-TOWERMODEL
using System.Collections.Generic;
using QFramework;
using UnityEngine;

namespace TowerDefense.Game.Model {
    public interface ITowerModel : IModel {
        Dictionary<string, TowerRuntimeData> ActiveTowers { get; } // Key: InstanceID
        void AddTower(TowerRuntimeData towerData);
        void RemoveTower(string instanceID);
        TowerRuntimeData GetTower(string instanceID);
        void ClearTowers(); // For level end
    }
}
