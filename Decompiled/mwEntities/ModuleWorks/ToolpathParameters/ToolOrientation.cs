using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum ToolOrientation
{
	automatic,
	awayFromClearance,
	towardsClearance
}
