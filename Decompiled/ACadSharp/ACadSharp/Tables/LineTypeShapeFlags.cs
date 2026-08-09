using System;

namespace ACadSharp.Tables;

[Flags]
public enum LineTypeShapeFlags : short
{
	None = 0,
	RotationIsAbsolute = 1,
	Text = 2,
	Shape = 4
}
