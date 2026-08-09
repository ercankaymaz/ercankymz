using System;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class PointEventArgs : EventArgs
{
	private Point _point;

	public Point Point
	{
		get
		{
			return _point;
		}
		set
		{
			_point = value;
		}
	}

	public PointEventArgs(Point point)
	{
		_point = point;
	}
}
