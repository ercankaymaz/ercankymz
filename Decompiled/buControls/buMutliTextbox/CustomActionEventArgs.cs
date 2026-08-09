using System;
using System.Runtime.CompilerServices;

namespace buMutliTextbox;

public class CustomActionEventArgs : EventArgs
{
	[CompilerGenerated]
	private FCTBAction fctbaction_0;

	public FCTBAction Action
	{
		[CompilerGenerated]
		get
		{
			return fctbaction_0;
		}
		[CompilerGenerated]
		private set
		{
			fctbaction_0 = value;
		}
	}

	public CustomActionEventArgs(FCTBAction action)
	{
		Action = action;
	}
}
