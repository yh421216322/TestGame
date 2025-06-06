# 《Unity 项目配置指南》

## 1. Unity编辑器版本
- 推荐版本: [填写具体的Unity版本, 如 2021.3.x LTS]

## 2. 项目设置
- **图形API**: [例如: DirectX11 for Windows]
- **分辨率与宽高比**: [例如: 默认 1920x1080, 支持动态调整]
- **输入系统**: [例如: Unity Input Manager 或 New Input System (若使用)]

## 3. QFramework 集成确认
1. 确认 `Assets/Framework` 目录存在且包含QFramework核心文件。
2. 确认 `RegisterManager.cs` 已按《框架集成指南》配置并挂载到场景中的持久化对象上。

## 4. 预制体创建与配置 (示例模板 - 后续按实际填写)
### 4.1 创建基础敌人预制体: `TriangleEnemy_PF`
1. 在 `Assets/Resources/Prefabs/Enemies/` 目录右键 > Create > 3D Object > [选择一个基础形状，如棱柱或自定义模型]。
   *   或者：Create Empty，然后添加子对象作为视觉表现。
2. 重命名为 `TriangleEnemy_PF`。
3. **Inspector面板操作**：
   - 添加 `BoxCollider` 或 `CapsuleCollider` 组件 (Is Trigger 可根据需要勾选)。
   - 添加 `Rigidbody` 组件 (如果需要物理效果，通常2D游戏可能不需要或使用Rigidbody2D)。
     - `Use Gravity`: False (除非特殊设计)
     - `Constraints`: Freeze Rotation (X, Y, Z), Freeze Position (Y) (对于地面单位)
   - 挂载 `EnemyController.cs` 脚本 (路径: `Assets/Scripts/GameScripts/View/EnemyController.cs`)。
   - 在 `EnemyController` 脚本中暴露的字段（如血条引用、特效挂点）进行拖拽赋值。
   - 添加 `QFramework.Poolable` 脚本 (如果对象池系统需要)。
4. 将配置好的GameObject从Hierarchy拖拽到 `Assets/Resources/Prefabs/Enemies/` 使其成为预制体。

### 4.2 创建基础防御塔预制体: `CubeTower_PF`
*(类似步骤，填写具体组件和脚本)*

## 5. 场景设置
- **MainGameScene**:
    - 主摄像机配置。
    - 光照配置 (2D游戏可能使用Unlit材质或简单光照)。
    - "GameRoot" / "QFrameworkRoot" 对象，挂载 `RegisterManager` 和其他全局系统。
    - UI Canvas 设置。
        - Render Mode: Screen Space - Camera / Overlay
        - Canvas Scaler: Scale With Screen Size

*此文档将随开发进度更新具体的配置步骤*
