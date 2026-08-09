using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum ImpellerTiltParamsTiltStrategy
{
	TsFixedLeadLagAngle,
	TsLeadLagAngleSplitterAndTrailingEdge,
	TsTiltLines,
	TsSwarfBlades
}
