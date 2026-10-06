# 魔法飞弹与 Mana
所有单帧透明PNG为256×256，PPU512，Bilinear，无压缩。
MagicMissile.png：飞弹静态素材，朝右。
Flight：4帧尾焰循环，12fps，0.333秒。Pivot(0.65625,0.5)固定在圆头中心，位置移动由游戏代码控制。
Hit：7帧命中爆闪→碎片缩小→完全透明，12fps，约0.583秒，不循环。第7帧有意完全透明。Pivot(0.5,0.5)，命中对象放在飞弹圆头碰撞位置。
Mana.png：静态薄荷绿色魔法球，不含动画。
附带两个.anim，作用于同一对象的SpriteRenderer，未在Unity编辑器内验证导入。将Flight/Hit/Mana的.png与.meta一起导入，保持动画引用。
Sheets包含两张等间距图集，按256×256切片，Flight从左到右4格，Hit从左到右7格。若使用单帧和附带.anim，无需导入Sheets。
Flight_Preview.gif和Hit_Preview.gif只用于预览。Hit预览为方便观看重复播放，Unity动画本身不循环。
使用内置imagegen生成，保留原生透明度，切片后以固定缩放和锚点整理，没有绿幕抠图或描边收缩。
