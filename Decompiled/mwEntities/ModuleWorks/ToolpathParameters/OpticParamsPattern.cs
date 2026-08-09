using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum OpticParamsPattern
{
	PSpiral,
	POneWay,
	PZigZag,
	PRadial,
	PFollowGuideCurves,
	PSpiralMorph,
	PParallelMorph,
	PParallelMorphZigZag,
	PDrumFollowGuideCurves,
	PDrumOneWay,
	PDrumZigZag,
	PDrumParallelToCurve,
	PDrumParallelToCurveZigZag,
	PRing
}
