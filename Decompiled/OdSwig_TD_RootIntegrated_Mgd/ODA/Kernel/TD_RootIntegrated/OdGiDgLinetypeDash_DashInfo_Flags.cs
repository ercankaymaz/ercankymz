using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiDgLinetypeDash_DashInfo_Flags
{
	kFlagDash = 1,
	kFlagPassCorner = 2,
	kFlagCanBeScaled = 4,
	kFlagInvertStrokeInFirstCode = 8,
	kFlagInvertStrokeInLastCode = 0x10,
	kFlagIncreasingTaper = 0x20,
	kFlagDecreasingTaper = 0x40,
	kFlagBaseStrokeDash = 0x80
}
