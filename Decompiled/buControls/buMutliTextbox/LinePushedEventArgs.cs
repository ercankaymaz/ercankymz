using System;
using System.Runtime.CompilerServices;

namespace buMutliTextbox;

public class LinePushedEventArgs : EventArgs
{
	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private int int_0;

	[CompilerGenerated]
	private string string_1;

	[CompilerGenerated]
	private string string_2;

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
		private set
		{
			string_1 = value;
		}
	}

	public string SavedText
	{
		[CompilerGenerated]
		get
		{
			return string_2;
		}
		[CompilerGenerated]
		set
		{
			string_2 = value;
		}
	}

	public LinePushedEventArgs(string sourceLineText, int displayedLineIndex, string displayedLineText)
	{
		SourceLineText = sourceLineText;
		DisplayedLineIndex = displayedLineIndex;
		DisplayedLineText = displayedLineText;
		SavedText = displayedLineText;
	}
}
