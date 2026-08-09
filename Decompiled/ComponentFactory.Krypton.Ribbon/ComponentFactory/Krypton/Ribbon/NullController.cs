using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class NullController : GlobalId, IMouseController
{
	private static NullController _singleton;

	public static NullController Singleton
	{
		get
		{
			if (_singleton == null)
			{
				_singleton = new NullController();
			}
			return _singleton;
		}
	}

	public virtual bool IgnoreVisualFormLeftButtonDown => false;

	private NullController()
	{
	}

	public virtual void MouseEnter(Control c)
	{
	}

	public virtual void MouseMove(Control c, Point pt)
	{
	}

	public virtual bool MouseDown(Control c, Point pt, MouseButtons button)
	{
		return false;
	}

	public virtual void MouseUp(Control c, Point pt, MouseButtons button)
	{
	}

	public virtual void MouseLeave(Control c, ViewBase next)
	{
	}

	public virtual void DoubleClick(Point pt)
	{
	}
}
