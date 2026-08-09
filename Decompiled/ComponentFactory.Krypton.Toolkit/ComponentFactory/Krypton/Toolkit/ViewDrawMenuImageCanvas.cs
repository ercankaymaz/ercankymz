#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

internal class ViewDrawMenuImageCanvas : ViewDrawCanvas, IContextMenuItemColumn
{
	private int _columnIndex;

	private Size _lastPreferredSize;

	private int _overridePreferredWidth;

	private bool _zeroHeight;

	public int ColumnIndex => _columnIndex;

	public Size LastPreferredSize => _lastPreferredSize;

	public int OverridePreferredWidth
	{
		set
		{
			_overridePreferredWidth = value;
		}
	}

	public ViewDrawMenuImageCanvas(IPaletteBack paletteBack, IPaletteBorder paletteBorder, int columnIndex, bool zeroHeight)
		: base(paletteBack, paletteBorder, VisualOrientation.Top)
	{
		_columnIndex = columnIndex;
		_overridePreferredWidth = 0;
		_zeroHeight = zeroHeight;
	}

	public override string ToString()
	{
		return "ViewDrawMenuCanvas:" + base.Id;
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		Size preferredSize = base.GetPreferredSize(context);
		if (_overridePreferredWidth != 0)
		{
			preferredSize.Width = _overridePreferredWidth;
		}
		else
		{
			_lastPreferredSize = base.GetPreferredSize(context);
		}
		if (_zeroHeight)
		{
			preferredSize.Height = 0;
		}
		return preferredSize;
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		base.Layout(context);
	}

	public override void RenderBefore(RenderContext context)
	{
		Debug.Assert(context != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		base.RenderBefore(context);
	}
}
