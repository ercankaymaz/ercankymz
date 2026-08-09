using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum SwarfMillingBasedTpCalcParamsSlicesDirectionType
{
	SdAlongToolAxis,
	SdAlongContactLine,
	SdFollowSurfaceTopology
}
