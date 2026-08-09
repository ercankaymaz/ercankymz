using System;

namespace ScintillaNET;

public class CallTipClickEventArgs : EventArgs
{
	private readonly Scintilla scintilla;

	public CallTipClickType CallTipClickType { get; internal set; }

	public CallTipClickEventArgs(Scintilla scintilla, CallTipClickType callTipClickType)
	{
		this.scintilla = scintilla;
		CallTipClickType = callTipClickType;
	}
}
