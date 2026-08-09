using System.Drawing;
using System.Drawing.Drawing2D;

namespace ComponentFactory.Krypton.Toolkit;

public class MementoBackExpertChecked : MementoDisposable
{
	public RectangleF drawRect;

	public Color color1;

	public Color color2;

	public VisualOrientation orientation;

	public LinearGradientBrush entireBrush;

	public GraphicsPath ellipsePath;

	public PathGradientBrush insideLighten;

	public GraphicsPath clipPath;

	public MementoBackExpertChecked(RectangleF dR, Color c1, Color c2, VisualOrientation orient)
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
		if (entireBrush != null)
		{
			entireBrush.Dispose();
			ellipsePath.Dispose();
			insideLighten.Dispose();
			clipPath.Dispose();
			entireBrush = null;
			ellipsePath = null;
			insideLighten = null;
			clipPath = null;
		}
		base.Dispose(disposing);
	}
}
