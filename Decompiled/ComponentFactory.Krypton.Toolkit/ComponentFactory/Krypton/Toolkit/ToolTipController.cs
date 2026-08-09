#define DEBUG
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class ToolTipController : GlobalId, IMouseController
{
	private ToolTipManager _manager;

	private ViewBase _targetElement;

	private IMouseController _targetController;

	public bool IgnoreVisualFormLeftButtonDown
	{
		get
		{
			if (_targetController != null)
			{
				return _targetController.IgnoreVisualFormLeftButtonDown;
			}
			return false;
		}
	}

	public ToolTipController(ToolTipManager manager, ViewBase targetElement, IMouseController targetController)
	{
		Debug.Assert(manager != null);
		Debug.Assert(targetElement != null);
		_manager = manager;
		_targetElement = targetElement;
		_targetController = targetController;
	}

	public void MouseEnter(Control c)
	{
		_manager.MouseEnter(_targetElement, c);
		if (_targetController != null)
		{
			_targetController.MouseEnter(c);
		}
	}

	public void MouseMove(Control c, Point pt)
	{
		_manager.MouseMove(_targetElement, c, pt);
		if (_targetController != null)
		{
			_targetController.MouseMove(c, pt);
		}
	}

	public bool MouseDown(Control c, Point pt, MouseButtons button)
	{
		_manager.MouseDown(_targetElement, c, pt, button);
		if (_targetController != null)
		{
			return _targetController.MouseDown(c, pt, button);
		}
		return false;
	}

	public void MouseUp(Control c, Point pt, MouseButtons button)
	{
		_manager.MouseUp(_targetElement, c, pt, button);
		if (_targetController != null)
		{
			_targetController.MouseUp(c, pt, button);
		}
	}

	public void MouseLeave(Control c, ViewBase next)
	{
		_manager.MouseLeave(_targetElement, c, next);
		if (_targetController != null)
		{
			_targetController.MouseLeave(c, next);
		}
	}

	public void DoubleClick(Point pt)
	{
		_manager.DoubleClick(_targetElement, pt);
		if (_targetController != null)
		{
			_targetController.DoubleClick(pt);
		}
	}
}
