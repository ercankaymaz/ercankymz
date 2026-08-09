using System;

namespace SourceGrid;

[Flags]
public enum EditableMode
{
	None = 0,
	F2Key = 1,
	DoubleClick = 2,
	SingleClick = 4,
	AnyKey = 9,
	Focus = 0x10,
	Default = 0xB
}
