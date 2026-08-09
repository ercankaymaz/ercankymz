#define DEBUG
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class RecentDocController : GlobalId, IMouseController, IKeyController, ISourceController, IContextMenuTarget
{
	private bool _mouseOver;

	private ViewDrawRibbonAppMenuRecentDec _menuItem;

	private NeedPaintHandler _needPaint;

	private ViewContextMenuManager _viewManager;

	public virtual bool HasSubMenu => false;

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

	public RecentDocController(ViewContextMenuManager viewManager, ViewDrawRibbonAppMenuRecentDec menuItem, NeedPaintHandler needPaint)
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
	}

	public void ClearSubMenu()
	{
	}

	public bool MatchMnemonic(char charCode)
	{
		return Control.IsMnemonic(charCode, _menuItem.ShortcutText);
	}

	public void MnemonicActivate()
	{
		PressMenuItem();
	}

	public ViewBase GetActiveView()
	{
		return _menuItem;
	}

	public bool DoesStackedClientMouseDownBecomeCurrent(Point pt)
	{
		return true;
	}

	public virtual void MouseEnter(Control c)
	{
		if (!_mouseOver)
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
		return false;
	}

	public virtual void MouseUp(Control c, Point pt, MouseButtons button)
	{
		PressMenuItem();
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
			PressMenuItem();
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

	public void PerformNeedPaint(bool layout)
	{
		OnNeedPaint(layout);
	}

	private void PressMenuItem()
	{
		if (_menuItem.CanCloseMenu)
		{
			CancelEventArgs e = new CancelEventArgs();
			_menuItem.Closing(e);
			if (!e.Cancel)
			{
				_menuItem.Close(new CloseReasonEventArgs(ToolStripDropDownCloseReason.ItemClicked));
			}
		}
		_menuItem.RecentDoc.PerformClick();
		PerformNeedPaint(layout: true);
	}

	private void HighlightState()
	{
		_menuItem.ElementState = PaletteState.Tracking;
		_menuItem.SetPalettes(_menuItem.Provider.ProviderStateHighlight.ItemHighlight.Back, _menuItem.Provider.ProviderStateHighlight.ItemHighlight.Border);
		PerformNeedPaint(layout: false);
	}

	private void NormalState()
	{
		_menuItem.ElementState = PaletteState.Normal;
		_menuItem.SetPalettes(_menuItem.Provider.ProviderStateNormal.ItemHighlight.Back, _menuItem.Provider.ProviderStateNormal.ItemHighlight.Border);
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
