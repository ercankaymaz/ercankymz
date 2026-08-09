#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewLayoutRibbonTabs : ViewComposite
{
	private class ViewDrawRibbonTabList : List<ViewDrawRibbonTab>
	{
	}

	private class ViewDrawRibbonTabSepList : List<ViewDrawRibbonTabSep>
	{
	}

	private class ContextNameList : List<string>
	{
	}

	private static readonly int TAB_MINWIDTH;

	private static readonly int TAB_EXCESS;

	private static ContextTabSetCollection _contextTabSets;

	private KryptonRibbon _ribbon;

	private ViewDrawRibbonTabList _tabCache;

	private ViewDrawRibbonTabSepList _tabSepCache;

	private ViewDrawRibbonDesignTab _viewAddTab;

	private ViewLayoutRibbonTabsSpare _tabsSpare;

	private NeedPaintHandler _needPaint;

	private ContextNameList _cachedSelectedContext;

	private Control _parentControl;

	private Size[] _cachedSizes;

	private int _cachedPreferredWidth;

	private int _cachedMinimumWidth;

	private int _cachedAllTabCount;

	private int _cachedNonContextTabCount;

	private bool _showSeparators;

	public NeedPaintHandler NeedPaintDelegate
	{
		set
		{
			_needPaint = value;
		}
	}

	public Control ParentControl
	{
		get
		{
			return _parentControl;
		}
		set
		{
			_parentControl = value;
		}
	}

	public ViewLayoutRibbonTabsSpare GetViewForSpare => _tabsSpare;

	public static ContextTabSetCollection ContextTabSets => _contextTabSets;

	static ViewLayoutRibbonTabs()
	{
		TAB_MINWIDTH = 32;
		TAB_EXCESS = 14;
		_contextTabSets = new ContextTabSetCollection();
	}

	public ViewLayoutRibbonTabs(KryptonRibbon ribbon, NeedPaintHandler needPaint)
	{
		Debug.Assert(ribbon != null);
		Debug.Assert(needPaint != null);
		_ribbon = ribbon;
		_needPaint = needPaint;
		_tabCache = new ViewDrawRibbonTabList();
		_tabSepCache = new ViewDrawRibbonTabSepList();
	}

	public override string ToString()
	{
		return "ViewLayoutRibbonTabs:" + base.Id;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			Clear();
			foreach (ViewDrawRibbonTab item in _tabCache)
			{
				item.Dispose();
			}
			foreach (ViewDrawRibbonTabSep item2 in _tabSepCache)
			{
				item2.Dispose();
			}
			_tabCache.Clear();
			_tabSepCache.Clear();
		}
		base.Dispose(disposing);
	}

	public ViewDrawRibbonTab GetViewForRibbonTab(KryptonRibbonTab ribbonTab)
	{
		foreach (ViewDrawRibbonTab item in _tabCache)
		{
			if (item.RibbonTab == ribbonTab)
			{
				return item;
			}
		}
		return null;
	}

	public ViewDrawRibbonTab GetViewForFirstRibbonTab()
	{
		using (IEnumerator<ViewBase> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				ViewBase current = enumerator.Current;
				if (current.Visible && current is ViewDrawRibbonTab)
				{
					return current as ViewDrawRibbonTab;
				}
			}
		}
		return null;
	}

	public ViewDrawRibbonTab GetViewForNextRibbonTab(KryptonRibbonTab ribbonTab)
	{
		bool flag = false;
		using (IEnumerator<ViewBase> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				ViewBase current = enumerator.Current;
				if (current is ViewDrawRibbonTab)
				{
					ViewDrawRibbonTab viewDrawRibbonTab = (ViewDrawRibbonTab)current;
					if (!flag)
					{
						flag = viewDrawRibbonTab.RibbonTab == ribbonTab;
					}
					else if (current.Visible)
					{
						return viewDrawRibbonTab;
					}
				}
			}
		}
		return null;
	}

	public ViewDrawRibbonTab GetViewForPreviousRibbonTab(KryptonRibbonTab ribbonTab)
	{
		bool flag = false;
		foreach (ViewBase item in Reverse())
		{
			if (item is ViewDrawRibbonTab)
			{
				ViewDrawRibbonTab viewDrawRibbonTab = (ViewDrawRibbonTab)item;
				if (!flag)
				{
					flag = viewDrawRibbonTab.RibbonTab == ribbonTab;
				}
				else if (item.Visible)
				{
					return viewDrawRibbonTab;
				}
			}
		}
		return null;
	}

	public ViewDrawRibbonTab GetViewForLastRibbonTab()
	{
		foreach (ViewBase item in Reverse())
		{
			if (item.Visible && item is ViewDrawRibbonTab)
			{
				return item as ViewDrawRibbonTab;
			}
		}
		return null;
	}

	public KeyTipInfo[] GetTabKeyTips()
	{
		KeyTipInfoList keyTipInfoList = new KeyTipInfoList();
		using (IEnumerator<ViewBase> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				ViewBase current = enumerator.Current;
				if (current is ViewDrawRibbonTab)
				{
					ViewDrawRibbonTab viewDrawRibbonTab = (ViewDrawRibbonTab)current;
					Rectangle rectangle = viewDrawRibbonTab.OwningControl.RectangleToScreen(viewDrawRibbonTab.ClientRectangle);
					keyTipInfoList.Add(new KeyTipInfo(screenPt: new Point(rectangle.Left + rectangle.Width / 2, rectangle.Bottom + 2), enabled: true, keyString: viewDrawRibbonTab.RibbonTab.KeyTip, clientRect: viewDrawRibbonTab.ClientRectangle, target: viewDrawRibbonTab.KeyTipTarget));
				}
			}
		}
		return keyTipInfoList.ToArray();
	}

	public void ProcessMouseWheel(bool next)
	{
		KryptonRibbonTab kryptonRibbonTab = _ribbon.SelectedTab;
		bool flag = false;
		KryptonRibbonTab kryptonRibbonTab2 = null;
		using (IEnumerator<ViewBase> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				ViewBase current = enumerator.Current;
				if (!current.Visible || !(current is ViewDrawRibbonTab))
				{
					continue;
				}
				ViewDrawRibbonTab viewDrawRibbonTab = (ViewDrawRibbonTab)current;
				if (viewDrawRibbonTab.RibbonTab == _ribbon.SelectedTab)
				{
					if (!next)
					{
						if (kryptonRibbonTab2 != null)
						{
							kryptonRibbonTab = kryptonRibbonTab2;
						}
						break;
					}
					flag = true;
				}
				else if (next && flag)
				{
					kryptonRibbonTab = viewDrawRibbonTab.RibbonTab;
					break;
				}
				kryptonRibbonTab2 = viewDrawRibbonTab.RibbonTab;
			}
		}
		if (kryptonRibbonTab != null)
		{
			_ribbon.SelectedTab = kryptonRibbonTab;
		}
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		SyncChildrenToRibbonTabs();
		Size empty = Size.Empty;
		_cachedSizes = new Size[Count];
		_cachedMinimumWidth = 0;
		_cachedAllTabCount = 0;
		_cachedNonContextTabCount = 0;
		for (int i = 0; i < Count; i++)
		{
			ViewBase viewBase = this[i];
			if (!viewBase.Visible)
			{
				continue;
			}
			_cachedSizes[i] = viewBase.GetPreferredSize(context);
			if (_cachedSizes[i].Width <= 0)
			{
				continue;
			}
			empty.Width += _cachedSizes[i].Width;
			int num = _cachedSizes[i].Height;
			if (viewBase is ViewDrawRibbonTab)
			{
				num++;
				_cachedAllTabCount++;
				ViewDrawRibbonTab viewDrawRibbonTab = viewBase as ViewDrawRibbonTab;
				if (string.IsNullOrEmpty(viewDrawRibbonTab.RibbonTab.ContextName))
				{
					_cachedNonContextTabCount++;
				}
			}
			else if (viewBase is ViewDrawRibbonDesignTab)
			{
				num++;
				_cachedAllTabCount++;
			}
			empty.Height = Math.Max(empty.Height, num);
			_cachedMinimumWidth += Math.Min(_cachedSizes[i].Width, TAB_MINWIDTH);
		}
		_cachedPreferredWidth = empty.Width;
		empty.Height = Math.Max(empty.Height, _ribbon.CalculatedValues.TabHeight);
		empty.Width = _cachedMinimumWidth;
		if (_tabsSpare != null && empty.Width < context.DisplayRectangle.Width)
		{
			empty.Width = context.DisplayRectangle.Width;
		}
		return empty;
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		SyncChildrenToRibbonTabs();
		ClientRectangle = context.DisplayRectangle;
		int num = ClientLocation.X;
		if (Count > 0)
		{
			Size[] array = AdjustSizesToFit();
			int y = ClientRectangle.Y;
			int bottom = ClientRectangle.Bottom;
			int clientHeight = ClientHeight;
			for (int i = 0; i < Count; i++)
			{
				if (array[i].Width > 0)
				{
					if (this[i] is ViewDrawRibbonTabSep)
					{
						ViewDrawRibbonTabSep viewDrawRibbonTabSep = this[i] as ViewDrawRibbonTabSep;
						viewDrawRibbonTabSep.Draw = _showSeparators;
						context.DisplayRectangle = new Rectangle(num, y, array[i].Width, clientHeight);
					}
					else if (this[i] is ViewDrawRibbonTab)
					{
						ViewDrawRibbonTab viewDrawRibbonTab = this[i] as ViewDrawRibbonTab;
						viewDrawRibbonTab.Checked = _ribbon.SelectedTab == viewDrawRibbonTab.RibbonTab;
						context.DisplayRectangle = new Rectangle(num, bottom - array[i].Height, array[i].Width, array[i].Height);
					}
					else if (this[i] is ViewDrawRibbonDesignTab)
					{
						context.DisplayRectangle = new Rectangle(num, bottom - array[i].Height, array[i].Width, array[i].Height);
					}
					this[i].Layout(context);
					num += array[i].Width;
				}
			}
		}
		Rectangle rectangle = Rectangle.Empty;
		if (_tabsSpare != null)
		{
			_tabsSpare.Visible = false;
			if (num < ClientRectangle.Right && _ribbon.GetRedirector().GetMetricBool(PaletteState.Normal, PaletteMetricBool.RibbonTabsSpareCaption) == InheritBool.True)
			{
				rectangle = (context.DisplayRectangle = new Rectangle(num, ClientRectangle.Y, ClientRectangle.Right - num, ClientHeight));
				_tabsSpare.Visible = true;
				_tabsSpare.Layout(context);
				num = ClientRectangle.Right;
			}
		}
		if (_ribbon.CaptionArea.KryptonForm != null)
		{
			if (!rectangle.IsEmpty)
			{
				rectangle = _parentControl.RectangleToScreen(rectangle);
				rectangle = _ribbon.CaptionArea.KryptonForm.RectangleToClient(rectangle);
			}
			_ribbon.CaptionArea.KryptonForm.CustomCaptionArea = rectangle;
		}
		ClientRectangle = new Rectangle(ClientLocation, new Size(num - ClientLocation.X, ClientHeight));
		context.DisplayRectangle = new Rectangle(ClientLocation, new Size(num - ClientLocation.X, ClientHeight));
	}

	private void SyncChildrenToRibbonTabs()
	{
		Clear();
		if (_tabCache.Count < _ribbon.RibbonTabs.Count)
		{
			for (int i = _tabCache.Count; i < _ribbon.RibbonTabs.Count; i++)
			{
				_tabCache.Add(new ViewDrawRibbonTab(_ribbon, this, _needPaint));
			}
		}
		if (_tabSepCache.Count < _ribbon.RibbonTabs.Count)
		{
			for (int j = _tabSepCache.Count; j < _ribbon.RibbonTabs.Count; j++)
			{
				_tabSepCache.Add(new ViewDrawRibbonTabSep(_ribbon.StateCommon.RibbonGeneral));
			}
		}
		UpdateContextNameCache();
		ContextTabSets.Clear();
		AddTabsWithContextName(string.Empty);
		foreach (string item in _cachedSelectedContext)
		{
			if (_ribbon.RibbonContexts[item] != null)
			{
				AddTabsWithContextName(item);
			}
		}
		if (_ribbon.InDesignHelperMode)
		{
			if (_viewAddTab == null)
			{
				_viewAddTab = new ViewDrawRibbonDesignTab(_ribbon, _needPaint);
			}
			Add(_viewAddTab);
		}
		else
		{
			if (_tabsSpare == null)
			{
				_tabsSpare = new ViewLayoutRibbonTabsSpare();
			}
			Add(_tabsSpare);
		}
	}

	private void AddTabsWithContextName(string contextName)
	{
		ContextTabSet contextTabSet = null;
		for (int i = 0; i < _ribbon.RibbonTabs.Count; i++)
		{
			KryptonRibbonTab tab = _ribbon.RibbonTabs[i];
			if (IsRibbonVisible(tab, contextName))
			{
				_tabCache[i].RibbonTab = null;
			}
		}
		for (int j = 0; j < _ribbon.RibbonTabs.Count; j++)
		{
			KryptonRibbonTab kryptonRibbonTab = _ribbon.RibbonTabs[j];
			if (!IsRibbonVisible(kryptonRibbonTab, contextName))
			{
				continue;
			}
			ViewDrawRibbonTab viewDrawRibbonTab = _tabCache[j];
			Add(viewDrawRibbonTab);
			Add(_tabSepCache[j]);
			viewDrawRibbonTab.RibbonTab = kryptonRibbonTab;
			if (!string.IsNullOrEmpty(contextName))
			{
				if (contextTabSet == null)
				{
					contextTabSet = new ContextTabSet(viewDrawRibbonTab, _ribbon.RibbonContexts[kryptonRibbonTab.ContextName]);
				}
				else
				{
					contextTabSet.UpdateLastTab(viewDrawRibbonTab);
				}
			}
		}
		if (contextTabSet != null)
		{
			ContextTabSets.Add(contextTabSet);
		}
	}

	private Size[] AdjustSizesToFit()
	{
		_showSeparators = false;
		Size[] array = new Size[_cachedSizes.Length];
		for (int i = 0; i < _cachedSizes.Length; i++)
		{
			array[i] = _cachedSizes[i];
		}
		if (_cachedPreferredWidth > ClientWidth)
		{
			if (_cachedMinimumWidth > ClientWidth)
			{
				for (int j = 0; j < array.Length; j++)
				{
					array[j].Width = Math.Min(array[j].Width, TAB_MINWIDTH);
				}
				_showSeparators = true;
			}
			else
			{
				int num = _cachedPreferredWidth;
				int num2 = Math.Min(num - ClientWidth, _cachedNonContextTabCount * TAB_EXCESS);
				int k = 0;
				int num3 = _cachedNonContextTabCount;
				for (; k < array.Length; k++)
				{
					if (num3 <= 0)
					{
						break;
					}
					if (array[k].Width > TAB_MINWIDTH)
					{
						int num4 = Math.Min(num2 / num3, TAB_EXCESS);
						array[k].Width -= num4;
						num2 -= num4;
						num -= num4;
						num3--;
					}
				}
				if (num > ClientWidth)
				{
					_showSeparators = true;
					do
					{
						int num5 = 0;
						int num6 = 0;
						for (int l = 0; l < array.Length; l++)
						{
							if (array[l].Width > TAB_MINWIDTH && array[l].Width > num5)
							{
								num6 = num5;
								num5 = array[l].Width;
							}
						}
						if (num5 <= TAB_MINWIDTH)
						{
							break;
						}
						List<int> list = new List<int>();
						for (int m = 0; m < array.Length; m++)
						{
							if (array[m].Width == num5)
							{
								list.Add(m);
							}
						}
						int val = (num5 - num6) * list.Count;
						num2 = Math.Min(val, num - ClientWidth);
						int num7 = 0;
						int num8 = list.Count;
						while (num7 < list.Count)
						{
							if (array[list[num7]].Width > TAB_MINWIDTH)
							{
								int num9 = Math.Min(num2 / num8, TAB_EXCESS);
								array[list[num7]].Width -= num9;
								num2 -= num9;
								num -= num9;
							}
							num7++;
							num8--;
						}
					}
					while (num > ClientWidth);
				}
			}
		}
		return array;
	}

	private void UpdateContextNameCache()
	{
		if (_cachedSelectedContext == null)
		{
			_cachedSelectedContext = new ContextNameList();
		}
		else
		{
			_cachedSelectedContext.Clear();
		}
		if (_ribbon.InDesignHelperMode)
		{
			foreach (KryptonRibbonContext ribbonContext in _ribbon.RibbonContexts)
			{
				_cachedSelectedContext.Add(ribbonContext.ContextName);
			}
			return;
		}
		if (string.IsNullOrEmpty(_ribbon.SelectedContext))
		{
			return;
		}
		string[] array = _ribbon.SelectedContext.Split(',');
		string[] array2 = array;
		foreach (string item in array2)
		{
			if (!_cachedSelectedContext.Contains(item))
			{
				_cachedSelectedContext.Add(item);
			}
		}
	}

	private bool IsRibbonVisible(KryptonRibbonTab tab, string contextName)
	{
		if (tab.Visible || _ribbon.InDesignHelperMode)
		{
			if (tab.ContextName.Equals(contextName))
			{
				return true;
			}
			if (_ribbon.InDesignHelperMode && !string.IsNullOrEmpty(tab.ContextName) && string.IsNullOrEmpty(contextName))
			{
				return _ribbon.RibbonContexts[tab.ContextName] == null;
			}
		}
		return false;
	}
}
