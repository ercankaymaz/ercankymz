using System;
using System.Runtime.CompilerServices;

namespace buMutliTextbox;

public class TextChangingEventArgs : EventArgs
{
	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private bool bool_0;

	public string InsertingText
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
		[CompilerGenerated]
		set
		{
			string_0 = value;
		}
	}

	public bool Cancel
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
		[CompilerGenerated]
		set
		{
			bool_0 = value;
		}
	}
}
