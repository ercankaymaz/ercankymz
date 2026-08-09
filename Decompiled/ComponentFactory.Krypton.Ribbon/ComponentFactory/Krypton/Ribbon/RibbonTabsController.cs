#define DEBUG
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class RibbonTabsController : GlobalId, IMouseController
{
	private KryptonRibbon _ribbon;

	private bool _rightButtonDown;

	public virtual bool IgnoreVisualFormLeftButtonDown => false;

	public event MouseEventHandler ContextClick;

	public RibbonTabsController(KryptonRibbon ribbon)
	{
		Debug.Assert(ribbon != null);
		_ribbon = ribbon;
	}

	public virtual void MouseEnter(Control c)
	{
	}

	public virtual void MouseMove(Control c, Point pt)
	{
	}

	public virtual bool MouseDown(Control c, Point pt, MouseButtons button)
	{
		if (button == MouseButtons.Right)
		{
			_rightButtonDown = true;
		}
		return false;
	}

	public virtual void MouseUp(Control c, Point pt, MouseButtons button)
	{
		if (button == MouseButtons.Right && _rightButtonDown)
		{
			_rightButtonDown = false;
			OnContextClick(new MouseEventArgs(MouseButtons.Right, 1, pt.X, pt.Y, 0));
		}
	}

	public virtual void MouseLeave(Control c, ViewBase next)
	{
	}

	public virtual void DoubleClick(Point pt)
	{
	}

	protected virtual void OnContextClick(MouseEventArgs e)
	{
		if (this.ContextClick != null)
		{
			this.ContextClick(this, e);
		}
	}
}
