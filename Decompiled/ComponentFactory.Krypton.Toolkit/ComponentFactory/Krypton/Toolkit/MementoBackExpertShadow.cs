using System.Drawing;
using System.Drawing.Drawing2D;

namespace ComponentFactory.Krypton.Toolkit;

public class MementoBackExpertShadow : MementoDisposable
{
	public RectangleF drawRect;

	public Color color1;

	public Color color2;

	public GraphicsPath path1;

	public GraphicsPath path2;

	public GraphicsPath path3;

	public SolidBrush brush1;

	public SolidBrush brush2;

	public SolidBrush brush3;

	public MementoBackExpertShadow(RectangleF dR, Color c1, Color c2)
	{
		drawRect = dR;
		color1 = c1;
		color2 = c2;
	}

	public bool UseCachedValues(RectangleF dR, Color c1, Color c2)
	{
		bool result = drawRect.Equals(dR) && color1.Equals(c1) && color2.Equals(c2);
		drawRect = dR;
		color1 = c1;
		color2 = c2;
		return result;
	}

	public override void Dispose(bool disposing)
	{
		if (path1 != null)
		{
			path1.Dispose();
			path2.Dispose();
			path3.Dispose();
			brush1.Dispose();
			brush2.Dispose();
			brush3.Dispose();
			path1 = null;
			path2 = null;
			path3 = null;
			brush1 = null;
			brush2 = null;
			brush3 = null;
		}
		base.Dispose(disposing);
	}
}
