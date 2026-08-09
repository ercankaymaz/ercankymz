using System.Drawing;
using System.Drawing.Drawing2D;

namespace ComponentFactory.Krypton.Toolkit;

public class MementoRibbonLinearBorder : MementoRectTwoColor
{
	public LinearGradientBrush linearBrush;

	public Pen linearPen;

	public GraphicsPath borderPath;

	public MementoRibbonLinearBorder(Rectangle r, Color color1, Color color2)
		: base(r, color1, color2)
	{
	}

	public override void Dispose(bool disposing)
	{
		if (linearBrush != null)
		{
			linearBrush.Dispose();
			borderPath.Dispose();
			linearPen.Dispose();
			linearBrush = null;
			borderPath = null;
			linearPen = null;
		}
		base.Dispose(disposing);
	}
}
