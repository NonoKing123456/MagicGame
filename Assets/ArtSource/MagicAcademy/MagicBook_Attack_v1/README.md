# 魔法书 Attack

抬起并略微收拢、快速展开并下沉、恢复到起始待机姿态。首轮源视频后段存在封面缺口，修正版有过度翻折，均未直接交付。选取首轮轮廓完整的真实视频帧重新剪辑节奏，部分倒序回位；没有合成绘制新姿态。逐帧移除源视频的整体位置漂移，在共同基线之上烘焙约12像素抬起、9像素下沉到PNG，保持同一Pivot和恒定缩放。18帧中最后一帧与第一帧相同。攻击不循环。展开姿态比参考略偏正面，仍有AI透视变化。

- 真实 Grok 图生视频，模型 grok-imagine-video-1.5-lite，4秒、720p 请求、无音频；实际视频尺寸见 VIDEO_INFO.json。
- 交付 18 帧，12fps，时长 1.500 秒；Loop Time = False。
- PNG：512×512，PPU=256，Pivot=(0.5, 0.4208984375)。依据当前 MagicBook_0 子精灵的裁切区域计算锚点，保持原单位世界尺寸；单张原图不修改。
- Clip：Assets/Animations/Characters/Magic Book/Attack.anim；绑定同一对象的 SpriteRenderer.m_Sprite。
- PNG 和 .meta 必须一起复制，以保留 Clip 使用的 GUID。ZIP 中 Unity/Assets 目录包含资源与动画相对路径。
- 保留黑色描边，不使用最终 Alpha 腐蚀。GIF 为浅色底预览，独立 PNG 有真正的透明 Alpha。
- 真实 AI 视频仍有少量书页/封面外观和透视漂移，结束姿态与 Idle 可能略有差异。
- 未在 Unity 编辑器中验证导入和播放。当前 Magic Book Prefab 无 Animator；需要在使用对象上添加 Animator 并连接 Clip。
- 本任务没有修改共享 Prefab、场景或 Animator Controller。攻击 Clip 没有添加发射弹体事件，需由游戏逻辑同步。

源视频：D:\WorkSpace\Arts\Grok_MagicBook_Attack_v1\MagicBook_Attack_720p_4s.mp4
请求 ID：0d659f2e-beb9-975c-8711-bbef6563f054
详细帧号、时间、映射和循环比较见 Animation_Info.json。
