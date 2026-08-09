using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace buMutliTextbox;

public class LineRemovedEventArgs : EventArgs
{
	[CompilerGenerated]
	private int int_0;

	[CompilerGenerated]
	private int int_1;

	[CompilerGenerated]
	private List<int> list_0;

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

	public List<int> RemovedLineUniqueIds
	{
		[CompilerGenerated]
		get
		{
			return list_0;
		}
		[CompilerGenerated]
		private set
		{
			list_0 = value;
		}
	}

	public LineRemovedEventArgs(int index, int count, List<int> removedLineIds)
	{
		Index = index;
		Count = count;
		RemovedLineUniqueIds = removedLineIds;
	}
}
