# 头盔史莱姆：现有帧加头盔

使用内置imagegen，参考Units_v1/HelmetSlime.png提取灰色金边头盔并镜像为朝左。没有生成新视频。
史莱姆身体来自当前普通史莱姆Move、Attack、Death Clip实际引用的PNG；仅作一次恒定等比尺寸换算，没有重画身体、倒放、插帧或增加停顿。头盔按脸部位置逐帧贴合，保持刚性。
移动与攻击保持原动作。死亡时身体软化，头盔下沉并略向右侧倾，最后留在紫色液体上。

- Move：19帧，约0.617秒，循环；沿用当前Unity Clip的60 Sample Rate，实际换帧约30fps。
- Attack：9帧，0.75秒，不循环。
- 原攻击第1与第9帧为同一待机姿态，新增头盔后保留该原始回位关系；没有新增重复帧或额外停顿。
- Death：32帧，约2.667秒，不循环；沿用当前Clip选出的源帧，不擅自恢复为旧导出文件的48帧/4秒。
- 每帧768×768、PPU=100。Pivot=(0.5,0.12239583333333333)，依据HelmetSlime_0的实际裁切、底部Pivot和可见地面计算；未统一硬设为普通史莱姆的280 PPU。
- PNG：Assets/ArtSource/MagicAcademy/HelmetSlime_Animations_v1/{Move,Attack,Death}/Frames。
- Clip：Assets/Animations/Enemies/Helmet Slime/{Move,Attack,Death}.anim。
- PNG与.meta一起复制；ZIP中的Unity/Assets按相同目录放入项目，保持GUID引用。
- GIF为浅底预览，独立PNG有真正透明Alpha；Outline_QA.jpg检查浅底、深底及128px辨识度。
- 没有修改普通史莱姆素材、共享Prefab、场景或Animator Controller。当前未找到独立头盔史莱姆Prefab，需在所使用对象的Animator中接入这些Clip。
- 这是单张刚性头盔叠加方案，头盔不随液体非等比变形，个别强压扁姿态可能有轻微悬挑。原视频身体的少量外观漂移仍保留。
- 未在Unity编辑器内验证导入或播放。QA_Result.json验证重复帧、身体保护、源文件不变、时间曲线与GUID引用。

制作脚本：Tools/SpritePipeline/helmet_slime_attach.py。ImageGen提示词见PROMPT.txt，原始生成附件保留在Accessories。
