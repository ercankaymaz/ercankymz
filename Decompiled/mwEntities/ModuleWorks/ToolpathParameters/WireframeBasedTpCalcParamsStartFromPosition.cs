using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum WireframeBasedTpCalcParamsStartFromPosition
{
	SfpInteriorCorner,
	SfpCurveStartPoint,
	SfpUserDefinedStartPoint,
	SfpMidpointLongestLine,
	SfpInteriorCornerCloseToCurveStartPoint
}
