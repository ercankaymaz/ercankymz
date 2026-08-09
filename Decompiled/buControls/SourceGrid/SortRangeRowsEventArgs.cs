using System;
using System.Collections;

namespace SourceGrid;

public class SortRangeRowsEventArgs : EventArgs
{
	private Range p_Range;

	private int keyColumn;

	private bool p_bAscending;

	private IComparer p_CellComparer;

	public Range Range => p_Range;

	public int KeyColumn => keyColumn;

	public bool Ascending => p_bAscending;

	public IComparer CellComparer => p_CellComparer;

	public SortRangeRowsEventArgs(Range p_Range, int keyColumn, bool p_bAscending, IComparer p_CellComparer)
	{
		this.p_Range = p_Range;
		this.keyColumn = keyColumn;
		this.p_bAscending = p_bAscending;
		this.p_CellComparer = p_CellComparer;
	}
}
