using System;

namespace ACadSharp.Tables;

[Flags]
public enum LayerFlags : short
{
	None = 0,
	Frozen = 1,
	FrozenNewViewports = 2,
	Locked = 4,
	XrefDependent = 0x10,
	XrefResolved = 0x20,
	Referenced = 0x40
}
