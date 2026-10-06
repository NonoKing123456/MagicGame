# 魔法书 Idle

轻微书页与封面活动。移除源视频的水平和基线漂移，统一恒定缩放。源视频的长片段有尺寸漂移，改选尺寸更稳定的短片段，按正序/倒序往返播放，并在两端短暂停顿。首尾为同一帧，循环接点不会出现不同姿态的跳切；往返转折处仍可能有节奏变化。真实视频姿态，没有合成绘制新帧。

- 真实 Grok 图生视频，模型 grok-imagine-video-1.5-lite，4秒、720p 请求、无音频；实际视频尺寸见 VIDEO_INFO.json。
- 交付 15 帧，12fps，时长 1.250 秒；Loop Time = True。
- PNG：512×512，PPU=256，Pivot=(0.5, 0.4208984375)。依据当前 MagicBook_0 子精灵的裁切区域计算锚点，保持原单位世界尺寸；单张原图不修改。
- Clip：Assets/Animations/Characters/Magic Book/Idle.anim；绑定同一对象的 SpriteRenderer.m_Sprite。
- PNG 和 .meta 必须一起复制，以保留 Clip 使用的 GUID。ZIP 中 Unity/Assets 目录包含资源与动画相对路径。
- 保留黑色描边，不使用最终 Alpha 腐蚀。GIF 为浅色底预览，独立 PNG 有真正的透明 Alpha。
- 真实 AI 视频仍有少量书页/封面外观和透视漂移，循环接点可能略有变化。
- 未在 Unity 编辑器中验证导入和播放。当前 Magic Book Prefab 无 Animator；需要在使用对象上添加 Animator 并连接 Clip。
- 本任务没有修改共享 Prefab、场景或 Animator Controller。攻击 Clip 没有添加发射弹体事件，需由游戏逻辑同步。

源视频：D:\WorkSpace\Arts\Grok_MagicBook_Idle_v1\MagicBook_Idle_720p_4s.mp4
请求 ID：7d6b3c31-4248-98f2-881b-6f7f02571582
详细帧号、时间、映射和循环比较见 Animation_Info.json。
