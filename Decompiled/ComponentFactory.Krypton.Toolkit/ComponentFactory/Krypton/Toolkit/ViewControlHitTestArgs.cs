using System;
using System.ComponentModel;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class ViewControlHitTestArgs : CancelEventArgs
{
	private Point _pt;

	private IntPtr _result;

	public Point Point => _pt;

	public IntPtr Result
	{
		get
		{
			return _result;
		}
		set
		{
			_result = value;
		}
	}

	public ViewControlHitTestArgs(Point pt)
		: base(cancel: true)
	{
		_pt = pt;
		_result = IntPtr.Zero;
	}
}
