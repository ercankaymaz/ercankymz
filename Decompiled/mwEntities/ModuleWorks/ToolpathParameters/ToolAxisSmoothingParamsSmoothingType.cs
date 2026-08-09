using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum ToolAxisSmoothingParamsSmoothingType
{
	TasStGlobal,
	TasStRelativeToRotaryAxis,
	TasStRelativeToCuttingDirection
}
