using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum ProbingBasedTpCalcParamsMoveAction
{
	directStartEndPoint,
	directSafePoint,
	blendSplineStartEndPoint,
	blendSplineSafePoint,
	retractToClearanceArea
}
