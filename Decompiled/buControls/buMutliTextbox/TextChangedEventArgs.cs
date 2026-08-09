using System;
using System.Runtime.CompilerServices;

namespace buMutliTextbox;

public class TextChangedEventArgs : EventArgs
{
	[CompilerGenerated]
	private Range range_0;

	public Range ChangedRange
	{
		[CompilerGenerated]
		get
		{
			return range_0;
		}
		[CompilerGenerated]
		set
		{
			range_0 = value;
		}
	}

	public TextChangedEventArgs(Range changedRange)
	{
		ChangedRange = changedRange;
	}
}
