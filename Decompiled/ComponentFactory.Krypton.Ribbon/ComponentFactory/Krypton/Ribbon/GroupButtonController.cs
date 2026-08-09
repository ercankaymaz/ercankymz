#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class GroupButtonController : GlobalId, IMouseController, ISourceController, IKeyController, IRibbonKeyTipTarget
{
	private KryptonRibbon _ribbon;

	private ViewDrawRibbonGroupButtonBackBorder _target;

	private NeedPaintHandler _needPaint;

	private GroupButtonType _buttonType;

	private Rectangle _splitRectangle;

	private bool _rightButtonDown;

	private bool _mouseInSplit;

	private bool _previousMouseInSplit;

	private bool _fixedPressed;

	private bool _captured;

	private bool _mouseOver;

	private bool _hasFocus;

	public bool MouseInSplit => _mouseInSplit;

	public Rectangle SplitRectangle
	{
		get
		{
			return _splitRectangle;
		}
		set
		{
			_splitRectangle = value;
		}
	}

	public GroupButtonType ButtonType
	{
		get
		{
			return _buttonType;
		}
		set
		{
			_buttonType = value;
		}
	}

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

	public event EventHandler Click;

	public event MouseEventHandler ContextClick;

	public event EventHandler DropDown;

	public GroupButtonController(KryptonRibbon ribbon, ViewDrawRibbonGroupButtonBackBorder target, NeedPaintHandler needPaint)
	{
		Debug.Assert(ribbon != null);
		Debug.Assert(target != null);
		Debug.Assert(needPaint != null);
		_ribbon = ribbon;
		_target = target;
		NeedPaint = needPaint;
		_buttonType = GroupButtonType.Push;
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

	public virtual void MouseMove(Control c, Point pt)
	{
		if (!_mouseOver)
		{
			_mouseOver = true;
		}
		if (ButtonType == GroupButtonType.Split)
		{
			_mouseInSplit = _splitRectangle.Contains(pt);
		}
		UpdateTargetState(pt);
	}

	public virtual bool MouseDown(Control c, Point pt, MouseButtons button)
	{
		if (button == MouseButtons.Left)
		{
			if (ClickOnDown(pt) && _target.Enabled)
			{
				_captured = true;
				if (!_fixedPressed)
				{
					UpdateTargetState(pt);
					_fixedPressed = true;
					switch (ButtonType)
					{
					case GroupButtonType.Split:
						if (ButtonType == GroupButtonType.Split)
						{
							_mouseInSplit = _splitRectangle.Contains(pt);
						}
						if (_splitRectangle.Contains(pt))
						{
							OnDropDown(new MouseEventArgs(MouseButtons.Left, 1, pt.X, pt.Y, 0));
						}
						else
						{
							OnClick(new MouseEventArgs(MouseButtons.Left, 1, pt.X, pt.Y, 0));
						}
						break;
					case GroupButtonType.DropDown:
						OnDropDown(new MouseEventArgs(MouseButtons.Left, 1, pt.X, pt.Y, 0));
						break;
					default:
						OnClick(new MouseEventArgs(MouseButtons.Left, 1, pt.X, pt.Y, 0));
						break;
					}
				}
			}
			else
			{
				_captured = true;
				UpdateTargetState(pt);
			}
		}
		if (button == MouseButtons.Right)
		{
			_rightButtonDown = true;
		}
		return _captured;
	}

	public virtual void MouseUp(Control c, Point pt, MouseButtons button)
	{
		if (_captured && !ClickOnDown(pt))
		{
			_captured = false;
			if (button == MouseButtons.Left)
			{
				if (_target.ElementState == PaletteState.Pressed)
				{
					_target.ElementState = PaletteState.Tracking;
					if (_target.Enabled)
					{
						switch (ButtonType)
						{
						case GroupButtonType.Split:
							if (ButtonType == GroupButtonType.Split)
							{
								_mouseInSplit = _splitRectangle.Contains(pt);
							}
							if (_splitRectangle.Contains(pt))
							{
								OnDropDown(new MouseEventArgs(MouseButtons.Left, 1, pt.X, pt.Y, 0));
							}
							else
							{
								OnClick(new MouseEventArgs(MouseButtons.Left, 1, pt.X, pt.Y, 0));
							}
							break;
						case GroupButtonType.DropDown:
							OnDropDown(new MouseEventArgs(MouseButtons.Left, 1, pt.X, pt.Y, 0));
							break;
						default:
							OnClick(new MouseEventArgs(MouseButtons.Left, 1, pt.X, pt.Y, 0));
							break;
						}
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
		if (!_target.ContainsRecurse(next))
		{
			_mouseOver = false;
			if (!_fixedPressed)
			{
				_captured = false;
				UpdateTargetState(c);
			}
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
		switch (_buttonType)
		{
		case GroupButtonType.Push:
		case GroupButtonType.Check:
			ribbon.KillKeyboardMode();
			OnClick(new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
			break;
		case GroupButtonType.DropDown:
		case GroupButtonType.Split:
			ribbon.KillKeyboardMode();
			_captured = true;
			_fixedPressed = true;
			UpdateTargetState(Point.Empty);
			OnDropDown(new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
			break;
		}
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
		PaletteState paletteState;
		if (!_target.Enabled)
		{
			paletteState = PaletteState.Normal;
		}
		else
		{
			paletteState = PaletteState.Normal;
			if (_captured)
			{
				paletteState = ((!_fixedPressed && !_target.ClientRectangle.Contains(pt)) ? PaletteState.Normal : PaletteState.Pressed);
			}
			else if (_mouseOver || _hasFocus)
			{
				paletteState = PaletteState.Tracking;
				if (_hasFocus)
				{
					_mouseInSplit = true;
				}
			}
			else
			{
				paletteState = PaletteState.Normal;
			}
		}
		if (_target.ElementState != paletteState || _mouseInSplit != _previousMouseInSplit)
		{
			_target.ElementState = paletteState;
			_previousMouseInSplit = _mouseInSplit;
			OnNeedPaint(needLayout: false);
		}
	}

	protected virtual void OnClick(EventArgs e)
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
			this.ContextClick(this, e);
		}
	}

	protected virtual void OnDropDown(EventArgs e)
	{
		if (this.DropDown != null)
		{
			this.DropDown(_target, e);
		}
	}

	protected virtual void OnNeedPaint(bool needLayout)
	{
		if (_needPaint != null)
		{
			_needPaint(this, new NeedLayoutEventArgs(needLayout, _target.ClientRectangle));
		}
	}

	private void KeyDownRibbon(KryptonRibbon ribbon, KeyEventArgs e)
	{
		ViewBase viewBase = null;
		switch (e.KeyData)
		{
		case Keys.Left:
		case Keys.Tab | Keys.Shift:
			viewBase = ribbon.GroupsArea.ViewGroups.GetPreviousFocusItem(_target);
			if (viewBase == null)
			{
				viewBase = ribbon.TabsArea.LayoutTabs.GetViewForRibbonTab(ribbon.SelectedTab);
			}
			break;
		case Keys.Tab:
		case Keys.Right:
			viewBase = ribbon.GroupsArea.ViewGroups.GetNextFocusItem(_target);
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
			switch (_buttonType)
			{
			case GroupButtonType.Push:
			case GroupButtonType.Check:
				_ribbon.KillKeyboardMode();
				OnClick(new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
				break;
			case GroupButtonType.DropDown:
			case GroupButtonType.Split:
				_ribbon.KillKeyboardKeyTips();
				_hasFocus = true;
				_captured = true;
				_fixedPressed = true;
				UpdateTargetState(Point.Empty);
				OnDropDown(new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
				break;
			}
			break;
		}
		if (viewBase != null && viewBase != Target)
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
			switch (_buttonType)
			{
			case GroupButtonType.Push:
			case GroupButtonType.Check:
				_ribbon.KillKeyboardMode();
				OnClick(new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
				break;
			case GroupButtonType.DropDown:
			case GroupButtonType.Split:
				_ribbon.KillKeyboardKeyTips();
				_hasFocus = true;
				_captured = true;
				_fixedPressed = true;
				UpdateTargetState(Point.Empty);
				OnDropDown(new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
				break;
			}
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
			switch (_buttonType)
			{
			case GroupButtonType.Push:
			case GroupButtonType.Check:
				_ribbon.KillKeyboardMode();
				OnClick(new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
				break;
			case GroupButtonType.DropDown:
			case GroupButtonType.Split:
				_ribbon.KillKeyboardKeyTips();
				_hasFocus = true;
				_captured = true;
				_fixedPressed = true;
				UpdateTargetState(Point.Empty);
				OnDropDown(new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
				break;
			}
			break;
		}
	}

	private bool ClickOnDown(Point pt)
	{
		return _buttonType switch
		{
			GroupButtonType.DropDown => true, 
			GroupButtonType.Split => _splitRectangle.Contains(pt), 
			_ => false, 
		};
	}
}
