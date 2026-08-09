#define DEBUG
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

internal class MenuLinkLabelController : GlobalId, IMouseController, IKeyController, ISourceController, IContextMenuTarget
{
	private bool _mouseOver;

	private bool _mouseReallyOver;

	private bool _highlight;

	private bool _mouseDown;

	private ViewDrawContent _target;

	private ViewDrawMenuLinkLabel _menuLinkLabel;

	private NeedPaintHandler _needPaint;

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

	public MenuLinkLabelController(ViewContextMenuManager viewManager, ViewDrawContent target, ViewDrawMenuLinkLabel linkLabel, NeedPaintHandler needPaint)
	{
		Debug.Assert(viewManager != null);
		Debug.Assert(target != null);
		Debug.Assert(linkLabel != null);
		Debug.Assert(needPaint != null);
		_viewManager = viewManager;
		_target = target;
		_menuLinkLabel = linkLabel;
		NeedPaint = needPaint;
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
		if (_menuLinkLabel.ItemEnabled)
		{
			return Control.IsMnemonic(charCode, _menuLinkLabel.ItemText);
		}
		return false;
	}

	public void MnemonicActivate()
	{
		if (_menuLinkLabel.ItemEnabled)
		{
			PressMenuLinkLabel(keyboard: true);
		}
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
		if (!_mouseOver && _menuLinkLabel.ItemEnabled)
		{
			_mouseReallyOver = _target.ClientRectangle.Contains(c.PointToClient(Control.MousePosition));
			_mouseOver = true;
			ViewManager.SetTarget(this, startTimer: true);
			UpdateTarget();
		}
	}

	public virtual void MouseMove(Control c, Point pt)
	{
		if (_menuLinkLabel.ItemEnabled)
		{
			_mouseReallyOver = true;
		}
	}

	public virtual bool MouseDown(Control c, Point pt, MouseButtons button)
	{
		if (button == MouseButtons.Left && _menuLinkLabel.ItemEnabled)
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
			PressMenuLinkLabel(keyboard: false);
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
			if (_menuLinkLabel.ItemEnabled)
			{
				PressMenuLinkLabel(keyboard: true);
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

	private void PressMenuLinkLabel(bool keyboard)
	{
		if (keyboard)
		{
			_target.ElementState = PaletteState.Pressed;
			_menuLinkLabel.Pressed = true;
			PerformNeedPaint();
			Application.DoEvents();
		}
		if (_menuLinkLabel.KryptonContextMenuLinkLabel.AutoClose && _menuLinkLabel.CanCloseMenu)
		{
			CancelEventArgs e = new CancelEventArgs();
			_menuLinkLabel.Closing(e);
			if (!e.Cancel)
			{
				_menuLinkLabel.Close(new CloseReasonEventArgs(ToolStripDropDownCloseReason.ItemClicked));
			}
		}
		if (this.Click != null)
		{
			this.Click(this, EventArgs.Empty);
		}
		if (keyboard)
		{
			UpdateTarget();
			PerformNeedPaint();
		}
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
		UpdateTarget();
	}

	private void NormalState()
	{
		_highlight = false;
		UpdateTarget();
	}

	private void UpdateTarget()
	{
		bool pressed = false;
		PaletteState elementState = ((!_menuLinkLabel.ItemEnabled) ? PaletteState.Disabled : PaletteState.Normal);
		if (_mouseOver)
		{
			if (_mouseDown)
			{
				elementState = PaletteState.Pressed;
				pressed = true;
			}
			else
			{
				elementState = PaletteState.Tracking;
			}
		}
		_target.ElementState = elementState;
		_menuLinkLabel.Pressed = pressed;
		_menuLinkLabel.Focused = _highlight && !_mouseReallyOver;
		PerformNeedPaint();
	}
}
