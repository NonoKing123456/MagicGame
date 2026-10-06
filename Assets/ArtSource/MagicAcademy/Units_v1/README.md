# 魔法学院：第一批五单位静态原型
交付：Lineup.png、MagicBook.png、AlchemyCauldron.png、Gargoyle.png、Slime.png、HelmetSlime.png。
五张单体均512×512 RGBA，透明背景，无地面投影、文字或UI，完整轮廓保留。深色粗描边、紫蓝金配色、轻俯视三分之四视角。石像鬼的翅膀收起；两种史莱姆保持同种生物、相同身体宽度，头盔版额外增加头盔高度。
单体底部基准统一为y=448；建议Unity Sprite (2D and UI)、Single，Pivot为Custom (0.5,0.125)，PPU可先用512，按你的格子尺寸统一调整。Filter Mode可用Bilinear，保持非像素卡通边缘。压缩按项目实际显示检查。
书是漂浮单位，底部基准为摆放用虚拟基准，并非真实接地。没有制作动画、Sprite Sheet、场景、特效或UI。
使用内置image_gen：先Lineup，再修正折叠翅膀，再各生成单体。HelmetSlime以普通Slime为编辑目标，只加参考头盔。单体外观忠实于Lineup但并非逐像素复制；头盔版保留同种身体和表情设计，并非像素完全一致。
导出只做透明背景的低alpha噪声清理、裁边、等比缩放与统一画布摆放，没有用代码重新绘制单位。
检查：五张透明通道、完整轮廓、基准和缩小辨识度；风格/视角/描边整体一致，五个静态原型PASS。UnitReview.jpg/SmallSizeReview.jpg仅为验收预览，不用作图集。Sources保留生成原图，PROMPTS.json记录实际提示词，QA.json记录画布与基准。

更新：普通Slime改为右上高光、左侧暗部。HelmetSlime保持原版；Lineup.png保留初始设计参考，最新单体以Slime.png为准。原版Slime在Sources/Slime-v1.png。

用户取消改光：Slime.png已恢复初版；HelmetSlime未变。Grok蠕动输入以初版镜像为左向。
