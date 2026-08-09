using System;

namespace SourceGrid;

public class RangeEventArgs : EventArgs
{
	private Range p_GridRange;

	public Range Range => p_GridRange;

	public RangeEventArgs(Range p_GridRange)
	{
		this.p_GridRange = p_GridRange;
	}
}
