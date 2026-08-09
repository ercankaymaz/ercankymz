#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewLayoutRibbonGroups : ViewComposite
{
	private class GroupToView : Dictionary<KryptonRibbonGroup, ViewDrawRibbonGroup>
	{
	}

	private class ViewDrawRibbonGroupSepList : List<ViewLayoutRibbonSeparator>
	{
	}

	private static readonly int SEP_LENGTH_2007 = 2;

	private static readonly int SEP_LENGTH_2010 = 0;

	private KryptonRibbon _ribbon;

	private KryptonRibbonTab _ribbonTab;

	private NeedPaintHandler _needPaint;

	private ViewDrawRibbonDesignGroup _viewAddGroup;

	private GroupToView _groupToView;

	private ViewDrawRibbonGroupSepList _groupSepCache;

	private int[] _groupWidths;

	public NeedPaintHandler NeedPaintDelegate
	{
		set
		{
			_needPaint = value;
		}
	}

	private Size SeparatorSize
	{
		get
		{
			Size result = Size.Empty;
			if (_ribbon != null)
			{
				PaletteRibbonShape ribbonShape = _ribbon.RibbonShape;
				PaletteRibbonShape paletteRibbonShape = ribbonShape;
				result = ((paletteRibbonShape != PaletteRibbonShape.Office2007 && paletteRibbonShape == PaletteRibbonShape.Office2010) ? new Size(SEP_LENGTH_2010, SEP_LENGTH_2010) : new Size(SEP_LENGTH_2007, SEP_LENGTH_2007));
			}
			return result;
		}
	}

	public ViewLayoutRibbonGroups(KryptonRibbon ribbon, KryptonRibbonTab ribbonTab, NeedPaintHandler needPaint)
	{
		Debug.Assert(ribbon != null);
		Debug.Assert(ribbonTab != null);
		Debug.Assert(needPaint != null);
		_ribbon = ribbon;
		_ribbonTab = ribbonTab;
		_needPaint = needPaint;
		_groupToView = new GroupToView();
		_groupSepCache = new ViewDrawRibbonGroupSepList();
	}

	public override string ToString()
	{
		return "ViewLayoutRibbonGroups:" + base.Id;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			Clear();
			foreach (ViewDrawRibbonGroup value in _groupToView.Values)
			{
				value.Dispose();
			}
			foreach (ViewLayoutRibbonSeparator item in _groupSepCache)
			{
				item.Dispose();
			}
			_groupToView.Clear();
			_groupSepCache.Clear();
		}
		base.Dispose(disposing);
	}

	public ViewDrawRibbonGroup ViewGroupFromPoint(Point pt)
	{
		ViewLayoutControl viewLayoutControl = (ViewLayoutControl)base.Parent;
		Point location = viewLayoutControl.ChildControl.Location;
		pt.X -= location.X;
		pt.Y -= location.Y;
		using (IEnumerator<ViewBase> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				ViewBase current = enumerator.Current;
				if (current.Visible && current is ViewDrawRibbonGroup { ClientRectangle: var clientRectangle } viewDrawRibbonGroup && clientRectangle.Contains(pt))
				{
					return viewDrawRibbonGroup;
				}
			}
		}
		return null;
	}

	public KeyTipInfo[] GetGroupKeyTips()
	{
		KeyTipInfoList keyTipInfoList = new KeyTipInfoList();
		foreach (ViewDrawRibbonGroup value in _groupToView.Values)
		{
			if (value.Visible)
			{
				value.GetGroupKeyTips(keyTipInfoList);
			}
		}
		return keyTipInfoList.ToArray();
	}

	public ViewBase GetFirstFocusItem()
	{
		ViewBase viewBase = null;
		foreach (ViewDrawRibbonGroup value in _groupToView.Values)
		{
			viewBase = value.GetFirstFocusItem();
			if (viewBase != null)
			{
				break;
			}
		}
		return viewBase;
	}

	public ViewBase GetLastFocusItem()
	{
		ViewBase viewBase = null;
		ViewDrawRibbonGroup[] array = new ViewDrawRibbonGroup[_groupToView.Count];
		_groupToView.Values.CopyTo(array, 0);
		for (int num = array.Length - 1; num >= 0; num--)
		{
			viewBase = array[num].GetLastFocusItem();
			if (viewBase != null)
			{
				break;
			}
		}
		return viewBase;
	}

	public ViewBase GetNextFocusItem(ViewBase current)
	{
		ViewBase viewBase = null;
		bool matched = false;
		foreach (ViewDrawRibbonGroup value in _groupToView.Values)
		{
			viewBase = ((!matched) ? value.GetNextFocusItem(current, ref matched) : value.GetFirstFocusItem());
			if (viewBase != null)
			{
				break;
			}
		}
		return viewBase;
	}

	public ViewBase GetPreviousFocusItem(ViewBase current)
	{
		ViewBase viewBase = null;
		bool matched = false;
		ViewDrawRibbonGroup[] array = new ViewDrawRibbonGroup[_groupToView.Count];
		_groupToView.Values.CopyTo(array, 0);
		for (int num = array.Length - 1; num >= 0; num--)
		{
			viewBase = ((!matched) ? array[num].GetPreviousFocusItem(current, ref matched) : array[num].GetLastFocusItem());
			if (viewBase != null)
			{
				break;
			}
		}
		return viewBase;
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		SyncChildrenToRibbonGroups();
		return new Size(AdjustGroupStateToMatchSpace(context), _ribbon.CalculatedValues.GroupHeight);
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		ClientRectangle = context.DisplayRectangle;
		int num = ClientLocation.X;
		if (Count > 0)
		{
			int y = ClientLocation.Y;
			int clientHeight = ClientHeight;
			int i = 0;
			int num2 = 0;
			for (; i < Count; i++)
			{
				ViewBase viewBase = this[i];
				if (viewBase.Visible)
				{
					Size size = ((!(viewBase is ViewDrawRibbonGroup)) ? this[i].GetPreferredSize(context) : new Size(_groupWidths[num2++], _ribbon.CalculatedValues.GroupHeight));
					if (size.Width > 0)
					{
						context.DisplayRectangle = new Rectangle(num, y, size.Width, clientHeight);
						this[i].Layout(context);
						num += size.Width;
					}
				}
			}
		}
		ClientRectangle = new Rectangle(ClientLocation, new Size(num - ClientLocation.X, ClientHeight));
		context.DisplayRectangle = new Rectangle(ClientLocation, new Size(num - ClientLocation.X, ClientHeight));
	}

	private void SyncChildrenToRibbonGroups()
	{
		Clear();
		GroupToView groupToView = new GroupToView();
		foreach (KryptonRibbonGroup group in _ribbonTab.Groups)
		{
			ViewDrawRibbonGroup viewDrawRibbonGroup = null;
			if (_groupToView.ContainsKey(group))
			{
				viewDrawRibbonGroup = _groupToView[group];
			}
			if (viewDrawRibbonGroup == null)
			{
				viewDrawRibbonGroup = new ViewDrawRibbonGroup(_ribbon, group, _needPaint);
			}
			groupToView.Add(group, viewDrawRibbonGroup);
		}
		if (_groupSepCache.Count < _ribbonTab.Groups.Count)
		{
			for (int i = _groupSepCache.Count; i < _ribbonTab.Groups.Count; i++)
			{
				_groupSepCache.Add(new ViewLayoutRibbonSeparator(0, ignoreMouse: true));
			}
		}
		Size separatorSize = SeparatorSize;
		foreach (ViewLayoutRibbonSeparator item in _groupSepCache)
		{
			item.SeparatorSize = separatorSize;
		}
		bool flag = true;
		for (int j = 0; j < _ribbonTab.Groups.Count; j++)
		{
			KryptonRibbonGroup kryptonRibbonGroup = _ribbonTab.Groups[j];
			bool flag2 = _ribbon.InDesignHelperMode || kryptonRibbonGroup.Visible;
			_groupSepCache[j].Visible = flag2 && !flag;
			groupToView[kryptonRibbonGroup].Visible = flag2;
			if (flag2 && flag)
			{
				flag = false;
			}
			Add(_groupSepCache[j]);
			Add(groupToView[kryptonRibbonGroup]);
			if (_groupToView.ContainsKey(kryptonRibbonGroup))
			{
				_groupToView.Remove(kryptonRibbonGroup);
			}
		}
		if (_ribbon.InDesignHelperMode)
		{
			if (_viewAddGroup == null)
			{
				_viewAddGroup = new ViewDrawRibbonDesignGroup(_ribbon, _needPaint);
			}
			Add(_viewAddGroup);
		}
		foreach (ViewDrawRibbonGroup value in _groupToView.Values)
		{
			value.Dispose();
		}
		_groupToView = groupToView;
	}

	private int AdjustGroupStateToMatchSpace(ViewLayoutContext context)
	{
		List<GroupSizeWidth[]> list = new List<GroupSizeWidth[]>();
		List<IRibbonViewGroupSize> list2 = new List<IRibbonViewGroupSize>();
		int num = 0;
		int num2 = 0;
		using (IEnumerator<ViewBase> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				ViewBase current = enumerator.Current;
				if (current.Visible && current is IRibbonViewGroupSize)
				{
					IRibbonViewGroupSize ribbonViewGroupSize = (IRibbonViewGroupSize)current;
					GroupSizeWidth[] possibleSizes = ribbonViewGroupSize.GetPossibleSizes(context);
					num += SEP_LENGTH_2007;
					list.Add(possibleSizes);
					list2.Add(ribbonViewGroupSize);
					num2 = Math.Max(num2, possibleSizes.Length);
				}
			}
		}
		int num3 = 0;
		int width = context.DisplayRectangle.Width;
		int[] array = null;
		List<int> list3 = new List<int>();
		for (int i = 0; i < num2; i++)
		{
			for (int num4 = list.Count - 1; num4 >= 0; num4--)
			{
				if (list[num4].Length > i)
				{
					int num5 = num;
					list3.Clear();
					for (int num6 = list.Count - 1; num6 >= 0; num6--)
					{
						int val = i + ((num6 > num4) ? 1 : 0);
						val = Math.Min(val, list[num6].Length - 1);
						list3.Insert(0, val);
						int width2 = list[num6][val].Width;
						num5 += width2;
					}
					if (num5 > num3 && num5 <= width)
					{
						num3 = num5;
						array = list3.ToArray();
					}
				}
			}
		}
		if (num3 > 0)
		{
			_groupWidths = new int[list2.Count];
			for (int j = 0; j < list2.Count; j++)
			{
				_groupWidths[j] = list[j][array[j]].Width;
				list2[j].SetSolutionSize(list[j][array[j]].Sizing);
			}
		}
		else
		{
			_groupWidths = new int[list2.Count];
			for (int k = 0; k < list2.Count; k++)
			{
				_groupWidths[k] = list[k][list[k].Length - 1].Width;
				list2[k].SetSolutionSize(list[k][list[k].Length - 1].Sizing);
			}
		}
		return num3;
	}
}
