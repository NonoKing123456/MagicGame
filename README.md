# MagicGame

MagicGame 是使用 Unity 开发的 2D 魔法主题塔防游戏。放置魔法单位、收集法力，并抵挡逐波来袭的史莱姆。

## 在线游玩

**[在 itch.io 游玩 MagicGame](https://nonoking.itch.io/magic-game)**

## 游戏操作

- 点击单位卡牌，再点击空格放置单位；放置会消耗法力。
- 点击掉落的法力进行收集。
- 使用魔杖移除已放置的单位。
- 点击右上角暂停按钮或按 `Esc` 暂停、继续游戏。
- 从主菜单选择关卡，在关卡中可以重开或返回主菜单。

## 本地运行

1. 安装 Unity **6000.6.3f1** 和 Git LFS。
2. 克隆仓库并获取素材：

   ```sh
   git clone https://github.com/NonoKing123456/MagicGame.git
   cd MagicGame
   git lfs pull
   ```

3. 在 Unity Hub 中添加项目目录，使用对应版本的 Unity 打开。
4. 打开 `Assets/Scenes/MainMenu.unity`，点击 Play。

## 项目结构

| 目录 | 内容 |
| --- | --- |
| `Assets/Scripts` | 游戏流程、战斗网格、单位、敌人和 UI 脚本 |
| `Assets/Scenes` | 主菜单、关卡和结束场景 |
| `Assets/Prefabs` | 单位、卡牌和 UI 预制体 |
| `Assets/Animations` | 单位和敌人的动画 |
| `Assets/ArtSource` | 图片及动画帧素材 |
| `Assets/Audio` | 音乐和音效 |
| `Assets/Scripts/Data` | 关卡和单位配置 |

## 构建

在 Unity 的 Build Profiles 中选择目标平台。场景顺序为 MainMenu、Level、ThanksScene；构建 Web 版本时需安装对应的 Web Build Support 模块。

图片、音频等二进制素材通过 Git LFS 管理。素材的来源及说明见相应目录中的 README 和许可证文件。
