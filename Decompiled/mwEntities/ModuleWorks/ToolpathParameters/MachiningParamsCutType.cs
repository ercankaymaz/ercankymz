using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum MachiningParamsCutType
{
	CutParallel,
	CutAlongCurve,
	CutBetweenCurves,
	CutParallelCurves,
	CutProjectCurves,
	CutBetweenSurfaces,
	CutParallelSurface,
	CutFlowline
}
