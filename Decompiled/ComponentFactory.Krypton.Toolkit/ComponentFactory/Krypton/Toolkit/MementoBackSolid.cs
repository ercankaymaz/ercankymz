using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class MementoBackSolid : MementoDisposable
{
	public RectangleF drawRect;

	public Color color1;

	public SolidBrush solidBrush;

	public MementoBackSolid(RectangleF dR, Color c1)
	{
		drawRect = dR;
		color1 = c1;
	}

	public bool UseCachedValues(RectangleF dR, Color c1)
	{
		bool result = drawRect.Equals(dR) && color1.Equals(c1);
		drawRect = dR;
		color1 = c1;
		return result;
	}

	public override void Dispose(bool disposing)
	{
		if (solidBrush != null)
		{
			solidBrush.Dispose();
			solidBrush = null;
		}
		base.Dispose(disposing);
	}
}
