using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum TurningTpCalcParamsCompensationType
{
	computer,
	control,
	wear,
	inverseWear,
	off
}
