# 史莱姆朝左撞击攻击动画
Grok图生视频提取9张透明PNG。12fps，0.75秒，不循环。
蓄力压缩→向左撞击→恢复待机。固定初始待机Pivot，使用明确的后缩、前冲、回位轨迹；最大向左位移125像素，约0.446 Unity单位。只保留第一段撞击，末帧恢复首帧。
Attack.anim位于Assets/Animations/Enemies/Slime，SpriteRenderer曲线绑定在Animator同一对象。
Frames位于Assets/ArtSource/MagicAcademy/Slime_Attack_Left_v1/Frames。
画布768×768，地面基线672，Pivot(0.5,0.125)，PPU=280，等比缩放与移动素材相同。
抠图保护黑色描边。动画不自带伤害事件，命中与冷却由游戏逻辑控制。
预览GIF反复播放方便检查；Attack.anim不循环。尚未在Unity编辑器内验证播放。
