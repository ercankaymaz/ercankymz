using System.Drawing;
using System.Drawing.Drawing2D;

namespace ComponentFactory.Krypton.Toolkit;

public class MementoRibbonTabContextOffice2010 : MementoRectTwoColor
{
	public Pen borderInnerPen;

	public Pen borderOuterPen;

	public SolidBrush topBrush;

	public LinearGradientBrush bottomBrush;

	public MementoRibbonTabContextOffice2010(Rectangle r, Color color1, Color color2)
		: base(r, color1, color2)
	{
	}

	public override void Dispose(bool disposing)
	{
		if (borderInnerPen != null)
		{
			borderInnerPen.Dispose();
			borderOuterPen.Dispose();
			topBrush.Dispose();
			bottomBrush.Dispose();
			borderInnerPen = null;
			borderOuterPen = null;
			topBrush = null;
			bottomBrush = null;
		}
		base.Dispose(disposing);
	}
}
