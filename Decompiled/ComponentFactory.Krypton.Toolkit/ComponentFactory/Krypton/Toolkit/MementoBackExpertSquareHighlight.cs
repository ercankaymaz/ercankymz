using System.Drawing;
using System.Drawing.Drawing2D;

namespace ComponentFactory.Krypton.Toolkit;

public class MementoBackExpertSquareHighlight : MementoDisposable
{
	public RectangleF drawRect;

	public Color color1;

	public Color color2;

	public VisualOrientation orientation;

	public SolidBrush backBrush;

	public Rectangle innerRect;

	public LinearGradientBrush innerBrush;

	public GraphicsPath ellipsePath;

	public PathGradientBrush insideLighten;

	public MementoBackExpertSquareHighlight(RectangleF dR, Color c1, Color c2, VisualOrientation orient)
	{
		drawRect = dR;
		color1 = c1;
		color2 = c2;
		orientation = orient;
	}

	public bool UseCachedValues(RectangleF dR, Color c1, Color c2, VisualOrientation orient)
	{
		bool result = drawRect.Equals(dR) && color1.Equals(c1) && color2.Equals(c2) && orientation == orient;
		drawRect = dR;
		color1 = c1;
		color2 = c2;
		orientation = orient;
		return result;
	}

	public override void Dispose(bool disposing)
	{
		if (backBrush != null)
		{
			backBrush.Dispose();
			innerBrush.Dispose();
			ellipsePath.Dispose();
			insideLighten.Dispose();
			backBrush = null;
			innerBrush = null;
			ellipsePath = null;
			insideLighten = null;
		}
		base.Dispose(disposing);
	}
}
