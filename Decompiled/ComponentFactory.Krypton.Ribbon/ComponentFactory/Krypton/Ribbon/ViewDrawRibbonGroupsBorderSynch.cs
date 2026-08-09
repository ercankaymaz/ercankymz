using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewDrawRibbonGroupsBorderSynch : ViewDrawRibbonGroupsBorder
{
	private class TabToView : Dictionary<KryptonRibbonTab, ViewLayoutRibbonScrollPort>
	{
	}

	private static readonly int SCROLL_SPEED = 24;

	private TabToView _tabToView;

	public ViewDrawRibbonGroupsBorderSynch(KryptonRibbon ribbon, NeedPaintHandler needPaintDelegate)
		: base(ribbon, borderOutside: false, needPaintDelegate)
	{
		_tabToView = new TabToView();
	}

	public override string ToString()
	{
		return "ViewDrawRibbonGroupsBorderSynch:" + base.Id;
	}

	public ViewDrawRibbonGroup ViewGroupFromPoint(Point pt)
	{
		if (base.Ribbon.SelectedTab != null)
		{
			ViewLayoutRibbonScrollPort viewLayoutRibbonScrollPort = _tabToView[base.Ribbon.SelectedTab];
			ViewLayoutControl viewLayoutControl = viewLayoutRibbonScrollPort[0] as ViewLayoutControl;
			ViewLayoutRibbonGroups viewLayoutRibbonGroups = viewLayoutControl.ChildView as ViewLayoutRibbonGroups;
			return viewLayoutRibbonGroups.ViewGroupFromPoint(pt);
		}
		return null;
	}

	public KeyTipInfo[] GetGroupKeyTips(KryptonRibbonTab tab)
	{
		if (_tabToView.ContainsKey(tab))
		{
			return _tabToView[tab].GetGroupKeyTips();
		}
		return new KeyTipInfo[0];
	}

	public ViewBase GetFirstFocusItem()
	{
		if (base.Ribbon.SelectedTab != null && _tabToView.ContainsKey(base.Ribbon.SelectedTab))
		{
			return _tabToView[base.Ribbon.SelectedTab].GetFirstFocusItem();
		}
		return null;
	}

	public ViewBase GetLastFocusItem()
	{
		if (base.Ribbon.SelectedTab != null && _tabToView.ContainsKey(base.Ribbon.SelectedTab))
		{
			return _tabToView[base.Ribbon.SelectedTab].GetLastFocusItem();
		}
		return null;
	}

	public ViewBase GetNextFocusItem(ViewBase current)
	{
		if (base.Ribbon.SelectedTab != null && _tabToView.ContainsKey(base.Ribbon.SelectedTab))
		{
			return _tabToView[base.Ribbon.SelectedTab].GetNextFocusItem(current);
		}
		return null;
	}

	public ViewBase GetPreviousFocusItem(ViewBase current)
	{
		if (base.Ribbon.SelectedTab != null && _tabToView.ContainsKey(base.Ribbon.SelectedTab))
		{
			return _tabToView[base.Ribbon.SelectedTab].GetPreviousFocusItem(current);
		}
		return null;
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		SyncChildrenToRibbonTabs();
		return base.GetPreferredSize(context);
	}

	public override void Layout(ViewLayoutContext context)
	{
		SyncChildrenToRibbonTabs();
		base.Layout(context);
	}

	private void SyncChildrenToRibbonTabs()
	{
		Clear();
		TabToView tabToView = new TabToView();
		foreach (KryptonRibbonTab ribbonTab in base.Ribbon.RibbonTabs)
		{
			ViewLayoutRibbonScrollPort viewLayoutRibbonScrollPort = null;
			if (_tabToView.ContainsKey(ribbonTab))
			{
				viewLayoutRibbonScrollPort = _tabToView[ribbonTab];
			}
			if (viewLayoutRibbonScrollPort == null)
			{
				ViewLayoutRibbonGroups viewLayoutRibbonGroups = new ViewLayoutRibbonGroups(base.Ribbon, ribbonTab, base.NeedPaintDelegate);
				viewLayoutRibbonScrollPort = new ViewLayoutRibbonScrollPort(base.Ribbon, Orientation.Horizontal, viewLayoutRibbonGroups, insetForTabs: false, SCROLL_SPEED, base.NeedPaintDelegate);
				viewLayoutRibbonScrollPort.TransparentBackground = true;
				viewLayoutRibbonGroups.NeedPaintDelegate = viewLayoutRibbonScrollPort.ViewControlPaintDelegate;
			}
			viewLayoutRibbonScrollPort.Visible = base.Ribbon.SelectedTab == ribbonTab;
			tabToView.Add(ribbonTab, viewLayoutRibbonScrollPort);
			_tabToView.Remove(ribbonTab);
		}
		TabToView tabToView2 = _tabToView;
		_tabToView = tabToView;
		foreach (KryptonRibbonTab ribbonTab2 in base.Ribbon.RibbonTabs)
		{
			Add(_tabToView[ribbonTab2]);
		}
		foreach (ViewLayoutRibbonScrollPort value in tabToView2.Values)
		{
			value.Dispose();
		}
	}
}
