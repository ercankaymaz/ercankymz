using System;

namespace SourceGrid;

[Flags]
public enum CellResizeMode
{
	None = 0,
	Height = 1,
	Width = 2,
	Both = 3
}
