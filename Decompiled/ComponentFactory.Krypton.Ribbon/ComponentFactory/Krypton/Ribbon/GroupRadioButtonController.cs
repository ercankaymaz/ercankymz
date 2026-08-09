#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class GroupRadioButtonController : GlobalId, IMouseController, ISourceController, IKeyController, IRibbonKeyTipTarget
{
	private KryptonRibbon _ribbon;

	private ViewBase _targetMain;

	private ViewDrawRibbonGroupRadioButtonImage _targetImage;

	private NeedPaintHandler _needPaint;

	private bool _rightButtonDown;

	private bool _fixedPressed;

	private bool _captured;

	private bool _mouseOver;

	private bool _hasFocus;

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

	public ViewBase TargetMain => _targetMain;

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

	public event EventHandler Click;

	public event MouseEventHandler ContextClick;

	public GroupRadioButtonController(KryptonRibbon ribbon, ViewBase targetMain, ViewDrawRibbonGroupRadioButtonImage targetImage, NeedPaintHandler needPaint)
	{
		Debug.Assert(ribbon != null);
		Debug.Assert(targetMain != null);
		Debug.Assert(targetImage != null);
		Debug.Assert(needPaint != null);
		_ribbon = ribbon;
		_targetMain = targetMain;
		_targetImage = targetImage;
		NeedPaint = needPaint;
	}

	public void RemoveFixed()
	{
		if (_fixedPressed)
		{
			_captured = false;
			_fixedPressed = false;
			UpdateTargetState(Point.Empty);
		}
	}

	public virtual void MouseEnter(Control c)
	{
		_mouseOver = true;
		if (!_fixedPressed)
		{
			UpdateTargetState(c);
		}
	}

	public virtual bool MouseDown(Control c, Point pt, MouseButtons button)
	{
		if (button == MouseButtons.Left)
		{
			_captured = true;
			UpdateTargetState(pt);
		}
		if (button == MouseButtons.Right)
		{
			_rightButtonDown = true;
		}
		return _captured;
	}

	public virtual void MouseMove(Control c, Point pt)
	{
		UpdateTargetState(pt);
	}

	public virtual void MouseUp(Control c, Point pt, MouseButtons button)
	{
		if (_captured)
		{
			_captured = false;
			if (button == MouseButtons.Left)
			{
				if (_targetImage.Pressed)
				{
					_targetImage.Pressed = false;
					_targetImage.Tracking = true;
					if (_targetImage.Enabled)
					{
						OnClick(new MouseEventArgs(MouseButtons.Left, 1, pt.X, pt.Y, 0));
					}
				}
				OnNeedPaint(needLayout: false);
			}
			else
			{
				UpdateTargetState(pt);
			}
		}
		if (button == MouseButtons.Right && _rightButtonDown)
		{
			_rightButtonDown = false;
			OnContextClick(new MouseEventArgs(MouseButtons.Right, 1, pt.X, pt.Y, 0));
		}
	}

	public virtual void MouseLeave(Control c, ViewBase next)
	{
		_mouseOver = false;
		if (!_fixedPressed)
		{
			_captured = false;
			UpdateTargetState(c);
		}
	}

	public virtual void DoubleClick(Point pt)
	{
	}

	public virtual void GotFocus(Control c)
	{
		_hasFocus = true;
		UpdateTargetState(Point.Empty);
	}

	public virtual void LostFocus(Control c)
	{
		_hasFocus = false;
		UpdateTargetState(Point.Empty);
	}

	public void KeyDown(Control c, KeyEventArgs e)
	{
		c = _ribbon.GetControllerControl(c);
		if (c is KryptonRibbon)
		{
			KeyDownRibbon(c as KryptonRibbon, e);
		}
		else if (c is VisualPopupGroup)
		{
			KeyDownPopupGroup(c as VisualPopupGroup, e);
		}
		else if (c is VisualPopupMinimized)
		{
			KeyDownPopupMinimized(c as VisualPopupMinimized, e);
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
		ribbon.KillKeyboardMode();
		OnClick(new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
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
		bool flag = false;
		bool flag2 = false;
		if (_targetImage.Enabled)
		{
			if (_captured)
			{
				if (_fixedPressed || _targetMain.ClientRectangle.Contains(pt))
				{
					flag2 = true;
				}
			}
			else if (_mouseOver || _hasFocus)
			{
				flag = true;
			}
		}
		if (_targetImage.Pressed != flag2 || _targetImage.Tracking != flag)
		{
			_targetImage.Pressed = flag2;
			_targetImage.Tracking = flag;
			OnNeedPaint(needLayout: false);
		}
	}

	protected virtual void OnClick(EventArgs e)
	{
		if (this.Click != null)
		{
			this.Click(_targetMain, e);
		}
	}

	protected virtual void OnContextClick(MouseEventArgs e)
	{
		if (this.ContextClick != null)
		{
			this.ContextClick(this, e);
		}
	}

	protected virtual void OnNeedPaint(bool needLayout)
	{
		if (_needPaint != null)
		{
			_needPaint(this, new NeedLayoutEventArgs(needLayout, _targetMain.ClientRectangle));
		}
	}

	private void KeyDownRibbon(KryptonRibbon ribbon, KeyEventArgs e)
	{
		ViewBase viewBase = null;
		switch (e.KeyData)
		{
		case Keys.Left:
		case Keys.Tab | Keys.Shift:
			viewBase = ribbon.GroupsArea.ViewGroups.GetPreviousFocusItem(_targetMain);
			if (viewBase == null)
			{
				viewBase = ribbon.TabsArea.LayoutTabs.GetViewForRibbonTab(ribbon.SelectedTab);
			}
			break;
		case Keys.Tab:
		case Keys.Right:
			viewBase = ribbon.GroupsArea.ViewGroups.GetNextFocusItem(_targetMain);
			if (viewBase == null)
			{
				viewBase = ribbon.TabsArea.ButtonSpecManager.GetFirstVisibleViewButton(PaletteRelativeEdgeAlign.Far);
			}
			if (viewBase == null)
			{
				viewBase = ribbon.TabsArea.ButtonSpecManager.GetFirstVisibleViewButton(PaletteRelativeEdgeAlign.Inherit);
			}
			if (viewBase == null)
			{
				if (ribbon.TabsArea.LayoutAppButton.Visible)
				{
					viewBase = ribbon.TabsArea.LayoutAppButton.AppButton;
				}
				else if (ribbon.TabsArea.LayoutAppTab.Visible)
				{
					viewBase = ribbon.TabsArea.LayoutAppTab.AppTab;
				}
			}
			break;
		case Keys.Return:
		case Keys.Space:
			_ribbon.KillKeyboardMode();
			OnClick(new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
			break;
		}
		if (viewBase != null && viewBase != TargetMain)
		{
			if (viewBase is ViewDrawRibbonTab && !ribbon.RealMinimizedMode)
			{
				ribbon.SelectedTab = ((ViewDrawRibbonTab)viewBase).RibbonTab;
			}
			ribbon.FocusView = viewBase;
		}
	}

	private void KeyDownPopupGroup(VisualPopupGroup popupGroup, KeyEventArgs e)
	{
		switch (e.KeyData)
		{
		case Keys.Left:
		case Keys.Tab | Keys.Shift:
			popupGroup.SetPreviousFocusItem();
			break;
		case Keys.Tab:
		case Keys.Right:
			popupGroup.SetNextFocusItem();
			break;
		case Keys.Return:
		case Keys.Space:
			_ribbon.KillKeyboardMode();
			OnClick(new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
			break;
		}
	}

	private void KeyDownPopupMinimized(VisualPopupMinimized popupMinimized, KeyEventArgs e)
	{
		switch (e.KeyData)
		{
		case Keys.Left:
		case Keys.Tab | Keys.Shift:
			popupMinimized.SetPreviousFocusItem();
			break;
		case Keys.Tab:
		case Keys.Right:
			popupMinimized.SetNextFocusItem();
			break;
		case Keys.Return:
		case Keys.Space:
			_ribbon.KillKeyboardMode();
			OnClick(new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
			break;
		}
	}
}
