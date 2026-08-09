#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class ViewLayoutMenuItemsPile : ViewLayoutPile
{
	private class ColumnToWidth : Dictionary<int, int>
	{
	}

	private PaletteDoubleMetricRedirect _paletteItemHighlight;

	private ViewDrawMenuImageColumn _imageColumn;

	private ViewLayoutStack _itemStack;

	private ColumnToWidth _columnToWidth;

	public ViewLayoutStack ItemStack => _itemStack;

	public ViewLayoutMenuItemsPile(IContextMenuProvider provider, KryptonContextMenuItems items, bool standardStyle, bool imageColumn)
	{
		_paletteItemHighlight = provider.ProviderStateCommon.ItemHighlight;
		_imageColumn = new ViewDrawMenuImageColumn(items, provider.ProviderStateCommon.ItemImageColumn);
		ViewLayoutDocker viewLayoutDocker = new ViewLayoutDocker();
		viewLayoutDocker.Add(_imageColumn, ViewDockStyle.Left);
		viewLayoutDocker.Visible = imageColumn;
		_itemStack = new ViewLayoutStack(horizontal: false);
		_itemStack.FillLastChild = false;
		ViewLayoutDocker viewLayoutDocker2 = new ViewLayoutDocker { 
		{
			_itemStack,
			ViewDockStyle.Fill
		} };
		Padding metricPadding = _paletteItemHighlight.GetMetricPadding(PaletteState.Normal, PaletteMetricPadding.ContextMenuItemsCollection);
		viewLayoutDocker2.Add(new ViewLayoutSeparator(metricPadding.Left), ViewDockStyle.Left);
		viewLayoutDocker2.Add(new ViewLayoutSeparator(metricPadding.Right), ViewDockStyle.Right);
		viewLayoutDocker2.Add(new ViewLayoutSeparator(metricPadding.Top), ViewDockStyle.Top);
		viewLayoutDocker2.Add(new ViewLayoutSeparator(metricPadding.Bottom), ViewDockStyle.Bottom);
		Add(viewLayoutDocker);
		Add(viewLayoutDocker2);
	}

	public override string ToString()
	{
		return "ViewLayoutMenuItemsPile:" + base.Id;
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		_columnToWidth = new ColumnToWidth();
		ClearMenuItemColumns(this);
		base.GetPreferredSize(context);
		GatherMenuItemColumns(this);
		OverrideMenuItemColumns(this);
		UpdateImageColumnWidth(context.Renderer);
		return base.GetPreferredSize(context);
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		base.Layout(context);
	}

	private void GatherMenuItemColumns(ViewBase element)
	{
		if (element is IContextMenuItemColumn)
		{
			IContextMenuItemColumn contextMenuItemColumn = (IContextMenuItemColumn)element;
			int columnIndex = contextMenuItemColumn.ColumnIndex;
			Size lastPreferredSize = contextMenuItemColumn.LastPreferredSize;
			if (!_columnToWidth.ContainsKey(columnIndex))
			{
				_columnToWidth.Add(columnIndex, lastPreferredSize.Width);
			}
			else
			{
				int val = _columnToWidth[columnIndex];
				val = Math.Max(val, lastPreferredSize.Width);
				_columnToWidth[columnIndex] = val;
			}
		}
		foreach (ViewBase item in element)
		{
			GatherMenuItemColumns(item);
		}
	}

	private void OverrideMenuItemColumns(ViewBase element)
	{
		if (element is IContextMenuItemColumn)
		{
			IContextMenuItemColumn contextMenuItemColumn = (IContextMenuItemColumn)element;
			contextMenuItemColumn.OverridePreferredWidth = _columnToWidth[contextMenuItemColumn.ColumnIndex];
		}
		foreach (ViewBase item in element)
		{
			OverrideMenuItemColumns(item);
		}
	}

	private void ClearMenuItemColumns(ViewBase element)
	{
		if (element is IContextMenuItemColumn)
		{
			IContextMenuItemColumn contextMenuItemColumn = (IContextMenuItemColumn)element;
			contextMenuItemColumn.OverridePreferredWidth = 0;
		}
		foreach (ViewBase item in element)
		{
			ClearMenuItemColumns(item);
		}
	}

	private void UpdateImageColumnWidth(IRenderer renderer)
	{
		if (_columnToWidth.ContainsKey(0))
		{
			Padding borderDisplayPadding = renderer.RenderStandardBorder.GetBorderDisplayPadding(_paletteItemHighlight.Border, PaletteState.Normal, VisualOrientation.Top);
			int num = _columnToWidth[0];
			num += borderDisplayPadding.Left * 3;
			num += _paletteItemHighlight.GetMetricPadding(PaletteState.Normal, PaletteMetricPadding.ContextMenuItemHighlight).Left * 2;
			_imageColumn.ColumnWidth = num;
		}
	}
}
