using System.Drawing;
using System.Drawing.Drawing2D;

namespace ComponentFactory.Krypton.Toolkit;

public class MementoRibbonTabGlowing : MementoRectThreeColor
{
	public VisualOrientation orientation;

	public RectangleF fullRect;

	public RectangleF ellipseRect;

	public GraphicsPath outsidePath;

	public GraphicsPath topPath;

	public GraphicsPath ellipsePath;

	public SolidBrush insideBrush;

	public LinearGradientBrush topBrush;

	public PathGradientBrush ellipseBrush;

	public Pen insidePen;

	public Pen outsidePen;

	public MementoRibbonTabGlowing(Rectangle r, Color color1, Color color2, Color color3, VisualOrientation orient)
		: base(r, color1, color2, color3)
	{
		orient = orientation;
	}

	public bool UseCachedValues(Rectangle r, Color color1, Color color2, Color color3, VisualOrientation orient)
	{
		bool result = UseCachedValues(r, color1, color2, color3) && orient == orientation;
		orientation = orient;
		return result;
	}

	public override void Dispose(bool disposing)
	{
		if (outsidePath != null)
		{
			outsidePath.Dispose();
			topPath.Dispose();
			ellipsePath.Dispose();
			insideBrush.Dispose();
			topBrush.Dispose();
			insidePen.Dispose();
			outsidePen.Dispose();
			outsidePath = null;
			topPath = null;
			ellipsePath = null;
			insideBrush = null;
			topBrush = null;
			insidePen = null;
			outsidePen = null;
			if (ellipseBrush != null)
			{
				ellipseBrush.Dispose();
				ellipseBrush = null;
			}
		}
		base.Dispose(disposing);
	}
}
