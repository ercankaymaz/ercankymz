using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdGiDgLinetypeModifiers_ShiftMode
{
	kLsNoShift = 0,
	kLsShiftDistance = 1,
	kLsShiftFraction = 2,
	kLsShiftCentered = 3
}
