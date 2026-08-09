using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace buMutliTextbox;

public class WordWrapNeededEventArgs : EventArgs
{
	[CompilerGenerated]
	private List<int> list_0;

	[CompilerGenerated]
	private bool bool_0;

	[CompilerGenerated]
	private Line line_0;

	public List<int> CutOffPositions
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

	public bool ImeAllowed
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
		[CompilerGenerated]
		private set
		{
			bool_0 = value;
		}
	}

	public Line Line
	{
		[CompilerGenerated]
		get
		{
			return line_0;
		}
		[CompilerGenerated]
		private set
		{
			line_0 = value;
		}
	}

	public WordWrapNeededEventArgs(List<int> cutOffPositions, bool imeAllowed, Line line)
	{
		CutOffPositions = cutOffPositions;
		ImeAllowed = imeAllowed;
		Line = line;
	}
}
