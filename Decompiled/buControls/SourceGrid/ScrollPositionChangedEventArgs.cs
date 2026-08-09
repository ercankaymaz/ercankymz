using System;

namespace SourceGrid;

public class ScrollPositionChangedEventArgs : EventArgs
{
	private int p_NewValue;

	private int p_OldValue;

	public int NewValue => p_NewValue;

	public int OldValue => p_OldValue;

	public int Delta => p_OldValue - p_NewValue;

	public ScrollPositionChangedEventArgs(int p_NewValue, int p_OldValue)
	{
		this.p_NewValue = p_NewValue;
		this.p_OldValue = p_OldValue;
	}
}
