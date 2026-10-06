# 能量炉咕噜噜冒泡
沿用Grok图生视频流程，4秒源视频，导出12帧12fps循环，周期约1.000秒。
Idle.anim已放入Assets/Animations/Characters/Mana Stove，开启Loop Time，绑定同一对象的SpriteRenderer。
帧PNG在Assets/ArtSource/MagicAcademy/ManaStove_Bubble_v1/Frames。
每帧512×512，底部y=448。PPU=256，Pivot=(0.5, 0.37734375000000003)，与当前AlchemyCauldron_0的世界锚点相同。原单张PNG仍保留不变。
炉体大致静止，液面和泡泡动。真实AI视频存在少量炉体色块和轮廓变化，平移与基线漂移已归一化。
循环按上半部动态区域和绿色泡泡相似度选段；不声称逐像素无缝。详见Animation_Info.json的loopMatch。
洋红背景抠除，保留绿色液体和气泡、黑色描边。PNG与.meta需一起导入以保持Clip引用。
已有Mana Stove Prefab没有Animator组件；在使用的对象上添加Animator，并在其Controller中使用此Idle Clip即可播放。此任务未更改Prefab或已有Controller。
未在Unity编辑器内验证导入和播放。Bubble_Preview.gif仅为预览，源MP4在Grok_ManaStove_Bubble_v1目录。
