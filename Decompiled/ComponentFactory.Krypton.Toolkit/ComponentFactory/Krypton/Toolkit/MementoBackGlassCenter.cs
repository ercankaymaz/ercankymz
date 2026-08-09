using System.Drawing;
using System.Drawing.Drawing2D;

namespace ComponentFactory.Krypton.Toolkit;

public class MementoBackGlassCenter : MementoDisposable
{
	public RectangleF drawRect;

	public Color color2;

	public GraphicsPath path;

	public PathGradientBrush bottomBrush;

	public MementoBackGlassCenter(RectangleF dR, Color c2)
	{
		drawRect = dR;
		color2 = c2;
	}

	public bool UseCachedValues(RectangleF dR, Color c2)
	{
		bool result = drawRect.Equals(dR) && color2.Equals(c2);
		drawRect = dR;
		color2 = c2;
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
