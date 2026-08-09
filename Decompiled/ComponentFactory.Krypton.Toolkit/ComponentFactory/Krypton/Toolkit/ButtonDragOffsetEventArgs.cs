using System;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class ButtonDragOffsetEventArgs : EventArgs
{
	private Point _offset;

	public Point PointOffset => _offset;

	public ButtonDragOffsetEventArgs(Point offset)
	{
		_offset = offset;
	}
}
