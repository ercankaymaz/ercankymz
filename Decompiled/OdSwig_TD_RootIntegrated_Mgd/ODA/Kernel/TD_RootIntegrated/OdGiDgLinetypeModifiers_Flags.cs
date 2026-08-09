using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiDgLinetypeModifiers_Flags
{
	kFlagUseDashScale = 1,
	kFlagUseGapScale = 2,
	kFlagUseWidth = 4,
	kFlagUseEndWidth = 8,
	kFlagUseShift = 0x10,
	kFlagUseFractionShift = 0x20,
	kFlagUseCenteredShift = 0x40,
	kFlagTrueWidth = 0x80,
	kFlagOverrideBreakAtCorners = 0x100,
	kFlagOverrideRunThroughCorners = 0x200,
	kFlagsWidthMask = 0xC,
	kFlagsShiftMask = 0x70,
	kFlagsCornersMask = 0x300
}
