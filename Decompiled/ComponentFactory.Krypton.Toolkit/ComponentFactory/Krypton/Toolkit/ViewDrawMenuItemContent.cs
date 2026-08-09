#define DEBUG
using System.Diagnostics;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

internal class ViewDrawMenuItemContent : ViewDrawContent, IContextMenuItemColumn
{
	private int _columnIndex;

	private Size _lastPreferredSize;

	private int _overridePreferredWidth;

	public int ColumnIndex => _columnIndex;

	public Size LastPreferredSize => _lastPreferredSize;

	public int OverridePreferredWidth
	{
		set
		{
			_overridePreferredWidth = value;
		}
	}

	public ViewDrawMenuItemContent(IPaletteContent palette, IContentValues values, int columnIndex)
		: base(palette, values, VisualOrientation.Top)
	{
		_columnIndex = columnIndex;
		_overridePreferredWidth = 0;
	}

	public override string ToString()
	{
		return "ViewDrawMenuItemContent:" + base.Id;
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
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
		return preferredSize;
	}
}
