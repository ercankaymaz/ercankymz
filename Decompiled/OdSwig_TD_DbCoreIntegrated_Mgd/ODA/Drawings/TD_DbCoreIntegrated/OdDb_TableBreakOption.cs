using System;

namespace ODA.Drawings.TD_DbCoreIntegrated;

[Flags]
public enum OdDb_TableBreakOption
{
	kTableBreakNone = 0,
	kTableBreakEnableBreaking = 1,
	kTableBreakRepeatTopLabels = 2,
	kTableBreakRepeatBottomLabels = 4,
	kTableBreakAllowManualPositions = 8,
	kTableBreakAllowManualHeights = 0x10
}
