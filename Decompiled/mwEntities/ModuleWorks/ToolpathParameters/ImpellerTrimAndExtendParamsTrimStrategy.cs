using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum ImpellerTrimAndExtendParamsTrimStrategy
{
	TsNoTrim,
	TsTrimAutomatic,
	TsTrimLeadTrailEdge,
	TsTrimAngleFromTip,
	TsTrimAtLength,
	TsTrimSmart
}
