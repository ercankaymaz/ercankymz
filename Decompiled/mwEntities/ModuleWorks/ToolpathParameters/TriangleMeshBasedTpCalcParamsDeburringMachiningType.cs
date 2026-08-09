using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum TriangleMeshBasedTpCalcParamsDeburringMachiningType
{
	DmtDeburring3Axis,
	[Obsolete("Deprecated since 2021.12. Please use DmtDeburring3Axis instead!")]
	DmtDeburring3AxisCd,
	[Obsolete("Deprecated since 2021.12. Please use DmtDeburring5AxisIndexed instead!")]
	DmtDeburring3plus2,
	[Obsolete("Deprecated since 2021.12. Please use DmtDeburring5AxisIndexed instead!")]
	DmtDeburring3plus2Retilt,
	DmtDeburring4plus1,
	DmtDeburring4Axis,
	DmtDeburring5Axis,
	DmtDeburring5AxisIndexed
}
