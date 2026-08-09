#define DEBUG
using System.Diagnostics;
using System.Drawing;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewDrawRibbonMinimizeBar : ViewLayoutRibbonSeparator
{
	private static readonly int SEP_WIDTH = 2;

	private IPaletteRibbonGeneral _palette;

	public ViewDrawRibbonMinimizeBar(IPaletteRibbonGeneral palette)
		: base(SEP_WIDTH, ignoreMouse: true)
	{
		Debug.Assert(palette != null);
		_palette = palette;
	}

	public override string ToString()
	{
		return "ViewDrawRibbonMinimizeBar:" + base.Id;
	}

	public override void RenderBefore(RenderContext context)
	{
		using Pen pen = new Pen(_palette.GetRibbonMinimizeBarDark(PaletteState.Normal));
		using Pen pen2 = new Pen(_palette.GetRibbonMinimizeBarLight(PaletteState.Normal));
		context.Graphics.DrawLine(pen, ClientRectangle.Left, ClientRectangle.Bottom - 2, ClientRectangle.Right - 1, ClientRectangle.Bottom - 2);
		context.Graphics.DrawLine(pen2, ClientRectangle.Left, ClientRectangle.Bottom - 1, ClientRectangle.Right - 1, ClientRectangle.Bottom - 1);
	}
}
