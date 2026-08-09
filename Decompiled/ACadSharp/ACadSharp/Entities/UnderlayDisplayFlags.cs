using System;

namespace ACadSharp.Entities;

[Flags]
public enum UnderlayDisplayFlags : byte
{
	ClippingOn = 1,
	ShowUnderlay = 2,
	Monochrome = 4,
	AdjustForBackground = 8,
	ClipInsideMode = 0x10,
	Default = 0xB
}
