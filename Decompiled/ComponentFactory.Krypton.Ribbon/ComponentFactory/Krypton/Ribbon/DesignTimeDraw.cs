using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class DesignTimeDraw
{
	private static readonly int DESIGN_FLAP_WIDTH = 12;

	private static readonly int DESIGN_SEP_WIDTH = 6;

	public static int FlapWidth => DESIGN_FLAP_WIDTH;

	public static int SepWidth => DESIGN_SEP_WIDTH;

	public static void DrawArea(KryptonRibbon ribbon, RenderContext context, Rectangle clientRect, PaletteState state)
	{
		Color color = ((state != PaletteState.Normal) ? ribbon.StateCommon.RibbonGroupButton.Back.GetBackColor1(PaletteState.Tracking) : ribbon.StateCommon.RibbonGeneral.GetRibbonGroupSeparatorDark(PaletteState.Normal));
		using SolidBrush brush = new SolidBrush(color);
		context.Graphics.FillRectangle(brush, clientRect);
	}

	public static void DrawFlapArea(KryptonRibbon ribbon, RenderContext context, Rectangle clientRect, PaletteState state)
	{
		Color color = ((state != PaletteState.Normal) ? ribbon.StateCommon.RibbonGroupButton.Back.GetBackColor1(PaletteState.Tracking) : ControlPaint.Dark(ribbon.StateCommon.RibbonGeneral.GetRibbonGroupSeparatorDark(PaletteState.Normal)));
		Rectangle rect = clientRect;
		rect.Width -= DESIGN_SEP_WIDTH;
		rect.Height--;
		rect.X++;
		using (Pen pen = new Pen(color))
		{
			context.Graphics.DrawRectangle(pen, rect);
		}
		rect.Width = DESIGN_FLAP_WIDTH - 2;
		using SolidBrush brush = new SolidBrush(color);
		context.Graphics.FillRectangle(brush, rect);
	}
}
