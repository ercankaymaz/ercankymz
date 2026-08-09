using System.Drawing;
using System.Drawing.Drawing2D;

namespace ComponentFactory.Krypton.Toolkit;

public class MementoRibbonQATMinibar : MementoRectFiveColor
{
	public Pen lightPen;

	public Pen borderPen;

	public Pen whitenPen;

	public GraphicsPath borderPath;

	public GraphicsPath topRight1;

	public GraphicsPath bottomLeft1;

	public LinearGradientBrush innerBrush;

	public MementoRibbonQATMinibar(Rectangle r, Color color1, Color color2, Color color3, Color color4, Color color5)
		: base(r, color1, color2, color3, color4, color5)
	{
	}

	public override void Dispose(bool disposing)
	{
		if (lightPen != null)
		{
			lightPen.Dispose();
			borderPen.Dispose();
			whitenPen.Dispose();
			borderPath.Dispose();
			topRight1.Dispose();
			bottomLeft1.Dispose();
			innerBrush.Dispose();
			lightPen = null;
			borderPen = null;
			whitenPen = null;
			borderPath = null;
			topRight1 = null;
			bottomLeft1 = null;
			innerBrush = null;
		}
		base.Dispose(disposing);
	}
}
