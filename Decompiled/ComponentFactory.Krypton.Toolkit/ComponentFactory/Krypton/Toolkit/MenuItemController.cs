#define DEBUG
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

internal class MenuItemController : GlobalId, IMouseController, IKeyController, ISourceController, IContextMenuTarget
{
	private bool _mouseOver;

	private ViewDrawMenuItem _menuItem;

	private NeedPaintHandler _needPaint;

	private ViewContextMenuManager _viewManager;

	public virtual bool HasSubMenu => _menuItem.HasSubMenu;

	public Rectangle ClientRectangle => _menuItem.ClientRectangle;

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

	public MenuItemController(ViewContextMenuManager viewManager, ViewDrawMenuItem menuItem, NeedPaintHandler needPaint)
	{
		Debug.Assert(viewManager != null);
		Debug.Assert(menuItem != null);
		Debug.Assert(needPaint != null);
		_viewManager = viewManager;
		_menuItem = menuItem;
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
		_menuItem.ShowSubMenu(keyboardActivated: false);
	}

	public void ClearSubMenu()
	{
		_menuItem.ClearSubMenu();
	}

	public bool MatchMnemonic(char charCode)
	{
		if (_menuItem.ItemEnabled)
		{
			return Control.IsMnemonic(charCode, _menuItem.ItemText);
		}
		return false;
	}

	public void MnemonicActivate()
	{
		if (_menuItem.ItemEnabled)
		{
			if (!_menuItem.HasSubMenu)
			{
				PressMenuItem();
			}
			else
			{
				_menuItem.ShowSubMenu(keyboardActivated: true);
			}
		}
	}

	public ViewBase GetActiveView()
	{
		return _menuItem;
	}

	public bool DoesStackedClientMouseDownBecomeCurrent(Point pt)
	{
		if (_menuItem.ItemEnabled)
		{
			return !_menuItem.PointInSubMenu(pt);
		}
		return true;
	}

	public virtual void MouseEnter(Control c)
	{
		if (!_mouseOver && _menuItem.ItemEnabled)
		{
			_mouseOver = true;
			ViewManager.SetTarget(this, startTimer: true);
		}
	}

	public virtual void MouseMove(Control c, Point pt)
	{
	}

	public virtual bool MouseDown(Control c, Point pt, MouseButtons button)
	{
		if (_menuItem.ItemEnabled && _menuItem.PointInSubMenu(pt))
		{
			_menuItem.ShowSubMenu(keyboardActivated: false);
		}
		return false;
	}

	public virtual void MouseUp(Control c, Point pt, MouseButtons button)
	{
		if (_menuItem.ItemEnabled)
		{
			if (_menuItem.PointInSubMenu(pt))
			{
				_menuItem.ShowSubMenu(keyboardActivated: false);
			}
			else
			{
				PressMenuItem();
			}
		}
	}

	public virtual void MouseLeave(Control c, ViewBase next)
	{
		if (_mouseOver && !_menuItem.ContainsRecurse(next))
		{
			_mouseOver = false;
			ViewManager.ClearTarget(this);
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
			if (_menuItem.ItemEnabled)
			{
				if (!_menuItem.HasSubMenu)
				{
					PressMenuItem();
				}
				else
				{
					_menuItem.ShowSubMenu(keyboardActivated: true);
				}
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
			if (_viewManager.KeyLeft(!_menuItem.HasParentMenu))
			{
				_menuItem.DisposeContextMenu();
			}
			break;
		case Keys.Right:
			if (_menuItem.ItemEnabled && _menuItem.HasSubMenu)
			{
				_menuItem.ShowSubMenu(keyboardActivated: true);
			}
			else
			{
				_viewManager.KeyRight();
			}
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

	public void PerformNeedPaint(bool layout)
	{
		OnNeedPaint(layout);
	}

	private void PressMenuItem()
	{
		if (_menuItem.KryptonContextMenuItem.AutoClose && _menuItem.CanCloseMenu)
		{
			CancelEventArgs e = new CancelEventArgs();
			_menuItem.Closing(e);
			if (!e.Cancel)
			{
				_menuItem.Close(new CloseReasonEventArgs(ToolStripDropDownCloseReason.ItemClicked));
			}
		}
		_menuItem.KryptonContextMenuItem.PerformClick();
		PerformNeedPaint(layout: true);
	}

	private void HighlightState()
	{
		if (_menuItem.ItemEnabled)
		{
			_menuItem.ElementState = PaletteState.Tracking;
			_menuItem.SplitSeparator.ElementState = PaletteState.Tracking;
			_menuItem.SplitSeparator.SetPalettes(_menuItem.KryptonContextMenuItem.StateHighlight.ItemSplit.Back, _menuItem.KryptonContextMenuItem.StateHighlight.ItemSplit.Border);
			_menuItem.SetPalettes(_menuItem.KryptonContextMenuItem.StateHighlight.ItemHighlight.Back, _menuItem.KryptonContextMenuItem.StateHighlight.ItemHighlight.Border);
		}
		else
		{
			_menuItem.ElementState = PaletteState.Disabled;
			_menuItem.SplitSeparator.ElementState = PaletteState.Disabled;
			_menuItem.SplitSeparator.SetPalettes(_menuItem.KryptonContextMenuItem.StateDisabled.ItemSplit.Back, _menuItem.KryptonContextMenuItem.StateDisabled.ItemSplit.Border);
			_menuItem.SetPalettes(_menuItem.KryptonContextMenuItem.StateDisabled.ItemHighlight.Back, _menuItem.KryptonContextMenuItem.StateDisabled.ItemHighlight.Border);
		}
		PerformNeedPaint(layout: false);
	}

	private void NormalState()
	{
		_menuItem.ElementState = PaletteState.Normal;
		_menuItem.SplitSeparator.ElementState = PaletteState.Normal;
		_menuItem.SplitSeparator.SetPalettes(_menuItem.KryptonContextMenuItem.StateNormal.ItemSplit.Back, _menuItem.KryptonContextMenuItem.StateNormal.ItemSplit.Border);
		_menuItem.SetPalettes(_menuItem.KryptonContextMenuItem.StateNormal.ItemHighlight.Back, _menuItem.KryptonContextMenuItem.StateNormal.ItemHighlight.Border);
		PerformNeedPaint(layout: false);
	}

	protected virtual void OnNeedPaint(bool needLayout)
	{
		if (_needPaint != null)
		{
			_needPaint(this, new NeedLayoutEventArgs(needLayout, _menuItem.ClientRectangle));
		}
	}
}
