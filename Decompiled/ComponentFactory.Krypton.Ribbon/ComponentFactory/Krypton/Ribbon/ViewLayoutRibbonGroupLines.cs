#define DEBUG
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewLayoutRibbonGroupLines : ViewComposite, IRibbonViewGroupContainerView
{
	private class ItemToView : Dictionary<IRibbonGroupItem, ViewBase>
	{
	}

	private class ViewToItem : Dictionary<ViewBase, IRibbonGroupItem>
	{
	}

	private class ViewToGap : Dictionary<ViewBase, int>
	{
	}

	private class SizeList : List<Size>
	{
	}

	private class ViewList : List<ViewBase>
	{
	}

	private static readonly int DEFAULT_GAP = 2;

	private KryptonRibbon _ribbon;

	private KryptonRibbonGroupLines _ribbonLines;

	private ViewDrawRibbonDesignGroupLines _viewAddItem;

	private NeedPaintHandler _needPaint;

	private GroupItemSize _currentSize;

	private ItemToView _itemToView;

	private ViewToItem _viewToItem;

	private ViewToGap _viewToLargeGap;

	private ViewToGap _viewToMediumGap;

	private ViewToGap _viewToSmallGap;

	private ViewToGap _viewToGap;

	private SizeList _sizeLargeList;

	private SizeList _sizeMediumList;

	private SizeList _sizeSmallList;

	private SizeList _sizeList;

	private ViewList _viewLargeList;

	private ViewList _viewMediumList;

	private ViewList _viewSmallList;

	private ViewList _viewList;

	private int _split1Large;

	private int _split1Medium;

	private int _split1Small;

	private int _split2Small;

	public GroupItemSize CurrentSize
	{
		get
		{
			return _currentSize;
		}
		set
		{
			_currentSize = value;
			if (_viewAddItem != null)
			{
				_viewAddItem.CurrentSize = value;
			}
		}
	}

	public ViewLayoutRibbonGroupLines(KryptonRibbon ribbon, KryptonRibbonGroupLines ribbonLines, NeedPaintHandler needPaint)
	{
		Debug.Assert(ribbon != null);
		Debug.Assert(ribbonLines != null);
		Debug.Assert(needPaint != null);
		_ribbon = ribbon;
		_ribbonLines = ribbonLines;
		_needPaint = needPaint;
		Component = _ribbonLines;
		_itemToView = new ItemToView();
		_viewToItem = new ViewToItem();
		_sizeLargeList = new SizeList();
		_sizeMediumList = new SizeList();
		_sizeSmallList = new SizeList();
		_viewLargeList = new ViewList();
		_viewMediumList = new ViewList();
		_viewSmallList = new ViewList();
		_viewToLargeGap = new ViewToGap();
		_viewToMediumGap = new ViewToGap();
		_viewToSmallGap = new ViewToGap();
		ApplySize(ribbonLines.ItemSizeCurrent);
		_ribbonLines.PropertyChanged += OnLinesPropertyChanged;
		_ribbonLines.LinesView = this;
		if (_ribbon.InDesignMode)
		{
			ViewHightlightController viewHightlightController = new ViewHightlightController(this, needPaint);
			viewHightlightController.ContextClick += OnContextClick;
			MouseController = viewHightlightController;
		}
	}

	public override string ToString()
	{
		return "ViewLayoutRibbonGroupLines:" + base.Id;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			_ribbonLines.PropertyChanged -= OnLinesPropertyChanged;
		}
		base.Dispose(disposing);
	}

	public ViewBase GetFirstFocusItem()
	{
		ViewBase viewBase = null;
		using (IEnumerator<ViewBase> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				ViewBase current = enumerator.Current;
				if (!current.Visible)
				{
					continue;
				}
				if (current is IRibbonViewGroupContainerView)
				{
					IRibbonViewGroupContainerView ribbonViewGroupContainerView = (IRibbonViewGroupContainerView)current;
					viewBase = ribbonViewGroupContainerView.GetFirstFocusItem();
					if (viewBase != null)
					{
						break;
					}
				}
				else if (current is IRibbonViewGroupItemView)
				{
					IRibbonViewGroupItemView ribbonViewGroupItemView = (IRibbonViewGroupItemView)current;
					viewBase = ribbonViewGroupItemView.GetFirstFocusItem();
					if (viewBase != null)
					{
						break;
					}
				}
			}
		}
		return viewBase;
	}

	public ViewBase GetLastFocusItem()
	{
		ViewBase viewBase = null;
		foreach (ViewBase item in Reverse())
		{
			if (!item.Visible)
			{
				continue;
			}
			if (item is IRibbonViewGroupContainerView)
			{
				IRibbonViewGroupContainerView ribbonViewGroupContainerView = (IRibbonViewGroupContainerView)item;
				viewBase = ribbonViewGroupContainerView.GetLastFocusItem();
				if (viewBase != null)
				{
					break;
				}
			}
			else if (item is IRibbonViewGroupItemView)
			{
				IRibbonViewGroupItemView ribbonViewGroupItemView = (IRibbonViewGroupItemView)item;
				viewBase = ribbonViewGroupItemView.GetLastFocusItem();
				if (viewBase != null)
				{
					break;
				}
			}
		}
		return viewBase;
	}

	public ViewBase GetNextFocusItem(ViewBase current, ref bool matched)
	{
		ViewBase viewBase = null;
		using (IEnumerator<ViewBase> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				ViewBase current2 = enumerator.Current;
				if (!current2.Visible)
				{
					continue;
				}
				if (current2 is IRibbonViewGroupContainerView)
				{
					IRibbonViewGroupContainerView ribbonViewGroupContainerView = (IRibbonViewGroupContainerView)current2;
					viewBase = ((!matched) ? ribbonViewGroupContainerView.GetNextFocusItem(current, ref matched) : ribbonViewGroupContainerView.GetFirstFocusItem());
					if (viewBase != null)
					{
						break;
					}
				}
				else if (current2 is IRibbonViewGroupItemView)
				{
					IRibbonViewGroupItemView ribbonViewGroupItemView = (IRibbonViewGroupItemView)current2;
					viewBase = ((!matched) ? ribbonViewGroupItemView.GetNextFocusItem(current, ref matched) : ribbonViewGroupItemView.GetFirstFocusItem());
					if (viewBase != null)
					{
						break;
					}
				}
			}
		}
		return viewBase;
	}

	public ViewBase GetPreviousFocusItem(ViewBase current, ref bool matched)
	{
		ViewBase viewBase = null;
		foreach (ViewBase item in Reverse())
		{
			if (!item.Visible)
			{
				continue;
			}
			if (item is IRibbonViewGroupContainerView)
			{
				IRibbonViewGroupContainerView ribbonViewGroupContainerView = (IRibbonViewGroupContainerView)item;
				viewBase = ((!matched) ? ribbonViewGroupContainerView.GetPreviousFocusItem(current, ref matched) : ribbonViewGroupContainerView.GetLastFocusItem());
				if (viewBase != null)
				{
					break;
				}
			}
			else if (item is IRibbonViewGroupItemView)
			{
				IRibbonViewGroupItemView ribbonViewGroupItemView = (IRibbonViewGroupItemView)item;
				viewBase = ((!matched) ? ribbonViewGroupItemView.GetPreviousFocusItem(current, ref matched) : ribbonViewGroupItemView.GetLastFocusItem());
				if (viewBase != null)
				{
					break;
				}
			}
		}
		return viewBase;
	}

	public void GetGroupKeyTips(KeyTipInfoList keyTipList)
	{
		int num = 0;
		int lineHint = ((_currentSize == GroupItemSize.Small) ? 1 : 4);
		using IEnumerator<ViewBase> enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			ViewBase current = enumerator.Current;
			if (!current.Visible)
			{
				continue;
			}
			if (current is IRibbonViewGroupContainerView)
			{
				IRibbonViewGroupContainerView ribbonViewGroupContainerView = (IRibbonViewGroupContainerView)current;
				ribbonViewGroupContainerView.GetGroupKeyTips(keyTipList);
			}
			else if (current is IRibbonViewGroupItemView)
			{
				IRibbonViewGroupItemView ribbonViewGroupItemView = (IRibbonViewGroupItemView)current;
				ribbonViewGroupItemView.GetGroupKeyTips(keyTipList, lineHint);
				switch (_currentSize)
				{
				case GroupItemSize.Large:
					if (num == _split1Large)
					{
						lineHint = 5;
					}
					break;
				case GroupItemSize.Medium:
					if (num == _split1Medium)
					{
						lineHint = 5;
					}
					break;
				case GroupItemSize.Small:
					if (num == _split1Small)
					{
						lineHint = 2;
					}
					else if (num == _split2Small)
					{
						lineHint = 3;
					}
					break;
				}
			}
			num++;
		}
	}

	public ItemSizeWidth[] GetPossibleSizes(ViewLayoutContext context)
	{
		SyncChildrenToRibbonGroupItems();
		List<ItemSizeWidth> list = new List<ItemSizeWidth>();
		if (_ribbonLines.ItemSizeMaximum == GroupItemSize.Large)
		{
			ApplySize(GroupItemSize.Large);
			list.Add(new ItemSizeWidth(GroupItemSize.Large, GetPreferredSize(context).Width));
		}
		if (_ribbonLines.ItemSizeMaximum >= GroupItemSize.Medium && _ribbonLines.ItemSizeMinimum <= GroupItemSize.Medium)
		{
			ApplySize(GroupItemSize.Medium);
			ItemSizeWidth itemSizeWidth = new ItemSizeWidth(GroupItemSize.Medium, GetPreferredSize(context).Width);
			if (_ribbon.InDesignHelperMode)
			{
				if (list.Count == 0)
				{
					list.Add(itemSizeWidth);
				}
			}
			else if (list.Count == 0 || list[0].Width > itemSizeWidth.Width)
			{
				list.Add(itemSizeWidth);
			}
		}
		if (_ribbonLines.ItemSizeMinimum == GroupItemSize.Small)
		{
			ApplySize(GroupItemSize.Small);
			ItemSizeWidth itemSizeWidth2 = new ItemSizeWidth(GroupItemSize.Small, GetPreferredSize(context).Width);
			if (_ribbon.InDesignHelperMode)
			{
				if (list.Count == 0)
				{
					list.Add(itemSizeWidth2);
				}
			}
			else if (list.Count == 0 || list[list.Count - 1].Width > itemSizeWidth2.Width)
			{
				list.Add(itemSizeWidth2);
			}
		}
		ResetSize();
		return list.ToArray();
	}

	public void SetSolutionSize(ItemSizeWidth size)
	{
		_ribbonLines.ItemSizeCurrent = size.GroupItemSize;
		ApplySize(size.GroupItemSize);
	}

	public void ResetSolutionSize()
	{
		_ribbonLines.ItemSizeCurrent = _ribbonLines.ItemSizeMaximum;
		ApplySize(_ribbonLines.ItemSizeCurrent);
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		SyncChildrenToRibbonGroupItems();
		_sizeList.Clear();
		_viewList.Clear();
		_viewToGap.Clear();
		int num = 0;
		ViewBase viewBase = null;
		for (int i = 0; i < Count; i++)
		{
			ViewBase viewBase2 = this[i];
			if (!viewBase2.Visible)
			{
				continue;
			}
			if (viewBase2 is ViewLayoutRibbonGroupCluster)
			{
				ViewLayoutRibbonGroupCluster viewLayoutRibbonGroupCluster = (ViewLayoutRibbonGroupCluster)viewBase2;
				viewLayoutRibbonGroupCluster.StartSeparator = viewBase != null && !(viewBase is ViewLayoutRibbonGroupCluster);
				viewLayoutRibbonGroupCluster.EndSeparator = true;
			}
			if (viewBase != null)
			{
				if (_viewToItem.ContainsKey(viewBase2) && _viewToItem.ContainsKey(viewBase))
				{
					IRibbonGroupItem ribbonGroupItem = _viewToItem[viewBase2];
					IRibbonGroupItem previousItem = _viewToItem[viewBase];
					_viewToGap.Add(viewBase2, ribbonGroupItem.ItemGap(previousItem));
				}
				else
				{
					_viewToGap.Add(viewBase2, DEFAULT_GAP);
				}
			}
			Size preferredSize = viewBase2.GetPreferredSize(context);
			_sizeList.Add(preferredSize);
			_viewList.Add(viewBase2);
			num += preferredSize.Width;
			viewBase = viewBase2;
		}
		switch (_currentSize)
		{
		case GroupItemSize.Large:
			return LargeMediumPreferredSize(num, ref _split1Large);
		case GroupItemSize.Medium:
			return LargeMediumPreferredSize(num, ref _split1Medium);
		case GroupItemSize.Small:
			return SmallPreferredSize(num);
		default:
			Debug.Assert(condition: false);
			return Size.Empty;
		}
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		ClientRectangle = context.DisplayRectangle;
		if (Count > 0)
		{
			switch (_currentSize)
			{
			case GroupItemSize.Large:
				LargeMediumLayout(context, ref _split1Large);
				break;
			case GroupItemSize.Medium:
				LargeMediumLayout(context, ref _split1Medium);
				break;
			case GroupItemSize.Small:
				SmallLayout(context);
				break;
			default:
				Debug.Assert(condition: false);
				break;
			}
		}
		context.DisplayRectangle = ClientRectangle;
	}

	public override void RenderBefore(RenderContext context)
	{
		if (_ribbon.InDesignHelperMode)
		{
			DesignTimeDraw.DrawFlapArea(_ribbon, context, ClientRectangle, State);
		}
		base.RenderBefore(context);
	}

	protected virtual void OnNeedPaint(bool needLayout)
	{
		if (_needPaint != null)
		{
			_needPaint(this, new NeedLayoutEventArgs(needLayout));
			if (needLayout)
			{
				_ribbon.PerformLayout();
			}
		}
	}

	private void ApplySize(GroupItemSize size)
	{
		CurrentSize = size;
		GroupItemSize groupItemSize = GroupItemSize.Medium;
		switch (size)
		{
		case GroupItemSize.Large:
			_sizeList = _sizeLargeList;
			_viewList = _viewLargeList;
			_viewToGap = _viewToLargeGap;
			groupItemSize = GroupItemSize.Medium;
			break;
		case GroupItemSize.Medium:
			_sizeList = _sizeMediumList;
			_viewList = _viewMediumList;
			_viewToGap = _viewToMediumGap;
			groupItemSize = GroupItemSize.Small;
			break;
		case GroupItemSize.Small:
			_sizeList = _sizeSmallList;
			_viewList = _viewSmallList;
			_viewToGap = _viewToSmallGap;
			groupItemSize = GroupItemSize.Small;
			break;
		default:
			Debug.Assert(condition: false);
			break;
		}
		using IEnumerator<ViewBase> enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			ViewBase current = enumerator.Current;
			if (current is IRibbonViewGroupItemView ribbonViewGroupItemView)
			{
				ribbonViewGroupItemView.SetGroupItemSize(groupItemSize);
			}
		}
	}

	private void ResetSize()
	{
		using (IEnumerator<ViewBase> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				ViewBase current = enumerator.Current;
				if (current is IRibbonViewGroupItemView ribbonViewGroupItemView)
				{
					ribbonViewGroupItemView.ResetGroupItemSize();
				}
			}
		}
		CurrentSize = _ribbonLines.ItemSizeCurrent;
	}

	private void SyncChildrenToRibbonGroupItems()
	{
		Clear();
		ItemToView itemToView = new ItemToView();
		ViewToItem viewToItem = new ViewToItem();
		foreach (KryptonRibbonGroupItem item in _ribbonLines.Items)
		{
			ViewBase viewBase;
			if (_itemToView.ContainsKey(item))
			{
				viewBase = _itemToView[item];
				_itemToView.Remove(item);
			}
			else
			{
				viewBase = ((IRibbonGroupItem)item).CreateView(_ribbon, _needPaint);
			}
			viewBase.Visible = _ribbon.InDesignHelperMode || ((IRibbonGroupItem)item).Visible;
			itemToView.Add(item, viewBase);
			viewToItem.Add(viewBase, item);
			Add(viewBase);
		}
		if (_ribbon.InDesignHelperMode)
		{
			if (_viewAddItem == null)
			{
				_viewAddItem = new ViewDrawRibbonDesignGroupLines(_ribbon, _ribbonLines, _currentSize, _needPaint);
			}
			Add(_viewAddItem);
		}
		foreach (ViewBase value in _itemToView.Values)
		{
			value.Dispose();
		}
		_itemToView = itemToView;
		_viewToItem = viewToItem;
	}

	private Size LargeMediumPreferredSize(int totalWidth, ref int split1)
	{
		Size empty = Size.Empty;
		split1 = int.MaxValue;
		int num = 0;
		int num2 = 0;
		if (_sizeList.Count > 1)
		{
			int num3 = int.MaxValue;
			int num4 = totalWidth;
			int num5 = 0;
			for (int i = 0; i <= _sizeList.Count - 2; i++)
			{
				Size size = _sizeList[i];
				num5 += size.Width;
				num4 -= size.Width;
				int num6 = Math.Abs(num5 - num4);
				if (num6 < num3)
				{
					split1 = i;
					num3 = num6;
					num = num5;
					num2 = num4;
				}
			}
			if (split1 >= 0 && split1 < _sizeList.Count)
			{
				num += GetItemSpacingGap(0, split1);
				num2 += GetItemSpacingGap(split1 + 1, _sizeList.Count - 1);
			}
			empty.Width = Math.Max(num, num2);
		}
		else
		{
			empty.Width = totalWidth;
		}
		empty.Height = _ribbon.CalculatedValues.GroupTripleHeight;
		if (_ribbon.InDesignHelperMode)
		{
			empty.Width += DesignTimeDraw.FlapWidth + DesignTimeDraw.SepWidth;
		}
		return empty;
	}

	private Size SmallPreferredSize(int totalWidth)
	{
		Size empty = Size.Empty;
		_split1Small = int.MaxValue;
		_split2Small = int.MaxValue;
		switch (_sizeList.Count)
		{
		case 1:
			empty.Width = totalWidth;
			break;
		case 2:
			_split1Small = 0;
			empty.Width = Math.Max(_sizeList[0].Width, _sizeList[1].Width);
			break;
		case 3:
			_split1Small = 0;
			_split2Small = 1;
			empty.Width = Math.Max(_sizeList[0].Width, Math.Max(_sizeList[1].Width, _sizeList[2].Width));
			break;
		default:
		{
			int num = int.MaxValue;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			int num5 = totalWidth;
			int num6 = 0;
			for (int i = 0; i < _sizeList.Count - 2; i++)
			{
				Size size = _sizeList[i];
				num6 += size.Width;
				num5 -= size.Width;
				int num7 = num5;
				int num8 = 0;
				for (int j = i + 1; j < _sizeList.Count - 1; j++)
				{
					Size size2 = _sizeList[j];
					num8 += size2.Width;
					num7 -= size2.Width;
					int num9 = Math.Min(num6, Math.Min(num8, num7));
					int num10 = Math.Max(num6, Math.Max(num8, num7));
					int num11 = Math.Abs(num10 - num9);
					if (num11 < num)
					{
						_split1Small = i;
						_split2Small = j;
						num = num11;
						num2 = num6;
						num3 = num8;
						num4 = num7;
					}
				}
			}
			if (_split1Small >= 0 && _split1Small < _sizeList.Count && _split2Small >= 0 && _split2Small < _sizeList.Count)
			{
				num2 += GetItemSpacingGap(0, _split1Small);
				num3 += GetItemSpacingGap(_split1Small + 1, _split2Small);
				num4 += GetItemSpacingGap(_split2Small + 1, _sizeList.Count - 1);
			}
			empty.Width = Math.Max(num2, Math.Max(num3, num4));
			break;
		}
		}
		empty.Height = _ribbon.CalculatedValues.GroupTripleHeight;
		if (_ribbon.InDesignHelperMode)
		{
			empty.Width += DesignTimeDraw.FlapWidth + DesignTimeDraw.SepWidth;
		}
		return empty;
	}

	private void LargeMediumLayout(ViewLayoutContext context, ref int split1)
	{
		int num = ClientLocation.X;
		int num2 = ClientLocation.Y + _ribbon.CalculatedValues.GroupLineGapHeight;
		if (_ribbon.InDesignHelperMode)
		{
			num += DesignTimeDraw.FlapWidth;
		}
		ViewBase viewBase = null;
		int i = 0;
		int num3 = 0;
		for (; i < Count; i++)
		{
			ViewBase viewBase2 = this[i];
			if (!viewBase2.Visible)
			{
				continue;
			}
			if (viewBase2 is ViewLayoutRibbonGroupCluster)
			{
				ViewLayoutRibbonGroupCluster viewLayoutRibbonGroupCluster = (ViewLayoutRibbonGroupCluster)viewBase2;
				viewLayoutRibbonGroupCluster.StartSeparator = viewBase != null && !(viewBase is ViewLayoutRibbonGroupCluster);
				viewLayoutRibbonGroupCluster.EndSeparator = false;
			}
			if (viewBase != null && viewBase is ViewLayoutRibbonGroupCluster)
			{
				ViewLayoutRibbonGroupCluster viewLayoutRibbonGroupCluster2 = (ViewLayoutRibbonGroupCluster)viewBase;
				viewLayoutRibbonGroupCluster2.EndSeparator = true;
				context.DisplayRectangle = new Rectangle(viewBase.ClientLocation.X, viewBase.ClientLocation.Y, viewBase.ClientWidth, viewBase.ClientHeight);
				viewBase.Layout(context);
			}
			if (viewBase != null && _viewToGap.ContainsKey(viewBase2))
			{
				num += _viewToGap[viewBase2];
			}
			Size size = _sizeList[num3];
			context.DisplayRectangle = new Rectangle(num, num2, size.Width, size.Height);
			this[i].Layout(context);
			if (split1 == num3)
			{
				num = ClientLocation.X;
				if (_ribbon.InDesignHelperMode)
				{
					num += DesignTimeDraw.FlapWidth;
				}
				num2 += _ribbon.CalculatedValues.GroupLineHeight + _ribbon.CalculatedValues.GroupLineGapHeight;
				viewBase = null;
			}
			else
			{
				num += size.Width;
				viewBase = viewBase2;
			}
			num3++;
		}
	}

	private void SmallLayout(ViewLayoutContext context)
	{
		int num = ClientLocation.X;
		int num2 = ClientLocation.Y;
		if (_ribbon.InDesignHelperMode)
		{
			num += DesignTimeDraw.FlapWidth;
		}
		ViewBase viewBase = null;
		int i = 0;
		int num3 = 0;
		for (; i < Count; i++)
		{
			ViewBase viewBase2 = this[i];
			if (!viewBase2.Visible)
			{
				continue;
			}
			if (viewBase2 is ViewLayoutRibbonGroupCluster)
			{
				ViewLayoutRibbonGroupCluster viewLayoutRibbonGroupCluster = (ViewLayoutRibbonGroupCluster)viewBase2;
				viewLayoutRibbonGroupCluster.StartSeparator = viewBase != null && !(viewBase is ViewLayoutRibbonGroupCluster);
				viewLayoutRibbonGroupCluster.EndSeparator = false;
			}
			if (viewBase != null && viewBase is ViewLayoutRibbonGroupCluster)
			{
				ViewLayoutRibbonGroupCluster viewLayoutRibbonGroupCluster2 = (ViewLayoutRibbonGroupCluster)viewBase;
				viewLayoutRibbonGroupCluster2.EndSeparator = true;
				context.DisplayRectangle = new Rectangle(viewBase.ClientLocation.X, viewBase.ClientLocation.Y, viewBase.ClientWidth, viewBase.ClientHeight);
				viewBase.Layout(context);
			}
			if (viewBase != null && _viewToGap.ContainsKey(viewBase2))
			{
				num += _viewToGap[viewBase2];
			}
			Size size = _sizeList[num3];
			context.DisplayRectangle = new Rectangle(num, num2, size.Width, size.Height);
			this[i].Layout(context);
			if (_split1Small == num3 || _split2Small == num3)
			{
				num = ClientLocation.X;
				if (_ribbon.InDesignHelperMode)
				{
					num += DesignTimeDraw.FlapWidth;
				}
				num2 += _ribbon.CalculatedValues.GroupLineHeight;
				viewBase = null;
			}
			else
			{
				num += size.Width;
				viewBase = viewBase2;
			}
			num3++;
		}
	}

	private int GetItemSpacingGap(int start, int end)
	{
		int num = 0;
		for (int i = start + 1; i <= end; i++)
		{
			num += _viewToGap[_viewList[i]];
		}
		return num;
	}

	private void OnLinesPropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		bool flag = false;
		switch (e.PropertyName)
		{
		case "Visible":
			flag = true;
			break;
		case "ItemSizeMinimum":
		case "ItemSizeMaximum":
		case "ItemSizeCurrent":
			ApplySize(_ribbonLines.ItemSizeCurrent);
			flag = true;
			break;
		}
		if (flag && _ribbonLines.RibbonTab != null && _ribbon.SelectedTab == _ribbonLines.RibbonTab)
		{
			OnNeedPaint(needLayout: true);
		}
	}

	private void OnContextClick(object sender, MouseEventArgs e)
	{
		if (_ribbon.InDesignMode)
		{
			_ribbonLines.OnDesignTimeContextMenu(e);
		}
	}
}
