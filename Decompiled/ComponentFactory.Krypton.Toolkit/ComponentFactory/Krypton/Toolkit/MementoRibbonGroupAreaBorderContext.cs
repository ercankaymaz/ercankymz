using System.Drawing;
using System.Drawing.Drawing2D;

namespace ComponentFactory.Krypton.Toolkit;

public class MementoRibbonGroupAreaBorderContext : MementoRectThreeColor
{
	public GraphicsPath outsidePath;

	public GraphicsPath insidePath;

	public GraphicsPath shadowPath;

	public LinearGradientBrush fillBrush;

	public LinearGradientBrush fillTopBrush;

	public Pen shadowPen;

	public Pen outsidePen;

	public Pen insidePen;

	public MementoRibbonGroupAreaBorderContext(Rectangle r, Color color1, Color color2, Color color3)
		: base(r, color1, color2, color3)
	{
	}

	public override void Dispose(bool disposing)
	{
		if (outsidePath != null)
		{
			outsidePath.Dispose();
			insidePath.Dispose();
			shadowPath.Dispose();
			fillBrush.Dispose();
			fillTopBrush.Dispose();
			shadowPen.Dispose();
			outsidePen.Dispose();
			insidePen.Dispose();
			outsidePath = null;
			insidePath = null;
			shadowPath = null;
			fillBrush = null;
			fillTopBrush = null;
			shadowPen = null;
			outsidePen = null;
			insidePen = null;
		}
		base.Dispose(disposing);
	}
}
