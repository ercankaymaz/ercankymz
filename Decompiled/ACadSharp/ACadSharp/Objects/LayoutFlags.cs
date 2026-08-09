using System;

namespace ACadSharp.Objects;

[Flags]
public enum LayoutFlags : short
{
	None = 0,
	PaperSpaceLinetypeScaling = 1,
	LimitsChecking = 2
}
