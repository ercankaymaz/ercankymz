using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiEdgeStyle_EdgeModifier
{
	kNoEdgeModifiers = 0,
	kOverhang = 1,
	kJitter = 2,
	kWidth = 4,
	kColor = 8,
	kHaloGap = 0x10,
	kLinetype = 0x20,
	kAlwaysOnTop = 0x40,
	kOpacity = 0x80,
	kWiggle = 0x100,
	kTexture = 0x200
}
