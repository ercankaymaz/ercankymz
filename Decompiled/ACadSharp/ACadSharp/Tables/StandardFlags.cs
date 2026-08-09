using System;

namespace ACadSharp.Tables;

[Flags]
public enum StandardFlags : short
{
	None = 0,
	XrefDependent = 0x10,
	XrefResolved = 0x20,
	Referenced = 0x40
}
