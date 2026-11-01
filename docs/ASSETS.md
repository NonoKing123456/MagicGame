# 素材、LFS 与第三方来源

图片、动画帧、音乐和音效由 Git LFS 管理。克隆后执行 `git lfs pull`，保留资源对应 `.meta`，不以指针文件或重新生成的 GUID 替代原资源。

已有说明入口：

- [美术来源目录](../Assets/ArtSource/MagicAcademy/)
- [音频说明](../Assets/Audio/MagicAcademy/README.md)
- [音频署名](../Assets/Audio/MagicAcademy/Licenses/CREDITS.md)
- [战斗音乐说明](../Assets/Audio/MagicAcademy/Music/Battle/README.md)
- [战斗音乐署名](../Assets/Audio/MagicAcademy/Music/Battle/CREDITS.md)

各素材子目录包含制作或生成记录，不把所有素材视为同一种授权。新增资源记录作者或工具、来源、许可、修改和使用范围。没有明确许可的资源先确认其权利范围，不移除已有署名。

源码尚未单独声明项目许可证；根 `.gitattributes` 中模板的 MIT 注释只涉及该模板，不自动覆盖游戏代码或素材。
