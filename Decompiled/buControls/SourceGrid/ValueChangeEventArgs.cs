using System;
using System.Runtime.CompilerServices;

namespace SourceGrid;

public class ValueChangeEventArgs : EventArgs
{
	[CompilerGenerated]
	private object object_0;

	[CompilerGenerated]
	private object object_1;

	public object NewValue
	{
		[CompilerGenerated]
		get
		{
			return object_0;
		}
		[CompilerGenerated]
		set
		{
			object_0 = value;
		}
	}

	public object OldValue
	{
		[CompilerGenerated]
		get
		{
			return object_1;
		}
		[CompilerGenerated]
		set
		{
			object_1 = value;
		}
	}

	public ValueChangeEventArgs(object oldValue, object newValue)
	{
		NewValue = newValue;
		OldValue = oldValue;
	}
}
