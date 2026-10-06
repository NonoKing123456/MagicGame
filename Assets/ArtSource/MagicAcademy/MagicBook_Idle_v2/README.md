# 魔法书 Idle 返工版 v2

连续真实视频中的轻微待机片段，按时间正序取帧。不做倒放，不复制首尾帧或峰值帧，不增加停顿。Idle 开启循环；首尾选取相近阶段，仍可能有轻微接点变化。

12帧，12fps，1.000秒；每个PNG的解码像素不同，每个源视频帧号只使用一次。重复检测记录见QA_Result.json。
512×512透明PNG，PPU=256，Pivot=(0.5, 0.4208984375)，同现有MagicBook_0锚点，恒定等比缩放。
Clip路径：Assets/Animations/Characters/Magic Book/Idle.anim。保留原Clip的.meta与GUID，更新为v2帧引用。
PNG路径：Assets/ArtSource/MagicAcademy/MagicBook_Idle_v2/Frames。PNG与.meta一起导入。
循环Clip在周期边界有一个零时长的首帧键，非循环Clip在结束边界有末帧键；都不是额外重复播放的一帧。
浅底GIF用于预览；独立PNG带真正透明Alpha。没有最终Alpha腐蚀，保护深色描边。
真实AI视频仍有少量书页/封面与透视变化。未在Unity内验证播放，没有修改Prefab、场景或Animator Controller。
