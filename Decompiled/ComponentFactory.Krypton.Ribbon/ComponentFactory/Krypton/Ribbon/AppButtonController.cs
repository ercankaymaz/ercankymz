using System;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class AppButtonController : GlobalId, IMouseController, ISourceController, IKeyController, IRibbonKeyTipTarget
{
	private KryptonRibbon _ribbon;

	private ViewBase _target1;

	private ViewBase _target2;

	private ViewBase _target3;

	private bool _mouseOver;

	private bool _mouseDown;

	private bool _fixedPressed;

	private bool _hasFocus;

	private bool _keyboard;

	private Timer _updateTimer;

	public ViewBase Target1
	{
		get
		{
			return _target1;
		}
		set
		{
			_target1 = value;
		}
	}

	public ViewBase Target2
	{
		get
		{
			return _target2;
		}
		set
		{
			_target2 = value;
		}
	}

	public ViewBase Target3
	{
		get
		{
			return _target3;
		}
		set
		{
			_target3 = value;
		}
	}

	public bool Keyboard => _keyboard;

	public virtual bool IgnoreVisualFormLeftButtonDown => true;

	public event EventHandler Click;

	public event EventHandler MouseReleased;

	public event NeedPaintHandler NeedPaint;

	public AppButtonController(KryptonRibbon ribbon)
	{
		_ribbon = ribbon;
		_updateTimer = new Timer();
		_updateTimer.Interval = 1;
		_updateTimer.Tick += OnUpdateTimer;
		_keyboard = false;
	}

	public void RemoveFixed()
	{
		if (_fixedPressed)
		{
			_mouseDown = false;
			_fixedPressed = false;
			_updateTimer.Start();
		}
	}

	public virtual void MouseEnter(Control c)
	{
		_mouseOver = true;
		if (!_fixedPressed)
		{
			_updateTimer.Start();
		}
	}

	public virtual void MouseMove(Control c, Point pt)
	{
	}

	public virtual bool MouseDown(Control c, Point pt, MouseButtons button)
	{
		if (button == MouseButtons.Left)
		{
			_mouseDown = true;
			if (!_fixedPressed && _ribbon.Enabled)
			{
				UpdateTargetState();
				_fixedPressed = true;
				_keyboard = false;
				OnClick(new MouseEventArgs(MouseButtons.Left, 1, pt.X, pt.Y, 0));
			}
		}
		return false;
	}

	public virtual void MouseUp(Control c, Point pt, MouseButtons button)
	{
		if (button == MouseButtons.Left)
		{
			OnMouseReleased(new MouseEventArgs(MouseButtons.Left, 1, pt.X, pt.Y, 0));
		}
	}

	public virtual void MouseLeave(Control c, ViewBase next)
	{
		_mouseOver = false;
		if (!_fixedPressed)
		{
			_updateTimer.Start();
		}
	}

	public virtual void DoubleClick(Point pt)
	{
	}

	public virtual void GotFocus(Control c)
	{
		_hasFocus = true;
		if (!_fixedPressed)
		{
			_updateTimer.Start();
		}
	}

	public virtual void LostFocus(Control c)
	{
		_hasFocus = false;
		if (!_fixedPressed)
		{
			_updateTimer.Start();
		}
	}

	public void KeyDown(Control c, KeyEventArgs e)
	{
		ViewBase viewBase = null;
		KryptonRibbon kryptonRibbon = (KryptonRibbon)c;
		switch (e.KeyData)
		{
		case Keys.Tab:
		case Keys.Right:
			viewBase = kryptonRibbon.GetFirstQATView();
			if (viewBase == null)
			{
				viewBase = kryptonRibbon.TabsArea.ButtonSpecManager.GetLastVisibleViewButton(PaletteRelativeEdgeAlign.Near);
			}
			if (viewBase == null)
			{
				viewBase = ((e.KeyData != Keys.Tab || kryptonRibbon.SelectedTab == null) ? kryptonRibbon.TabsArea.LayoutTabs.GetViewForFirstRibbonTab() : kryptonRibbon.TabsArea.LayoutTabs.GetViewForRibbonTab(kryptonRibbon.SelectedTab));
			}
			if (viewBase == null)
			{
				viewBase = kryptonRibbon.TabsArea.ButtonSpecManager.GetFirstVisibleViewButton(PaletteRelativeEdgeAlign.Far);
			}
			if (viewBase == null)
			{
				viewBase = kryptonRibbon.TabsArea.ButtonSpecManager.GetFirstVisibleViewButton(PaletteRelativeEdgeAlign.Inherit);
			}
			break;
		case Keys.Left:
		case Keys.Tab | Keys.Shift:
			viewBase = kryptonRibbon.TabsArea.ButtonSpecManager.GetLastVisibleViewButton(PaletteRelativeEdgeAlign.Far);
			if (viewBase == null)
			{
				viewBase = kryptonRibbon.TabsArea.ButtonSpecManager.GetLastVisibleViewButton(PaletteRelativeEdgeAlign.Inherit);
			}
			if (viewBase == null)
			{
				if (e.KeyData != Keys.Left)
				{
					viewBase = kryptonRibbon.GroupsArea.ViewGroups.GetLastFocusItem();
					if (viewBase == null)
					{
						viewBase = ((kryptonRibbon.SelectedTab == null) ? kryptonRibbon.TabsArea.LayoutTabs.GetViewForLastRibbonTab() : kryptonRibbon.TabsArea.LayoutTabs.GetViewForRibbonTab(kryptonRibbon.SelectedTab));
					}
				}
				else
				{
					viewBase = kryptonRibbon.TabsArea.LayoutTabs.GetViewForLastRibbonTab();
				}
			}
			if (viewBase == null)
			{
				viewBase = kryptonRibbon.TabsArea.ButtonSpecManager.GetFirstVisibleViewButton(PaletteRelativeEdgeAlign.Near);
			}
			if (viewBase == null)
			{
				viewBase = kryptonRibbon.GetLastQATView();
			}
			break;
		case Keys.Return:
		case Keys.Space:
		case Keys.Down:
			_fixedPressed = true;
			UpdateTargetState();
			_keyboard = true;
			OnClick(new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
			break;
		}
		if (viewBase != null && viewBase != _target1 && viewBase != _target2 && viewBase != _target3)
		{
			if (viewBase is ViewDrawRibbonTab && !kryptonRibbon.RealMinimizedMode)
			{
				kryptonRibbon.SelectedTab = ((ViewDrawRibbonTab)viewBase).RibbonTab;
			}
			kryptonRibbon.FocusView = viewBase;
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
		ribbon.KillKeyboardKeyTips();
		_fixedPressed = true;
		UpdateTargetState();
		ribbon.FocusView = ribbon.TabsArea.LayoutAppButton.AppButton;
		_keyboard = true;
		OnClick(new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
	}

	protected void UpdateTargetState()
	{
		PaletteState paletteState = PaletteState.Normal;
		if (_ribbon.Enabled)
		{
			if (_fixedPressed)
			{
				paletteState = PaletteState.Pressed;
			}
			else if (_mouseDown)
			{
				paletteState = PaletteState.Pressed;
			}
			else if (_mouseOver || _hasFocus)
			{
				paletteState = PaletteState.Tracking;
			}
		}
		bool flag = false;
		if (_target1 != null && _target1.ElementState != paletteState)
		{
			_target1.ElementState = paletteState;
			flag = true;
		}
		if (_target2 != null && _target2.ElementState != paletteState)
		{
			_target2.ElementState = paletteState;
			flag = true;
		}
		if (_target3 != null && _target3.ElementState != paletteState)
		{
			_target3.ElementState = paletteState;
			flag = true;
		}
		if (flag)
		{
			if (_target1 != null && !_target1.ClientRectangle.IsEmpty)
			{
				OnNeedPaint(needLayout: false, _target1.ClientRectangle);
			}
			if (_target2 != null && !_target2.ClientRectangle.IsEmpty)
			{
				OnNeedPaint(needLayout: false, _target2.ClientRectangle);
			}
			if (_target3 != null && !_target3.ClientRectangle.IsEmpty)
			{
				OnNeedPaint(needLayout: false, _target3.ClientRectangle);
			}
			Application.DoEvents();
		}
	}

	protected virtual void OnNeedPaint(bool needLayout, Rectangle invalidRect)
	{
		if (this.NeedPaint != null)
		{
			this.NeedPaint(this, new NeedLayoutEventArgs(needLayout, invalidRect));
		}
	}

	protected virtual void OnClick(MouseEventArgs e)
	{
		if (this.Click != null)
		{
			this.Click(this, e);
		}
		_keyboard = false;
	}

	protected virtual void OnMouseReleased(MouseEventArgs e)
	{
		if (this.MouseReleased != null)
		{
			this.MouseReleased(this, e);
		}
	}

	private void OnUpdateTimer(object sender, EventArgs e)
	{
		_updateTimer.Stop();
		UpdateTargetState();
	}
}
