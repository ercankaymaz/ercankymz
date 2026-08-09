using System.ComponentModel;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class PointEventCancelArgs : CancelEventArgs
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

	public PointEventCancelArgs(Point point)
	{
		_point = point;
	}
}
