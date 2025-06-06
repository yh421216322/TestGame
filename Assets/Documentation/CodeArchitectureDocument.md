# 《代码架构说明书》

## 1. 四层架构依赖图
```plaintext
表现层 (Controller / View)
           │
           ▼ (SendCommand / QueryModel / ListenEvent)
系统层 (ISystem)
           │
           ▼ (GetModel / SendEvent / ExecuteCommand)
数据层 (IModel)
           │
           ▼ (BindableProperty / Event)
工具层 (IUtility)  <-- 可被各层直接调用

依赖关系说明:
- 表现层: 依赖系统层和数据层(通常通过Controller)。可以直接访问Model获取数据用于显示，通过SendCommand发送用户操作。监听Model或System的事件更新视图。
- 系统层: 依赖数据层。执行业务逻辑，修改Model数据，发送事件。可以获取其他System。
- 数据层: 独立，不依赖其他业务层。定义数据结构和状态，通过BindableProperty或事件通知外部变化。
- 工具层: 独立，提供通用功能，可被任何层调用。上层不能反向依赖工具层的具体业务实现。
- Command: 由表现层发起，可访问和操作Model和System。
- Event: 可由Model或System发起，被其他层监听。
```

## 2. 关键接口对照表 (模板)
| 接口名称                 | 示例实现类 (待填充)      | 职责描述                                     | 所属分层 |
|--------------------------|--------------------------|----------------------------------------------|----------|
| `IGameModel`             | `GameModel`              | 管理全局游戏状态、玩家数据、关卡配置等         | 数据层   |
| `ITowerModel`            | `TowerModel`             | 管理关卡内激活的防御塔数据                     | 数据层   |
| `IEnemyModel`            | `EnemyModel`             | 管理关卡内激活的敌人数据                       | 数据层   |
| `ILevelManagerSystem`    | `LevelManagerSystem`     | 管理关卡开始、结束、波数推进等核心流程         | 系统层   |
| `IEnemySpawnSystem`      | `EnemySpawnSystem`       | 负责根据关卡配置生成敌人                       | 系统层   |
| `ITowerManageSystem`     | `TowerManageSystem`      | 处理防御塔的建造、升级、出售逻辑               | 系统层   |
| `IBattleSystem`          | `BattleSystem`           | 处理攻击、伤害计算、死亡等战斗相关逻辑         | 系统层   |
| `IObjectPoolSystem`      | `ObjectPoolSystem` (QFramework) | 提供对象池服务，用于预制体的复用             | 系统层   |
| `ITimeSystem`            | `TimeSystem` (QFramework) | 提供延迟任务、计时器等时间相关服务             | 系统层   |
| `IDataStorageUtility`    | `DataStorageUtility`     | 封装游戏数据的本地存储和读取操作               | 工具层   |
| `GamePlayUIController`   | `GamePlayUIController`   | 控制游戏主界面HUD的显示与交互                  | 表现层   |
| `TowerController`        | `TowerController`        | (View) 挂载于塔预制体，负责塔的视觉表现        | 表现层   |
| `EnemyController`        | `EnemyController`        | (View) 挂载于敌人预制体，负责敌人的视觉表现    | 表现层   |
| `BuildTowerCommand`      | `BuildTowerCommand`      | 执行建造防御塔的指令                           | Command  |
| `EnemyKilledEvent`       | `EnemyKilledEvent`       | 敌人被击杀时触发的事件                         | Event    |
*此表将在开发过程中持续更新*
