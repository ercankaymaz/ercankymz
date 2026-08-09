using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class MementoRibbonQATFullbarSquare : MementoRectThreeColor
{
	public Pen lightPen;

	public SolidBrush mediumBrush;

	public Pen darkPen;

	public MementoRibbonQATFullbarSquare(Rectangle r, Color color1, Color color2, Color color3)
		: base(r, color1, color2, color3)
	{
	}

	public override void Dispose(bool disposing)
	{
		if (lightPen != null)
		{
			lightPen.Dispose();
			mediumBrush.Dispose();
			darkPen.Dispose();
			lightPen = null;
			mediumBrush = null;
			darkPen = null;
		}
		base.Dispose(disposing);
	}
}
