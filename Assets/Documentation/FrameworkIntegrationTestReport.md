# 《框架集成测试报告》

## 测试环境
- Unity版本: [填写版本]
- QFramework版本: [填写版本]
- 操作系统: [填写操作系统]
- 测试日期: YYYY-MM-DD

## 必测用例 (至少5个)

### 1. 用例：框架核心注册与初始化
- **测试目的**: 验证 `RegisterManager` 是否能正确注册和初始化Model、System、Utility。
- **前置条件**: `RegisterManager` 已配置并挂载。
- **测试步骤**:
    1. 启动游戏。
    2. 观察Unity控制台 (Console) 输出。
- **预期结果**:
    - 控制台输出 "Framework: RegisterManager Init" 日志。
    - 控制台输出各模块（如 `GameModel`, `LevelManagerSystem`）成功注册的日志。
    - 无相关错误或异常。
- **实际结果**: (测试时填写)
- **测试结论**: (通过/失败)

### 2. 用例：对象池系统（IObjectPoolSystem）预制体生成与回收
- **测试目的**: 验证通过 `IObjectPoolSystem` 生成和回收预制体功能是否正常。
- **前置条件**:
    - `IObjectPoolSystem` 已注册。
    - `Assets/Resources/Prefabs/UI/TestItem_PF.prefab` 存在一个简单的可辨识预制体。
- **测试步骤**:
    1. 创建一个测试脚本，注入 `IObjectPoolSystem`。
    2. 调用 `this.GetSystem<IObjectPoolSystem>().Spawn("Prefabs/UI/TestItem_PF");`。
    3. 观察场景中是否出现 `TestItem_PF` 实例。
    4. 调用 `this.GetSystem<IObjectPoolSystem>().Recycle(spawnedItemGO);`。
    5. 观察场景中 `TestItem_PF` 实例是否被禁用或从场景移除（根据对象池实现）。
    6. 检查控制台有无报错。
- **预期结果**:
    - 预制体能正确生成和回收。
    - 对象池计数器（如果有）正确更新。
    - 控制台无相关错误。
- **实际结果**: (测试时填写)
- **测试结论**: (通过/失败)

### 3. 用例：数据层（IModel）BindableProperty 数据监听与变更
- **测试目的**: 验证 `BindableProperty` 的值变更能够被正确监听到。
- **前置条件**:
    - `IGameModel` 及其实现 `GameModel` 已注册。
    - `GameModel` 中有一个 `BindableProperty<int> PlayerGold`。
- **测试步骤**:
    1. 创建一个测试脚本，获取 `IGameModel`。
    2. 订阅 `mGameModel.PlayerGold.Register(newVal => { Debug.Log("Gold changed: " + newVal); });`。
    3. 在另一个地方修改 `mGameModel.PlayerGold.Value = 100;`。
- **预期结果**:
    - 控制台输出 "Gold changed: 100"。
- **实际结果**: (测试时填写)
- **测试结论**: (通过/失败)

### 4. 用例：Command-Event 基础链路测试
- **测试目的**: 验证通过 `SendCommand` 后，对应的Command执行，并能通过 `SendEvent` 触发相应事件，事件能被正确监听到。
- **前置条件**:
    - `TestCommand.cs` 和 `TestEvent.cs` 已创建。
    - `TestCommand` 在 `OnExecute` 中 `this.SendEvent(new TestEvent());`。
    - 一个测试系统或Controller注册了对 `TestEvent` 的监听。
- **测试步骤**:
    1. 在测试脚本中 `this.SendCommand(new TestCommand());`。
- **预期结果**:
    - `TestEvent` 的监听回调被执行（例如打印日志）。
    - 控制台无相关错误。
- **实际结果**: (测试时填写)
- **测试结论**: (通过/失败)

### 5. 用例：延时任务系统（ITimeSystem）功能
- **测试目的**: 验证 `ITimeSystem` 可以正确执行延时任务。
- **前置条件**: `ITimeSystem` 已注册。
- **测试步骤**:
    1. 在测试脚本中获取 `ITimeSystem`。
    2. 调用 `this.GetSystem<ITimeSystem>().AddDelayTask(1f, () => { Debug.Log("Delay task executed!"); });`。
    3. 等待1秒。
- **预期结果**:
    - 1秒后，控制台输出 "Delay task executed!"。
- **实际结果**: (测试时填写)
- **测试结论**: (通过/失败)

---
*后续将根据具体功能模块添加更多测试用例*
