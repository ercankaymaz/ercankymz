using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum MachiningParamsSideTiltAproximationTypes
{
	ApproximateByOneVector,
	ApproximateByTwoVectors,
	SmoothApproximation,
	SmoothLocalApproximation,
	NoneApproximation
}
