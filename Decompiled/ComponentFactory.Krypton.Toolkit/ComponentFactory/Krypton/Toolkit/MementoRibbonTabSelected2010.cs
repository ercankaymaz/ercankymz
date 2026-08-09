using System.Drawing;
using System.Drawing.Drawing2D;

namespace ComponentFactory.Krypton.Toolkit;

public class MementoRibbonTabSelected2010 : MementoRectFiveColor
{
	public VisualOrientation orientation;

	public LinearGradientBrush centerBrush;

	public GraphicsPath outsidePath;

	public Pen outsidePen;

	public Pen centerPen;

	public LinearGradientBrush insideBrush;

	public GraphicsPath insidePath;

	public MementoRibbonTabSelected2010(Rectangle r, Color color1, Color color2, Color color3, Color color4, Color color5, VisualOrientation orient)
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
			outsidePen.Dispose();
			centerPen.Dispose();
			insideBrush.Dispose();
			insidePath.Dispose();
			centerBrush = null;
			outsidePath = null;
			outsidePen = null;
			centerPen = null;
			insideBrush = null;
			insidePath = null;
		}
		base.Dispose(disposing);
	}
}
