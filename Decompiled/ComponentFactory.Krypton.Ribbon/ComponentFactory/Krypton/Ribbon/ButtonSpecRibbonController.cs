using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ButtonSpecRibbonController : ButtonController
{
	private bool _hasFocus;

	public ButtonSpecRibbonController(ViewBase target, NeedPaintHandler needPaint)
		: base(target, needPaint)
	{
	}

	public override void KeyDown(Control c, KeyEventArgs e)
	{
		ViewBase viewBase = null;
		KryptonRibbon kryptonRibbon = (KryptonRibbon)c;
		ViewDrawButton viewDrawButton = (ViewDrawButton)base.Target;
		ButtonSpec buttonSpecFromView = kryptonRibbon.TabsArea.ButtonSpecManager.GetButtonSpecFromView(viewDrawButton);
		bool flag = buttonSpecFromView.Edge == PaletteRelativeEdgeAlign.Near;
		switch (e.KeyData)
		{
		case Keys.Tab:
		case Keys.Right:
			if (flag)
			{
				viewBase = kryptonRibbon.TabsArea.ButtonSpecManager.GetPreviousVisibleViewButton(PaletteRelativeEdgeAlign.Near, viewDrawButton);
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
				if (viewBase == null)
				{
					if (kryptonRibbon.TabsArea.LayoutAppButton.Visible)
					{
						viewBase = kryptonRibbon.TabsArea.LayoutAppButton.AppButton;
					}
					else if (kryptonRibbon.TabsArea.LayoutAppTab.Visible)
					{
						viewBase = kryptonRibbon.TabsArea.LayoutAppTab.AppTab;
					}
				}
				break;
			}
			viewBase = kryptonRibbon.TabsArea.ButtonSpecManager.GetNextVisibleViewButton(PaletteRelativeEdgeAlign.Far, viewDrawButton);
			if (viewBase == null)
			{
				viewBase = kryptonRibbon.TabsArea.ButtonSpecManager.GetNextVisibleViewButton(PaletteRelativeEdgeAlign.Inherit, viewDrawButton);
			}
			if (viewBase == null)
			{
				if (kryptonRibbon.TabsArea.LayoutAppButton.Visible)
				{
					viewBase = kryptonRibbon.TabsArea.LayoutAppButton.AppButton;
				}
				else if (kryptonRibbon.TabsArea.LayoutAppTab.Visible)
				{
					viewBase = kryptonRibbon.TabsArea.LayoutAppTab.AppTab;
				}
			}
			break;
		case Keys.Left:
		case Keys.Tab | Keys.Shift:
			if (flag)
			{
				viewBase = kryptonRibbon.TabsArea.ButtonSpecManager.GetNextVisibleViewButton(PaletteRelativeEdgeAlign.Near, viewDrawButton);
				if (viewBase == null)
				{
					viewBase = kryptonRibbon.GetLastQATView();
				}
				if (viewBase == null)
				{
					if (kryptonRibbon.TabsArea.LayoutAppButton.Visible)
					{
						viewBase = kryptonRibbon.TabsArea.LayoutAppButton.AppButton;
					}
					else if (kryptonRibbon.TabsArea.LayoutAppTab.Visible)
					{
						viewBase = kryptonRibbon.TabsArea.LayoutAppTab.AppTab;
					}
				}
				break;
			}
			viewBase = kryptonRibbon.TabsArea.ButtonSpecManager.GetPreviousVisibleViewButton(PaletteRelativeEdgeAlign.Far, viewDrawButton);
			if (viewBase == null)
			{
				viewBase = kryptonRibbon.TabsArea.ButtonSpecManager.GetPreviousVisibleViewButton(PaletteRelativeEdgeAlign.Inherit, viewDrawButton);
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
			if (viewBase == null)
			{
				if (kryptonRibbon.TabsArea.LayoutAppButton.Visible)
				{
					viewBase = kryptonRibbon.TabsArea.LayoutAppButton.AppButton;
				}
				else if (kryptonRibbon.TabsArea.LayoutAppTab.Visible)
				{
					viewBase = kryptonRibbon.TabsArea.LayoutAppTab.AppTab;
				}
			}
			break;
		case Keys.Return:
		case Keys.Space:
			kryptonRibbon.KillKeyboardMode();
			OnClick(new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
			break;
		}
		if (viewBase != null && viewBase != base.Target)
		{
			if (viewBase is ViewDrawRibbonTab && !kryptonRibbon.RealMinimizedMode)
			{
				kryptonRibbon.SelectedTab = ((ViewDrawRibbonTab)viewBase).RibbonTab;
			}
			kryptonRibbon.FocusView = viewBase;
		}
	}

	public override void KeyPress(Control c, KeyPressEventArgs e)
	{
	}

	public override bool KeyUp(Control c, KeyEventArgs e)
	{
		return false;
	}

	public override void GotFocus(Control c)
	{
		_hasFocus = true;
		UpdateTargetState(c);
	}

	public override void LostFocus(Control c)
	{
		_hasFocus = false;
		UpdateTargetState(c);
	}

	protected override void UpdateTargetState(Point pt)
	{
		if (_hasFocus)
		{
			if (base.Target.ElementState != PaletteState.Tracking)
			{
				base.Target.ElementState = PaletteState.Tracking;
				OnNeedPaint(needLayout: true);
			}
		}
		else
		{
			base.UpdateTargetState(pt);
		}
	}
}
