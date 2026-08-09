using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum ToolAxisControlParamsContactPointDefintionType
{
	[Obsolete("Deprecated since 2021.04. Please use ByHeight instead!")]
	CdOnAllContours = 0,
	[Obsolete("Deprecated since 2021.04. Please use ByLineParameter instead!")]
	CdOnSingleContours = 1,
	ByHeight = 0,
	ByLineParameter = 1
}
