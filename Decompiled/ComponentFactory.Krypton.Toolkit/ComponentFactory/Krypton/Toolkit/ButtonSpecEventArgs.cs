#define DEBUG
using System;
using System.Diagnostics;

namespace ComponentFactory.Krypton.Toolkit;

public class ButtonSpecEventArgs : EventArgs
{
	private ButtonSpec _spec;

	private int _index;

	public ButtonSpec ButtonSpec => _spec;

	public int Index => _index;

	public ButtonSpecEventArgs(ButtonSpec spec, int index)
	{
		Debug.Assert(spec != null);
		Debug.Assert(index >= 0);
		_spec = spec;
		_index = index;
	}
}
