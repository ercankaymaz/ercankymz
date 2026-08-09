using System;

namespace SourceGrid;

[Flags]
public enum FocusStyle
{
	None = 0,
	RemoveFocusCellOnLeave = 1,
	RemoveSelectionOnLeave = 2,
	FocusFirstCellOnEnter = 4,
	Default = 5
}
