using System;
using System.Runtime.CompilerServices;

namespace buMutliTextbox;

public class SelectedEventArgs : EventArgs
{
	[CompilerGenerated]
	private AutocompleteItem autocompleteItem_0;

	[CompilerGenerated]
	private buMultiTextBox buMultiTextBox_0;

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

	public buMultiTextBox Tb
	{
		[CompilerGenerated]
		get
		{
			return buMultiTextBox_0;
		}
		[CompilerGenerated]
		set
		{
			buMultiTextBox_0 = value;
		}
	}
}
