#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ButtonSpecAppButtonController : ButtonController, IContextMenuTarget
{
	private ViewDrawButton _target;

	private ViewContextMenuManager _viewManager;

	public bool HasSubMenu => false;

	public Rectangle ClientRectangle => _target.ClientRectangle;

	public ButtonSpecAppButtonController(ViewContextMenuManager viewManager, ViewDrawButton target, NeedPaintHandler needPaint)
		: base(target, needPaint)
	{
		_target = target;
		_viewManager = viewManager;
	}

	public override void KeyDown(Control c, KeyEventArgs e)
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
		default:
			base.KeyDown(c, e);
			break;
		}
	}

	public override void KeyPress(Control c, KeyPressEventArgs e)
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

	public void ShowTarget()
	{
	}

	public void ClearTarget()
	{
	}

	public void ShowSubMenu()
	{
	}

	public void ClearSubMenu()
	{
	}

	public bool MatchMnemonic(char charCode)
	{
		return Control.IsMnemonic(charCode, _target.ButtonValues.GetShortText());
	}

	public void MnemonicActivate()
	{
		OnClick(new MouseEventArgs(MouseButtons.None, 1, 0, 0, 0));
	}

	public ViewBase GetActiveView()
	{
		return _target;
	}

	public bool DoesStackedClientMouseDownBecomeCurrent(Point pt)
	{
		return true;
	}
}
