# 魔法学院单位卡片
五张独立卡片：魔法书、炼金锅、石像鬼、普通史莱姆、头盔史莱姆。
全部512×768，透明外缘，统一卡框；角色图使用原有PNG，仅等比缩放与排版。
CardFrame.png为相同的空白卡框，可用于以后增加单位。
标题栏和费用栏留空，未假设任何单位价格。推荐用TextMeshPro动态填写名称与Mana费用；敌人卡片可将费用栏用于其他信息。
Canvas内使用UI Image，Preserve Aspect开启，显示尺寸建议96×144或112×168。无需按场景单位的512 PPU设置；卡片.meta用UI常见的100 PPU，实际UI尺寸由RectTransform控制。
CardLayout.json记录文字区域，坐标原点为图片左上角；UnityNormalized字段采用左下角原点。
卡片导入设置：Sprite Single、Bilinear、无压缩、无MipMap、居中Pivot。导入时将.png与.meta一起复制。未在运行中的Unity编辑器内验证。
Cards_Review.jpg和Cards_Small_Review.jpg只是检视图，不是UI素材。
卡框由内置imagegen生成，原生透明通道保留；没有绿幕抠除或描边收缩。
