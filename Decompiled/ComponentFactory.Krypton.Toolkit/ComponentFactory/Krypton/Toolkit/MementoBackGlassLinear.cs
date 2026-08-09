using System.Drawing;
using System.Drawing.Drawing2D;

namespace ComponentFactory.Krypton.Toolkit;

public class MementoBackGlassLinear : MementoDisposable
{
	public RectangleF drawRect;

	public RectangleF outerRect;

	public Color color1;

	public Color color2;

	public Color glassColor1;

	public Color glassColor2;

	public VisualOrientation orientation;

	public float glassPercent;

	public RectangleF glassRect;

	public RectangleF mainRect;

	public SolidBrush totalBrush;

	public LinearGradientBrush topBrush;

	public LinearGradientBrush bottomBrush;

	public MementoBackGlassLinear(RectangleF dR, RectangleF oR, Color c1, Color c2, Color gC1, Color gC2, VisualOrientation orient, float gP)
	{
		drawRect = dR;
		outerRect = oR;
		color1 = c1;
		color2 = c2;
		glassColor1 = gC1;
		glassColor2 = gC2;
		orientation = orient;
		glassPercent = gP;
	}

	public bool UseCachedValues(RectangleF dR, RectangleF oR, Color c1, Color c2, Color gC1, Color gC2, VisualOrientation orient, float gP)
	{
		bool result = drawRect.Equals(dR) && outerRect.Equals(oR) && color1.Equals(c1) && color2.Equals(c2) && glassColor1.Equals(gC1) && glassColor2.Equals(gC2) && orientation == orient && glassPercent == gP;
		drawRect = dR;
		outerRect = oR;
		color1 = c1;
		color2 = c2;
		glassColor1 = gC1;
		glassColor2 = gC2;
		orientation = orient;
		glassPercent = gP;
		return result;
	}

	public override void Dispose(bool disposing)
	{
		if (totalBrush != null)
		{
			totalBrush.Dispose();
			totalBrush = null;
			if (topBrush != null)
			{
				topBrush.Dispose();
				bottomBrush.Dispose();
				topBrush = null;
				bottomBrush = null;
			}
		}
		base.Dispose(disposing);
	}
}
