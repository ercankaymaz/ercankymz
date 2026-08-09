using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum DeburringTiltingStrategy
{
	normalToContour,
	fixedToMainAxis
}
