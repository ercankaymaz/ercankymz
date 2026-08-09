using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum MultiaxisRoughingBasedTpCalcParamsPattern
{
	TcMrbOffsetFromFloor,
	TcMrbOffsetFromCeiling,
	TcMrbMorphBetweenCeilingAndFloor,
	TcMrbOffsetFromWall,
	TcMrbParallel,
	[Obsolete("Not used, instead use MultiaxisRoughingBasedTpCalcParamsGuideCurve::GcUserDefinedDrive", true)]
	TcMrbParallelToUserDefinedCurve,
	TcMrbParallelToFloor,
	TcMrbLastType
}
