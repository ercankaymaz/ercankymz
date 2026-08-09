using System.Drawing;
using System.Drawing.Drawing2D;

namespace ComponentFactory.Krypton.Toolkit;

public class MementoRibbonGroupCollapsedBorder : MementoRectFourColor
{
	public GraphicsPath solidPath;

	public GraphicsPath insidePath;

	public Pen solidPen;

	public Pen insidePen;

	public MementoRibbonGroupCollapsedBorder(Rectangle r, Color color1, Color color2, Color color3, Color color4)
		: base(r, color1, color2, color3, color4)
	{
	}

	public override void Dispose(bool disposing)
	{
		if (solidPath != null)
		{
			solidPath.Dispose();
			insidePath.Dispose();
			solidPen.Dispose();
			insidePen.Dispose();
			solidPath = null;
			insidePath = null;
			solidPen = null;
			insidePen = null;
		}
		base.Dispose(disposing);
	}
}
