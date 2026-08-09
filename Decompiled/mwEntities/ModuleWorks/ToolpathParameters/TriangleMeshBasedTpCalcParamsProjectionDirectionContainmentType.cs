using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum TriangleMeshBasedTpCalcParamsProjectionDirectionContainmentType
{
	TmbPdctSameAsGuideCurve,
	TmbPdctSurfaceNormal,
	TmbPdctOtherDirection,
	TmbPdctMachiningDirection,
	TmbPdctNoProjection
}
