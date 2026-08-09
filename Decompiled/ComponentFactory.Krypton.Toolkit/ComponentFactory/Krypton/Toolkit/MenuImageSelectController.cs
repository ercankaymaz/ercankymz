#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

internal class MenuImageSelectController : GlobalId, IMouseController, ISourceController, IKeyController, IContextMenuTarget
{
	private ViewDrawMenuImageSelectItem _target;

	private ViewLayoutMenuItemSelect _layout;

	private ViewContextMenuManager _viewManager;

	private NeedPaintHandler _needPaint;

	private Point _mousePoint;

	private bool _captured;

	private bool _mouseOver;

	public Point MousePoint => _mousePoint;

	public virtual bool HasSubMenu => false;

	public Rectangle ClientRectangle => _target.ClientRectangle;

	public virtual bool IgnoreVisualFormLeftButtonDown => false;

	public NeedPaintHandler NeedPaint
	{
		get
		{
			return _needPaint;
		}
		set
		{
			Debug.Assert((_needPaint == null && value != null) || (_needPaint != null && value == null));
			_needPaint = value;
		}
	}

	public ViewBase Target => _target;

	protected bool Captured
	{
		get
		{
			return _captured;
		}
		set
		{
			_captured = value;
		}
	}

	public event MouseEventHandler Click;

	public MenuImageSelectController(ViewContextMenuManager viewManager, ViewDrawMenuImageSelectItem target, ViewLayoutMenuItemSelect layout, NeedPaintHandler needPaint)
	{
		Debug.Assert(viewManager != null);
		Debug.Assert(target != null);
		Debug.Assert(layout != null);
		Debug.Assert(needPaint != null);
		_mousePoint = CommonHelper.NullPoint;
		_viewManager = viewManager;
		_target = target;
		_layout = layout;
		NeedPaint = needPaint;
	}

	public virtual void ShowTarget()
	{
		_target.Track();
		UpdateTargetState(new Point(int.MaxValue, int.MaxValue));
	}

	public virtual void ClearTarget()
	{
		_target.Untrack();
		UpdateTargetState(new Point(int.MaxValue, int.MaxValue));
	}

	public void ShowSubMenu()
	{
	}

	public void ClearSubMenu()
	{
	}

	public bool MatchMnemonic(char charCode)
	{
		return false;
	}

	public void MnemonicActivate()
	{
	}

	public ViewBase GetActiveView()
	{
		return _target;
	}

	public bool DoesStackedClientMouseDownBecomeCurrent(Point pt)
	{
		return true;
	}

	public virtual void MouseEnter(Control c)
	{
		if (_layout.ItemEnabled)
		{
			_mouseOver = true;
			UpdateTargetState(c);
		}
	}

	public virtual void MouseMove(Control c, Point pt)
	{
		if (_layout.ItemEnabled)
		{
			_mousePoint = pt;
			UpdateTargetState(pt);
		}
	}

	public virtual bool MouseDown(Control c, Point pt, MouseButtons button)
	{
		if (_layout.ItemEnabled && button == MouseButtons.Left)
		{
			_captured = true;
			UpdateTargetState(pt);
		}
		return _captured;
	}

	public virtual void MouseUp(Control c, Point pt, MouseButtons button)
	{
		if (!_layout.ItemEnabled || !_captured)
		{
			return;
		}
		_captured = false;
		if (button == MouseButtons.Left)
		{
			if (_target.ElementState == PaletteState.Pressed)
			{
				_target.ElementState = PaletteState.Tracking;
				if (_target.Enabled)
				{
					OnClick(new MouseEventArgs(MouseButtons.Left, 1, pt.X, pt.Y, 0));
				}
			}
			OnNeedPaint(needLayout: true);
		}
		else
		{
			UpdateTargetState(pt);
		}
	}

	public virtual void MouseLeave(Control c, ViewBase next)
	{
		if (!_target.ContainsRecurse(next))
		{
			_mouseOver = false;
			_mousePoint = CommonHelper.NullPoint;
			_captured = false;
			UpdateTargetState(c);
		}
	}

	public virtual void DoubleClick(Point pt)
	{
	}

	public void GotFocus(Control c)
	{
	}

	public void LostFocus(Control c)
	{
	}

	public virtual void KeyDown(Control c, KeyEventArgs e)
	{
		Debug.Assert(c != null);
		Debug.Assert(e != null);
		if (c == null)
		{
			throw new ArgumentNullException("c");
		}
		if (e == null)
		{
			throw new ArgumentNullException("e");
		}
		switch (e.KeyCode)
		{
		case Keys.Return:
		case Keys.Space:
			if (_layout.ItemEnabled)
			{
				Point pt = new Point(int.MaxValue, int.MaxValue);
				OnClick(new MouseEventArgs(MouseButtons.Left, 1, pt.X, pt.Y, 0));
				UpdateTargetState(pt);
			}
			break;
		case Keys.Tab:
			_viewManager.KeyTab(e.Shift);
			break;
		case Keys.Home:
			_viewManager.KeyHome();
			break;
		case Keys.End:
			_viewManager.KeyEnd();
			break;
		case Keys.Up:
			_viewManager.KeyUp();
			break;
		case Keys.Down:
			_viewManager.KeyDown();
			break;
		case Keys.Left:
			_viewManager.KeyLeft(wrap: true);
			break;
		case Keys.Right:
			_viewManager.KeyRight();
			break;
		}
	}

	public virtual void KeyPress(Control c, KeyPressEventArgs e)
	{
		Debug.Assert(c != null);
		Debug.Assert(e != null);
		if (c == null)
		{
			throw new ArgumentNullException("c");
		}
		if (e == null)
		{
			throw new ArgumentNullException("e");
		}
		_viewManager.KeyMnemonic(e.KeyChar);
	}

	public virtual bool KeyUp(Control c, KeyEventArgs e)
	{
		Debug.Assert(c != null);
		Debug.Assert(e != null);
		if (c == null)
		{
			throw new ArgumentNullException("c");
		}
		if (e == null)
		{
			throw new ArgumentNullException("e");
		}
		return false;
	}

	public void PerformNeedPaint()
	{
		OnNeedPaint(needLayout: false);
	}

	public void PerformNeedPaint(bool needLayout)
	{
		OnNeedPaint(needLayout);
	}

	protected void UpdateTargetState(Control c)
	{
		if (c != null && !c.IsDisposed)
		{
			Form form = c.FindForm();
			if (form != null && form.Visible)
			{
				UpdateTargetState(c.PointToClient(Control.MousePosition));
				return;
			}
		}
		UpdateTargetState(new Point(int.MaxValue, int.MaxValue));
	}

	protected virtual void UpdateTargetState(Point pt)
	{
		PaletteState paletteState;
		if (!_target.Enabled)
		{
			paletteState = PaletteState.Disabled;
		}
		else
		{
			paletteState = PaletteState.Normal;
			paletteState = (_captured ? ((!_target.ClientRectangle.Contains(pt)) ? PaletteState.Tracking : PaletteState.Pressed) : ((!_mouseOver) ? PaletteState.Normal : PaletteState.Tracking));
		}
		if (_target.ElementState != paletteState)
		{
			if (paletteState == PaletteState.Tracking)
			{
				_target.Track();
			}
			else
			{
				_target.Untrack();
			}
			_target.ElementState = paletteState;
			OnNeedPaint(needLayout: false);
		}
	}

	protected virtual void OnClick(MouseEventArgs e)
	{
		if (this.Click != null)
		{
			this.Click(_target, e);
		}
	}

	protected virtual void OnNeedPaint(bool needLayout)
	{
		if (_needPaint != null)
		{
			_needPaint(this, new NeedLayoutEventArgs(needLayout, _target.ClientRectangle));
		}
	}
}
