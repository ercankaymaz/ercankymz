#define DEBUG
using System.Diagnostics;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

internal class ViewDrawMenuImageColumn : ViewDrawDocker
{
	private ViewLayoutSeparator _separator;

	public int ColumnWidth
	{
		set
		{
			_separator.SeparatorSize = new Size(value, 0);
		}
	}

	public ViewDrawMenuImageColumn(KryptonContextMenuItems items, PaletteDoubleRedirect palette)
		: base(items.StateNormal.Back, items.StateNormal.Border)
	{
		items.SetPaletteRedirect(palette);
		_separator = new ViewLayoutSeparator(0);
		Add(_separator);
	}

	public override string ToString()
	{
		return "ViewDrawMenuImageColumn:" + base.Id;
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		ClientRectangle = context.DisplayRectangle;
		base.Layout(context);
	}
}
