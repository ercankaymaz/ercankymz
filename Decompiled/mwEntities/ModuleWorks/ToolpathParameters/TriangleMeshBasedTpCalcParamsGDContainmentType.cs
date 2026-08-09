using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum TriangleMeshBasedTpCalcParamsGDContainmentType
{
	TmbGdProjectionCurves,
	TmbGdNearestCurves,
	TmbGdProjectionAlongDirection,
	TmbGdNoProjection
}
