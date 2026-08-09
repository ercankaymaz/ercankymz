using System.Drawing;
using System.Drawing.Drawing2D;

namespace ComponentFactory.Krypton.Toolkit;

public class MementoBackDarkEdge : MementoDisposable
{
	public RectangleF drawRect;

	public Color color1;

	public int thickness;

	public VisualOrientation orientation;

	public RectangleF entireRect;

	public LinearGradientBrush entireBrush;

	public MementoBackDarkEdge(RectangleF dR, Color c1, int thick, VisualOrientation orient)
	{
		drawRect = dR;
		color1 = c1;
		thickness = thick;
		orientation = orient;
	}

	public bool UseCachedValues(RectangleF dR, Color c1, int thick, VisualOrientation orient)
	{
		bool result = drawRect.Equals(dR) && color1.Equals(c1) && thickness == thick && orientation == orient;
		drawRect = dR;
		color1 = c1;
		thickness = thick;
		orientation = orient;
		return result;
	}

	public override void Dispose(bool disposing)
	{
		if (entireBrush != null)
		{
			entireBrush.Dispose();
			entireBrush = null;
		}
		base.Dispose(disposing);
	}
}
