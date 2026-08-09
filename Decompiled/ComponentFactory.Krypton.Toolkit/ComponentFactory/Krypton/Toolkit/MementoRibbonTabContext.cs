using System.Drawing;
using System.Drawing.Drawing2D;

namespace ComponentFactory.Krypton.Toolkit;

public class MementoRibbonTabContext : MementoRectTwoColor
{
	public Rectangle fillRect;

	public Pen borderPen;

	public Pen underlinePen;

	public LinearGradientBrush fillBrush;

	public MementoRibbonTabContext(Rectangle r, Color color1, Color color2)
		: base(r, color1, color2)
	{
	}

	public override void Dispose(bool disposing)
	{
		if (borderPen != null)
		{
			borderPen.Dispose();
			fillBrush.Dispose();
			underlinePen.Dispose();
			borderPen = null;
			fillBrush = null;
			underlinePen = null;
		}
		base.Dispose(disposing);
	}
}
