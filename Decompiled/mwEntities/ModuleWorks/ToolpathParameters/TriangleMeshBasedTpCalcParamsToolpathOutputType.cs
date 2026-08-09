using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum TriangleMeshBasedTpCalcParamsToolpathOutputType
{
	TotPointDistribution,
	TotFitArcs,
	TotHighSurfaceQuality,
	TotFitArcsAndPointDistribution,
	TotPolygonizeAndPointDistribution
}
