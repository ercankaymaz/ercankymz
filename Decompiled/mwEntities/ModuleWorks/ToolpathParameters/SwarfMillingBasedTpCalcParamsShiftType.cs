using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum SwarfMillingBasedTpCalcParamsShiftType
{
	StShiftNotSet = -1,
	StShiftConstForEachSlice,
	StShiftGradualForEachSlice
}
