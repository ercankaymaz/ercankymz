using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum MultiaxisRoughingBasedTpCalcParamsGuideCurve
{
	GcFloorCurve,
	GcCeilingCurve,
	GcUserDefinedDrive,
	GcLongestDimension
}
