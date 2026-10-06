# 魔法学院设置 UI

使用内置 imagegen，参考现有 CardFrame、TopCardBar、ManaCounter 的深蓝描边、金色边框和浅色内板。

## 独立透明 PNG
- SettingsPanel：空设置面板，顶部标题栏和中央内容区留空。
- SliderTrack / SliderFill / SliderHandle：滑动条的底槽、填充和滑块。
- ExitButton / RestartButton：按钮底图；文字在 Unity 中动态填写。
- CheckboxBox / CheckboxCheck：复选框和独立勾号。
- PauseButton：右上角暂停按钮，双竖线图标已绘入。

PNG 外部是真实透明 Alpha。仅裁去留白、等比缩放和补齐画布；没有颜色抠除或 Alpha 腐蚀。Sources 保存所选生成原图。
素材已导入 Assets/ArtSource/MagicAcademy/SettingsUI_v1。PPU 400 沿用现有 UI；Single、Full Rect、居中 Pivot、Bilinear、无压缩。面板、按钮和滑动条提供 9-slice 边界；UI 推荐尺寸见 SettingsUILayout.json。

## UI 预制件
Assets/Prefabs/UIs/SettingsUI_v1 包含 SettingsPanel、Slider、Checkbox、ExitButton、RestartButton、PauseButton。
将预制件放到已有 Canvas 内，场景需要 EventSystem。Slider 已连接 Fill Rect / Handle Rect；Checkbox 已连接独立 Checkmark。按钮用 Color Tint 显示悬停、按下和禁用状态。
SettingsPanel 包含两条 Slider、一行 Checkbox、底部重新开始和退出按钮。所有 TextMeshPro 标签为空，按需设置中文文案和支持中文的字体资产。预览中的中文仅用于展示，未烘焙进 PNG。
PauseButton 默认锚在父级右上角，距边缘 24，大小 64。按钮点击事件、音量滑条以及复选框含义留给项目逻辑绑定；本次不修改场景、管理器或现有 UI。
退出按钮可绑定 Application.Quit 对应的项目方法；重新开始可绑定现有 GameManager.RestartLevel。暂停与恢复请绑定项目方法。
所有文件引用和局部组件引用已检查；尚未在 Unity 内验证导入及交互。

SettingsPanel_Preview.jpg / Components_Preview.jpg / Edges_QA.jpg 仅为预览。
PROMPTS.txt 保存最终提示词。ZIP 保留 Unity 的 Assets 相对目录和 .meta。
