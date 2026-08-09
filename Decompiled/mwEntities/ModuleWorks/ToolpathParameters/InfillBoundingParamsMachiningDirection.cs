using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum InfillBoundingParamsMachiningDirection
{
	[Obsolete("Deprecated since 2025.12 with API-8866, please use IbpMdDirection1 instead.")]
	IbpMdFollowCurveChaining,
	[Obsolete("Deprecated since 2025.12 with API-8866, please use IbpMdDirection2 instead.")]
	IbpMdFollowCurveChainingReverse,
	IbpMdDirection1,
	IbpMdDirection2
}
