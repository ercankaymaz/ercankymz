using System.Drawing;
using System.Drawing.Drawing2D;

namespace ComponentFactory.Krypton.Toolkit;

public class MementoBackGlassFade : MementoDisposable
{
	public RectangleF drawRect;

	public RectangleF outerRect;

	public Color color1;

	public Color color2;

	public Color glassColor1;

	public Color glassColor2;

	public VisualOrientation orientation;

	public RectangleF glassRect;

	public LinearGradientBrush mainBrush;

	public LinearGradientBrush topBrush;

	public MementoBackGlassFade(RectangleF dR, RectangleF oR, Color c1, Color c2, Color gC1, Color gC2, VisualOrientation orient)
	{
		drawRect = dR;
		outerRect = oR;
		color1 = c1;
		color2 = c2;
		glassColor1 = gC1;
		glassColor2 = gC2;
		orientation = orient;
	}

	public bool UseCachedValues(RectangleF dR, RectangleF oR, Color c1, Color c2, Color gC1, Color gC2, VisualOrientation orient)
	{
		bool result = drawRect.Equals(dR) && outerRect.Equals(oR) && color1.Equals(c1) && color2.Equals(c2) && glassColor1.Equals(gC1) && glassColor2.Equals(gC2) && orientation == orient;
		drawRect = dR;
		outerRect = oR;
		color1 = c1;
		color2 = c2;
		glassColor1 = gC1;
		glassColor2 = gC2;
		orientation = orient;
		return result;
	}

	public override void Dispose(bool disposing)
	{
		if (topBrush != null)
		{
			topBrush.Dispose();
			mainBrush.Dispose();
			topBrush = null;
			mainBrush = null;
		}
		base.Dispose(disposing);
	}
}
