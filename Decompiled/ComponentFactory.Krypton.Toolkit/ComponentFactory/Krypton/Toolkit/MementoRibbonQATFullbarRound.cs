using System.Drawing;
using System.Drawing.Drawing2D;

namespace ComponentFactory.Krypton.Toolkit;

public class MementoRibbonQATFullbarRound : MementoRectThreeColor
{
	public Rectangle innerRect;

	public LinearGradientBrush innerBrush;

	public GraphicsPath darkPath;

	public GraphicsPath lightPath1;

	public GraphicsPath lightPath2;

	public Pen darkPen;

	public MementoRibbonQATFullbarRound(Rectangle r, Color color1, Color color2, Color color3)
		: base(r, color1, color2, color3)
	{
	}

	public override void Dispose(bool disposing)
	{
		if (innerBrush != null)
		{
			innerBrush.Dispose();
			darkPath.Dispose();
			lightPath1.Dispose();
			lightPath2.Dispose();
			darkPen.Dispose();
			innerBrush = null;
			darkPath = null;
			lightPath1 = null;
			lightPath2 = null;
			darkPen = null;
		}
		base.Dispose(disposing);
	}
}
