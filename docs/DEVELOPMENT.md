# 开发、构建与验证

[返回首页](../README.md) · [排查问题](FAQ.md) · [素材说明](ASSETS.md)

## 工具链与完整克隆

Unity `6000.6.3f1`，以 `ProjectSettings/ProjectVersion.txt` 为准。克隆前安装 Git LFS，克隆后运行 `git lfs pull`；使用 `git lfs ls-files` 检查受管理的资源。

不要把含 `version https://git-lfs.github.com/spec/v1` 的指针当作真实图片或音频导入。第一次导入需要网络解析 Unity 包；运行已完成的游戏和首次开发环境准备不同。

## 场景与状态

启用场景顺序：MainMenu、Level、ThanksScene。`GameSession` 保留选关状态，`GameManager` 组织 Ready、Playing、Paused 等状态，LevelPanel / LevelButton 处理关卡入口。

最后一关的 NextLevel 会进入 ThanksScene。本次补上通关场景的构建条目，并在跳转后返回，避免对超出 LevelCatalog 长度的索引继续初始化。这一修复尚需 Unity 编译和最终关卡通关验证。

## 代码与数据

| 模块 | 关注点 |
| --- | --- |
| BattleGrid / PlacementController | 网格与放置规则 |
| ManaManager | 法力与资源收集 |
| EnemyManager / Enemy | 波次、敌人和战斗生命周期 |
| UnitCatalog / LevelCatalog | 单位配置、初始法力、波次数量与间隔 |
| UIManager / SettingPanel | 暂停、重开及菜单 |

场景、预制体与 ScriptableObject 会引用序列化字段。改名或移动时保留 `.meta`，检查 GUID、组件引用和动画事件，不只搜索 C#。

## 构建

Unity Build Profiles 选择目标平台，检查上面三个有效场景，再构建至忽略目录。Web 构建需要同版本 Web Build Support，测试时使用对应的静态托管入口，不假定任意浏览器直接打开构建文件都可运行。

## 冒烟流程

1. MainMenu 选择关卡，正确读取 LevelCatalog。
2. 选择单位，在合法格子放置；法力不足或非法格子不能错误扣费或放置。
3. 收集法力、魔杖移除、敌人波次与胜负流程正常。
4. 暂停、继续、重开、返回菜单后状态一致。
5. 最后一关进入 ThanksScene，无场景缺失或索引越界错误。
6. 独立构建中重复通关与入口验证。

本次只做版本、源码及场景 GUID 静态核对，未运行 Unity 或上传新游戏包。素材说明与实际运行检查分开记录。
