using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class DragStartEventCancelArgs : PointEventCancelArgs
{
	private Point _offset;

	private Control _c;

	public Point Offset
	{
		get
		{
			return _offset;
		}
		set
		{
			_offset = value;
		}
	}

	public Control Control => _c;

	public DragStartEventCancelArgs(Point point, Point offset, Control c)
		: base(point)
	{
		_offset = offset;
		_c = c;
	}
}
