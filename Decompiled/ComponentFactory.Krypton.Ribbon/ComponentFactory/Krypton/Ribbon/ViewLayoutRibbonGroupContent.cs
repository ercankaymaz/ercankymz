#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewLayoutRibbonGroupContent : ViewComposite, IRibbonViewGroupSize
{
	private class ContainerToView : Dictionary<IRibbonGroupContainer, ViewBase>
	{
	}

	private static readonly int EMPTY_WIDTH = 48;

	private static readonly Padding _padding = new Padding(1, 0, 1, 1);

	private KryptonRibbon _ribbon;

	private KryptonRibbonGroup _ribbonGroup;

	private ViewDrawRibbonDesignGroupContainer _viewAddContainer;

	private ViewLayoutRibbonGroupButton _dialogView;

	private NeedPaintHandler _needPaint;

	private ContainerToView _containerToView;

	private List<ItemSizeWidth[]> _listWidths;

	private int[] _containerWidths;

	public ViewLayoutRibbonGroupButton DialogView
	{
		get
		{
			return _dialogView;
		}
		set
		{
			_dialogView = value;
		}
	}

	public ViewLayoutRibbonGroupContent(KryptonRibbon ribbon, KryptonRibbonGroup ribbonGroup, NeedPaintHandler needPaint)
	{
		Debug.Assert(ribbon != null);
		Debug.Assert(ribbonGroup != null);
		Debug.Assert(needPaint != null);
		_ribbon = ribbon;
		_ribbonGroup = ribbonGroup;
		_needPaint = needPaint;
		_containerToView = new ContainerToView();
	}

	public override string ToString()
	{
		return "ViewLayoutRibbonGroupContent:" + base.Id;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
		}
		base.Dispose(disposing);
	}

	public void GetGroupKeyTips(KeyTipInfoList keyTipList)
	{
		using IEnumerator<ViewBase> enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			ViewBase current = enumerator.Current;
			if (current.Visible && current is IRibbonViewGroupContainerView)
			{
				IRibbonViewGroupContainerView ribbonViewGroupContainerView = (IRibbonViewGroupContainerView)current;
				ribbonViewGroupContainerView.GetGroupKeyTips(keyTipList);
			}
		}
	}

	public ViewBase GetFirstFocusItem()
	{
		ViewBase viewBase = null;
		using (IEnumerator<ViewBase> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				ViewBase current = enumerator.Current;
				if (current.Visible && current is IRibbonViewGroupContainerView)
				{
					IRibbonViewGroupContainerView ribbonViewGroupContainerView = (IRibbonViewGroupContainerView)current;
					viewBase = ribbonViewGroupContainerView.GetFirstFocusItem();
					if (viewBase != null)
					{
						break;
					}
				}
			}
		}
		if (viewBase == null && _ribbonGroup.Visible)
		{
			viewBase = DialogView.GetFocusView();
		}
		return viewBase;
	}

	public ViewBase GetLastFocusItem()
	{
		ViewBase viewBase = null;
		if (_ribbonGroup.Visible)
		{
			viewBase = DialogView.GetFocusView();
			if (viewBase == null)
			{
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
		if (viewBase == null)
		{
			if (matched)
			{
				if (_ribbonGroup.Visible)
				{
					viewBase = DialogView.GetFocusView();
				}
			}
			else
			{
				matched = DialogView.GetFocusView() == current;
			}
		}
		return viewBase;
	}

	public ViewBase GetPreviousFocusItem(ViewBase current, ref bool matched)
	{
		ViewBase viewBase = null;
		if (matched)
		{
			if (_ribbonGroup.Visible)
			{
				viewBase = DialogView.GetFocusView();
			}
		}
		else
		{
			matched = DialogView.GetFocusView() == current;
		}
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

	public GroupSizeWidth[] GetPossibleSizes(ViewLayoutContext context)
	{
		SyncChildrenToRibbonGroupItems();
		_listWidths = new List<ItemSizeWidth[]>();
		int num = 0;
		int val = 0;
		for (int i = 0; i < Count; i++)
		{
			if (this[i].Visible && this[i] is IRibbonViewGroupContainerView)
			{
				IRibbonViewGroupContainerView ribbonViewGroupContainerView = (IRibbonViewGroupContainerView)this[i];
				ItemSizeWidth[] possibleSizes = ribbonViewGroupContainerView.GetPossibleSizes(context);
				if (_listWidths.Count > 0)
				{
					num++;
				}
				_listWidths.Add(possibleSizes);
				val = Math.Max(val, possibleSizes.Length);
			}
		}
		List<GroupSizeWidth> list = new List<GroupSizeWidth>();
		int[] array = new int[_listWidths.Count];
		List<int> list2 = new List<int>();
		List<ItemSizeWidth> list3 = new List<ItemSizeWidth>();
		int num2 = _listWidths.Count - 1;
		int num3 = num2;
		bool flag = false;
		bool flag2 = true;
		do
		{
			int num4 = num;
			list2.Clear();
			list3.Clear();
			for (int num5 = _listWidths.Count - 1; num5 >= 0; num5--)
			{
				ItemSizeWidth itemSizeWidth = _listWidths[num5][array[num5]];
				num4 += itemSizeWidth.Width;
				list2.Insert(0, itemSizeWidth.Width);
				list3.Insert(0, itemSizeWidth);
			}
			if (list.Count == 0 || list[list.Count - 1].Width != num4)
			{
				list.Add(new GroupSizeWidth(num4, list3.ToArray()));
			}
			flag = false;
			if (flag2)
			{
				for (int j = 0; j <= num2; j++)
				{
					if (_listWidths[num3].Length > array[num3] + 1 && _listWidths[num3][array[num3]].Tag >= 0)
					{
						array[num3]++;
						flag = true;
					}
					num3--;
					if (num3 < 0)
					{
						num3 = num2;
					}
					if (flag)
					{
						break;
					}
				}
				if (!flag)
				{
					flag2 = false;
				}
			}
			if (flag)
			{
				continue;
			}
			for (int k = 0; k <= num2; k++)
			{
				if (_listWidths[num3].Length > array[num3] + 1)
				{
					array[num3]++;
					flag = true;
				}
				num3--;
				if (num3 < 0)
				{
					num3 = num2;
				}
				if (flag)
				{
					break;
				}
			}
		}
		while (flag);
		if (list.Count == 0)
		{
			list.Add(new GroupSizeWidth(EMPTY_WIDTH, new ItemSizeWidth[0]));
		}
		if (_ribbon.InDesignHelperMode)
		{
			int width = _viewAddContainer.GetPreferredSize(context).Width;
			foreach (GroupSizeWidth item in list)
			{
				item.Width += width;
			}
		}
		return list.ToArray();
	}

	public void SetSolutionSize(ItemSizeWidth[] size)
	{
		if (size == null || size.Length == 0)
		{
			for (int i = 0; i < Count; i++)
			{
				if (this[i].Visible && this[i] is IRibbonViewGroupContainerView)
				{
					IRibbonViewGroupContainerView ribbonViewGroupContainerView = (IRibbonViewGroupContainerView)this[i];
					ribbonViewGroupContainerView.ResetSolutionSize();
				}
			}
			_containerWidths = null;
			return;
		}
		_containerWidths = new int[size.Length];
		int j = 0;
		int num = 0;
		for (; j < Count; j++)
		{
			if (this[j].Visible && this[j] is IRibbonViewGroupContainerView)
			{
				_containerWidths[num] = size[num].Width;
				IRibbonViewGroupContainerView ribbonViewGroupContainerView2 = (IRibbonViewGroupContainerView)this[j];
				ribbonViewGroupContainerView2.SetSolutionSize(size[num++]);
			}
		}
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		SyncChildrenToRibbonGroupItems();
		Size empty = Size.Empty;
		int i = 0;
		int num = 0;
		for (; i < Count; i++)
		{
			ViewBase viewBase = this[i];
			if (!viewBase.Visible)
			{
				continue;
			}
			Size size = ((_containerWidths == null || !(viewBase is IRibbonViewGroupContainerView)) ? viewBase.GetPreferredSize(context) : new Size(_containerWidths[num++], _ribbon.CalculatedValues.GroupTripleHeight));
			if (size.Width > 0)
			{
				if (empty.Width > 0)
				{
					empty.Width++;
				}
				empty.Width += size.Width;
				empty.Height = Math.Max(empty.Height, size.Height);
			}
		}
		return CommonHelper.ApplyPadding(Orientation.Horizontal, empty, _padding);
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		ClientRectangle = CommonHelper.ApplyPadding(Orientation.Horizontal, context.DisplayRectangle, _padding);
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
					Size size = ((_containerWidths == null || !(viewBase is IRibbonViewGroupContainerView)) ? viewBase.GetPreferredSize(context) : new Size(_containerWidths[num2++], _ribbon.CalculatedValues.GroupTripleHeight));
					if (size.Width > 0)
					{
						context.DisplayRectangle = new Rectangle(num, y, size.Width, clientHeight);
						this[i].Layout(context);
						num += size.Width + 1;
					}
				}
			}
		}
		context.DisplayRectangle = ClientRectangle;
	}

	private void SyncChildrenToRibbonGroupItems()
	{
		Clear();
		ContainerToView containerToView = new ContainerToView();
		foreach (KryptonRibbonGroupContainer item in _ribbonGroup.Items)
		{
			ViewBase viewBase = ((!_containerToView.ContainsKey(item)) ? item.CreateView(_ribbon, _needPaint) : _containerToView[item]);
			viewBase.Visible = item.Visible || _ribbon.InDesignHelperMode;
			containerToView.Add(item, viewBase);
			Add(viewBase);
		}
		if (_ribbon.InDesignHelperMode)
		{
			if (_viewAddContainer == null)
			{
				_viewAddContainer = new ViewDrawRibbonDesignGroupContainer(_ribbon, _ribbonGroup, _needPaint);
			}
			Add(_viewAddContainer);
		}
		_containerToView = containerToView;
	}
}
