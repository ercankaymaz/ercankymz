using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum MultiaxisRoughingBasedTpCalcParamsWallOrientationCurveType
{
	WoctAutomatic,
	WoctByFloorCurve,
	WoctByCeilingCurve,
	WoctByDirection,
	WoctLastType
}
