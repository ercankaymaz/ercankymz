using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum MultiXPostParamsSolution
{
	CollisionFree,
	WithinLimits,
	CollisionFreeAndWithinLimits
}
