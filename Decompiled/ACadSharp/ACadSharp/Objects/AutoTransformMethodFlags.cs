using System;

namespace ACadSharp.Objects;

[Flags]
public enum AutoTransformMethodFlags : byte
{
	None = 0,
	NoAutoTransform = 1,
	ScaleMapper = 2,
	IncludeCurrentBlock = 4
}
