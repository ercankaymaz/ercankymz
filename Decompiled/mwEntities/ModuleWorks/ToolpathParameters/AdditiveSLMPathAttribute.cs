using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum AdditiveSLMPathAttribute
{
	Any,
	Contour,
	ContourBlocked,
	FillContour,
	FillContouerBlocked,
	InfillSegment,
	InfillSegmentRetract,
	LastType
}
