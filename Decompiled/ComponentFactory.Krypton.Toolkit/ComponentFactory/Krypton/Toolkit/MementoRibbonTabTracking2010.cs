using System.Drawing;
using System.Drawing.Drawing2D;

namespace ComponentFactory.Krypton.Toolkit;

public class MementoRibbonTabTracking2010 : MementoRectFourColor
{
	public VisualOrientation orientation;

	public GraphicsPath borderPath;

	public GraphicsPath outsidePath;

	public GraphicsPath insidePath;

	public SolidBrush outsideBrush;

	public LinearGradientBrush insideBrush;

	public Pen outsidePen;

	public MementoRibbonTabTracking2010(Rectangle r, Color color1, Color color2, Color color3, Color color4, VisualOrientation orient)
		: base(r, color1, color2, color3, color4)
	{
		orientation = orient;
	}

	public bool UseCachedValues(Rectangle r, Color color1, Color color2, Color color3, Color color4, VisualOrientation orient)
	{
		bool result = rect.Equals(r) && c1.Equals(color1) && c2.Equals(color2) && c3.Equals(color1) && c4.Equals(color2) && orient == orientation;
		rect = r;
		c1 = color1;
		c2 = color2;
		c3 = color3;
		c4 = color4;
		orientation = orient;
		return result;
	}

	public override void Dispose(bool disposing)
	{
		if (outsidePath != null)
		{
			borderPath.Dispose();
			outsidePath.Dispose();
			insidePath.Dispose();
			outsideBrush.Dispose();
			insideBrush.Dispose();
			outsidePen.Dispose();
			borderPath = null;
			outsidePath = null;
			insidePath = null;
			outsideBrush = null;
			insideBrush = null;
			outsidePen = null;
		}
		base.Dispose(disposing);
	}
}
