#define DEBUG
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewLayoutRibbonGroupTriple : ViewComposite, IRibbonViewGroupContainerView
{
	private class ItemToView : Dictionary<IRibbonGroupItem, ViewBase>
	{
	}

	private class ViewToSize : Dictionary<ViewBase, Size>
	{
	}

	private KryptonRibbon _ribbon;

	private KryptonRibbonGroupTriple _ribbonTriple;

	private ViewDrawRibbonDesignGroupTriple _viewAddItem;

	private NeedPaintHandler _needPaint;

	private GroupItemSize _currentSize;

	private ItemToView _itemToView;

	private ViewToSize _smallCache;

	private ViewToSize _mediumCache;

	private ViewToSize _largeCache;

	private int _smallWidest;

	private int _mediumWidest;

	public ViewLayoutRibbonGroupTriple(KryptonRibbon ribbon, KryptonRibbonGroupTriple ribbonTriple, NeedPaintHandler needPaint)
	{
		Debug.Assert(ribbon != null);
		Debug.Assert(ribbonTriple != null);
		Debug.Assert(needPaint != null);
		_ribbon = ribbon;
		_ribbonTriple = ribbonTriple;
		_needPaint = needPaint;
		Component = _ribbonTriple;
		_itemToView = new ItemToView();
		_smallCache = new ViewToSize();
		_mediumCache = new ViewToSize();
		_largeCache = new ViewToSize();
		SetCurrentSize(ribbonTriple.ItemSizeCurrent);
		_ribbonTriple.PropertyChanged += OnTriplePropertyChanged;
		_ribbonTriple.TripleView = this;
		if (_ribbon.InDesignMode)
		{
			ViewHightlightController viewHightlightController = new ViewHightlightController(this, needPaint);
			viewHightlightController.ContextClick += OnContextClick;
			MouseController = viewHightlightController;
		}
	}

	public override string ToString()
	{
		return "ViewLayoutRibbonGroupTriple:" + base.Id;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			_ribbonTriple.PropertyChanged -= OnTriplePropertyChanged;
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
				if (current.Visible && current is IRibbonViewGroupItemView)
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
			if (item.Visible && item is IRibbonViewGroupItemView)
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
				if (current2.Visible && current2 is IRibbonViewGroupItemView)
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
			if (item.Visible && item is IRibbonViewGroupItemView)
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
		using IEnumerator<ViewBase> enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			ViewBase current = enumerator.Current;
			if (current.Visible && current is IRibbonViewGroupItemView)
			{
				IRibbonViewGroupItemView ribbonViewGroupItemView = (IRibbonViewGroupItemView)current;
				ribbonViewGroupItemView.GetGroupKeyTips(keyTipList, IndexOf(current) + 1);
			}
		}
	}

	public ItemSizeWidth[] GetPossibleSizes(ViewLayoutContext context)
	{
		SyncChildrenToRibbonGroupItems();
		List<ItemSizeWidth> list = new List<ItemSizeWidth>();
		if (_ribbonTriple.ItemSizeMaximum == GroupItemSize.Large)
		{
			ApplySize(GroupItemSize.Large);
			list.Add(new ItemSizeWidth(GroupItemSize.Large, GetPreferredSize(context).Width));
		}
		if (_ribbonTriple.ItemSizeMaximum >= GroupItemSize.Medium && _ribbonTriple.ItemSizeMinimum <= GroupItemSize.Medium)
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
		if (_ribbonTriple.ItemSizeMinimum == GroupItemSize.Small)
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
		_ribbonTriple.ItemSizeCurrent = size.GroupItemSize;
	}

	public void ResetSolutionSize()
	{
		_ribbonTriple.ItemSizeCurrent = _ribbonTriple.ItemSizeMaximum;
		ApplySize(_ribbonTriple.ItemSizeCurrent);
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		switch (_currentSize)
		{
		case GroupItemSize.Small:
			_smallCache.Clear();
			_smallWidest = 0;
			break;
		case GroupItemSize.Medium:
			_mediumCache.Clear();
			_mediumWidest = 0;
			break;
		case GroupItemSize.Large:
			_largeCache.Clear();
			break;
		}
		SyncChildrenToRibbonGroupItems();
		Size empty = Size.Empty;
		bool flag = _currentSize == GroupItemSize.Large;
		for (int i = 0; i < Count; i++)
		{
			ViewBase viewBase = this[i];
			if (!viewBase.Visible)
			{
				continue;
			}
			Size preferredSize = viewBase.GetPreferredSize(context);
			switch (_currentSize)
			{
			case GroupItemSize.Small:
				_smallCache.Add(viewBase, preferredSize);
				_smallWidest = Math.Max(_smallWidest, preferredSize.Width);
				break;
			case GroupItemSize.Medium:
				_mediumCache.Add(viewBase, preferredSize);
				_mediumWidest = Math.Max(_mediumWidest, preferredSize.Width);
				break;
			case GroupItemSize.Large:
				_largeCache.Add(viewBase, preferredSize);
				break;
			}
			if (flag)
			{
				if (empty.Width > 0)
				{
					empty.Width++;
				}
				empty.Width += preferredSize.Width;
				empty.Height = Math.Max(empty.Height, preferredSize.Height);
			}
			else
			{
				empty.Height += preferredSize.Height;
				empty.Width = Math.Max(empty.Width, preferredSize.Width);
			}
		}
		if (_ribbon.InDesignHelperMode)
		{
			empty.Width += DesignTimeDraw.FlapWidth + DesignTimeDraw.SepWidth;
		}
		return empty;
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		ClientRectangle = context.DisplayRectangle;
		bool flag = _currentSize == GroupItemSize.Large;
		int num = ((_currentSize == GroupItemSize.Small) ? _smallWidest : _mediumWidest);
		if (Count > 0)
		{
			int num2 = ClientLocation.X;
			int num3 = ClientLocation.Y;
			if (_ribbon.InDesignHelperMode)
			{
				num2 += DesignTimeDraw.FlapWidth;
			}
			int num4 = ClientRectangle.Right - num2;
			for (int i = 0; i < Count; i++)
			{
				ViewBase viewBase = this[i];
				if (!viewBase.Visible)
				{
					continue;
				}
				Size size = Size.Empty;
				switch (_currentSize)
				{
				case GroupItemSize.Small:
					size = _smallCache[viewBase];
					break;
				case GroupItemSize.Medium:
					size = _mediumCache[viewBase];
					break;
				case GroupItemSize.Large:
					size = _largeCache[viewBase];
					break;
				}
				if (flag)
				{
					context.DisplayRectangle = new Rectangle(num2, num3, size.Width, ClientHeight);
					this[i].Layout(context);
					num2 += size.Width + 1;
					continue;
				}
				switch (_ribbonTriple.ItemAlignment)
				{
				case RibbonItemAlignment.Near:
					context.DisplayRectangle = new Rectangle(num2, num3, size.Width, size.Height);
					break;
				case RibbonItemAlignment.Center:
					context.DisplayRectangle = new Rectangle(num2 + (num - size.Width) / 2, num3, size.Width, size.Height);
					break;
				case RibbonItemAlignment.Far:
					context.DisplayRectangle = new Rectangle(num2 + num - size.Width, num3, size.Width, size.Height);
					break;
				}
				this[i].Layout(context);
				num3 += size.Height;
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
		using (IEnumerator<ViewBase> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				ViewBase current = enumerator.Current;
				if (current is IRibbonViewGroupItemView ribbonViewGroupItemView)
				{
					ribbonViewGroupItemView.SetGroupItemSize(size);
				}
			}
		}
		SetCurrentSize(size);
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
		SetCurrentSize(_ribbonTriple.ItemSizeCurrent);
	}

	private void SetCurrentSize(GroupItemSize size)
	{
		_currentSize = size;
		if (_viewAddItem != null)
		{
			_viewAddItem.CurrentSize = size;
		}
	}

	private void SyncChildrenToRibbonGroupItems()
	{
		Clear();
		ItemToView itemToView = new ItemToView();
		foreach (KryptonRibbonGroupItem item in _ribbonTriple.Items)
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
			Add(viewBase);
		}
		if (_ribbon.InDesignHelperMode && Count < 3)
		{
			if (_viewAddItem == null)
			{
				_viewAddItem = new ViewDrawRibbonDesignGroupTriple(_ribbon, _ribbonTriple, _currentSize, _needPaint);
			}
			Add(_viewAddItem);
		}
		foreach (ViewBase value in _itemToView.Values)
		{
			value.Dispose();
		}
		_itemToView = itemToView;
	}

	private void OnTriplePropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		bool flag = false;
		switch (e.PropertyName)
		{
		case "Visible":
		case "ItemAlignment":
			flag = true;
			break;
		case "ItemSizeMinimum":
		case "ItemSizeMaximum":
		case "ItemSizeCurrent":
			SetCurrentSize(_ribbonTriple.ItemSizeCurrent);
			flag = true;
			break;
		}
		if (flag && _ribbonTriple.RibbonTab != null && _ribbon.SelectedTab == _ribbonTriple.RibbonTab)
		{
			OnNeedPaint(needLayout: true);
		}
	}

	private void OnContextClick(object sender, MouseEventArgs e)
	{
		if (_ribbon.InDesignMode)
		{
			_ribbonTriple.OnDesignTimeContextMenu(e);
		}
	}
}
