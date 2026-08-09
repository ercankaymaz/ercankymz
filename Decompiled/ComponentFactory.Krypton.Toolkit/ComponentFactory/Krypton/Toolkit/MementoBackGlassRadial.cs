using System.Drawing;
using System.Drawing.Drawing2D;

namespace ComponentFactory.Krypton.Toolkit;

public class MementoBackGlassRadial : MementoDisposable
{
	public RectangleF drawRect;

	public Color color1;

	public Color color2;

	public float factorX;

	public float factorY;

	public VisualOrientation orientation;

	public RectangleF mainRect;

	public GraphicsPath path;

	public PathGradientBrush bottomBrush;

	public MementoBackGlassRadial(RectangleF dR, Color c1, Color c2, float fX, float fY, VisualOrientation orient)
	{
		drawRect = dR;
		color1 = c1;
		color2 = c2;
		factorX = fX;
		factorY = fY;
		orientation = orient;
	}

	public bool UseCachedValues(RectangleF dR, Color c1, Color c2, float fX, float fY, VisualOrientation orient)
	{
		bool result = drawRect.Equals(dR) && color1.Equals(c1) && color2.Equals(c2) && factorX == fX && factorY == fY && orientation == orient;
		drawRect = dR;
		color1 = c1;
		color2 = c2;
		factorX = fX;
		factorY = fY;
		orientation = orient;
		return result;
	}

	public override void Dispose(bool disposing)
	{
		if (path != null)
		{
			path.Dispose();
			path = null;
		}
		if (bottomBrush != null)
		{
			bottomBrush.Dispose();
			bottomBrush = null;
		}
		base.Dispose(disposing);
	}
}
