using System;

namespace SourceGrid;

[Flags]
public enum ContextMenuStyle
{
	None = 0,
	ColumnResize = 1,
	RowResize = 2,
	AutoSize = 4,
	ClearSelection = 8,
	CopyPasteSelection = 0x10,
	CellContextMenu = 0x20
}
