using System.Drawing;
using System.Drawing.Drawing2D;

namespace ComponentFactory.Krypton.Toolkit;

public class MementoRibbonTabTracking2007 : MementoRectTwoColor
{
	public VisualOrientation orientation;

	public Rectangle half1Rect;

	public Rectangle half2Rect;

	public RectangleF half2RectF;

	public RectangleF ellipseRect;

	public GraphicsPath outsidePath;

	public GraphicsPath topPath;

	public GraphicsPath ellipsePath;

	public LinearGradientBrush half1LeftBrush;

	public LinearGradientBrush half1RightBrush;

	public LinearGradientBrush half1LightBrush;

	public LinearGradientBrush outsideBrush;

	public LinearGradientBrush insideBrush;

	public LinearGradientBrush topBrush;

	public PathGradientBrush ellipseBrush;

	public SolidBrush half2Brush;

	public Pen outsidePen;

	public Pen topPen;

	public MementoRibbonTabTracking2007(Rectangle r, Color color1, Color color2, VisualOrientation orient)
		: base(r, color1, color2)
	{
		orientation = orient;
	}

	public bool UseCachedValues(Rectangle r, Color color1, Color color2, VisualOrientation orient)
	{
		bool result = rect.Equals(r) && c1.Equals(color1) && c2.Equals(color2) && orient == orientation;
		rect = r;
		c1 = color1;
		c2 = color2;
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
			half1LeftBrush.Dispose();
			half1RightBrush.Dispose();
			half1LightBrush.Dispose();
			outsideBrush.Dispose();
			insideBrush.Dispose();
			topBrush.Dispose();
			half2Brush.Dispose();
			outsidePen.Dispose();
			topPen.Dispose();
			outsidePath = null;
			topPath = null;
			ellipsePath = null;
			half1LeftBrush = null;
			half1RightBrush = null;
			half1LightBrush = null;
			outsideBrush = null;
			insideBrush = null;
			topBrush = null;
			half2Brush = null;
			outsidePen = null;
			topPen = null;
			if (ellipseBrush != null)
			{
				ellipseBrush.Dispose();
				ellipseBrush = null;
			}
		}
		base.Dispose(disposing);
	}
}
