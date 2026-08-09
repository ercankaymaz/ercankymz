#define DEBUG
using System.Diagnostics;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class DomainUpDownController : GlobalId, ISourceController, IKeyController, IRibbonKeyTipTarget
{
	private KryptonRibbon _ribbon;

	private KryptonRibbonGroupDomainUpDown _domainUpDown;

	private ViewDrawRibbonGroupDomainUpDown _target;

	public DomainUpDownController(KryptonRibbon ribbon, KryptonRibbonGroupDomainUpDown domainUpDown, ViewDrawRibbonGroupDomainUpDown target)
	{
		Debug.Assert(ribbon != null);
		Debug.Assert(domainUpDown != null);
		Debug.Assert(target != null);
		_ribbon = ribbon;
		_domainUpDown = domainUpDown;
		_target = target;
	}

	public void GotFocus(Control c)
	{
		if (_domainUpDown.LastDomainUpDown != null && _domainUpDown.LastDomainUpDown.DomainUpDown != null && _domainUpDown.LastDomainUpDown.DomainUpDown.CanFocus)
		{
			_ribbon.LostFocusLosesKeyboard = false;
			_domainUpDown.LastDomainUpDown.DomainUpDown.Focus();
		}
	}

	public void LostFocus(Control c)
	{
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
		if (_domainUpDown.LastDomainUpDown.CanFocus)
		{
			ribbon.LostFocusLosesKeyboard = false;
			ribbon.IgnoreRestoreFocus = true;
			ribbon.KillKeyboardMode();
			_domainUpDown.LastDomainUpDown.DomainUpDown.Focus();
			if (_domainUpDown.LastParentControl is VisualPopupGroup)
			{
				VisualPopupGroup visualPopupGroup = (VisualPopupGroup)_domainUpDown.LastParentControl;
				visualPopupGroup.RestorePreviousFocus = true;
			}
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
		}
		if (viewBase != null && viewBase != _target)
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
		}
	}
}
