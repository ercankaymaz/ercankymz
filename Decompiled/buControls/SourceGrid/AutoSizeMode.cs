using System;

namespace SourceGrid;

[Flags]
public enum AutoSizeMode
{
	None = 0,
	EnableAutoSize = 1,
	EnableAutoSizeView = 9,
	EnableStretch = 2,
	MinimumSize = 4,
	Default = 3
}
