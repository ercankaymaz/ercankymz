using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum DrillingBasedTpCalcParamsDrillCycle
{
	DcDrill,
	DcCsink,
	DcFace,
	DcPeck,
	DcBore,
	DcReam,
	DcTap
}
