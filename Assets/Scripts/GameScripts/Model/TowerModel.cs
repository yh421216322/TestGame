// Assets/Scripts/GameScripts/Model/TowerModel.cs
// 所属模块: 数据层 / 防御塔Model实现
// 开发状态: 进行中
// 关联需求编号: REQ-CORE-TOWERMODEL
using System.Collections.Generic;
using QFramework;
using UnityEngine;

namespace TowerDefense.Game.Model {
    public class TowerModel : AbstractModel, ITowerModel {
        public Dictionary<string, TowerRuntimeData> ActiveTowers { get; private set; }

        protected override void OnInit() {
            ActiveTowers = new Dictionary<string, TowerRuntimeData>();
            Debug.Log("TowerModel Initialized.");
        }

        public void AddTower(TowerRuntimeData towerData) {
            if (towerData != null && !ActiveTowers.ContainsKey(towerData.InstanceID)) {
                ActiveTowers.Add(towerData.InstanceID, towerData);
            } else {
                 Debug.LogWarning($"[TowerModel] Attempted to add null or duplicate tower: {towerData?.InstanceID}");
            }
        }

        public void RemoveTower(string instanceID) {
            ActiveTowers.Remove(instanceID);
        }

        public TowerRuntimeData GetTower(string instanceID) {
            ActiveTowers.TryGetValue(instanceID, out var tower);
            return tower;
        }
        public void ClearTowers() {
            ActiveTowers.Clear();
        }
    }
}
