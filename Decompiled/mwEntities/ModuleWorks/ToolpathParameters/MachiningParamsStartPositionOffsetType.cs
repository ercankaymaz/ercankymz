using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum MachiningParamsStartPositionOffsetType
{
	SpShiftByVal,
	SpRotateByDeg,
	SpMinimizeSurfNormChange
}
