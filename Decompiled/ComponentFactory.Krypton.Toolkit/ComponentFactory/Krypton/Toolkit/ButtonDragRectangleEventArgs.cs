using System;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class ButtonDragRectangleEventArgs : EventArgs
{
	private Point _point;

	private Rectangle _dragRect;

	private bool _preDragOffset;

	public Point Point => _point;

	public Rectangle DragRect
	{
		get
		{
			return _dragRect;
		}
		set
		{
			_dragRect = value;
		}
	}

	public bool PreDragOffset
	{
		get
		{
			return _preDragOffset;
		}
		set
		{
			_preDragOffset = value;
		}
	}

	public ButtonDragRectangleEventArgs(Point point)
	{
		_point = point;
		_dragRect = new Rectangle(_point, Size.Empty);
		_dragRect.Inflate(SystemInformation.DragSize);
		_preDragOffset = true;
	}
}
