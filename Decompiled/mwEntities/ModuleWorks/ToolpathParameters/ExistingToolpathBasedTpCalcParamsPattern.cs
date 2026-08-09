using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum ExistingToolpathBasedTpCalcParamsPattern
{
	TcEtbConversion,
	TcEtbDrop,
	TcEtbWrap,
	TcEtbAutotilt3To5Axis,
	TcEtbLink2Toolpathts,
	[Obsolete("Deprecated since 2025.08")]
	TcEtbMachineAwareness,
	TcEtbSafeRetractApproach,
	TcEtbTransformToolpath,
	TcEtbFeedControl
}
