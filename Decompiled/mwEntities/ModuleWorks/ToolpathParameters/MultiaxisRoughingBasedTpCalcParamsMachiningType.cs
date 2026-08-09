using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum MultiaxisRoughingBasedTpCalcParamsMachiningType
{
	MrbMtRoughing,
	MrbMtFinishing,
	MrbMtFloorFinishing,
	MrbMtWallFinishing,
	MrbMtRestFinishing
}
