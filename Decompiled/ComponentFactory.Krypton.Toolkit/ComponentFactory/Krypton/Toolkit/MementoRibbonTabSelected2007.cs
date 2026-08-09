using System.Drawing;
using System.Drawing.Drawing2D;

namespace ComponentFactory.Krypton.Toolkit;

public class MementoRibbonTabSelected2007 : MementoRectFiveColor
{
	public VisualOrientation orientation;

	public Rectangle centerRect;

	public LinearGradientBrush centerBrush;

	public GraphicsPath outsidePath;

	public SolidBrush insideBrush;

	public Pen outsidePen;

	public Pen middlePen;

	public Pen insidePen;

	public Pen centerPen;

	public MementoRibbonTabSelected2007(Rectangle r, Color color1, Color color2, Color color3, Color color4, Color color5, VisualOrientation orient)
		: base(r, color1, color2, color3, color4, color5)
	{
		orient = orientation;
	}

	public bool UseCachedValues(Rectangle r, Color color1, Color color2, Color color3, Color color4, Color color5, VisualOrientation orient)
	{
		bool result = UseCachedValues(r, color1, color2, color3, color4, color5) && orient == orientation;
		orientation = orient;
		return result;
	}

	public override void Dispose(bool disposing)
	{
		if (centerBrush != null)
		{
			centerBrush.Dispose();
			outsidePath.Dispose();
			insideBrush.Dispose();
			outsidePen.Dispose();
			middlePen.Dispose();
			insidePen.Dispose();
			centerPen.Dispose();
			centerBrush = null;
			outsidePath = null;
			insideBrush = null;
			outsidePen = null;
			middlePen = null;
			insidePen = null;
			centerPen = null;
		}
		base.Dispose(disposing);
	}
}
