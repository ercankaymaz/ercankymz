using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum MachiningParamsAxialShiftType
{
	AstConstForEachContour,
	AstGradualForAllCuts,
	AstGradualForEachContour
}
