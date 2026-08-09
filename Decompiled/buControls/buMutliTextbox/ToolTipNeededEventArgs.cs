using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace buMutliTextbox;

public class ToolTipNeededEventArgs : EventArgs
{
	[CompilerGenerated]
	private Place place_0;

	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private string string_1;

	[CompilerGenerated]
	private string string_2;

	[CompilerGenerated]
	private ToolTipIcon toolTipIcon_0;

	public Place Place
	{
		[CompilerGenerated]
		get
		{
			return place_0;
		}
		[CompilerGenerated]
		private set
		{
			place_0 = value;
		}
	}

	public string HoveredWord
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

	public string ToolTipTitle
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

	public string ToolTipText
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

	public ToolTipIcon ToolTipIcon
	{
		[CompilerGenerated]
		get
		{
			return toolTipIcon_0;
		}
		[CompilerGenerated]
		set
		{
			toolTipIcon_0 = value;
		}
	}

	public ToolTipNeededEventArgs(Place place, string hoveredWord)
	{
		HoveredWord = hoveredWord;
		Place = place;
	}
}
