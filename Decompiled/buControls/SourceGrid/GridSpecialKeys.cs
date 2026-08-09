using System;

namespace SourceGrid;

[Flags]
public enum GridSpecialKeys
{
	None = 0,
	Arrows = 0x10,
	Tab = 0x20,
	PageDownUp = 0x40,
	Enter = 0x80,
	Escape = 0x100,
	Control = 0x200,
	Shift = 0x400,
	Default = 0x7F0
}
