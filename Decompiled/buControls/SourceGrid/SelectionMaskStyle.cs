using System;

namespace SourceGrid;

[Flags]
public enum SelectionMaskStyle
{
	None = 0,
	DrawOnlyInitializedCells = 1,
	DrawSeletionOverCells = 2,
	Default = 2
}
