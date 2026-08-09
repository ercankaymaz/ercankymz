using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum ToolAxisControlParamsSideTiltBy
{
	[Obsolete("Deprecated since 2021.04. Please use Angle instead!")]
	CdOnAllContours = 0,
	[Obsolete("Deprecated since 2021.04. Please use ContactPoint instead!")]
	CdOnSingleContours = 1,
	Angle = 0,
	ContactPoint = 1
}
