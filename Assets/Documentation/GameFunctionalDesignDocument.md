# 《游戏功能设计文档》

## 1. 需求概述
- **功能目标**: 开发一款PC端2D塔防游戏，包含1-20个关卡。游戏对象用几何形状（圆形、三角形、方形等）代替。防御塔在关卡内可以升级，在关卡外可以永久改造。具备吸引玩家的粘性和有深度的游戏系统。
- **核心玩法**: 玩家通过策略性放置和升级防御塔，抵御一波波敌人，防止敌人到达终点。
- **目标用户**: PC端塔防游戏爱好者。
- **关键特性**:
    - QFramework框架应用
    - 四层架构
    - 详细的文档体系
    - 迭代开发流程

## 2. 模块划分与层级定位 (初步)
*此部分将在各里程碑中详细填充*
- **数据层 (Model)**:
    - GameModel: Manages global game state including current level, player resources (gold, health), wave progression, game pause state, permanent tower upgrade data (loaded from storage), and configurations for all levels (e.g., enemy sequences, wave counts, initial resources).
    - TowerModel: Stores and manages runtime data for all active towers within a single game level. This includes each tower's unique ID, type, current upgrade level (in-game), position, and potentially its current target or cooldown state.
    - EnemyModel: Stores and manages runtime data for all active enemies within a single game level. This includes each enemy's unique ID, type, current health, position, movement speed, and progress along its designated path.
- **系统层 (System)**:
    - LevelManagerSystem: 管理关卡流程、波数。
    - EnemySpawnSystem: 负责敌人生成逻辑。
    - TowerManageSystem: 负责塔的建造、升级、出售。
    - BattleSystem: 处理战斗逻辑、伤害计算。
    - ObjectPoolSystem: (框架提供) 管理对象池。
    - TimeSystem: (框架提供) 管理时间相关任务。
- **表现层 (Controller/View)**:
    - 各类UI Controller (如GamePlayUIController, LevelSelectionUIController)。
    - TowerController, EnemyController (挂载在预制体上的视图逻辑)。
- **工具层 (Utility)**:
    - DataStorageUtility: 负责游戏数据的存取。
- **Command/Event**:
    - 游戏核心操作的指令和状态变更的事件。

## 3. 开发任务拆解 (按里程碑规划)
*此部分将链接到各里程碑的具体任务*
- [里程碑一：核心玩法原型搭建](#里程碑一核心玩法原型搭建)
- [里程碑二：关卡系统与永久改造](#里程碑二关卡系统与永久改造)
- [里程碑三：游戏深度与粘性功能](#里程碑三游戏深度与粘性功能)
- [里程碑四：打磨、测试与文档完善](#里程碑四打磨测试与文档完善)

## 3.1 数据层详细设计
### GameModel
- `CurrentLevelID` (BindableProperty<int>): 当前关卡ID。
- `PlayerGold` (BindableProperty<int>): 玩家金币。
- `PlayerHealth` (BindableProperty<int>): 玩家生命值。
- `CurrentWave` (BindableProperty<int>): 当前波数。
- `MaxWaves` (BindableProperty<int>): 当前关卡最大波数。
- `IsGamePaused` (BindableProperty<bool>): 游戏是否暂停。
- `IsGameOver` (BindableProperty<bool>): 游戏是否结束。
- `TowerPermanentUpgradesData` (Dictionary<string, TowerTypePermanentUpgrades>): 防御塔永久升级数据 (Key: TowerTypeID)。
- `LevelConfigs` (Dictionary<int, LevelConfigData>): 关卡配置数据 (Key: LevelID)。

### TowerModel
- `ActiveTowers` (Dictionary<string, TowerRuntimeData>): 活动中的防御塔实例 (Key: InstanceID)。

### EnemyModel
- `ActiveEnemies` (Dictionary<string, EnemyRuntimeData>): 活动中的敌人实例 (Key: InstanceID)。

---
*后续各模块详细设计将在此文档中持续更新*
