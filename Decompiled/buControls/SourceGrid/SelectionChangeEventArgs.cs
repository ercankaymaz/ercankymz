using System;

namespace SourceGrid;

public class SelectionChangeEventArgs : EventArgs
{
	private Range p_Range;

	private SelectionChangeEventType p_Type;

	public Range Range => p_Range;

	public SelectionChangeEventType EventType => p_Type;

	public SelectionChangeEventArgs(SelectionChangeEventType p_Type, Range p_Range)
	{
		this.p_Type = p_Type;
		this.p_Range = p_Range;
	}
}
