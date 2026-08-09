using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum MachiningParamsCurvTiltType
{
	ClosestPnt,
	AngleFromCurv,
	AngleFromSpindleMainDir,
	FromStartToEnd,
	AutomaticCurv,
	FromStartToEndForEachContour
}
