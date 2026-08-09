#define DEBUG
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ContextTitleController : GlobalId, IMouseController
{
	private KryptonRibbon _ribbon;

	private ContextTabSet _context;

	private bool _mouseOver;

	public ContextTabSet ContextTabSet
	{
		get
		{
			return _context;
		}
		set
		{
			_context = value;
		}
	}

	public virtual bool IgnoreVisualFormLeftButtonDown => false;

	public ContextTitleController(KryptonRibbon ribbon)
	{
		Debug.Assert(ribbon != null);
		_ribbon = ribbon;
	}

	public virtual void MouseEnter(Control c)
	{
		_mouseOver = true;
	}

	public virtual void MouseMove(Control c, Point pt)
	{
	}

	public virtual bool MouseDown(Control c, Point pt, MouseButtons button)
	{
		if (_mouseOver && button == MouseButtons.Left && ContextTabSet != null && !_ribbon.InDesignMode && _ribbon.Enabled)
		{
			ContextTabSet.FirstTab.RibbonTab.Ribbon.SelectedTab = ContextTabSet.FirstTab.RibbonTab;
		}
		return false;
	}

	public virtual void MouseUp(Control c, Point pt, MouseButtons button)
	{
	}

	public virtual void MouseLeave(Control c, ViewBase next)
	{
		_mouseOver = false;
	}

	public virtual void DoubleClick(Point pt)
	{
	}
}
