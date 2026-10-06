# 魔法书 Attack 返工版 v2

完整真实视频姿态按时间正序各用一次：轻抬并收拢 → 快速展开并稍微下沉。跳过源视频过度闭合与破损段；最后在展开姿态结束，不添加倒放回位。不循环。上下位移烘焙为约12像素抬起、9像素下沉。展开时仍略偏正面。

14帧，12fps，1.167秒；每个PNG的解码像素不同，每个源视频帧号只使用一次。重复检测记录见QA_Result.json。
512×512透明PNG，PPU=256，Pivot=(0.5, 0.4208984375)，同现有MagicBook_0锚点，恒定等比缩放。
Clip路径：Assets/Animations/Characters/Magic Book/Attack.anim。保留原Clip的.meta与GUID，更新为v2帧引用。
PNG路径：Assets/ArtSource/MagicAcademy/MagicBook_Attack_v2/Frames。PNG与.meta一起导入。
循环Clip在周期边界有一个零时长的首帧键，非循环Clip在结束边界有末帧键；都不是额外重复播放的一帧。
浅底GIF用于预览；独立PNG带真正透明Alpha。没有最终Alpha腐蚀，保护深色描边。
真实AI视频仍有少量书页/封面与透视变化。未在Unity内验证播放，没有修改Prefab、场景或Animator Controller。
