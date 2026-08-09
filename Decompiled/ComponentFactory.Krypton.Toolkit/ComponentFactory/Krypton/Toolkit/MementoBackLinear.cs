using System.Drawing;
using System.Drawing.Drawing2D;

namespace ComponentFactory.Krypton.Toolkit;

public class MementoBackLinear : MementoDisposable
{
	public RectangleF drawRect;

	public bool sigma;

	public Color color1;

	public Color color2;

	public VisualOrientation orientation;

	public LinearGradientBrush entireBrush;

	public MementoBackLinear(RectangleF dR, bool sig, Color c1, Color c2, VisualOrientation orient)
	{
		drawRect = dR;
		sigma = sig;
		color1 = c1;
		color2 = c2;
		orientation = orient;
	}

	public bool UseCachedValues(RectangleF dR, bool sig, Color c1, Color c2, VisualOrientation orient)
	{
		bool result = drawRect.Equals(dR) && sigma == sig && color1.Equals(c1) && color2.Equals(c2) && orientation == orient;
		drawRect = dR;
		sigma = sig;
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
			entireBrush = null;
		}
		base.Dispose(disposing);
	}
}
