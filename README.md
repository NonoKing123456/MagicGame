# MagicGame · 魔法塔防

Unity 2D 魔法主题塔防游戏。选择魔法单位、消耗并收集法力，在网格上布置防线，抵挡逐波来袭的史莱姆。

[在线游玩](https://nonoking.itch.io/magic-game) · [开发与构建](docs/DEVELOPMENT.md) · [常见问题](docs/FAQ.md) · [素材说明](docs/ASSETS.md)

## 游戏内容与操作

| 操作 | 用途 |
| --- | --- |
| 点击单位卡牌，再点击空格 | 放置单位并消耗法力 |
| 点击掉落法力 | 收集资源 |
| 使用魔杖 | 移除已放置单位 |
| 暂停按钮或 Esc | 暂停、继续 |
| 主菜单选择关卡 | 进入对应战斗 |
| 关卡中的菜单 | 重开或返回主菜单 |

关卡波次、初始法力和单位配置由项目数据资源管理。具体可用单位与关卡以当前构建为准。

## 本地运行

项目固定使用 **Unity 6000.6.3f1**。图片、音频等资源使用 Git LFS，首次克隆需安装并初始化 Git LFS：

```sh
git lfs install
git clone https://github.com/NonoKing123456/MagicGame.git
cd MagicGame
git lfs pull
```

在 Unity Hub 添加仓库根目录，等待依赖和资源导入完成，打开 `Assets/Scenes/MainMenu.unity`，点击 Play，再从菜单选关。

仓库 ZIP 不一定包含完整 LFS 资源。若看到只有几行文本的图片或音频文件，请使用上面的 Git LFS 流程补全，不要在 Unity 中另造同名资源替换引用。

## 项目结构

| 路径 | 内容 |
| --- | --- |
| `Assets/Scripts/Managers/` | 状态、网格、放置、敌人、法力与音频管理 |
| `Assets/Scripts/Data/` | 单位、关卡和波次配置 |
| `Assets/Scripts/Enemy/` | 敌人行为 |
| `Assets/Scripts/Items/` | 投射物、法力等对象 |
| `Assets/Scripts/UIs/` | 卡牌、选关、设置及魔杖 |
| `Assets/Scenes/` | MainMenu、Level、ThanksScene 等场景 |
| `Assets/Prefabs/`、`Assets/Animations/` | 预制体与动画 |
| `Assets/ArtSource/`、`Assets/Audio/` | 美术、动画帧、音乐及来源说明 |

## 构建与验证

Build Profiles 的有效场景顺序为 **MainMenu → Level → ThanksScene**，构建 Web 版本需对应的 Web Build Support。

本次补齐了原本遗漏的 ThanksScene 构建条目，并让最后一关跳转后立即返回，避免继续以越界关卡索引初始化战斗。版本、场景路径和 GUID 已静态核对；Unity 编译、通关跳转与新构建仍需在编辑器实测。步骤见 [开发文档](docs/DEVELOPMENT.md)。

## 反馈与许可

通过 [Issues](https://github.com/NonoKing123456/MagicGame/issues) 反馈关卡、单位或构建问题，附进入关卡的方式、复现步骤和 Console 错误。贡献说明见 [CONTRIBUTING.md](CONTRIBUTING.md)，安全问题见 [SECURITY.md](SECURITY.md)。

项目尚未单独声明源码许可证。美术和音频包含各自来源记录，详见 [素材说明](docs/ASSETS.md)，不要将仓库公开理解为所有素材具有相同许可。
