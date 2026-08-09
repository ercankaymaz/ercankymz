using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum ProjectCurvesParamsProjectionType
{
	PcpPtUserDefined,
	PcpPtRadial,
	PcpPtSpiral,
	PcpPtOffset,
	PcpPtUShape,
	PcpPtParallel
}
