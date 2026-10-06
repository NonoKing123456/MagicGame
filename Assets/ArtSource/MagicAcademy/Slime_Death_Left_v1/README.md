# 史莱姆朝左死亡动画
使用之前的Grok图生视频流程生成一段4秒视频，再提取48张透明PNG。12fps，不循环。
闭眼→身体塌陷→摊成紫色泥滩→停留。最终泥滩仍保留简化闭眼表情，没有消失或复活。
Death.anim已放入Assets/Animations/Enemies/Slime。SpriteRenderer曲线绑定在Animator同一对象上。
Frames放入Assets/ArtSource/MagicAcademy/Slime_Death_Left_v1/Frames。
画布768×768，锚点(384,672)，Pivot(0.5,0.125)，PPU=280，沿用项目现有史莱姆移动帧设置；等比缩放与移动帧一致。
所有帧固定底部和水平中心，取消视频位移。抠图保护黑色描边，无最终Alpha腐蚀。
最后停留为泥滩；尸体清理时间由游戏逻辑控制。没有更改现有Animator Controller或Move.anim。
预览GIF为方便观看反复播放，Death.anim本身关闭循环。尚未在Unity编辑器内确认导入与播放。
