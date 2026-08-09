#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class ToolTipEventArgs : EventArgs
{
	private ViewBase _target;

	private Point _screenPt;

	public ViewBase Target => _target;

	public Point ScreenPt => _screenPt;

	public ToolTipEventArgs(ViewBase target, Point screenPt)
	{
		Debug.Assert(target != null);
		_target = target;
		_screenPt = screenPt;
	}
}
