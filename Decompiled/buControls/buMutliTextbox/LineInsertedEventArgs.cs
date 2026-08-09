using System;
using System.Runtime.CompilerServices;

namespace buMutliTextbox;

public class LineInsertedEventArgs : EventArgs
{
	[CompilerGenerated]
	private int int_0;

	[CompilerGenerated]
	private int int_1;

	public int Index
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
		[CompilerGenerated]
		private set
		{
			int_0 = value;
		}
	}

	public int Count
	{
		[CompilerGenerated]
		get
		{
			return int_1;
		}
		[CompilerGenerated]
		private set
		{
			int_1 = value;
		}
	}

	public LineInsertedEventArgs(int index, int count)
	{
		Index = index;
		Count = count;
	}
}
