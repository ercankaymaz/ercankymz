using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum InfillBoundingParamsMachiningAreaMode
{
	IbpMamSameAsInfill,
	IbpMamLanes,
	IbpMamRegions
}
