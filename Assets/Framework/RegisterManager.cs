// Assets/Framework/RegisterManager.cs
using QFramework; // Assuming QFramework's core namespace

namespace TowerDefense.Game { // Or a more generic namespace if preferred for the framework part
    public class RegisterManager : Architecture<RegisterManager> {
        protected override void Init() {
            // 注册游戏模块
            UnityEngine.Debug.Log("Framework: RegisterManager Init");

            // 示例注册 (后续将替换为实际的Model, System, Utility)
            // this.RegisterModel<IGameModel>(new GameModel());
            // this.RegisterSystem<IObjectPoolSystem>(new ObjectPoolSystem()); // Assuming ObjectPoolSystem is part of QFramework or custom
            // this.RegisterUtility<IDataStorage>(new DataStorage());

            this.RegisterModel<TowerDefense.Game.Model.IGameModel>(new TowerDefense.Game.Model.GameModel());
            this.RegisterModel<TowerDefense.Game.Model.ITowerModel>(new TowerDefense.Game.Model.TowerModel());
            this.RegisterModel<TowerDefense.Game.Model.IEnemyModel>(new TowerDefense.Game.Model.EnemyModel());
            UnityEngine.Debug.Log("Game Models (Game, Tower, Enemy) registered successfully.");
        }

        // 可选：如果QFramework有特定的启动或初始化方法，请在此处调用
        public void Launch() {
            UnityEngine.Debug.Log("Framework: RegisterManager Launched");
            // 例如： QFramework.QFramework.Launch(); 或其他初始化调用
        }
    }
}
