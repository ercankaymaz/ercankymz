using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum AdditiveFDMWallStartPointStrategy
{
	MinimumDistance,
	InnerCorner,
	OuterCorner,
	Corner
}
