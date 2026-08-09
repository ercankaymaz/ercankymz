using System;

namespace ACadSharp.Objects;

[Flags]
public enum LeaderLinePropertOverrideFlags
{
	None = 0,
	PathType = 1,
	LineColor = 2,
	LineType = 4,
	LineWeight = 8,
	ArrowheadSize = 0x10,
	Arrowhead = 0x20
}
