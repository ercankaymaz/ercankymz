using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum ImpellerBlendFinishParamsRangeDeterminationMode
{
	RdmReferenceTool,
	RdmMaxOffset,
	RdmCutCount,
	RdmSameAsOtherSide
}
