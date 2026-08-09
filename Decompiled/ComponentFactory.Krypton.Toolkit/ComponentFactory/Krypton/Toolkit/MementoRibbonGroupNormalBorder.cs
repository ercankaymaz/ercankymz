using System.Drawing;
using System.Drawing.Drawing2D;

namespace ComponentFactory.Krypton.Toolkit;

public class MementoRibbonGroupNormalBorder : MementoRectTwoColor
{
	public Rectangle backRect;

	public GraphicsPath solidPath;

	public GraphicsPath insidePath;

	public GraphicsPath outsidePath;

	public GraphicsPath lightPath;

	public Pen solidPen;

	public MementoRibbonGroupNormalBorder(Rectangle r, Color color1, Color color2)
		: base(r, color1, color2)
	{
	}

	public override void Dispose(bool disposing)
	{
		if (solidPath != null)
		{
			solidPath.Dispose();
			insidePath.Dispose();
			outsidePath.Dispose();
			lightPath.Dispose();
			solidPen.Dispose();
			solidPath = null;
			insidePath = null;
			outsidePath = null;
			lightPath = null;
			solidPen = null;
		}
		base.Dispose(disposing);
	}
}
