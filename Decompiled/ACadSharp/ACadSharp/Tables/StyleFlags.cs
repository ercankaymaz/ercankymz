using System;

namespace ACadSharp.Tables;

[Flags]
public enum StyleFlags
{
	None = 0,
	IsShape = 1,
	VerticalText = 4,
	XrefDependent = 0x10,
	XrefResolved = 0x20,
	Referenced = 0x40
}
