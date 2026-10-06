# Magic Game 主界面与关卡选择美术

使用内置 imagegen，沿用现有魔法学院单位设计及深蓝、金色、浅色内板的 UI 风格。本次仅生成美术资源，没有创建 Prefab、组件、场景或跳转逻辑。

## 独立 PNG
- MainMenuPoster.png：1920×1080 完整不透明主界面背景。保留原角色构图，中央留出菜单空间。生成原图为约 16:9，等比整理到 1080p，仅裁去最多 2 像素的画布边缘；Sources 中保留原始分辨率。
- MagicGameLogo.png：1600×480，独立透明标题，准确文本 Magic Game，两个单词留有间距。
- ButtonStartGame.png / ButtonSelectLevel.png / ButtonGameSettings.png：720×180，独立透明按钮底图，分别带播放、地图、齿轮图标。按钮文字未烘焙。
- LevelSelectPanel.png：1600×1000，独立透明外缘的空关卡面板，标题栏和内容区留空。
- LevelButtonTemplate.png：512×512，独立透明关卡按钮模板；关卡编号、名称和点击目标由 Unity 分别填写。

## 摆放参考
MenuUILayout.json 提供 1920×1080 下的标题、菜单按钮和 4 列×3 行关卡按钮参考布局。关卡面板没有烘焙网格，可自由改变行列数和间距。
推荐主菜单按钮显示 480×120，关卡按钮显示 176×176。按钮含图标，使用 Simple + Preserve Aspect，等比缩放以免拉伸图标；面板可用 Sliced 调整容器尺寸。PPU 400 沿用当前项目 UI，Sprite Single / Full Rect / 居中 Pivot / Bilinear / 无压缩。
主菜单与关卡选择 JPEG 仅为组合预览，其中中文、编号和页码为示意，没有烘焙进 PNG。不同 Canvas 尺寸可将布局坐标等比缩放。
点击关卡后跳转的功能未实现；仅提供可重复使用的美术模板。

## 路径与验证
Unity：Assets/ArtSource/MagicAcademy/MenuUI_v1。
美术：D:/WorkSpace/Arts/MagicAcademy_MenuUI_v1。
PNG 真透明边缘、完整轮廓、缩小后的识别度已检查；未在 Unity 内验证导入。
不改变旧素材、Prefab、场景或游戏逻辑。PROMPTS.txt 为最终提示词；Sources 为生成原图。ZIP 保留 Assets 目录结构与 .meta。
