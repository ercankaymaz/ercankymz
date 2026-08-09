using System;

namespace ACadSharp.Blocks;

[Flags]
public enum BlockTypeFlags
{
	None = 0,
	Anonymous = 1,
	NonConstantAttributeDefinitions = 2,
	XRef = 4,
	XRefOverlay = 8,
	XRefDependent = 0x10,
	XRefResolved = 0x20,
	Referenced = 0x40
}
