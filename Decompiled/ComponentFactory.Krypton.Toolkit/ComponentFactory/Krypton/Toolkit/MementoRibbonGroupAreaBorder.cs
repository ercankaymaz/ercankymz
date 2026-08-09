using System.Drawing;
using System.Drawing.Drawing2D;

namespace ComponentFactory.Krypton.Toolkit;

public class MementoRibbonGroupAreaBorder : MementoRectFiveColor
{
	public GraphicsPath outsidePath;

	public GraphicsPath insidePathN;

	public GraphicsPath insidePathL;

	public GraphicsPath shadowPath;

	public LinearGradientBrush fillBrush;

	public LinearGradientBrush fillTopBrush;

	public Pen shadowPenN;

	public Pen shadowPenL;

	public Pen outsidePen;

	public Pen insidePen;

	public MementoRibbonGroupAreaBorder(Rectangle r, Color color1, Color color2, Color color3, Color color4, Color color5)
		: base(r, color1, color2, color3, color4, color5)
	{
	}

	public override void Dispose(bool disposing)
	{
		if (outsidePath != null)
		{
			outsidePath.Dispose();
			insidePathN.Dispose();
			insidePathL.Dispose();
			shadowPath.Dispose();
			fillBrush.Dispose();
			fillTopBrush.Dispose();
			shadowPenN.Dispose();
			shadowPenL.Dispose();
			outsidePen.Dispose();
			insidePen.Dispose();
			outsidePath = null;
			insidePathN = null;
			insidePathL = null;
			shadowPath = null;
			fillBrush = null;
			fillTopBrush = null;
			shadowPenN = null;
			shadowPenL = null;
			outsidePen = null;
			insidePen = null;
		}
		base.Dispose(disposing);
	}
}
