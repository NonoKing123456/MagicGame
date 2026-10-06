# 魔法学院战斗配乐选集

2026-10-06 · 4 首战斗配乐，另含 Heartfelt 的入场与收尾片段。

推荐顺序依据作者给出的战斗定位、配器及循环结构，再结合卡牌放置、魔法飞弹、史莱姆连续来袭的玩法判断。配乐尚未进行主观试听与游戏内混音验收。

## 推荐顺序与场景

| 曲目 | 建议用途 | 时长 | 循环 | 授权 |
|---|---|---:|---|---|
| [Heartfelt Battle](Heartfelt_Loop.ogg) | 首选：普通波次／魔法对抗 | 153.6s | 作者提供循环段 | CC0-1.0 |
| [Light battle theme](LightBattle_Loop.ogg) | 备选：轻度战斗／小规模波次 | 104.8s | 作者提供循环段 | CC-BY-4.0 |
| [Hope (Orchestral battle music)](Hope_Loop.ogg) | 密集波次／守住阵线 | 69.8s | 作者提供循环段 | CC0-1.0 |
| [Battle Theme A](BattleThemeA.ogg) | 最终波次／大型战斗完整版储备 | 95.9s | 播放一次 | CC0-1.0 |
| [Heartfelt Battle — Intro](Heartfelt_Intro.ogg) | 配套过渡：战斗入场 | 12.8s | 播放一次 | CC0-1.0 |
| [Heartfelt Battle — Outro](Heartfelt_Outro.ogg) | 配套过渡：战斗收尾 | 3.2s | 播放一次 | CC0-1.0 |

## 选曲理由

- **Heartfelt Battle**：作者标注幻想战斗，配器为弦乐、钢琴、圆号；以这组配器作为学院魔法战斗的首选候选。 [作者页面](https://opengameart.org/content/heartfelt-battle-loopable-fantasy-stringspianohorn)
- **Light battle theme**：作者明确标注轻度战斗、combat、loop；适合先测试低压普通波次，与卡牌操作及短音效配合。 [作者页面](https://opengameart.org/content/light-battle-theme)
- **Hope (Orchestral battle music)**：作者标注明亮的管弦乐战斗循环，文件注明 165 BPM；为敌群变密时准备较强推进感。 [作者页面](https://opengameart.org/content/hopeorchestral-battle-music)
- **Battle Theme A**：作者描述为 RPG 史诗战斗，突出弦乐和圆号；用于高强度阶段候选。原发布文件为完整 MP3，未宣称无缝循环。 [作者页面](https://opengameart.org/content/battle-theme-a)

## 使用方式

先在 Preview.html 逐曲比较。Heartfelt 的顺序为 Intro → Loop（重复）→ Outro；需要无缝调度时用 DSP 时间排程，避免在 Update 里用粗略等待拼接。

Light Battle 和 Hope 可以直接从作者的循环段开始。Battle Theme A 保留完整版用于最终波次储备，未制作循环点；不要把整曲直接设置 loop 并声称无缝。

建议音量已按各曲测得的整体响度调整到接近的试听水平，未改变源文件音量。进入密集战斗时先压低音乐，让施法、受击和 Mana 音效保持清楚。

三条原始 OGG 循环段直接复制，保留完整首尾。Intro 与 Outro 也直接复制；MP3 完整版转为 OGG。Unity 使用 Streaming、立体声，并保留 .meta 引用。

来源、原文件、哈希、响度和授权见 catalog.json；署名要求见 [CREDITS.md](CREDITS.md)。原始下载与网页快照保留在 Tools/AudioLibrary/Sources/BattleMusic_20261006。
