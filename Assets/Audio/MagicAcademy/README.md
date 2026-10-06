# 魔法学院音频素材库

已入库 28 个音效和 7 个音乐文件（4 首战斗曲、2 个配套过渡片段及 1 首探索候选）。风格依据：现有非像素卡通魔法学院美术、Magic Book／Mana Stove／Gargoyle／Slime，以及卡牌放置、飞弹命中和 Mana 自动回收逻辑。

双击 Preview.html 可在浏览器逐条试听、筛选；也可在 Unity Project 中选中音频使用 Inspector 预览。

## 首选组合

- 魔法书：PageTurn_01 → Cast_01；飞弹：MagicHit_01。
- 炉子：Bubble_01/02/03 随机择一；Mana：Appear_01 → Collect_01/02。
- 石像鬼：StoneHurt_01/02 → Collapse_01/02。
- 史莱姆：Attack_01、Hurt_01、Death_01；Move_01 用较低音量。
- 卡牌：CardSelect_01 → PlaceConfirm_01；费用不足：CannotAfford_01。
- 音乐：Academy_OnceUponATime_Loop，轻幻想钢琴／管弦乐，建议从 0.12 音量开始。

## 与现有逻辑匹配

魔法书攻击间隔 1.5 秒，预备 0.73 秒；PageTurn_01 裁切后约 0.59 秒，发射声在 ShootProjectile 再触发。MagicHit_01 裁切后约 0.40 秒，对应 0.583 秒飞弹命中特效。史莱姆攻击间隔 0.88 秒、预备 0.28 秒，攻击声在 DealDamage 触发。石像鬼死亡音短于 1.1 秒的 dyingTime。

Mana 目前是飞向计数器后自动加 25，并没有点击拾取逻辑；回收声应放在 Mana.Update 的到达判定里。炉子实际计时公式会让当前参数约每 3.57–4.67 秒生成一次资源，冒泡声应跟 GenerateMana 事件触发。

HelmetHit_Reserve 仅为现有 HelmetSlime 美术预留；当前没有对应预制体／独立行为。石像鬼现有预制体没有攻击组件，因此未为它设定攻击音。

## 接入与混音提示

CharacterAudio.cs 当前为空，场景和预制体尚未绑定本库；此次完成下载、整理和导入设置。catalog.csv/json 提供逐文件接入方法和建议音量。

- 每个事件随机择一版本；放置确认与备用落下声择一，避免全部叠放。
- 死亡／命中仅首次状态转换播放；持续碰撞或重复伤害需防重触发。
- 魔法书／炉子当前 dyingTime 为 0，销毁后音效需由独立播放器保留尾音。
- 史莱姆移动约 0.617 秒循环；不要在 FixedUpdate 每帧播放。用动画帧事件，并限制同时出声数量。
- 炉子环境声可先不用；启用时用一个共享低音量层，停止于炉子全灭。
- 炉子泡泡循环已去掉两端空白并轻微平滑裁口；音乐保持完整首尾。接入时检查循环接缝听感。
- SFX 为 44.1 kHz 单声道 16-bit WAV，建议 Decompress On Load；音乐为立体声 OGG，建议 Streaming。文件附 .meta；AudioSource 建议 Spatial Blend=0。

## 文件清单

| 文件 | 用途 | 时长（秒） | 建议音量 |
|---|---|---:|---:|
| [SFX/MagicBook/PageTurn_01.wav](SFX/MagicBook/PageTurn_01.wav) | 魔法书翻页／攻击预备 | 0.593 | 0.30 |
| [SFX/MagicBook/PageTurn_02.wav](SFX/MagicBook/PageTurn_02.wav) | 翻页备用变化 | 0.700 | 0.25 |
| [SFX/MagicBook/Cast_01.wav](SFX/MagicBook/Cast_01.wav) | 魔法飞弹发射 | 0.517 | 0.45 |
| [SFX/MagicBook/Disappear_01.wav](SFX/MagicBook/Disappear_01.wav) | 魔法书消失候选：纸页散开 | 0.962 | 0.25 |
| [SFX/Projectile/MagicHit_01.wav](SFX/Projectile/MagicHit_01.wav) | 飞弹魔法命中 | 0.403 | 0.35 |
| [SFX/ManaStove/Bubble_01.wav](SFX/ManaStove/Bubble_01.wav) | 炉子冒泡／Mana 生成 | 0.273 | 0.25 |
| [SFX/ManaStove/Bubble_02.wav](SFX/ManaStove/Bubble_02.wav) | 冒泡变化 | 0.414 | 0.22 |
| [SFX/ManaStove/Bubble_03.wav](SFX/ManaStove/Bubble_03.wav) | 冒泡变化 | 0.389 | 0.22 |
| [SFX/ManaStove/Bubbling_Loop.wav](SFX/ManaStove/Bubbling_Loop.wav) | 炉子低音量持续冒泡候选 | 4.665 | 0.10 |
| [SFX/Mana/Appear_01.wav](SFX/Mana/Appear_01.wav) | Mana 魔法球出现 | 0.211 | 0.25 |
| [SFX/Mana/Collect_01.wav](SFX/Mana/Collect_01.wav) | Mana 到达计数器／回收 | 0.094 | 0.35 |
| [SFX/Mana/Collect_02.wav](SFX/Mana/Collect_02.wav) | Mana 回收变化 | 0.142 | 0.30 |
| [SFX/Gargoyle/StoneHurt_01.wav](SFX/Gargoyle/StoneHurt_01.wav) | 石像鬼受击 | 0.130 | 0.35 |
| [SFX/Gargoyle/StoneHurt_02.wav](SFX/Gargoyle/StoneHurt_02.wav) | 石像鬼受击变化 | 0.329 | 0.32 |
| [SFX/Gargoyle/Collapse_01.wav](SFX/Gargoyle/Collapse_01.wav) | 石像鬼死亡／石块崩塌 | 0.441 | 0.50 |
| [SFX/Gargoyle/Collapse_02.wav](SFX/Gargoyle/Collapse_02.wav) | 石块崩塌变化 | 0.621 | 0.45 |
| [SFX/Gargoyle/StonePlace_01.wav](SFX/Gargoyle/StonePlace_01.wav) | 石像鬼落地放置候选 | 0.591 | 0.30 |
| [SFX/Slime/Move_01.wav](SFX/Slime/Move_01.wav) | 史莱姆蠕动黏液声 | 0.351 | 0.12 |
| [SFX/Slime/Attack_01.wav](SFX/Slime/Attack_01.wav) | 史莱姆攻击黏液声 | 0.515 | 0.32 |
| [SFX/Slime/Hurt_01.wav](SFX/Slime/Hurt_01.wav) | 史莱姆受击黏液声 | 0.459 | 0.25 |
| [SFX/Slime/Death_01.wav](SFX/Slime/Death_01.wav) | 史莱姆死亡塌软候选 | 0.431 | 0.40 |
| [SFX/Slime/HelmetHit_Reserve.wav](SFX/Slime/HelmetHit_Reserve.wav) | 头盔史莱姆金属受击储备 | 0.196 | 0.25 |
| [SFX/UI/CardSelect_01.wav](SFX/UI/CardSelect_01.wav) | 卡牌选中 | 0.026 | 0.25 |
| [SFX/UI/CardSelect_02.wav](SFX/UI/CardSelect_02.wav) | 卡牌选中备用：轻拨弦 | 0.084 | 0.22 |
| [SFX/UI/PlaceConfirm_01.wav](SFX/UI/PlaceConfirm_01.wav) | 放置成功确认 | 0.290 | 0.30 |
| [SFX/UI/PlaceDrop_Alternative.wav](SFX/UI/PlaceDrop_Alternative.wav) | 放置成功备用：轻落下 | 0.118 | 0.25 |
| [SFX/UI/CannotAfford_01.wav](SFX/UI/CannotAfford_01.wav) | Mana 不足／无效操作 | 0.156 | 0.22 |
| [SFX/UI/Cancel_01.wav](SFX/UI/Cancel_01.wav) | 取消／无效格子放置 | 0.061 | 0.20 |
| [Music/Academy_OnceUponATime_Loop.ogg](Music/Academy_OnceUponATime_Loop.ogg) | 轻幻想钢琴／管弦乐循环候选 | 57.595 | 0.12 |

## 首尾裁切

28 个音效（包括炉子冒泡循环）均检查首尾。以 2 毫秒 RMS 窗口、相对峰值 -48 dB 判断声音边界，保留起音前 2 毫秒和衰减后 8 毫秒余量；仅裁两端，保留内部停顿和声音主体。音效加约 1 毫秒淡入、4 毫秒淡出，避免裁口爆音。已无多余空白的音效保持时长。
背景音乐保留完整循环段。catalog.json/csv 记录原时长、裁后时长、头尾裁切量；裁切前成品备份：Tools/AudioLibrary/Backups/BeforeTrim_20261005。

## 来源和验收

来源及授权见 [Licenses/CREDITS.md](Licenses/CREDITS.md)。原始文件保留在 Tools/AudioLibrary/Sources，未全量导入 Unity。

已校验所有成品可解码、非静音、采样值有效、无满幅削波；音乐保留立体声。处理增益和文件哈希写入 catalog.json。

选材依据作者分类、对象材质与事件时长；尚未进行主观试听或 Unity Play Mode 混音验收。音量为起始建议，应在战斗密集场景试听调整。


## 战斗配乐选集（2026-10-06）

新增 4 首战斗配乐及 2 个配套过渡片段，见 [Music/Battle/README.md](Music/Battle/README.md)，可打开 [战斗配乐试听页](Music/Battle/Preview.html)。建议先试 Heartfelt 的循环段，再按敌群密度比较 Light Battle 与 Hope。旧 Once Upon a Time 保留作为探索／准备阶段候选。

本组包含 CC-BY 4.0 素材，署名要求与可复制鸣谢文字见 [Music/Battle/CREDITS.md](Music/Battle/CREDITS.md)。
