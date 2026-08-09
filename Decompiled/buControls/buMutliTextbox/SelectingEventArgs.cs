using System;
using System.Runtime.CompilerServices;

namespace buMutliTextbox;

public class SelectingEventArgs : EventArgs
{
	[CompilerGenerated]
	private AutocompleteItem autocompleteItem_0;

	[CompilerGenerated]
	private bool bool_0;

	[CompilerGenerated]
	private int int_0;

	[CompilerGenerated]
	private bool bool_1;

	public AutocompleteItem Item
	{
		[CompilerGenerated]
		get
		{
			return autocompleteItem_0;
		}
		[CompilerGenerated]
		internal set
		{
			autocompleteItem_0 = value;
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

	public int SelectedIndex
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
		[CompilerGenerated]
		set
		{
			int_0 = value;
		}
	}

	public bool Handled
	{
		[CompilerGenerated]
		get
		{
			return bool_1;
		}
		[CompilerGenerated]
		set
		{
			bool_1 = value;
		}
	}
}
