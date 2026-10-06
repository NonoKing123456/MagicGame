# 史莱姆向左蠕动：游戏序列帧
19张透明PNG，768×768，24fps，周期约0.792秒。Frames按Crawl_Left_01到19顺序播放，再回到01。
源视频第64～82帧；第83帧为最接近的下一周期对应姿势，未重复放入。源周期首尾轮廓相似度约96.4%，这是实视频选帧，不是逐像素相同的无缝动画。
绿幕和绿色地面阴影已经抠除，保留粗描边和卡通颜色；统一等比缩放，保留压扁/拉长，没有重画或AI补帧。
每帧底部y=672，水平主体居中。原视频位移和上下漂移已消除，游戏中由代码控制向左移动。
画布扩大到768是为了容纳史莱姆的横向拉伸，不是放大单位；以源初始静态体宽408映射到340，PPU仍为512，与之前静态单位一致。
Unity项目已放入Assets/ArtSource/MagicAcademy/Slime_Crawl_v1/Frames。附带Sprite Single、Bilinear、无压缩、Full Rect、PPU512、Custom Pivot(0.5,0.125)的导入配置。未在运行中的Unity编辑器内确认导入结果。
使用方法：选择01～19拖到Animation窗口创建Crawl动画，Samples设24，Loop Time开启；挂到SpriteRenderer所在对象。移动速度独立设置。
Crawl_Left_Preview.gif是检视预览，不是游戏播放资源；Frames_Review.jpg仅为逐帧验收图。Native_Selected保留960原始透明帧，便于后续修整。只制作此蠕动动作，没有扩展Idle/Attack/Hit/Death。
