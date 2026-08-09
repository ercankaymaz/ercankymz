using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class DialogLauncherButtonController : LeftUpButtonController, ISourceController, IKeyController, IRibbonKeyTipTarget
{
	private bool _hasFocus;

	public DialogLauncherButtonController(KryptonRibbon ribbon, ViewBase target, NeedPaintHandler needPaint)
		: base(ribbon, target, needPaint)
	{
	}

	public virtual void GotFocus(Control c)
	{
		_hasFocus = true;
		UpdateTargetState(Point.Empty);
		OnNeedPaint(needLayout: false);
	}

	public virtual void LostFocus(Control c)
	{
		_hasFocus = false;
		UpdateTargetState(Point.Empty);
		OnNeedPaint(needLayout: false);
	}

	public void KeyDown(Control c, KeyEventArgs e)
	{
		c = base.Ribbon.GetControllerControl(c);
		if (c is KryptonRibbon)
		{
			KeyDownRibbon(e);
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
		base.Ribbon.KillKeyboardMode();
		OnClick(new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
	}

	protected override void UpdateTargetState(Point pt)
	{
		if (_hasFocus)
		{
			if (base.Target.ElementState != PaletteState.Tracking)
			{
				base.Target.ElementState = PaletteState.Tracking;
				OnNeedPaint(needLayout: false);
			}
		}
		else
		{
			base.UpdateTargetState(pt);
		}
	}

	private void KeyDownRibbon(KeyEventArgs e)
	{
		ViewBase viewBase = null;
		switch (e.KeyData)
		{
		case Keys.Left:
		case Keys.Tab | Keys.Shift:
			viewBase = base.Ribbon.GroupsArea.ViewGroups.GetPreviousFocusItem(base.Target);
			if (viewBase == null)
			{
				viewBase = base.Ribbon.TabsArea.LayoutTabs.GetViewForRibbonTab(base.Ribbon.SelectedTab);
			}
			break;
		case Keys.Tab:
		case Keys.Right:
			viewBase = base.Ribbon.GroupsArea.ViewGroups.GetNextFocusItem(base.Target);
			if (viewBase == null)
			{
				viewBase = base.Ribbon.TabsArea.ButtonSpecManager.GetFirstVisibleViewButton(PaletteRelativeEdgeAlign.Far);
			}
			if (viewBase == null)
			{
				viewBase = base.Ribbon.TabsArea.ButtonSpecManager.GetFirstVisibleViewButton(PaletteRelativeEdgeAlign.Inherit);
			}
			if (viewBase == null)
			{
				if (base.Ribbon.TabsArea.LayoutAppButton.Visible)
				{
					viewBase = base.Ribbon.TabsArea.LayoutAppButton.AppButton;
				}
				else if (base.Ribbon.TabsArea.LayoutAppTab.Visible)
				{
					viewBase = base.Ribbon.TabsArea.LayoutAppTab.AppTab;
				}
			}
			break;
		case Keys.Return:
		case Keys.Space:
			base.Ribbon.KillKeyboardMode();
			OnClick(new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
			break;
		}
		if (viewBase != null && viewBase != base.Target)
		{
			if (viewBase is ViewDrawRibbonTab && !base.Ribbon.RealMinimizedMode)
			{
				base.Ribbon.SelectedTab = ((ViewDrawRibbonTab)viewBase).RibbonTab;
			}
			base.Ribbon.FocusView = viewBase;
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
			base.Ribbon.KillKeyboardMode();
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
			base.Ribbon.KillKeyboardMode();
			OnClick(new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
			break;
		}
	}
}
