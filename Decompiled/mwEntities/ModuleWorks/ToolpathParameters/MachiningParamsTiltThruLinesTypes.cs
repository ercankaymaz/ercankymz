using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum MachiningParamsTiltThruLinesTypes
{
	UseAllLinesWeightedByDistance,
	UseAlwaysClosestTwoLines,
	UseOnSurfaceLines,
	UseAlwaysClosestToSurface
}
