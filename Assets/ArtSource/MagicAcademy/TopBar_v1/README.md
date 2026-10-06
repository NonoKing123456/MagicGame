# 顶部横向卡槽栏
TopCardBar.png：1280×384，透明外缘，5个空卡槽，没有烘焙角色卡片或文字。
风格沿用现有卡片的深蓝描边、金色框与蓝色背板。
Unity项目路径：Assets/ArtSource/MagicAcademy/TopBar_v1。
Canvas中创建Image，设置顶部居中锚点，勾选Preserve Aspect。推荐显示尺寸960×288，可整体等比缩小。
在背景Image上方添加5个独立的卡片Image。TopBarLayout.json给出1280×384画布对应的卡片中心与建议尺寸；若缩小到960×288，所有坐标和尺寸乘0.75。
卡片宽高保持2:3，文字和费用可继续由TextMeshPro填写。JPEG仅为预览，不是游戏背景。
导入配置沿用当前项目卡框的PPU，其余保持Sprite Single、Bilinear、无压缩、居中Pivot；UI显示尺寸由RectTransform控制。未在Unity编辑器内验证导入。
使用内置imagegen生成，原生透明通道保留，整理时只裁去留白并等比缩放，无绿幕抠图或描边收缩。
