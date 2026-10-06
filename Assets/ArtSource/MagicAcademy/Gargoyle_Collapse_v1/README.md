# 石像鬼崩塌散架动画
36帧透明PNG，12fps，3.00秒，非循环。碎裂→石块下落→留下石堆。
Death.anim位于Assets/Animations/Characters/Gargoyle。
画布1024×1024，PPU=256，Pivot=(0.5, 0.4248046875)。锚点匹配现有Gargoyle_0 Sprite的中心，缩放匹配原静态素材。
所有帧使用同一位置转换，保留碎片的下落与散开，不逐帧居中或固定碎片最低点。
透明PNG保留深色描边，未进行最终Alpha腐蚀。
预览GIF重复播放便于检查，Unity Clip不循环。尚未在Unity编辑器内验证播放；现有Prefab未更改。
