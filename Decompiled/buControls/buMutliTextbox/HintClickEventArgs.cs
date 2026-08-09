using System;
using System.Runtime.CompilerServices;

namespace buMutliTextbox;

public class HintClickEventArgs : EventArgs
{
	[CompilerGenerated]
	private Hint hint_0;

	public Hint Hint
	{
		[CompilerGenerated]
		get
		{
			return hint_0;
		}
		[CompilerGenerated]
		private set
		{
			hint_0 = value;
		}
	}

	public HintClickEventArgs(Hint hint)
	{
		Hint = hint;
	}
}
