#define DEBUG
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

internal class MenuColorBlockController : GlobalId, IMouseController, IKeyController, ISourceController, IContextMenuTarget
{
	private bool _mouseOver;

	private bool _mouseReallyOver;

	private bool _highlight;

	private bool _mouseDown;

	private ViewBase _target;

	private NeedPaintHandler _needPaint;

	private ViewDrawMenuColorBlock _menuColorBlock;

	private ViewContextMenuManager _viewManager;

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

	private ViewContextMenuManager ViewManager => _viewManager;

	public event EventHandler Click;

	public MenuColorBlockController(ViewContextMenuManager viewManager, ViewBase target, ViewDrawMenuColorBlock colorBlock, NeedPaintHandler needPaint)
	{
		Debug.Assert(viewManager != null);
		Debug.Assert(target != null);
		Debug.Assert(colorBlock != null);
		Debug.Assert(needPaint != null);
		_viewManager = viewManager;
		_target = target;
		_menuColorBlock = colorBlock;
		NeedPaint = needPaint;
		UpdateTarget();
	}

	public virtual void ShowTarget()
	{
		HighlightState();
	}

	public virtual void ClearTarget()
	{
		NormalState();
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
		if (!_mouseOver && _menuColorBlock.ItemEnabled)
		{
			_mouseReallyOver = _target.ClientRectangle.Contains(c.PointToClient(Control.MousePosition));
			_mouseOver = true;
			ViewManager.SetTarget(this, startTimer: true);
			UpdateTarget();
		}
	}

	public virtual void MouseMove(Control c, Point pt)
	{
		if (_menuColorBlock.ItemEnabled)
		{
			_mouseReallyOver = true;
		}
	}

	public virtual bool MouseDown(Control c, Point pt, MouseButtons button)
	{
		if (button == MouseButtons.Left && _menuColorBlock.ItemEnabled)
		{
			_mouseDown = true;
			UpdateTarget();
		}
		return false;
	}

	public virtual void MouseUp(Control c, Point pt, MouseButtons button)
	{
		if (_mouseDown && button == MouseButtons.Left)
		{
			_mouseDown = false;
			UpdateTarget();
			PressColorBlock();
		}
	}

	public virtual void MouseLeave(Control c, ViewBase next)
	{
		if (!_target.ContainsRecurse(next))
		{
			_mouseOver = false;
			_mouseReallyOver = false;
			_mouseDown = false;
			ViewManager.ClearTarget(this);
			UpdateTarget();
		}
	}

	public virtual void DoubleClick(Point pt)
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
			if (_menuColorBlock.ItemEnabled)
			{
				PressColorBlock();
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

	public virtual void GotFocus(Control c)
	{
	}

	public virtual void LostFocus(Control c)
	{
	}

	public void PerformNeedPaint()
	{
		OnNeedPaint();
	}

	private void PressColorBlock()
	{
		if (this.Click != null)
		{
			this.Click(this, EventArgs.Empty);
		}
		if (_menuColorBlock.KryptonContextMenuColorColumns.AutoClose && _menuColorBlock.CanCloseMenu)
		{
			CancelEventArgs e = new CancelEventArgs();
			_menuColorBlock.Closing(e);
			if (!e.Cancel)
			{
				_menuColorBlock.Close(new CloseReasonEventArgs(ToolStripDropDownCloseReason.ItemClicked));
			}
		}
		UpdateTarget();
		PerformNeedPaint();
	}

	private void OnNeedPaint()
	{
		if (_needPaint != null)
		{
			_needPaint(this, new NeedLayoutEventArgs(needLayout: false));
		}
	}

	private void HighlightState()
	{
		_highlight = true;
		_menuColorBlock.KryptonContextMenuColorColumns.OnTrackingColor(new ColorEventArgs(_menuColorBlock.Color));
		UpdateTarget();
	}

	private void NormalState()
	{
		_highlight = false;
		_menuColorBlock.KryptonContextMenuColorColumns.OnTrackingColor(new ColorEventArgs(Color.Empty));
		UpdateTarget();
	}

	private void UpdateTarget()
	{
		PaletteState elementState = ((!_mouseOver && !_highlight) ? PaletteState.Normal : ((!_mouseDown) ? PaletteState.Tracking : PaletteState.Pressed));
		_menuColorBlock.ElementState = elementState;
		PerformNeedPaint();
	}
}
