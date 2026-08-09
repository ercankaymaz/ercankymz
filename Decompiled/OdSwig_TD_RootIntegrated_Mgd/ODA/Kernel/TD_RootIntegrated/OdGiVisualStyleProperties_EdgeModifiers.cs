using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiVisualStyleProperties_EdgeModifiers
{
	kNoEdgeModifiers = 0,
	kEdgeOverhangFlag = 1,
	kEdgeJitterFlag = 2,
	kEdgeWidthFlag = 4,
	kEdgeColorFlag = 8,
	kEdgeHaloGapFlag = 0x10,
	kAlwaysOnTopFlag = 0x40,
	kEdgeOpacityFlag = 0x80,
	kEdgeWiggleFlag = 0x100,
	kEdgeTextureFlag = 0x200
}
