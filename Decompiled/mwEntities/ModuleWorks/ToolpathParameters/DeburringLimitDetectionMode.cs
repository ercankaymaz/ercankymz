using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum DeburringLimitDetectionMode
{
	none,
	byHeight,
	byMesh
}
