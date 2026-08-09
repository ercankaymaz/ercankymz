#define DEBUG
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class RibbonTabController : GlobalId, IMouseController, ISourceController, IKeyController, IRibbonKeyTipTarget
{
	private KryptonRibbon _ribbon;

	private bool _mouseOver;

	private bool _rightButtonDown;

	private ViewDrawRibbonTab _target;

	private NeedPaintHandler _needPaint;

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

	private bool Active
	{
		get
		{
			if (_ribbon == null)
			{
				return false;
			}
			if (_ribbon.InDesignMode)
			{
				return true;
			}
			Form form = _ribbon.FindForm();
			return CommonHelper.ActiveFloatingWindow != null || (form != null && (form.ContainsFocus || (form.Parent != null && form.Visible && form.Enabled)));
		}
	}

	public event MouseEventHandler Click;

	public event MouseEventHandler ContextClick;

	public RibbonTabController(KryptonRibbon ribbon, ViewDrawRibbonTab target, NeedPaintHandler needPaint)
	{
		Debug.Assert(ribbon != null);
		Debug.Assert(target != null);
		_target = target;
		_ribbon = ribbon;
		NeedPaint = needPaint;
	}

	public virtual void MouseEnter(Control c)
	{
		if (Active)
		{
			_mouseOver = true;
			UpdateTargetState(c);
		}
	}

	public virtual void MouseMove(Control c, Point pt)
	{
	}

	public virtual bool MouseDown(Control c, Point pt, MouseButtons button)
	{
		if (Active)
		{
			switch (button)
			{
			case MouseButtons.Left:
				if (_target.Enabled)
				{
					OnClick(new MouseEventArgs(MouseButtons.Left, 1, pt.X, pt.Y, 0));
				}
				UpdateTargetState(c);
				break;
			case MouseButtons.Right:
				_rightButtonDown = true;
				break;
			}
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
		if (!_target.ContainsRecurse(next))
		{
			_mouseOver = false;
			UpdateTargetState(c);
		}
	}

	public virtual void DoubleClick(Point pt)
	{
		if (!_ribbon.InDesignMode && _ribbon.AllowMinimizedChange)
		{
			_ribbon.MinimizedMode = !_ribbon.MinimizedMode;
		}
	}

	public virtual void GotFocus(Control c)
	{
		_target.HasFocus = true;
		OnNeedPaint(needLayout: false, _target.ClientRectangle);
	}

	public virtual void LostFocus(Control c)
	{
		_target.HasFocus = false;
		OnNeedPaint(needLayout: false, _target.ClientRectangle);
	}

	public void KeyDown(Control c, KeyEventArgs e)
	{
		ViewBase viewBase = null;
		Keys keys = e.KeyData;
		if (_ribbon.SelectedTab == null)
		{
			if (keys == Keys.Tab)
			{
				keys = Keys.Right;
			}
			if (keys == (Keys.Tab | Keys.Shift))
			{
				keys = Keys.Left;
			}
		}
		switch (keys)
		{
		case Keys.Right:
			viewBase = _target.ViewLayoutRibbonTabs.GetViewForNextRibbonTab(_target.RibbonTab);
			if (viewBase == null)
			{
				viewBase = _ribbon.TabsArea.ButtonSpecManager.GetFirstVisibleViewButton(PaletteRelativeEdgeAlign.Far);
			}
			if (viewBase == null)
			{
				viewBase = _ribbon.TabsArea.ButtonSpecManager.GetFirstVisibleViewButton(PaletteRelativeEdgeAlign.Inherit);
			}
			if (viewBase == null)
			{
				if (_ribbon.TabsArea.LayoutAppButton.Visible)
				{
					viewBase = _ribbon.TabsArea.LayoutAppButton.AppButton;
				}
				else if (_ribbon.TabsArea.LayoutAppTab.Visible)
				{
					viewBase = _ribbon.TabsArea.LayoutAppTab.AppTab;
				}
			}
			break;
		case Keys.Left:
			viewBase = _target.ViewLayoutRibbonTabs.GetViewForPreviousRibbonTab(_target.RibbonTab);
			if (viewBase == null)
			{
				viewBase = _ribbon.TabsArea.ButtonSpecManager.GetFirstVisibleViewButton(PaletteRelativeEdgeAlign.Near);
			}
			if (viewBase == null)
			{
				viewBase = _ribbon.GetLastQATView();
			}
			if (viewBase == null)
			{
				if (_ribbon.TabsArea.LayoutAppButton.Visible)
				{
					viewBase = _ribbon.TabsArea.LayoutAppButton.AppButton;
				}
				else if (_ribbon.TabsArea.LayoutAppTab.Visible)
				{
					viewBase = _ribbon.TabsArea.LayoutAppTab.AppTab;
				}
			}
			break;
		case Keys.Tab | Keys.Shift:
			viewBase = _ribbon.TabsArea.ButtonSpecManager.GetFirstVisibleViewButton(PaletteRelativeEdgeAlign.Near);
			if (viewBase == null)
			{
				viewBase = _ribbon.GetLastQATView();
			}
			if (viewBase == null)
			{
				if (_ribbon.TabsArea.LayoutAppButton.Visible)
				{
					viewBase = _ribbon.TabsArea.LayoutAppButton.AppButton;
				}
				else if (_ribbon.TabsArea.LayoutAppTab.Visible)
				{
					viewBase = _ribbon.TabsArea.LayoutAppTab.AppTab;
				}
			}
			break;
		case Keys.Down:
			viewBase = _ribbon.GroupsArea.ViewGroups.GetFirstFocusItem();
			break;
		case Keys.Tab:
			viewBase = _ribbon.GroupsArea.ViewGroups.GetFirstFocusItem();
			if (viewBase == null)
			{
				viewBase = _ribbon.TabsArea.ButtonSpecManager.GetFirstVisibleViewButton(PaletteRelativeEdgeAlign.Near);
			}
			if (viewBase == null)
			{
				viewBase = _ribbon.GetLastQATView();
			}
			if (viewBase == null)
			{
				if (_ribbon.TabsArea.LayoutAppButton.Visible)
				{
					viewBase = _ribbon.TabsArea.LayoutAppButton.AppButton;
				}
				else if (_ribbon.TabsArea.LayoutAppTab.Visible)
				{
					viewBase = _ribbon.TabsArea.LayoutAppTab.AppTab;
				}
			}
			break;
		case Keys.Return:
		case Keys.Space:
			if (_ribbon.RealMinimizedMode && _ribbon.SelectedTab != _target.RibbonTab)
			{
				_ribbon.SelectedTab = _target.RibbonTab;
				if (VisualPopupManager.Singleton.CurrentPopup != null && VisualPopupManager.Singleton.CurrentPopup is VisualPopupMinimized)
				{
					VisualPopupMinimized visualPopupMinimized = (VisualPopupMinimized)VisualPopupManager.Singleton.CurrentPopup;
					visualPopupMinimized.SetFirstFocusItem();
				}
			}
			break;
		}
		if (viewBase != null && viewBase != _target)
		{
			if (viewBase is ViewDrawRibbonTab && !_ribbon.RealMinimizedMode)
			{
				_ribbon.SelectedTab = ((ViewDrawRibbonTab)viewBase).RibbonTab;
			}
			_ribbon.FocusView = viewBase;
		}
	}

	public void KeyPress(Control c, KeyPressEventArgs e)
	{
	}

	public bool KeyUp(Control c, KeyEventArgs e)
	{
		return false;
	}

	public void KeyTipSelect(KryptonRibbon ribbon)
	{
		if (_ribbon.SelectedTab != _target.RibbonTab)
		{
			_ribbon.SelectedTab = _target.RibbonTab;
		}
		_ribbon.FocusView = _target;
		KeyTipMode keyTipMode = ((!_ribbon.RealMinimizedMode) ? KeyTipMode.SelectedGroups : KeyTipMode.PopupMinimized);
		_ribbon.KeyTipMode = keyTipMode;
		_ribbon.SetKeyTips(_ribbon.GenerateKeyTipsForSelectedTab(), keyTipMode);
	}

	protected void UpdateTargetState(Control c)
	{
		if (c == null || c.IsDisposed)
		{
			UpdateTargetState(new Point(int.MaxValue, int.MaxValue));
		}
		else
		{
			UpdateTargetState(c.PointToClient(Control.MousePosition));
		}
	}

	protected void UpdateTargetState(Point pt)
	{
		PaletteState paletteState = ((!_target.Enabled) ? PaletteState.Disabled : (_target.Checked ? ((!_mouseOver) ? PaletteState.CheckedNormal : PaletteState.CheckedTracking) : ((!_mouseOver) ? PaletteState.Normal : PaletteState.Tracking)));
		if (_target.ElementState != paletteState)
		{
			_target.ElementState = paletteState;
			OnNeedPaint(needLayout: false, _target.ClientRectangle);
		}
	}

	protected virtual void OnClick(MouseEventArgs e)
	{
		if (this.Click != null)
		{
			this.Click(_target, e);
		}
	}

	protected virtual void OnContextClick(MouseEventArgs e)
	{
		if (this.ContextClick != null)
		{
			this.ContextClick(_target, e);
		}
	}

	protected virtual void OnNeedPaint(bool needLayout, Rectangle invalidRect)
	{
		if (_needPaint != null)
		{
			invalidRect = new Rectangle(0, invalidRect.Y - 3, _ribbon.Width, invalidRect.Height + 3);
			_needPaint(this, new NeedLayoutEventArgs(needLayout, invalidRect));
		}
	}
}
