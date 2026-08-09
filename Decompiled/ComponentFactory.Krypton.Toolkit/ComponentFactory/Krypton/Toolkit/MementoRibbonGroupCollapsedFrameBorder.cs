using System.Drawing;
using System.Drawing.Drawing2D;

namespace ComponentFactory.Krypton.Toolkit;

public class MementoRibbonGroupCollapsedFrameBorder : MementoRectTwoColor
{
	public GraphicsPath solidPath;

	public SolidBrush titleBrush;

	public Pen solidPen;

	public MementoRibbonGroupCollapsedFrameBorder(Rectangle r, Color color1, Color color2)
		: base(r, color1, color2)
	{
	}

	public override void Dispose(bool disposing)
	{
		if (solidPath != null)
		{
			solidPath.Dispose();
			titleBrush.Dispose();
			solidPen.Dispose();
			solidPath = null;
			titleBrush = null;
			solidPen = null;
		}
		base.Dispose(disposing);
	}
}
