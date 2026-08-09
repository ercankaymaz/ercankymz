#define DEBUG
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewLayoutRibbonGroupCluster : ViewComposite, IRibbonViewGroupItemView
{
	private class ItemToView : Dictionary<IRibbonGroupItem, ViewBase>
	{
	}

	private class ViewToEdge : Dictionary<ViewBase, ViewDrawRibbonGroupClusterEdge>
	{
	}

	private class ViewToSize : Dictionary<ViewBase, Size>
	{
	}

	private KryptonRibbon _ribbon;

	private KryptonRibbonGroupCluster _ribbonCluster;

	private ViewDrawRibbonDesignCluster _viewAddItem;

	private ViewDrawRibbonGroupClusterSeparator _startSep;

	private ViewDrawRibbonGroupClusterSeparator _endSep;

	private PaletteBorderEdge _paletteBorderEdge;

	private PaletteRibbonShape _lastShape;

	private NeedPaintHandler _needPaint;

	private ItemToView _itemToView;

	private ViewToEdge _viewToEdge;

	private ViewToSize _viewToSizeMedium;

	private ViewToSize _viewToSizeSmall;

	private GroupItemSize _currentSize;

	private bool _startSepVisible;

	private bool _endSepVisible;

	public bool StartSeparator
	{
		set
		{
			_startSepVisible = value;
		}
	}

	public bool EndSeparator
	{
		set
		{
			_endSepVisible = value;
		}
	}

	public ViewLayoutRibbonGroupCluster(KryptonRibbon ribbon, KryptonRibbonGroupCluster ribbonCluster, NeedPaintHandler needPaint)
	{
		Debug.Assert(ribbon != null);
		Debug.Assert(ribbonCluster != null);
		Debug.Assert(needPaint != null);
		_ribbon = ribbon;
		_ribbonCluster = ribbonCluster;
		_needPaint = needPaint;
		_currentSize = GroupItemSize.Medium;
		Component = _ribbonCluster;
		_startSep = new ViewDrawRibbonGroupClusterSeparator(_ribbon, start: true);
		_endSep = new ViewDrawRibbonGroupClusterSeparator(_ribbon, start: false);
		_startSepVisible = false;
		_endSepVisible = false;
		PaletteBorderEdgeRedirect inherit = new PaletteBorderEdgeRedirect(_ribbon.StateCommon.RibbonGroupClusterButton.Border, needPaint);
		_paletteBorderEdge = new PaletteBorderEdge(inherit, needPaint);
		_lastShape = PaletteRibbonShape.Office2007;
		_itemToView = new ItemToView();
		_viewToEdge = new ViewToEdge();
		_viewToSizeMedium = new ViewToSize();
		_viewToSizeSmall = new ViewToSize();
		_ribbonCluster.PropertyChanged += OnClusterPropertyChanged;
		_ribbonCluster.ClusterView = this;
		if (_ribbon.InDesignMode)
		{
			ViewHightlightController viewHightlightController = new ViewHightlightController(this, needPaint);
			viewHightlightController.ContextClick += OnContextClick;
			MouseController = viewHightlightController;
		}
	}

	public override string ToString()
	{
		return "ViewLayoutRibbonGroupCluster:" + base.Id;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			_ribbonCluster.PropertyChanged -= OnClusterPropertyChanged;
			_ribbonCluster.ClusterView = null;
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

	public void GetGroupKeyTips(KeyTipInfoList keyTipList, int lineHint)
	{
		using IEnumerator<ViewBase> enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			ViewBase current = enumerator.Current;
			if (current.Visible && current is IRibbonViewGroupItemView)
			{
				IRibbonViewGroupItemView ribbonViewGroupItemView = (IRibbonViewGroupItemView)current;
				ribbonViewGroupItemView.GetGroupKeyTips(keyTipList, lineHint);
			}
		}
	}

	public void SetGroupItemSize(GroupItemSize size)
	{
		SyncChildrenToRibbonGroupItems();
		foreach (KryptonRibbonGroupItem item in _ribbonCluster.Items)
		{
			IRibbonViewGroupItemView ribbonViewGroupItemView = _itemToView[item] as IRibbonViewGroupItemView;
			ribbonViewGroupItemView.SetGroupItemSize(size);
		}
		_currentSize = size;
	}

	public void ResetGroupItemSize()
	{
		foreach (KryptonRibbonGroupItem item in _ribbonCluster.Items)
		{
			IRibbonViewGroupItemView ribbonViewGroupItemView = _itemToView[item] as IRibbonViewGroupItemView;
			ribbonViewGroupItemView.ResetGroupItemSize();
		}
		ViewLayoutRibbonGroupLines viewLayoutRibbonGroupLines = (ViewLayoutRibbonGroupLines)base.Parent;
		_currentSize = ((viewLayoutRibbonGroupLines.CurrentSize != GroupItemSize.Small) ? GroupItemSize.Medium : GroupItemSize.Small);
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		SyncChildrenToRibbonGroupItems();
		ViewToSize viewToSize = ((_currentSize != GroupItemSize.Small) ? _viewToSizeMedium : _viewToSizeSmall);
		viewToSize.Clear();
		Size empty = Size.Empty;
		for (int i = 0; i < Count; i++)
		{
			ViewBase viewBase = this[i];
			if (viewBase.Visible)
			{
				Size preferredSize = viewBase.GetPreferredSize(context);
				viewToSize.Add(viewBase, preferredSize);
				empty.Width += preferredSize.Width;
				empty.Height = Math.Max(empty.Height, preferredSize.Height);
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
		_startSep.Visible = _startSepVisible && _lastShape == PaletteRibbonShape.Office2010;
		_endSep.Visible = _endSepVisible && _lastShape == PaletteRibbonShape.Office2010;
		if (Count > 0)
		{
			ViewToSize viewToSize = ((_currentSize != GroupItemSize.Small) ? _viewToSizeMedium : _viewToSizeSmall);
			int num = ClientLocation.X;
			int y = ClientLocation.Y;
			if (_ribbon.InDesignHelperMode)
			{
				num += DesignTimeDraw.FlapWidth;
			}
			for (int i = 0; i < Count; i++)
			{
				ViewBase viewBase = this[i];
				if (viewBase.Visible)
				{
					Size size = viewToSize[viewBase];
					context.DisplayRectangle = new Rectangle(num, y, size.Width, ClientHeight);
					this[i].Layout(context);
					num += size.Width;
				}
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

	private void SyncChildrenToRibbonGroupItems()
	{
		_lastShape = _ribbon.RibbonShape;
		bool flag = _lastShape != PaletteRibbonShape.Office2010;
		bool borderIgnoreNormal = _lastShape == PaletteRibbonShape.Office2010;
		bool constantBorder = _lastShape != PaletteRibbonShape.Office2010;
		bool drawNonTrackingAreas = _lastShape != PaletteRibbonShape.Office2010;
		Clear();
		Add(_startSep);
		ItemToView itemToView = new ItemToView();
		ViewToEdge viewToEdge = new ViewToEdge();
		ViewBase viewBase = null;
		ViewBase viewBase2 = null;
		foreach (KryptonRibbonGroupItem item in _ribbonCluster.Items)
		{
			ViewBase viewBase3;
			ViewDrawRibbonGroupClusterEdge viewDrawRibbonGroupClusterEdge;
			if (_itemToView.ContainsKey(item))
			{
				viewBase3 = _itemToView[item];
				viewDrawRibbonGroupClusterEdge = _viewToEdge[viewBase3];
				_itemToView.Remove(item);
				_viewToEdge.Remove(viewBase3);
			}
			else
			{
				viewBase3 = ((IRibbonGroupItem)item).CreateView(_ribbon, _needPaint);
				viewDrawRibbonGroupClusterEdge = new ViewDrawRibbonGroupClusterEdge(_ribbon, _paletteBorderEdge);
			}
			viewBase3.Visible = _ribbon.InDesignHelperMode || ((IRibbonGroupItem)item).Visible;
			viewDrawRibbonGroupClusterEdge.Visible = flag && (_ribbon.InDesignHelperMode || ((IRibbonGroupItem)item).Visible);
			itemToView.Add(item, viewBase3);
			viewToEdge.Add(viewBase3, viewDrawRibbonGroupClusterEdge);
			Add(viewBase3);
			Add(viewDrawRibbonGroupClusterEdge);
			if (viewBase3.Visible && viewBase == null)
			{
				viewBase = viewBase3;
			}
			if (viewBase3.Visible)
			{
				viewBase2 = viewBase3;
			}
		}
		foreach (ViewBase value in itemToView.Values)
		{
			if (!value.Visible || (!(value is ViewDrawRibbonGroupClusterButton) && !(value is ViewDrawRibbonGroupClusterColorButton)))
			{
				continue;
			}
			PaletteDrawBorders paletteDrawBorders = PaletteDrawBorders.TopBottom;
			PaletteRibbonShape lastShape = _lastShape;
			PaletteRibbonShape paletteRibbonShape = lastShape;
			if (paletteRibbonShape == PaletteRibbonShape.Office2007 || paletteRibbonShape != PaletteRibbonShape.Office2010)
			{
				paletteDrawBorders = PaletteDrawBorders.TopBottom;
				if (value == viewBase)
				{
					paletteDrawBorders = ((value != viewBase2) ? PaletteDrawBorders.TopBottomLeft : PaletteDrawBorders.All);
				}
				else if (value == viewBase2)
				{
					paletteDrawBorders = PaletteDrawBorders.TopBottomRight;
				}
			}
			else
			{
				paletteDrawBorders = PaletteDrawBorders.All;
			}
			if (value == viewBase2)
			{
				Remove(viewToEdge[value]);
			}
			ViewDrawRibbonGroupClusterButton viewDrawRibbonGroupClusterButton = value as ViewDrawRibbonGroupClusterButton;
			ViewDrawRibbonGroupClusterColorButton viewDrawRibbonGroupClusterColorButton = value as ViewDrawRibbonGroupClusterColorButton;
			if (viewDrawRibbonGroupClusterButton != null)
			{
				viewDrawRibbonGroupClusterButton.MaxBorderEdges = paletteDrawBorders;
				viewDrawRibbonGroupClusterButton.BorderIgnoreNormal = borderIgnoreNormal;
				viewDrawRibbonGroupClusterButton.ConstantBorder = constantBorder;
				viewDrawRibbonGroupClusterButton.DrawNonTrackingAreas = drawNonTrackingAreas;
			}
			if (viewDrawRibbonGroupClusterColorButton != null)
			{
				viewDrawRibbonGroupClusterColorButton.MaxBorderEdges = paletteDrawBorders;
				viewDrawRibbonGroupClusterColorButton.BorderIgnoreNormal = borderIgnoreNormal;
				viewDrawRibbonGroupClusterColorButton.ConstantBorder = constantBorder;
				viewDrawRibbonGroupClusterColorButton.DrawNonTrackingAreas = drawNonTrackingAreas;
			}
		}
		foreach (ViewBase value2 in _itemToView.Values)
		{
			value2.Dispose();
		}
		foreach (ViewDrawRibbonGroupClusterEdge value3 in _viewToEdge.Values)
		{
			value3.Dispose();
		}
		Add(_endSep);
		_startSep.Visible = _lastShape == PaletteRibbonShape.Office2010;
		_endSep.Visible = _lastShape == PaletteRibbonShape.Office2010;
		if (_ribbon.InDesignHelperMode)
		{
			if (_viewAddItem == null)
			{
				_viewAddItem = new ViewDrawRibbonDesignCluster(_ribbon, _ribbonCluster, _needPaint);
			}
			Add(_viewAddItem);
		}
		_itemToView = itemToView;
		_viewToEdge = viewToEdge;
	}

	private void OnClusterPropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		bool flag = false;
		string propertyName = e.PropertyName;
		string text = propertyName;
		if (text == "Visible")
		{
			flag = true;
		}
		if (flag && _ribbonCluster.RibbonTab != null && _ribbon.SelectedTab == _ribbonCluster.RibbonTab)
		{
			OnNeedPaint(needLayout: true);
		}
	}

	private void OnContextClick(object sender, MouseEventArgs e)
	{
		if (_ribbon.InDesignMode)
		{
			_ribbonCluster.OnDesignTimeContextMenu(e);
		}
	}
}
