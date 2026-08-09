using System.Drawing;
using System.Drawing.Drawing2D;

namespace ComponentFactory.Krypton.Toolkit;

public class MementoRibbonTabContextSelected : MementoRectTwoColor
{
	public VisualOrientation orientation;

	public Rectangle interiorRect;

	public LinearGradientBrush insideBrush;

	public GraphicsPath outsidePath;

	public Pen outsidePen;

	public Pen l1;

	public Pen l2;

	public Pen l3;

	public Pen leftPen;

	public Pen rightPen;

	public Pen bottomInnerPen;

	public Pen bottomOuterPen;

	public MementoRibbonTabContextSelected(Rectangle r, Color color1, Color color2, VisualOrientation orient)
		: base(r, color1, color2)
	{
		orient = orientation;
	}

	public bool UseCachedValues(Rectangle r, Color color1, Color color2, VisualOrientation orient)
	{
		bool result = UseCachedValues(r, color1, color2) && orient == orientation;
		orientation = orient;
		return result;
	}

	public override void Dispose(bool disposing)
	{
		if (outsidePath != null)
		{
			outsidePath.Dispose();
			insideBrush.Dispose();
			outsidePen.Dispose();
			l1.Dispose();
			l2.Dispose();
			l3.Dispose();
			leftPen.Dispose();
			rightPen.Dispose();
			bottomInnerPen.Dispose();
			bottomOuterPen.Dispose();
			outsidePath = null;
			insideBrush = null;
			outsidePen = null;
			l1 = null;
			l2 = null;
			l3 = null;
			leftPen = null;
			rightPen = null;
			bottomInnerPen = null;
			bottomOuterPen = null;
		}
		base.Dispose(disposing);
	}
}
