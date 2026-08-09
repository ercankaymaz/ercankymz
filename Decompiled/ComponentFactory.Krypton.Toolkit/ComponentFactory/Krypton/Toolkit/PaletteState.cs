using System;

namespace ComponentFactory.Krypton.Toolkit;

[Flags]
public enum PaletteState
{
	Disabled = 1,
	Normal = 2,
	Tracking = 4,
	Pressed = 8,
	Checked = 0x1000,
	CheckedNormal = 0x1002,
	CheckedTracking = 0x1004,
	CheckedPressed = 0x1008,
	Context = 0x2000,
	ContextNormal = 0x2002,
	ContextTracking = 0x2004,
	ContextPressed = 0x2008,
	ContextCheckedNormal = 0x2010,
	ContextCheckedTracking = 0x2020,
	Override = 0x100000,
	FocusOverride = 0x100001,
	NormalDefaultOverride = 0x100002,
	LinkVisitedOverride = 0x100004,
	LinkNotVisitedOverride = 0x100008,
	LinkPressedOverride = 0x100010,
	BoldedOverride = 0x100020,
	TodayOverride = 0x100040
}
