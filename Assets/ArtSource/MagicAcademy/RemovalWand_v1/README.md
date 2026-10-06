# 清除魔杖与收纳格
两张独立512×512透明PNG，沿用现有藏蓝、金色与薄荷绿画风。
RemovalWand.png用于清除工具图标；RemovalWandSlot.png为空收纳格，不含魔杖。
Unity UI建议：右上角Image使用Slot，尺寸96×96；子Image使用Wand，居中，尺寸66×66，保持比例。拿起工具时只隐藏子Image。
Slot_WithWand_Preview.png只是组合预览，未放入项目作为第三个运行时素材。
使用内置image_gen生成，保留原始Alpha；仅缩放并组合预览。完整提示词见GenerationPrompts.md。
PNG与导入设置已放入Assets/ArtSource/MagicAcademy/RemovalWand_v1。未修改场景或UI逻辑。
