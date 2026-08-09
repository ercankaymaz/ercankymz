using System.Drawing;
using System.Drawing.Drawing2D;

namespace ComponentFactory.Krypton.Toolkit;

public class MementoRibbonGroupAreaBorder3 : MementoRectFiveColor
{
	public Rectangle borderRect;

	public Point[] borderPoints;

	public Rectangle backRect1;

	public Rectangle backRect2;

	public LinearGradientBrush backBrush1;

	public LinearGradientBrush backBrush2;

	public SolidBrush backBrush3;

	public LinearGradientBrush gradientBorderBrush;

	public Pen gradientBorderPen;

	public Pen solidBorderPen;

	public Pen shadowPen1;

	public Pen shadowPen2;

	public Pen shadowPen3;

	public MementoRibbonGroupAreaBorder3(Rectangle r, Color color1, Color color2, Color color3, Color color4, Color color5)
		: base(r, color1, color2, color3, color4, color5)
	{
	}

	public override void Dispose(bool disposing)
	{
		if (backBrush1 != null)
		{
			backBrush1.Dispose();
			backBrush2.Dispose();
			backBrush3.Dispose();
			gradientBorderBrush.Dispose();
			gradientBorderPen.Dispose();
			solidBorderPen.Dispose();
			shadowPen1.Dispose();
			shadowPen2.Dispose();
			shadowPen3.Dispose();
			backBrush1 = null;
			backBrush2 = null;
			backBrush3 = null;
			gradientBorderBrush = null;
			gradientBorderPen = null;
			solidBorderPen = null;
			shadowPen1 = null;
			shadowPen2 = null;
			shadowPen3 = null;
		}
		base.Dispose(disposing);
	}
}
