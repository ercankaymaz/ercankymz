using System;

namespace ModuleWorks.ToolpathParameters;

[Serializable]
public enum AdditiveFDMPattern
{
	Triangles,
	Cubic,
	Grid,
	Lines,
	Mesh,
	ZigZag,
	Concentric
}
