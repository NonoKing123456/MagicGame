# Mana 数量格
ManaCounter.png为512×192透明PNG，左侧包含Mana图标，右侧数字区留空。
在Unity Canvas中使用UI Image，Preserve Aspect开启，显示尺寸可先设192×72。
数字用单独的TextMeshProUGUI叠放，不需要更换背景PNG；文字居中、深蓝色，建议初始字号24并按需要启用Auto Size。
ManaCounterLayout.json记录数字区域（原点为图像左上角）及Unity标准化区域（左下角原点）。
ManaCounter_250_Preview.jpg仅演示效果，250未烘焙进素材PNG。
导入设置沿用现有顶部栏：Sprite Single、Bilinear、无压缩、居中Pivot。PPU与当前项目顶部栏一致；Canvas中尺寸由RectTransform控制。
已保存到Assets/ArtSource/MagicAcademy/ManaCounter_v1，未在Unity编辑器内验证导入。
使用内置imagegen生成，保留原生透明度，仅裁去外部留白并等比缩放，没有绿幕抠除、描边收缩或新增动画。
