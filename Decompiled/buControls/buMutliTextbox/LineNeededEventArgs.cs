using System;
using System.Runtime.CompilerServices;

namespace buMutliTextbox;

public class LineNeededEventArgs : EventArgs
{
	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private int int_0;

	[CompilerGenerated]
	private string string_1;

	public string SourceLineText
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
		[CompilerGenerated]
		private set
		{
			string_0 = value;
		}
	}

	public int DisplayedLineIndex
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

	public string DisplayedLineText
	{
		[CompilerGenerated]
		get
		{
			return string_1;
		}
		[CompilerGenerated]
		set
		{
			string_1 = value;
		}
	}

	public LineNeededEventArgs(string sourceLineText, int displayedLineIndex)
	{
		SourceLineText = sourceLineText;
		DisplayedLineIndex = displayedLineIndex;
		DisplayedLineText = sourceLineText;
	}
}
