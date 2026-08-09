using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum AdditiveFDMDistancePriority
{
	ZOverridesXy,
	XyOverridesZ
}
