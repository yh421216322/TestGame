# 《框架集成指南》

## 1. 框架目录结构
```plaintext
- Assets/
  - Framework/  (QFramework核心)
    - Scripts/
      - ISystem/
      - Tools/
      - QFramework.cs
      - RegisterManager.cs (需在此项目或框架中定义)
    - ... (其他QFramework目录)
  - Scripts/
    - GameScripts/ (本项目代码)
      - Controller/
      - Model/
      - System/
      - Utility/
      - Command/
      - Event/
      - View/ (存放MonoBehaviour，被Controller驱动)
      - Consts.cs
  - Resources/
    - Prefabs/
      - Towers/
      - Enemies/
      - Projectiles/
      - UI/
      - Effects/
    - Data/ (存放ScriptableObject或JSON数据定义)
  - Documentation/ (本文档存放处)
```

## 2. 注册配置步骤
1. 确保 `Assets/Framework/RegisterManager.cs` 或 `Assets/Scripts/GameScripts/Common/RegisterManager.cs` 存在并继承自 `QFramework.Architecture<T>`。
2. 打开 `RegisterManager.cs` 文件，在 `protected override void Init()` 方法中添加模块注册代码：
   ```csharp
   // 示例 (具体注册内容根据实际模块添加)
   // 数据层
   RegisterModel<IGameModel>(new GameModel());
   RegisterModel<ITowerModel>(new TowerModel());
   RegisterModel<IEnemyModel>(new EnemyModel());

   // 系统层
   // RegisterSystem<IObjectPoolSystem>(new ObjectPoolSystem()); // 若QFramework未自动注册
   // RegisterSystem<ITimeSystem>(new TimeSystem());           // 若QFramework未自动注册
   RegisterSystem<ILevelManagerSystem>(new LevelManagerSystem());
   RegisterSystem<IEnemySpawnSystem>(new EnemySpawnSystem());
   // ... 其他系统

   // 工具层
   RegisterUtility<IDataStorageUtility>(new DataStorageUtility());
   ```
3. 在 Unity 场景中创建一个空GameObject (例如命名为 "GameRoot" 或 "QFrameworkRoot")。
4. 将 `RegisterManager.cs` 脚本挂载到此GameObject上。
5. (可选) 如果 `RegisterManager` 有启动方法 (如 `Launch()`), 确保其在游戏启动时被调用。

## 3. 预制体管理规范
- 所有需要动态实例化的游戏对象预制体必须存放于 `Assets/Resources/` 目录下的子文件夹（如 `Resources/Prefabs/Towers/`）。
- 预制体命名规范：以 `_PF` 后缀结尾，例如 `CubeTower_PF.prefab`。
- 生成预制体时需使用 `IObjectPoolSystem`：
  ```csharp
  // 示例：从 Prefabs/Towers/ 目录加载预制体
  GameObject towerGO = this.GetSystem<IObjectPoolSystem>().Spawn("Prefabs/Towers/CubeTower_PF");
  ```
- 回收预制体时需使用 `IObjectPoolSystem`：
  ```csharp
  this.GetSystem<IObjectPoolSystem>().Recycle(towerGO);
  ```

## 4. 常量使用规范
- 所有全局常量应定义在 `Assets/Scripts/GameScripts/Consts.cs` 文件中。
- 例如：预制体路径、事件名称（如果用字符串）、数据文件路径等。
