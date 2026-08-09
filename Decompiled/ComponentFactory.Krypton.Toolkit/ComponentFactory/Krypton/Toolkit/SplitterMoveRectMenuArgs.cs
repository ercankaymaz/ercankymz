using System;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class SplitterMoveRectMenuArgs : EventArgs
{
	private Rectangle _moveRect;

	public Rectangle MoveRect
	{
		get
		{
			return _moveRect;
		}
		set
		{
			_moveRect = value;
		}
	}

	public SplitterMoveRectMenuArgs(Rectangle moveRect)
	{
		_moveRect = moveRect;
	}
}
