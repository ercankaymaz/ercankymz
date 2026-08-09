using System;

namespace ACadSharp.Entities;

[Flags]
public enum InvisibleEdgeFlags
{
	None = 0,
	First = 1,
	Second = 2,
	Third = 4,
	Fourth = 8
}
