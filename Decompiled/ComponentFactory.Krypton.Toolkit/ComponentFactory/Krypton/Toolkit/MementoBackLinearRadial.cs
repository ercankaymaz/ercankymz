using System.Drawing;
using System.Drawing.Drawing2D;

namespace ComponentFactory.Krypton.Toolkit;

public class MementoBackLinearRadial : MementoDisposable
{
	public RectangleF drawRect;

	public Color color2;

	public Color color3;

	public VisualOrientation orientation;

	public RectangleF ellipseRect;

	public GraphicsPath path;

	public PathGradientBrush bottomBrush;

	public MementoBackLinearRadial(RectangleF dR, Color c2, Color c3, VisualOrientation orient)
	{
		drawRect = dR;
		color2 = c2;
		color3 = c3;
		orientation = orient;
	}

	public bool UseCachedValues(RectangleF dR, Color c2, Color c3, VisualOrientation orient)
	{
		bool result = drawRect.Equals(dR) && color2.Equals(c2) && color3.Equals(c3) && orientation == orient;
		drawRect = dR;
		color2 = c2;
		color3 = c3;
		orientation = orient;
		return result;
	}

	public override void Dispose(bool disposing)
	{
		if (path != null)
		{
			path.Dispose();
			bottomBrush.Dispose();
			path = null;
			bottomBrush = null;
		}
		base.Dispose(disposing);
	}
}
